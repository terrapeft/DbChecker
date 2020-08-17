namespace DbChecker
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.connStrComboBox = new System.Windows.Forms.ComboBox();
            this.resultsTextbox = new System.Windows.Forms.TextBox();
            this.connStrTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.queryTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wipeHistoryButton = new System.Windows.Forms.Button();
            this.deleteQueryButton = new System.Windows.Forms.Button();
            this.rightHistoryButton = new System.Windows.Forms.Button();
            this.leftHistoryButton = new System.Windows.Forms.Button();
            this.lastHistoryButton = new System.Windows.Forms.Button();
            this.firstHistoryButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.historyPositionLabel = new System.Windows.Forms.StatusBarPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConnStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteConnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryTextbox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyPositionLabel)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connStrComboBox
            // 
            this.connStrComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStrComboBox.FormattingEnabled = true;
            this.connStrComboBox.Location = new System.Drawing.Point(12, 33);
            this.connStrComboBox.Name = "connStrComboBox";
            this.connStrComboBox.Size = new System.Drawing.Size(973, 21);
            this.connStrComboBox.TabIndex = 0;
            this.connStrComboBox.SelectedIndexChanged += new System.EventHandler(this.connStrComboBox_SelectedIndexChanged);
            // 
            // resultsTextbox
            // 
            this.resultsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTextbox.Location = new System.Drawing.Point(3, 3);
            this.resultsTextbox.Multiline = true;
            this.resultsTextbox.Name = "resultsTextbox";
            this.resultsTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextbox.Size = new System.Drawing.Size(959, 315);
            this.resultsTextbox.TabIndex = 3;
            // 
            // connStrTextBox
            // 
            this.connStrTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStrTextBox.Location = new System.Drawing.Point(12, 60);
            this.connStrTextBox.Multiline = true;
            this.connStrTextBox.Name = "connStrTextBox";
            this.connStrTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.connStrTextBox.Size = new System.Drawing.Size(973, 48);
            this.connStrTextBox.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 114);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.queryTextbox);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(973, 564);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 6;
            // 
            // queryTextbox
            // 
            this.queryTextbox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.queryTextbox.AutoIndentCharsPatterns = "";
            this.queryTextbox.AutoScrollMinSize = new System.Drawing.Size(39, 14);
            this.queryTextbox.BackBrush = null;
            this.queryTextbox.CharHeight = 14;
            this.queryTextbox.CharWidth = 8;
            this.queryTextbox.CommentPrefix = "--";
            this.queryTextbox.CurrentPenSize = 3;
            this.queryTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.queryTextbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.queryTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTextbox.DocumentPath = null;
            this.queryTextbox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.queryTextbox.IsReplaceMode = false;
            this.queryTextbox.Language = FastColoredTextBoxNS.Language.SQL;
            this.queryTextbox.LeftBracket = '(';
            this.queryTextbox.Location = new System.Drawing.Point(0, 0);
            this.queryTextbox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.queryTextbox.Name = "queryTextbox";
            this.queryTextbox.Paddings = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.queryTextbox.RightBracket = ')';
            this.queryTextbox.SelectionChangedDelayedEnabled = false;
            this.queryTextbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.queryTextbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("queryTextbox.ServiceColors")));
            this.queryTextbox.Size = new System.Drawing.Size(973, 213);
            this.queryTextbox.TabIndex = 3;
            this.queryTextbox.Zoom = 100;
            this.queryTextbox.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.queryTextbox_TextChangedDelayed);
            this.queryTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.queryTextbox_KeyUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(973, 347);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.resultsDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(965, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Results";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.AllowUserToAddRows = false;
            this.resultsDataGridView.AllowUserToDeleteRows = false;
            this.resultsDataGridView.AllowUserToOrderColumns = true;
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.RowHeadersWidth = 51;
            this.resultsDataGridView.Size = new System.Drawing.Size(959, 315);
            this.resultsDataGridView.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.resultsTextbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(965, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Messages";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // wipeHistoryButton
            // 
            this.wipeHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wipeHistoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.wipeHistoryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.wipeHistoryButton.Location = new System.Drawing.Point(910, 698);
            this.wipeHistoryButton.Name = "wipeHistoryButton";
            this.wipeHistoryButton.Size = new System.Drawing.Size(75, 20);
            this.wipeHistoryButton.TabIndex = 9;
            this.wipeHistoryButton.Text = "Wipe history";
            this.toolTip1.SetToolTip(this.wipeHistoryButton, "Delete history from file");
            this.wipeHistoryButton.UseVisualStyleBackColor = false;
            this.wipeHistoryButton.Click += new System.EventHandler(this.wipeHistoryButton_Click);
            // 
            // deleteQueryButton
            // 
            this.deleteQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteQueryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteQueryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.deleteQueryButton.Location = new System.Drawing.Point(116, 698);
            this.deleteQueryButton.Name = "deleteQueryButton";
            this.deleteQueryButton.Size = new System.Drawing.Size(75, 20);
            this.deleteQueryButton.TabIndex = 12;
            this.deleteQueryButton.Text = "Delete query";
            this.toolTip1.SetToolTip(this.deleteQueryButton, "Delete query from history");
            this.deleteQueryButton.UseVisualStyleBackColor = false;
            this.deleteQueryButton.Click += new System.EventHandler(this.deleteQueryButton_Click);
            // 
            // rightHistoryButton
            // 
            this.rightHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rightHistoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rightHistoryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rightHistoryButton.Location = new System.Drawing.Point(254, 698);
            this.rightHistoryButton.Name = "rightHistoryButton";
            this.rightHistoryButton.Size = new System.Drawing.Size(20, 20);
            this.rightHistoryButton.TabIndex = 15;
            this.rightHistoryButton.Text = ">";
            this.toolTip1.SetToolTip(this.rightHistoryButton, "Delete history from file");
            this.rightHistoryButton.UseVisualStyleBackColor = false;
            this.rightHistoryButton.Click += new System.EventHandler(this.rightHistoryButton_Click);
            // 
            // leftHistoryButton
            // 
            this.leftHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leftHistoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.leftHistoryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.leftHistoryButton.Location = new System.Drawing.Point(232, 698);
            this.leftHistoryButton.Name = "leftHistoryButton";
            this.leftHistoryButton.Size = new System.Drawing.Size(20, 20);
            this.leftHistoryButton.TabIndex = 16;
            this.leftHistoryButton.Text = "<";
            this.toolTip1.SetToolTip(this.leftHistoryButton, "Delete history from file");
            this.leftHistoryButton.UseVisualStyleBackColor = false;
            this.leftHistoryButton.Click += new System.EventHandler(this.leftHistoryButton_Click);
            // 
            // lastHistoryButton
            // 
            this.lastHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastHistoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lastHistoryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.lastHistoryButton.Location = new System.Drawing.Point(280, 698);
            this.lastHistoryButton.Name = "lastHistoryButton";
            this.lastHistoryButton.Size = new System.Drawing.Size(29, 20);
            this.lastHistoryButton.TabIndex = 17;
            this.lastHistoryButton.Text = ">>";
            this.toolTip1.SetToolTip(this.lastHistoryButton, "Delete history from file");
            this.lastHistoryButton.UseVisualStyleBackColor = false;
            this.lastHistoryButton.Click += new System.EventHandler(this.lastHistoryButton_Click);
            // 
            // firstHistoryButton
            // 
            this.firstHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstHistoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.firstHistoryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.firstHistoryButton.Location = new System.Drawing.Point(197, 698);
            this.firstHistoryButton.Name = "firstHistoryButton";
            this.firstHistoryButton.Size = new System.Drawing.Size(29, 20);
            this.firstHistoryButton.TabIndex = 20;
            this.firstHistoryButton.Text = "<<";
            this.toolTip1.SetToolTip(this.firstHistoryButton, "Delete history from file");
            this.firstHistoryButton.UseVisualStyleBackColor = false;
            this.firstHistoryButton.Click += new System.EventHandler(this.firstHistoryButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 684);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(973, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "CSV|*.csv";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 697);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.historyPositionLabel});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(997, 21);
            this.statusBar1.TabIndex = 19;
            this.statusBar1.Text = "statusBar1";
            // 
            // historyPositionLabel
            // 
            this.historyPositionLabel.Name = "historyPositionLabel";
            this.historyPositionLabel.Text = "0/0";
            this.historyPositionLabel.Width = 200;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runStripMenuItem,
            this.saveConnStripMenuItem,
            this.deleteConnToolStripMenuItem,
            this.saveQueryToolStripMenuItem,
            this.importCSVToolStripMenuItem,
            this.saveResultsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(997, 24);
            this.menuStrip1.TabIndex = 22;
            // 
            // runStripMenuItem
            // 
            this.runStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.runStripMenuItem.Name = "runStripMenuItem";
            this.runStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runStripMenuItem.Text = "Run";
            this.runStripMenuItem.Click += new System.EventHandler(this.runButton_Click);
            // 
            // saveConnStripMenuItem
            // 
            this.saveConnStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saveConnStripMenuItem.Name = "saveConnStripMenuItem";
            this.saveConnStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.saveConnStripMenuItem.Text = "Save Conn";
            this.saveConnStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteConnToolStripMenuItem
            // 
            this.deleteConnToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.deleteConnToolStripMenuItem.Name = "deleteConnToolStripMenuItem";
            this.deleteConnToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.deleteConnToolStripMenuItem.Text = "Delete Conn";
            this.deleteConnToolStripMenuItem.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveQueryToolStripMenuItem
            // 
            this.saveQueryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.saveQueryToolStripMenuItem.Name = "saveQueryToolStripMenuItem";
            this.saveQueryToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.saveQueryToolStripMenuItem.Text = "Save Query";
            this.saveQueryToolStripMenuItem.Click += new System.EventHandler(this.saveQueryButton_Click);
            // 
            // importCSVToolStripMenuItem
            // 
            this.importCSVToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            this.importCSVToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.importCSVToolStripMenuItem.Text = "Import CSV";
            this.importCSVToolStripMenuItem.Click += new System.EventHandler(this.csvButton_Click);
            // 
            // saveResultsToolStripMenuItem
            // 
            this.saveResultsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.saveResultsToolStripMenuItem.Name = "saveResultsToolStripMenuItem";
            this.saveResultsToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.saveResultsToolStripMenuItem.Text = "Save Results";
            this.saveResultsToolStripMenuItem.Click += new System.EventHandler(this.saveResultsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 718);
            this.Controls.Add(this.firstHistoryButton);
            this.Controls.Add(this.lastHistoryButton);
            this.Controls.Add(this.leftHistoryButton);
            this.Controls.Add(this.rightHistoryButton);
            this.Controls.Add(this.deleteQueryButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.wipeHistoryButton);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.connStrTextBox);
            this.Controls.Add(this.connStrComboBox);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Database Lookup";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queryTextbox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyPositionLabel)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox connStrComboBox;
        private System.Windows.Forms.TextBox resultsTextbox;
        private System.Windows.Forms.TextBox connStrTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button wipeHistoryButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.Button deleteQueryButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private FastColoredTextBoxNS.FastColoredTextBox queryTextbox;
        private System.Windows.Forms.Button rightHistoryButton;
        private System.Windows.Forms.Button leftHistoryButton;
        private System.Windows.Forms.Button lastHistoryButton;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel historyPositionLabel;
        private System.Windows.Forms.Button firstHistoryButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConnStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteConnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultsToolStripMenuItem;
    }
}

