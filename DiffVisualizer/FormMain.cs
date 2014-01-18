using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DiffVisualizer
{
    public partial class FormMain : Form
    {
        public Config Cnfg = new Config();
        public const string CnfgName = "DiffVisualizer.conf";

        public struct DiffParser
        {
            public string FileName;
            public string OldFileName;
            public string IndexAndMode;
            public string FuncName;
            public int Line;
            public int ChangeLine;
            public int OldLine;
            public int OldChangeLine;
            public int LineShift;
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                using (Stream stfile = File.OpenRead(CnfgName))
                {
                    XmlSerializer xmlconfig = new XmlSerializer(typeof(Config));
                    Cnfg = (Config)xmlconfig.Deserialize(stfile);

                    int posX = Cnfg.posX;
                    int posY = Cnfg.posY;
                    int sHeight = Cnfg.Height;
                    int sWidth = Cnfg.Width;

                    if (sHeight < 200) sHeight = this.MinimumSize.Height;
                    if (sWidth < 200) sWidth = this.MinimumSize.Width;

                    this.Location = new Point(posX, posY);
                    this.Size = new Size(sWidth, sHeight);
                }
            }
            catch
            {
                bOptions_Click(null, null);
            }

            bwDiff.RunWorkerAsync(Cnfg);
        }

        private void bwDiff_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Config conf = e.Argument as Config;

            while (true)
            {
                try
                {
                    if (string.IsNullOrEmpty(Cnfg.Program)) return;

                    Process getdiff = new Process();
                    getdiff.StartInfo.FileName = Cnfg.Program;
                    getdiff.StartInfo.Arguments = Cnfg.Arguments;
                    getdiff.StartInfo.WorkingDirectory = Cnfg.WorkDir;
                    getdiff.StartInfo.RedirectStandardOutput = true;
                    getdiff.StartInfo.UseShellExecute = false;
                    getdiff.StartInfo.CreateNoWindow = true;
                    getdiff.Start();
                    string result = getdiff.StandardOutput.ReadToEnd();
                    getdiff.WaitForExit();

                    Dictionary<string, string> files = new Dictionary<string, string>();

                    DiffParser parser = new DiffParser();
                    Regex regLines =
                        new Regex(
                            @"@@ \-(?<OldLine>\d+)(\,(?<OldChangeLine>\d+))? \+(?<Line>\d+)(\,(?<ChangeLine>\d+))? @@(?<FuncName>.*)",
                            RegexOptions.Compiled);

                    int countlineheader = 0;
                    List<string> delete = new List<string>();
                    List<string> add = new List<string>();
                    foreach (string line in result.Split(new[] { '\n' }))
                    {
                        countlineheader--;
                        if (line.Length > 12 && line.Substring(0, 11) == @"diff --git ")
                        {
                            countlineheader = 4;
                        }
                        else if (countlineheader == 3)
                        {
                            parser.IndexAndMode = line.Substring(6);
                        }
                        else if (countlineheader == 2)
                        {
                            parser.OldFileName = line.Substring(line.IndexOf("/") + 1).TrimEnd();
                        }
                        else if (countlineheader == 1)
                        {
                            parser.FileName = line.Substring(line.IndexOf("/") + 1).TrimEnd();
                            files.Add(parser.FileName, "");
                        }
                        else
                        {
                            Match match_lines = regLines.Match(line);
                            if (match_lines.Success)
                            {
                                try
                                {
                                    parser.FuncName = match_lines.Groups["FuncName"].Value;
                                    parser.Line = int.Parse(match_lines.Groups["Line"].Value);
                                    parser.ChangeLine = int.Parse(match_lines.Groups["ChangeLine"].Value);
                                    parser.OldLine = int.Parse(match_lines.Groups["OldLine"].Value);
                                    parser.OldChangeLine = int.Parse(match_lines.Groups["OldChangeLine"].Value);
                                    parser.LineShift = 0;
                                    files[parser.FileName] += "<span class=\"lines\">" +
                                                              System.Net.WebUtility.HtmlEncode(line) +
                                                              "</span>" + Environment.NewLine;
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                            else
                            {
                                string diffstatus = line.Length > 0 ? line.Substring(0, 1) : "";
                                if (diffstatus == "-") delete.Add(line.Substring(1));
                                else if (diffstatus == "+") add.Add(line.Substring(1));
                                else
                                {
                                    if (delete.Count > 0 && add.Count > 0)
                                    {
                                        files[parser.FileName] += "<span class=\"modif\">" +
                                                                  System.Net.WebUtility.HtmlEncode(
                                            add.Aggregate((now, next) => now + Environment.NewLine + next)) +
                                                                  "</span>" + Environment.NewLine;
                                    }
                                    else if (delete.Count > 0)
                                    {
                                        files[parser.FileName] += "<span class=\"delete\">" +
                                                                  System.Net.WebUtility.HtmlEncode(
                                            delete.Aggregate((now, next) => now + Environment.NewLine + next)) +
                                                                  "</span>" + Environment.NewLine;
                                    }
                                    else if (add.Count > 0)
                                    {
                                        files[parser.FileName] += "<span class=\"add\">" +
                                                                  System.Net.WebUtility.HtmlEncode(
                                            add.Aggregate((now, next) => now + Environment.NewLine + next)) +
                                                                  "</span>" + Environment.NewLine;
                                    }
                                    files[parser.FileName] +=
                                        (line.Length > 0 ? System.Net.WebUtility.HtmlEncode(line.Substring(1)) : "") +
                                        Environment.NewLine;
                                    delete.Clear();
                                    add.Clear();
                                }
                            }
                        }
                    }

                    string html = "";

                    foreach (string key in files.Keys.OrderByDescending(
                                 delegate(string name)
                                 {
                                     FileInfo fi = new FileInfo(Cnfg.WorkDir + "\\" + name);
                                     return fi.LastWriteTime;
                                 }))
                    {
                        html += "<pre><span class=\"file\">" + key + "</span>" + Environment.NewLine + files[key] + "</pre>";
                    }

                    html = "<!DOCTYPE html>" + Environment.NewLine +
                           "<html>" + Environment.NewLine +
                           "<head>" + Environment.NewLine +
                           "<style type=\"text/css\">" + Environment.NewLine +
                           "body {background-color: #323232; color: #999999; font: " + Cnfg.Font + ";}" + Environment.NewLine +
                           ".file {color: #ffcc33}" + Environment.NewLine +
                           ".lines {color: #0099ff}" + Environment.NewLine +
                           ".add {color: #00ff33}" + Environment.NewLine +
                           ".delete {color: #ff6600}" + Environment.NewLine +
                           ".modif {color: #ff32ff}" + Environment.NewLine +
                           "</style>" + Environment.NewLine +
                           "</head>" + Environment.NewLine +
                           "<body>" + Environment.NewLine +
                           html +
                           "</body>" + Environment.NewLine +
                           "</html>";
                    worker.ReportProgress(0, html);
                }
                catch (Exception ex)
                {
                    string html = "<!DOCTYPE html>" + Environment.NewLine +
                                  "<html>" + Environment.NewLine +
                                  "<head>" + Environment.NewLine +
                                  "</head>" + Environment.NewLine +
                                  "<body>" + Environment.NewLine +
                                  "<pre>" + ex.ToString() + "</pre>" + Environment.NewLine +
                                  "</body>" + Environment.NewLine +
                                  "</html>";
                    worker.ReportProgress(0, html);
                }

                for (int sleep = (int)conf.Update * 10; sleep >= 0; sleep--)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    Thread.Sleep(100);
                }
            }
        }

        private void bwDiff_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (wbVisualizer2.Visible) wbVisualizer1.DocumentText = (string)e.UserState;
                else wbVisualizer2.DocumentText = (string)e.UserState;
            }
            catch { }
        }

        private void bwDiff_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.RunWorkerAsync(Cnfg);
        }

        private void wbVisualizer1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Rectangle scroll = new Rectangle();
            if (wbVisualizer2.Document != null)
                scroll = wbVisualizer2.Document.GetElementsByTagName("HTML")[0].ScrollRectangle;
            wbVisualizer1.Document.Window.ScrollTo(scroll.X, scroll.Y);
            wbVisualizer2.Hide();
            wbVisualizer1.Focus();
            wbVisualizer1.TabStop = true;
            bOptions.BackColor = wbVisualizer1.Document.BackColor;
        }

        private void wbVisualizer2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Rectangle scroll = new Rectangle();
            if (wbVisualizer1.Document != null)
                scroll = wbVisualizer1.Document.GetElementsByTagName("HTML")[0].ScrollRectangle;
            wbVisualizer2.Document.Window.ScrollTo(scroll.X, scroll.Y);
            wbVisualizer2.Show();
            wbVisualizer2.Focus();
            wbVisualizer1.TabStop = false;
            bOptions.BackColor = wbVisualizer2.Document.BackColor;
        }

        public bool SaveConfig()
        {
            try
            {
                using (Stream stfile = File.Open(CnfgName, FileMode.Create, FileAccess.Write))
                {
                    Cnfg.posX = this.Location.X;
                    Cnfg.posY = this.Location.Y;
                    Cnfg.Height = this.Size.Height;
                    Cnfg.Width = this.Size.Width;

                    XmlSerializer xmlconfig = new XmlSerializer(typeof(Config));
                    xmlconfig.Serialize(stfile, Cnfg);
                }
                return true;
            }
            catch { }
            return false;
        }

        private void bOptions_Click(object sender, EventArgs e)
        {
            FormOptions opt = new FormOptions();
            if (opt.Options(ref Cnfg))
            {
                bwDiff.CancelAsync();
                SaveConfig();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            bOptions.Left = this.Width - 35 - bOptions.Width;
        }

        private void wbVisualizer1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.O || e.KeyCode == Keys.P) && e.Control) bOptions_Click(null, null);
        }

        private void wbVisualizer2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            wbVisualizer1_PreviewKeyDown(sender, e);
        }
    }
}
