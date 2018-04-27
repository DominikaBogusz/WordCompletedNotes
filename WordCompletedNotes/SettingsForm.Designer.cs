namespace WordCompletedNotes
{
    partial class SettingsForm
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
            this.algLabel = new System.Windows.Forms.Label();
            this.algComboBox = new System.Windows.Forms.ComboBox();
            this.vocabularyCB = new System.Windows.Forms.CheckBox();
            this.sortCB = new System.Windows.Forms.CheckBox();
            this.limitCB = new System.Windows.Forms.CheckBox();
            this.limitNum = new System.Windows.Forms.NumericUpDown();
            this.groupBoxAutocompletion = new System.Windows.Forms.GroupBox();
            this.groupBoxNote = new System.Windows.Forms.GroupBox();
            this.fileButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.existingFileRB = new System.Windows.Forms.RadioButton();
            this.newFileRB = new System.Windows.Forms.RadioButton();
            this.groupBoxWordsSource = new System.Windows.Forms.GroupBox();
            this.databaseButton = new System.Windows.Forms.Button();
            this.databaseTextBox = new System.Windows.Forms.TextBox();
            this.existingSourceRB = new System.Windows.Forms.RadioButton();
            this.noSourceRB = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.limitNum)).BeginInit();
            this.groupBoxAutocompletion.SuspendLayout();
            this.groupBoxNote.SuspendLayout();
            this.groupBoxWordsSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // algLabel
            // 
            this.algLabel.AutoSize = true;
            this.algLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.algLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.algLabel.Location = new System.Drawing.Point(6, 26);
            this.algLabel.Name = "algLabel";
            this.algLabel.Size = new System.Drawing.Size(64, 15);
            this.algLabel.TabIndex = 1;
            this.algLabel.Text = "Algorithm:";
            // 
            // algComboBox
            // 
            this.algComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.algComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algComboBox.ForeColor = System.Drawing.Color.Black;
            this.algComboBox.FormattingEnabled = true;
            this.algComboBox.Items.AddRange(new object[] {
            "Simple",
            "Trie",
            "HeapTrie",
            "Database"});
            this.algComboBox.Location = new System.Drawing.Point(76, 23);
            this.algComboBox.Name = "algComboBox";
            this.algComboBox.Size = new System.Drawing.Size(153, 23);
            this.algComboBox.TabIndex = 3;
            this.algComboBox.SelectedIndexChanged += new System.EventHandler(this.algComboBox_SelectedIndexChanged);
            // 
            // vocabularyCB
            // 
            this.vocabularyCB.AutoSize = true;
            this.vocabularyCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vocabularyCB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.vocabularyCB.Location = new System.Drawing.Point(9, 77);
            this.vocabularyCB.Name = "vocabularyCB";
            this.vocabularyCB.Size = new System.Drawing.Size(130, 19);
            this.vocabularyCB.TabIndex = 4;
            this.vocabularyCB.Text = "Use vocabulary (PL)";
            this.vocabularyCB.UseVisualStyleBackColor = true;
            // 
            // sortCB
            // 
            this.sortCB.AutoSize = true;
            this.sortCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortCB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortCB.Location = new System.Drawing.Point(9, 52);
            this.sortCB.Name = "sortCB";
            this.sortCB.Size = new System.Drawing.Size(123, 19);
            this.sortCB.TabIndex = 5;
            this.sortCB.Text = "Sort by uses count";
            this.sortCB.UseVisualStyleBackColor = true;
            // 
            // limitCB
            // 
            this.limitCB.AutoSize = true;
            this.limitCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitCB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.limitCB.Location = new System.Drawing.Point(9, 102);
            this.limitCB.Name = "limitCB";
            this.limitCB.Size = new System.Drawing.Size(160, 19);
            this.limitCB.TabIndex = 6;
            this.limitCB.Text = "Limit number of prompts";
            this.limitCB.UseVisualStyleBackColor = true;
            // 
            // limitNum
            // 
            this.limitNum.Location = new System.Drawing.Point(175, 99);
            this.limitNum.Name = "limitNum";
            this.limitNum.Size = new System.Drawing.Size(54, 25);
            this.limitNum.TabIndex = 7;
            // 
            // groupBoxAutocompletion
            // 
            this.groupBoxAutocompletion.Controls.Add(this.algLabel);
            this.groupBoxAutocompletion.Controls.Add(this.limitNum);
            this.groupBoxAutocompletion.Controls.Add(this.algComboBox);
            this.groupBoxAutocompletion.Controls.Add(this.limitCB);
            this.groupBoxAutocompletion.Controls.Add(this.vocabularyCB);
            this.groupBoxAutocompletion.Controls.Add(this.sortCB);
            this.groupBoxAutocompletion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAutocompletion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxAutocompletion.Location = new System.Drawing.Point(12, 124);
            this.groupBoxAutocompletion.Name = "groupBoxAutocompletion";
            this.groupBoxAutocompletion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxAutocompletion.Size = new System.Drawing.Size(235, 134);
            this.groupBoxAutocompletion.TabIndex = 8;
            this.groupBoxAutocompletion.TabStop = false;
            this.groupBoxAutocompletion.Text = "Autocompletion";
            // 
            // groupBoxNote
            // 
            this.groupBoxNote.Controls.Add(this.fileButton);
            this.groupBoxNote.Controls.Add(this.fileTextBox);
            this.groupBoxNote.Controls.Add(this.existingFileRB);
            this.groupBoxNote.Controls.Add(this.newFileRB);
            this.groupBoxNote.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNote.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxNote.Location = new System.Drawing.Point(12, 12);
            this.groupBoxNote.Name = "groupBoxNote";
            this.groupBoxNote.Size = new System.Drawing.Size(235, 106);
            this.groupBoxNote.TabIndex = 9;
            this.groupBoxNote.TabStop = false;
            this.groupBoxNote.Text = "Note";
            // 
            // fileButton
            // 
            this.fileButton.Enabled = false;
            this.fileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileButton.Location = new System.Drawing.Point(176, 75);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(53, 23);
            this.fileButton.TabIndex = 3;
            this.fileButton.Text = "...";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Enabled = false;
            this.fileTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileTextBox.Location = new System.Drawing.Point(9, 75);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(160, 23);
            this.fileTextBox.TabIndex = 2;
            // 
            // existingFileRB
            // 
            this.existingFileRB.AutoSize = true;
            this.existingFileRB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.existingFileRB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.existingFileRB.Location = new System.Drawing.Point(9, 50);
            this.existingFileRB.Name = "existingFileRB";
            this.existingFileRB.Size = new System.Drawing.Size(148, 19);
            this.existingFileRB.TabIndex = 1;
            this.existingFileRB.Text = "Select existing file (.txt):";
            this.existingFileRB.UseVisualStyleBackColor = true;
            this.existingFileRB.CheckedChanged += new System.EventHandler(this.fileSourceChanged);
            // 
            // newFileRB
            // 
            this.newFileRB.AutoSize = true;
            this.newFileRB.Checked = true;
            this.newFileRB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFileRB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newFileRB.Location = new System.Drawing.Point(9, 25);
            this.newFileRB.Name = "newFileRB";
            this.newFileRB.Size = new System.Drawing.Size(103, 19);
            this.newFileRB.TabIndex = 0;
            this.newFileRB.TabStop = true;
            this.newFileRB.Text = "Create new file";
            this.newFileRB.UseVisualStyleBackColor = true;
            this.newFileRB.CheckedChanged += new System.EventHandler(this.fileSourceChanged);
            // 
            // groupBoxWordsSource
            // 
            this.groupBoxWordsSource.Controls.Add(this.databaseButton);
            this.groupBoxWordsSource.Controls.Add(this.databaseTextBox);
            this.groupBoxWordsSource.Controls.Add(this.existingSourceRB);
            this.groupBoxWordsSource.Controls.Add(this.noSourceRB);
            this.groupBoxWordsSource.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxWordsSource.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxWordsSource.Location = new System.Drawing.Point(12, 265);
            this.groupBoxWordsSource.Name = "groupBoxWordsSource";
            this.groupBoxWordsSource.Size = new System.Drawing.Size(235, 106);
            this.groupBoxWordsSource.TabIndex = 10;
            this.groupBoxWordsSource.TabStop = false;
            this.groupBoxWordsSource.Text = "Words source";
            // 
            // databaseButton
            // 
            this.databaseButton.Enabled = false;
            this.databaseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.databaseButton.Location = new System.Drawing.Point(176, 73);
            this.databaseButton.Name = "databaseButton";
            this.databaseButton.Size = new System.Drawing.Size(53, 23);
            this.databaseButton.TabIndex = 4;
            this.databaseButton.Text = "...";
            this.databaseButton.UseVisualStyleBackColor = true;
            this.databaseButton.Click += new System.EventHandler(this.databaseButton_Click);
            // 
            // databaseTextBox
            // 
            this.databaseTextBox.Enabled = false;
            this.databaseTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseTextBox.Location = new System.Drawing.Point(9, 74);
            this.databaseTextBox.Name = "databaseTextBox";
            this.databaseTextBox.Size = new System.Drawing.Size(160, 23);
            this.databaseTextBox.TabIndex = 3;
            // 
            // existingSourceRB
            // 
            this.existingSourceRB.AutoSize = true;
            this.existingSourceRB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.existingSourceRB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.existingSourceRB.Location = new System.Drawing.Point(9, 49);
            this.existingSourceRB.Name = "existingSourceRB";
            this.existingSourceRB.Size = new System.Drawing.Size(214, 19);
            this.existingSourceRB.TabIndex = 2;
            this.existingSourceRB.Text = "Select existing words database (.txt):";
            this.existingSourceRB.UseVisualStyleBackColor = true;
            this.existingSourceRB.CheckedChanged += new System.EventHandler(this.databaseSourceChanged);
            // 
            // noSourceRB
            // 
            this.noSourceRB.AutoSize = true;
            this.noSourceRB.Checked = true;
            this.noSourceRB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noSourceRB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.noSourceRB.Location = new System.Drawing.Point(9, 24);
            this.noSourceRB.Name = "noSourceRB";
            this.noSourceRB.Size = new System.Drawing.Size(158, 19);
            this.noSourceRB.TabIndex = 1;
            this.noSourceRB.TabStop = true;
            this.noSourceRB.Text = "No initial words database";
            this.noSourceRB.UseVisualStyleBackColor = true;
            this.noSourceRB.CheckedChanged += new System.EventHandler(this.databaseSourceChanged);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(12, 377);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(235, 28);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start editing note";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(258, 417);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBoxWordsSource);
            this.Controls.Add(this.groupBoxNote);
            this.Controls.Add(this.groupBoxAutocompletion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.limitNum)).EndInit();
            this.groupBoxAutocompletion.ResumeLayout(false);
            this.groupBoxAutocompletion.PerformLayout();
            this.groupBoxNote.ResumeLayout(false);
            this.groupBoxNote.PerformLayout();
            this.groupBoxWordsSource.ResumeLayout(false);
            this.groupBoxWordsSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label algLabel;
        private System.Windows.Forms.ComboBox algComboBox;
        private System.Windows.Forms.CheckBox vocabularyCB;
        private System.Windows.Forms.CheckBox sortCB;
        private System.Windows.Forms.CheckBox limitCB;
        private System.Windows.Forms.NumericUpDown limitNum;
        private System.Windows.Forms.GroupBox groupBoxAutocompletion;
        private System.Windows.Forms.GroupBox groupBoxNote;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.RadioButton existingFileRB;
        private System.Windows.Forms.RadioButton newFileRB;
        private System.Windows.Forms.GroupBox groupBoxWordsSource;
        private System.Windows.Forms.Button databaseButton;
        private System.Windows.Forms.TextBox databaseTextBox;
        private System.Windows.Forms.RadioButton existingSourceRB;
        private System.Windows.Forms.RadioButton noSourceRB;
        private System.Windows.Forms.Button startButton;
    }
}