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
            this.textBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.wordsDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUsedWordsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveUsedWordsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.totxtFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tomdfDatabaseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openWordsDatabaseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fromtxtFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.frommdfDatabaseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.autocompletionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.useDictionaryPLMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.algSimpleMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.algTrieMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.algTrieHeapMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox.Location = new System.Drawing.Point(5, 30);
            this.textBox.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(589, 281);
            this.textBox.TabIndex = 0;
            this.textBox.Click += new System.EventHandler(this.textBox_Click);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox.MouseHover += new System.EventHandler(this.textBox_MouseHover);
            this.textBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.wordsDatabaseToolStripMenuItem,
            this.autocompletionToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(6, 5, 0, 5);
            this.menuStrip.Size = new System.Drawing.Size(599, 30);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.Click += new System.EventHandler(this.DeactivateAutoForm);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenu,
            this.openMenu,
            this.saveMenu,
            this.saveAsMenu,
            this.exitMenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newMenu
            // 
            this.newMenu.Name = "newMenu";
            this.newMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenu.Size = new System.Drawing.Size(193, 22);
            this.newMenu.Text = "New";
            this.newMenu.Click += new System.EventHandler(this.newMenu_Click);
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenu.Size = new System.Drawing.Size(193, 22);
            this.openMenu.Text = "Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // saveMenu
            // 
            this.saveMenu.Enabled = false;
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenu.Size = new System.Drawing.Size(193, 22);
            this.saveMenu.Text = "Save";
            this.saveMenu.Click += new System.EventHandler(this.saveMenu_Click);
            // 
            // saveAsMenu
            // 
            this.saveAsMenu.Name = "saveAsMenu";
            this.saveAsMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMenu.Size = new System.Drawing.Size(193, 22);
            this.saveAsMenu.Text = "Save as...";
            this.saveAsMenu.Click += new System.EventHandler(this.saveAsMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitMenu.Size = new System.Drawing.Size(193, 22);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // wordsDatabaseToolStripMenuItem
            // 
            this.wordsDatabaseToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.wordsDatabaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showUsedWordsMenu,
            this.saveUsedWordsMenu,
            this.openWordsDatabaseMenu});
            this.wordsDatabaseToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.wordsDatabaseToolStripMenuItem.Name = "wordsDatabaseToolStripMenuItem";
            this.wordsDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.wordsDatabaseToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.wordsDatabaseToolStripMenuItem.Text = "&Words Database";
            // 
            // showUsedWordsMenu
            // 
            this.showUsedWordsMenu.Name = "showUsedWordsMenu";
            this.showUsedWordsMenu.Size = new System.Drawing.Size(188, 22);
            this.showUsedWordsMenu.Text = "Show used words";
            this.showUsedWordsMenu.Click += new System.EventHandler(this.showUsedWordsMenu_Click);
            // 
            // saveUsedWordsMenu
            // 
            this.saveUsedWordsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totxtFileMenu,
            this.tomdfDatabaseMenu});
            this.saveUsedWordsMenu.Name = "saveUsedWordsMenu";
            this.saveUsedWordsMenu.Size = new System.Drawing.Size(188, 22);
            this.saveUsedWordsMenu.Text = "Save used words";
            // 
            // totxtFileMenu
            // 
            this.totxtFileMenu.Name = "totxtFileMenu";
            this.totxtFileMenu.Size = new System.Drawing.Size(163, 22);
            this.totxtFileMenu.Text = "to .txt file";
            this.totxtFileMenu.Click += new System.EventHandler(this.totxtFileMenu_Click);
            // 
            // tomdfDatabaseMenu
            // 
            this.tomdfDatabaseMenu.Name = "tomdfDatabaseMenu";
            this.tomdfDatabaseMenu.Size = new System.Drawing.Size(163, 22);
            this.tomdfDatabaseMenu.Text = "to .mdf database";
            this.tomdfDatabaseMenu.Click += new System.EventHandler(this.tomdfDatabaseMenu_Click);
            // 
            // openWordsDatabaseMenu
            // 
            this.openWordsDatabaseMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromtxtFileMenu,
            this.frommdfDatabaseMenu});
            this.openWordsDatabaseMenu.Name = "openWordsDatabaseMenu";
            this.openWordsDatabaseMenu.Size = new System.Drawing.Size(188, 22);
            this.openWordsDatabaseMenu.Text = "Open words database";
            // 
            // fromtxtFileMenu
            // 
            this.fromtxtFileMenu.Name = "fromtxtFileMenu";
            this.fromtxtFileMenu.Size = new System.Drawing.Size(178, 22);
            this.fromtxtFileMenu.Text = "from .txt file";
            this.fromtxtFileMenu.Click += new System.EventHandler(this.fromtxtFileMenu_Click);
            // 
            // frommdfDatabaseMenu
            // 
            this.frommdfDatabaseMenu.Name = "frommdfDatabaseMenu";
            this.frommdfDatabaseMenu.Size = new System.Drawing.Size(178, 22);
            this.frommdfDatabaseMenu.Text = "from .mdf database";
            this.frommdfDatabaseMenu.Click += new System.EventHandler(this.frommdfDatabaseMenu_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.menuStrip, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBox, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(599, 341);
            this.tableLayoutPanel.TabIndex = 2;
            this.tableLayoutPanel.Click += new System.EventHandler(this.DeactivateAutoForm);
            // 
            // autocompletionToolStripMenuItem
            // 
            this.autocompletionToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.autocompletionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algorithmMenu,
            this.useDictionaryPLMenu});
            this.autocompletionToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.autocompletionToolStripMenuItem.Name = "autocompletionToolStripMenuItem";
            this.autocompletionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.autocompletionToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.autocompletionToolStripMenuItem.Text = "&Autocompletion";
            // 
            // algorithmMenu
            // 
            this.algorithmMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algSimpleMenu,
            this.algTrieMenu,
            this.algTrieHeapMenu});
            this.algorithmMenu.Name = "algorithmMenu";
            this.algorithmMenu.Size = new System.Drawing.Size(173, 22);
            this.algorithmMenu.Text = "Algorithm";
            // 
            // useDictionaryPLMenu
            // 
            this.useDictionaryPLMenu.CheckOnClick = true;
            this.useDictionaryPLMenu.Name = "useDictionaryPLMenu";
            this.useDictionaryPLMenu.Size = new System.Drawing.Size(173, 22);
            this.useDictionaryPLMenu.Text = "Use dictionary (PL)";
            // 
            // algSimpleMenu
            // 
            this.algSimpleMenu.Checked = true;
            this.algSimpleMenu.CheckOnClick = true;
            this.algSimpleMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.algSimpleMenu.Name = "algSimpleMenu";
            this.algSimpleMenu.Size = new System.Drawing.Size(152, 22);
            this.algSimpleMenu.Text = "Simple";
            this.algSimpleMenu.Click += new System.EventHandler(this.algSimpleMenu_Click);
            // 
            // algTrieMenu
            // 
            this.algTrieMenu.CheckOnClick = true;
            this.algTrieMenu.Name = "algTrieMenu";
            this.algTrieMenu.Size = new System.Drawing.Size(152, 22);
            this.algTrieMenu.Text = "Trie";
            this.algTrieMenu.Click += new System.EventHandler(this.algTrieMenu_Click);
            // 
            // algTrieHeapMenu
            // 
            this.algTrieHeapMenu.CheckOnClick = true;
            this.algTrieHeapMenu.Name = "algTrieHeapMenu";
            this.algTrieHeapMenu.Size = new System.Drawing.Size(152, 22);
            this.algTrieHeapMenu.Text = "Trie with Heap";
            this.algTrieHeapMenu.Click += new System.EventHandler(this.algTrieHeapMenu_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(599, 341);
            this.Controls.Add(this.tableLayoutPanel);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Autocomplete";
            this.Deactivate += new System.EventHandler(this.DeactivateAutoForm);
            this.Move += new System.EventHandler(this.MainForm_MoveOrResize);
            this.Resize += new System.EventHandler(this.MainForm_MoveOrResize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem newMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem wordsDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveUsedWordsMenu;
        private System.Windows.Forms.ToolStripMenuItem totxtFileMenu;
        private System.Windows.Forms.ToolStripMenuItem tomdfDatabaseMenu;
        private System.Windows.Forms.ToolStripMenuItem openWordsDatabaseMenu;
        private System.Windows.Forms.ToolStripMenuItem fromtxtFileMenu;
        private System.Windows.Forms.ToolStripMenuItem frommdfDatabaseMenu;
        private System.Windows.Forms.ToolStripMenuItem showUsedWordsMenu;
        private System.Windows.Forms.ToolStripMenuItem autocompletionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algorithmMenu;
        private System.Windows.Forms.ToolStripMenuItem algSimpleMenu;
        private System.Windows.Forms.ToolStripMenuItem algTrieMenu;
        private System.Windows.Forms.ToolStripMenuItem algTrieHeapMenu;
        private System.Windows.Forms.ToolStripMenuItem useDictionaryPLMenu;
    }
}

