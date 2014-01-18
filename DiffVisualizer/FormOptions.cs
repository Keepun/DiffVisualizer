using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DiffVisualizer.Properties;

namespace DiffVisualizer
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        public bool Options(ref Config cnfg)
        {
            if (string.IsNullOrEmpty(cnfg.Program))
            {
                FileInfo git = new FileInfo(ProgramFilesx86() + @"\Git\cmd\git.exe");
                tProgram.Text = git.Exists ? git.FullName : "";
            }
            else tProgram.Text = cnfg.Program;
            tArguments.Text = string.IsNullOrEmpty(cnfg.Arguments) ? "diff" : cnfg.Arguments;
            numSecs.Value = cnfg.Update > 0 ? cnfg.Update : 2;
            tFont.Text = string.IsNullOrEmpty(cnfg.Font) ? "70% serif" : cnfg.Font;
            tWorkDir.Text = string.IsNullOrEmpty(cnfg.WorkDir) ? "" : cnfg.WorkDir;

            if (base.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cnfg.Program = tProgram.Text.Trim();
                cnfg.Arguments = tArguments.Text.Trim();
                cnfg.Update = (uint)numSecs.Value;
                cnfg.Font = tFont.Text.Trim();
                cnfg.WorkDir = tWorkDir.Text.Trim();

                if (!File.Exists(cnfg.Program))
                {
                    MessageBox.Show(Resources.FormOptions_Options_Program_not_exists, Resources.Error);
                    return Options(ref cnfg);
                }

                if (string.IsNullOrEmpty(cnfg.WorkDir) && Directory.Exists(cnfg.WorkDir))
                {
                    MessageBox.Show(Resources.FormOptions_Options_WorkDir_not_exists, Resources.Error);
                    return Options(ref cnfg);
                }
                return true;
            }
            return false;
        }

        static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        private void bProgram_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Executable (.exe .bat .cmd)|*.exe;*.bat;*.cmd|All files (*.*)|*.*";
            FileInfo fi = new FileInfo(tProgram.Text.Trim());
            file.InitialDirectory = fi.DirectoryName;
            file.RestoreDirectory = true;
            if (file.ShowDialog() == DialogResult.OK) tProgram.Text = file.FileName;*/
            FileInfo fi = new FileInfo(tProgram.Text.Trim());
            openFileDialog.InitialDirectory = fi.DirectoryName;
            if (openFileDialog.ShowDialog() == DialogResult.OK) tProgram.Text = openFileDialog.FileName;
        }

        private void bWorkDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = tWorkDir.Text.Trim();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) tWorkDir.Text = folderBrowserDialog.SelectedPath;
        }
    }
}
