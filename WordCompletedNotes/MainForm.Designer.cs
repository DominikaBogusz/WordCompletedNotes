namespace WordCompletedNotes
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.listBox = new System.Windows.Forms.ListBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.menuStrip.Location = new System.Drawing.Point(9, 9);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(6, 4);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // listBox
            // 
            this.listBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.ItemHeight = 14;
            this.listBox.Location = new System.Drawing.Point(270, 54);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(125, 88);
            this.listBox.TabIndex = 4;
            this.listBox.TabStop = false;
            this.listBox.Visible = false;
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox.Location = new System.Drawing.Point(14, 11);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(407, 238);
            this.textBox.TabIndex = 5;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.textBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.textBox);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "WordCompletedNotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox textBox;
    }
}

