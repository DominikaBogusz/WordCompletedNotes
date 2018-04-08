namespace WordCompletedNotes
{
    partial class TestForm
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
            this.dictSmallCB = new System.Windows.Forms.CheckBox();
            this.dictMediumCB = new System.Windows.Forms.CheckBox();
            this.dictLargeCB = new System.Windows.Forms.CheckBox();
            this.insertSingleCB = new System.Windows.Forms.CheckBox();
            this.dictSizeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.insertDictCB = new System.Windows.Forms.CheckBox();
            this.findAllCB = new System.Windows.Forms.CheckBox();
            this.find10CB = new System.Windows.Forms.CheckBox();
            this.findMostUsedAllCB = new System.Windows.Forms.CheckBox();
            this.findMostUsed10CB = new System.Windows.Forms.CheckBox();
            this.repetitionsLabel = new System.Windows.Forms.Label();
            this.repetitionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.repetitionsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // algLabel
            // 
            this.algLabel.AutoSize = true;
            this.algLabel.Location = new System.Drawing.Point(34, 15);
            this.algLabel.Name = "algLabel";
            this.algLabel.Size = new System.Drawing.Size(53, 13);
            this.algLabel.TabIndex = 0;
            this.algLabel.Text = "Algorithm:";
            // 
            // algComboBox
            // 
            this.algComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.algComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algComboBox.ForeColor = System.Drawing.Color.Black;
            this.algComboBox.FormattingEnabled = true;
            this.algComboBox.Items.AddRange(new object[] {
            "Simple",
            "Trie",
            "HeapTrie"});
            this.algComboBox.Location = new System.Drawing.Point(93, 15);
            this.algComboBox.Name = "algComboBox";
            this.algComboBox.Size = new System.Drawing.Size(226, 21);
            this.algComboBox.TabIndex = 2;
            // 
            // dictSmallCB
            // 
            this.dictSmallCB.AutoSize = true;
            this.dictSmallCB.Location = new System.Drawing.Point(93, 42);
            this.dictSmallCB.Name = "dictSmallCB";
            this.dictSmallCB.Size = new System.Drawing.Size(145, 17);
            this.dictSmallCB.TabIndex = 3;
            this.dictSmallCB.Text = "small (500 random words)";
            this.dictSmallCB.UseVisualStyleBackColor = true;
            this.dictSmallCB.CheckedChanged += new System.EventHandler(this.dictSelectionChange);
            // 
            // dictMediumCB
            // 
            this.dictMediumCB.AutoSize = true;
            this.dictMediumCB.Location = new System.Drawing.Point(93, 65);
            this.dictMediumCB.Name = "dictMediumCB";
            this.dictMediumCB.Size = new System.Drawing.Size(170, 17);
            this.dictMediumCB.TabIndex = 4;
            this.dictMediumCB.Text = "medium (10000 random words)";
            this.dictMediumCB.UseVisualStyleBackColor = true;
            this.dictMediumCB.CheckedChanged += new System.EventHandler(this.dictSelectionChange);
            // 
            // dictLargeCB
            // 
            this.dictLargeCB.AutoSize = true;
            this.dictLargeCB.Location = new System.Drawing.Point(93, 88);
            this.dictLargeCB.Name = "dictLargeCB";
            this.dictLargeCB.Size = new System.Drawing.Size(226, 17);
            this.dictLargeCB.TabIndex = 5;
            this.dictLargeCB.Text = "large (over 2000000 words from dictionary)";
            this.dictLargeCB.UseVisualStyleBackColor = true;
            this.dictLargeCB.CheckedChanged += new System.EventHandler(this.dictSelectionChange);
            // 
            // insertSingleCB
            // 
            this.insertSingleCB.AutoSize = true;
            this.insertSingleCB.Location = new System.Drawing.Point(93, 111);
            this.insertSingleCB.Name = "insertSingleCB";
            this.insertSingleCB.Size = new System.Drawing.Size(108, 17);
            this.insertSingleCB.TabIndex = 6;
            this.insertSingleCB.Text = "Insert single word";
            this.insertSingleCB.UseVisualStyleBackColor = true;
            this.insertSingleCB.CheckedChanged += new System.EventHandler(this.funcSelectionChange);
            // 
            // dictSizeLabel
            // 
            this.dictSizeLabel.AutoSize = true;
            this.dictSizeLabel.Location = new System.Drawing.Point(9, 42);
            this.dictSizeLabel.Name = "dictSizeLabel";
            this.dictSizeLabel.Size = new System.Drawing.Size(78, 13);
            this.dictSizeLabel.TabIndex = 7;
            this.dictSizeLabel.Text = "Dictionary size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Functionalities:";
            // 
            // insertDictCB
            // 
            this.insertDictCB.AutoSize = true;
            this.insertDictCB.Location = new System.Drawing.Point(93, 134);
            this.insertDictCB.Name = "insertDictCB";
            this.insertDictCB.Size = new System.Drawing.Size(100, 17);
            this.insertDictCB.TabIndex = 9;
            this.insertDictCB.Text = "Insert dictionary";
            this.insertDictCB.UseVisualStyleBackColor = true;
            this.insertDictCB.CheckedChanged += new System.EventHandler(this.funcSelectionChange);
            // 
            // findAllCB
            // 
            this.findAllCB.AutoSize = true;
            this.findAllCB.Location = new System.Drawing.Point(93, 180);
            this.findAllCB.Name = "findAllCB";
            this.findAllCB.Size = new System.Drawing.Size(108, 17);
            this.findAllCB.TabIndex = 10;
            this.findAllCB.Text = "Find matches (all)";
            this.findAllCB.UseVisualStyleBackColor = true;
            this.findAllCB.CheckedChanged += new System.EventHandler(this.funcSelectionChange);
            // 
            // find10CB
            // 
            this.find10CB.AutoSize = true;
            this.find10CB.Location = new System.Drawing.Point(93, 157);
            this.find10CB.Name = "find10CB";
            this.find10CB.Size = new System.Drawing.Size(110, 17);
            this.find10CB.TabIndex = 11;
            this.find10CB.Text = "Find matches (10)";
            this.find10CB.UseVisualStyleBackColor = true;
            this.find10CB.CheckedChanged += new System.EventHandler(this.funcSelectionChange);
            // 
            // findMostUsedAllCB
            // 
            this.findMostUsedAllCB.AutoSize = true;
            this.findMostUsedAllCB.Location = new System.Drawing.Point(93, 227);
            this.findMostUsedAllCB.Name = "findMostUsedAllCB";
            this.findMostUsedAllCB.Size = new System.Drawing.Size(159, 17);
            this.findMostUsedAllCB.TabIndex = 12;
            this.findMostUsedAllCB.Text = "Find most used matches (all)";
            this.findMostUsedAllCB.UseVisualStyleBackColor = true;
            this.findMostUsedAllCB.CheckedChanged += new System.EventHandler(this.funcSelectionChange);
            // 
            // findMostUsed10CB
            // 
            this.findMostUsed10CB.AutoSize = true;
            this.findMostUsed10CB.Location = new System.Drawing.Point(93, 204);
            this.findMostUsed10CB.Name = "findMostUsed10CB";
            this.findMostUsed10CB.Size = new System.Drawing.Size(161, 17);
            this.findMostUsed10CB.TabIndex = 13;
            this.findMostUsed10CB.Text = "Find most used matches (10)";
            this.findMostUsed10CB.UseVisualStyleBackColor = true;
            this.findMostUsed10CB.CheckedChanged += new System.EventHandler(this.funcSelectionChange);
            // 
            // repetitionsLabel
            // 
            this.repetitionsLabel.AutoSize = true;
            this.repetitionsLabel.Location = new System.Drawing.Point(24, 252);
            this.repetitionsLabel.Name = "repetitionsLabel";
            this.repetitionsLabel.Size = new System.Drawing.Size(63, 13);
            this.repetitionsLabel.TabIndex = 14;
            this.repetitionsLabel.Text = "Repetitions:";
            // 
            // repetitionsNumericUpDown
            // 
            this.repetitionsNumericUpDown.Location = new System.Drawing.Point(93, 250);
            this.repetitionsNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.repetitionsNumericUpDown.Name = "repetitionsNumericUpDown";
            this.repetitionsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.repetitionsNumericUpDown.TabIndex = 15;
            this.repetitionsNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(12, 279);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(307, 29);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Save tests output to the file...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(332, 320);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.repetitionsNumericUpDown);
            this.Controls.Add(this.repetitionsLabel);
            this.Controls.Add(this.findMostUsed10CB);
            this.Controls.Add(this.findMostUsedAllCB);
            this.Controls.Add(this.find10CB);
            this.Controls.Add(this.findAllCB);
            this.Controls.Add(this.insertDictCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dictSizeLabel);
            this.Controls.Add(this.insertSingleCB);
            this.Controls.Add(this.dictLargeCB);
            this.Controls.Add(this.dictMediumCB);
            this.Controls.Add(this.dictSmallCB);
            this.Controls.Add(this.algLabel);
            this.Controls.Add(this.algComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(348, 359);
            this.MinimumSize = new System.Drawing.Size(348, 359);
            this.Name = "TestForm";
            this.Text = "Test Library Speed";
            ((System.ComponentModel.ISupportInitialize)(this.repetitionsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label algLabel;
        private System.Windows.Forms.ComboBox algComboBox;
        private System.Windows.Forms.CheckBox dictSmallCB;
        private System.Windows.Forms.CheckBox dictMediumCB;
        private System.Windows.Forms.CheckBox dictLargeCB;
        private System.Windows.Forms.CheckBox insertSingleCB;
        private System.Windows.Forms.Label dictSizeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox insertDictCB;
        private System.Windows.Forms.CheckBox findAllCB;
        private System.Windows.Forms.CheckBox find10CB;
        private System.Windows.Forms.CheckBox findMostUsedAllCB;
        private System.Windows.Forms.CheckBox findMostUsed10CB;
        private System.Windows.Forms.Label repetitionsLabel;
        private System.Windows.Forms.NumericUpDown repetitionsNumericUpDown;
        private System.Windows.Forms.Button saveButton;
    }
}