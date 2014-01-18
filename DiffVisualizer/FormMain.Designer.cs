namespace DiffVisualizer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.wbVisualizer1 = new System.Windows.Forms.WebBrowser();
            this.wbVisualizer2 = new System.Windows.Forms.WebBrowser();
            this.bOptions = new System.Windows.Forms.Button();
            this.bwDiff = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // wbVisualizer1
            // 
            this.wbVisualizer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbVisualizer1.Location = new System.Drawing.Point(0, 0);
            this.wbVisualizer1.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbVisualizer1.Name = "wbVisualizer1";
            this.wbVisualizer1.Size = new System.Drawing.Size(864, 525);
            this.wbVisualizer1.TabIndex = 0;
            this.wbVisualizer1.WebBrowserShortcutsEnabled = false;
            this.wbVisualizer1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbVisualizer1_DocumentCompleted);
            this.wbVisualizer1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.wbVisualizer1_PreviewKeyDown);
            // 
            // wbVisualizer2
            // 
            this.wbVisualizer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbVisualizer2.Location = new System.Drawing.Point(0, 0);
            this.wbVisualizer2.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbVisualizer2.Name = "wbVisualizer2";
            this.wbVisualizer2.Size = new System.Drawing.Size(864, 525);
            this.wbVisualizer2.TabIndex = 1;
            this.wbVisualizer2.Visible = false;
            this.wbVisualizer2.WebBrowserShortcutsEnabled = false;
            this.wbVisualizer2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbVisualizer2_DocumentCompleted);
            this.wbVisualizer2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.wbVisualizer2_PreviewKeyDown);
            // 
            // bOptions
            // 
            this.bOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bOptions.FlatAppearance.BorderSize = 0;
            this.bOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOptions.Image = global::DiffVisualizer.Properties.Resources.settings;
            this.bOptions.Location = new System.Drawing.Point(792, 0);
            this.bOptions.Name = "bOptions";
            this.bOptions.Size = new System.Drawing.Size(54, 54);
            this.bOptions.TabIndex = 2;
            this.bOptions.UseVisualStyleBackColor = false;
            this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // bwDiff
            // 
            this.bwDiff.WorkerReportsProgress = true;
            this.bwDiff.WorkerSupportsCancellation = true;
            this.bwDiff.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDiff_DoWork);
            this.bwDiff.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwDiff_ProgressChanged);
            this.bwDiff.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDiff_RunWorkerCompleted);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 525);
            this.Controls.Add(this.bOptions);
            this.Controls.Add(this.wbVisualizer2);
            this.Controls.Add(this.wbVisualizer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "Diff Visualizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbVisualizer1;
        private System.Windows.Forms.WebBrowser wbVisualizer2;
        private System.Windows.Forms.Button bOptions;
        private System.ComponentModel.BackgroundWorker bwDiff;
    }
}

