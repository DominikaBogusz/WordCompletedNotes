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
            this.groupBoxWordsSource = new System.Windows.Forms.GroupBox();
            this.databaseButton = new System.Windows.Forms.Button();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.existingSourceRB = new System.Windows.Forms.RadioButton();
            this.newSourceRB = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.limitNum)).BeginInit();
            this.groupBoxAutocompletion.SuspendLayout();
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
            this.algComboBox.Size = new System.Drawing.Size(253, 23);
            this.algComboBox.TabIndex = 3;
            this.algComboBox.SelectedIndexChanged += new System.EventHandler(this.algComboBox_SelectedIndexChanged);
            // 
            // vocabularyCB
            // 
            this.vocabularyCB.AutoSize = true;
            this.vocabularyCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vocabularyCB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.vocabularyCB.Location = new System.Drawing.Point(9, 80);
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
            this.sortCB.Location = new System.Drawing.Point(9, 55);
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
            this.limitCB.Location = new System.Drawing.Point(169, 55);
            this.limitCB.Name = "limitCB";
            this.limitCB.Size = new System.Drawing.Size(163, 19);
            this.limitCB.TabIndex = 6;
            this.limitCB.Text = "Limit number of prompts:";
            this.limitCB.UseVisualStyleBackColor = true;
            this.limitCB.CheckedChanged += new System.EventHandler(this.limitCB_CheckedChanged);
            // 
            // limitNum
            // 
            this.limitNum.Enabled = false;
            this.limitNum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitNum.Location = new System.Drawing.Point(276, 76);
            this.limitNum.Name = "limitNum";
            this.limitNum.Size = new System.Drawing.Size(53, 23);
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
            this.groupBoxAutocompletion.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAutocompletion.Name = "groupBoxAutocompletion";
            this.groupBoxAutocompletion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxAutocompletion.Size = new System.Drawing.Size(335, 112);
            this.groupBoxAutocompletion.TabIndex = 8;
            this.groupBoxAutocompletion.TabStop = false;
            this.groupBoxAutocompletion.Text = "Autocompletion";
            // 
            // groupBoxWordsSource
            // 
            this.groupBoxWordsSource.Controls.Add(this.databaseButton);
            this.groupBoxWordsSource.Controls.Add(this.sourceTextBox);
            this.groupBoxWordsSource.Controls.Add(this.existingSourceRB);
            this.groupBoxWordsSource.Controls.Add(this.newSourceRB);
            this.groupBoxWordsSource.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxWordsSource.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxWordsSource.Location = new System.Drawing.Point(12, 130);
            this.groupBoxWordsSource.Name = "groupBoxWordsSource";
            this.groupBoxWordsSource.Size = new System.Drawing.Size(335, 85);
            this.groupBoxWordsSource.TabIndex = 10;
            this.groupBoxWordsSource.TabStop = false;
            this.groupBoxWordsSource.Text = "Words source";
            // 
            // databaseButton
            // 
            this.databaseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.databaseButton.Location = new System.Drawing.Point(276, 48);
            this.databaseButton.Name = "databaseButton";
            this.databaseButton.Size = new System.Drawing.Size(53, 23);
            this.databaseButton.TabIndex = 4;
            this.databaseButton.Text = "...";
            this.databaseButton.UseVisualStyleBackColor = true;
            this.databaseButton.Click += new System.EventHandler(this.databaseButton_Click);
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceTextBox.Location = new System.Drawing.Point(9, 49);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ReadOnly = true;
            this.sourceTextBox.Size = new System.Drawing.Size(261, 23);
            this.sourceTextBox.TabIndex = 3;
            // 
            // existingSourceRB
            // 
            this.existingSourceRB.AutoSize = true;
            this.existingSourceRB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.existingSourceRB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.existingSourceRB.Location = new System.Drawing.Point(141, 24);
            this.existingSourceRB.Name = "existingSourceRB";
            this.existingSourceRB.Size = new System.Drawing.Size(176, 19);
            this.existingSourceRB.TabIndex = 2;
            this.existingSourceRB.Text = "Select existing words storage";
            this.existingSourceRB.UseVisualStyleBackColor = true;
            // 
            // newSourceRB
            // 
            this.newSourceRB.AutoSize = true;
            this.newSourceRB.Checked = true;
            this.newSourceRB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newSourceRB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newSourceRB.Location = new System.Drawing.Point(9, 24);
            this.newSourceRB.Name = "newSourceRB";
            this.newSourceRB.Size = new System.Drawing.Size(126, 19);
            this.newSourceRB.TabIndex = 1;
            this.newSourceRB.TabStop = true;
            this.newSourceRB.Text = "Create new storage";
            this.newSourceRB.UseVisualStyleBackColor = true;
            this.newSourceRB.CheckedChanged += new System.EventHandler(this.wordsSource_CheckedChange);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(12, 221);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(335, 28);
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
            this.ClientSize = new System.Drawing.Size(359, 260);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBoxWordsSource);
            this.Controls.Add(this.groupBoxAutocompletion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.limitNum)).EndInit();
            this.groupBoxAutocompletion.ResumeLayout(false);
            this.groupBoxAutocompletion.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxWordsSource;
        private System.Windows.Forms.Button databaseButton;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.RadioButton existingSourceRB;
        private System.Windows.Forms.RadioButton newSourceRB;
        private System.Windows.Forms.Button startButton;
    }
}