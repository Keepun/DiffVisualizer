namespace DiffVisualizer
{
    partial class FormOptions
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
            this.lProgram = new System.Windows.Forms.Label();
            this.tProgram = new System.Windows.Forms.TextBox();
            this.bProgram = new System.Windows.Forms.Button();
            this.tArguments = new System.Windows.Forms.TextBox();
            this.lArguments = new System.Windows.Forms.Label();
            this.lUpdate = new System.Windows.Forms.Label();
            this.numSecs = new System.Windows.Forms.NumericUpDown();
            this.tFont = new System.Windows.Forms.TextBox();
            this.lFont = new System.Windows.Forms.Label();
            this.bWorkDir = new System.Windows.Forms.Button();
            this.tWorkDir = new System.Windows.Forms.TextBox();
            this.lWorkDir = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numSecs)).BeginInit();
            this.SuspendLayout();
            // 
            // lProgram
            // 
            this.lProgram.AutoSize = true;
            this.lProgram.Location = new System.Drawing.Point(12, 25);
            this.lProgram.Name = "lProgram";
            this.lProgram.Size = new System.Drawing.Size(46, 13);
            this.lProgram.TabIndex = 0;
            this.lProgram.Text = "Program";
            // 
            // tProgram
            // 
            this.tProgram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tProgram.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tProgram.Location = new System.Drawing.Point(84, 22);
            this.tProgram.Name = "tProgram";
            this.tProgram.Size = new System.Drawing.Size(436, 20);
            this.tProgram.TabIndex = 1;
            // 
            // bProgram
            // 
            this.bProgram.Location = new System.Drawing.Point(526, 18);
            this.bProgram.Name = "bProgram";
            this.bProgram.Size = new System.Drawing.Size(87, 26);
            this.bProgram.TabIndex = 2;
            this.bProgram.Text = "Find...";
            this.bProgram.UseVisualStyleBackColor = true;
            this.bProgram.Click += new System.EventHandler(this.bProgram_Click);
            // 
            // tArguments
            // 
            this.tArguments.Location = new System.Drawing.Point(84, 63);
            this.tArguments.Name = "tArguments";
            this.tArguments.Size = new System.Drawing.Size(529, 20);
            this.tArguments.TabIndex = 4;
            this.tArguments.Text = "diff";
            // 
            // lArguments
            // 
            this.lArguments.AutoSize = true;
            this.lArguments.Location = new System.Drawing.Point(12, 66);
            this.lArguments.Name = "lArguments";
            this.lArguments.Size = new System.Drawing.Size(57, 13);
            this.lArguments.TabIndex = 3;
            this.lArguments.Text = "Arguments";
            // 
            // lUpdate
            // 
            this.lUpdate.AutoSize = true;
            this.lUpdate.Location = new System.Drawing.Point(12, 106);
            this.lUpdate.Name = "lUpdate";
            this.lUpdate.Size = new System.Drawing.Size(183, 13);
            this.lUpdate.TabIndex = 5;
            this.lUpdate.Text = "To update each                    seconds";
            // 
            // numSecs
            // 
            this.numSecs.Location = new System.Drawing.Point(95, 104);
            this.numSecs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSecs.Name = "numSecs";
            this.numSecs.Size = new System.Drawing.Size(50, 20);
            this.numSecs.TabIndex = 6;
            this.numSecs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tFont
            // 
            this.tFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tFont.Location = new System.Drawing.Point(84, 132);
            this.tFont.Name = "tFont";
            this.tFont.Size = new System.Drawing.Size(528, 20);
            this.tFont.TabIndex = 8;
            // 
            // lFont
            // 
            this.lFont.AutoSize = true;
            this.lFont.Location = new System.Drawing.Point(12, 135);
            this.lFont.Name = "lFont";
            this.lFont.Size = new System.Drawing.Size(52, 13);
            this.lFont.TabIndex = 7;
            this.lFont.Text = "CSS Font";
            // 
            // bWorkDir
            // 
            this.bWorkDir.Location = new System.Drawing.Point(525, 164);
            this.bWorkDir.Name = "bWorkDir";
            this.bWorkDir.Size = new System.Drawing.Size(87, 26);
            this.bWorkDir.TabIndex = 13;
            this.bWorkDir.Text = "WorkDir";
            this.bWorkDir.UseVisualStyleBackColor = true;
            this.bWorkDir.Click += new System.EventHandler(this.bWorkDir_Click);
            // 
            // tWorkDir
            // 
            this.tWorkDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tWorkDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tWorkDir.Location = new System.Drawing.Point(83, 168);
            this.tWorkDir.Name = "tWorkDir";
            this.tWorkDir.Size = new System.Drawing.Size(436, 20);
            this.tWorkDir.TabIndex = 12;
            // 
            // lWorkDir
            // 
            this.lWorkDir.AutoSize = true;
            this.lWorkDir.Location = new System.Drawing.Point(11, 171);
            this.lWorkDir.Name = "lWorkDir";
            this.lWorkDir.Size = new System.Drawing.Size(46, 13);
            this.lWorkDir.TabIndex = 11;
            this.lWorkDir.Text = "WorkDir";
            // 
            // bOK
            // 
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Location = new System.Drawing.Point(108, 220);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(174, 33);
            this.bOK.TabIndex = 14;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(322, 220);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(174, 33);
            this.bCancel.TabIndex = 15;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Executable (.exe .bat .cmd)|*.exe;*.bat;*.cmd|All files (*.*)|*.*";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Work folder";
            // 
            // FormOptions
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(625, 263);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bWorkDir);
            this.Controls.Add(this.tWorkDir);
            this.Controls.Add(this.lWorkDir);
            this.Controls.Add(this.tFont);
            this.Controls.Add(this.lFont);
            this.Controls.Add(this.numSecs);
            this.Controls.Add(this.lUpdate);
            this.Controls.Add(this.tArguments);
            this.Controls.Add(this.lArguments);
            this.Controls.Add(this.bProgram);
            this.Controls.Add(this.tProgram);
            this.Controls.Add(this.lProgram);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.numSecs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lProgram;
        private System.Windows.Forms.TextBox tProgram;
        private System.Windows.Forms.Button bProgram;
        private System.Windows.Forms.TextBox tArguments;
        private System.Windows.Forms.Label lArguments;
        private System.Windows.Forms.Label lUpdate;
        private System.Windows.Forms.NumericUpDown numSecs;
        private System.Windows.Forms.TextBox tFont;
        private System.Windows.Forms.Label lFont;
        private System.Windows.Forms.Button bWorkDir;
        private System.Windows.Forms.TextBox tWorkDir;
        private System.Windows.Forms.Label lWorkDir;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}