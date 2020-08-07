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
            this.runButton = new System.Windows.Forms.Button();
            this.connStrTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.queryTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.wipeHistoryButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveQueryButton = new System.Windows.Forms.Button();
            this.deleteQueryButton = new System.Windows.Forms.Button();
            this.saveResultsButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rightHistoryButton = new System.Windows.Forms.Button();
            this.leftHistoryButton = new System.Windows.Forms.Button();
            this.lastHistoryButton = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.historyPositionLabel = new System.Windows.Forms.StatusBarPanel();
            this.firstHistoryButton = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // connStrComboBox
            // 
            this.connStrComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStrComboBox.FormattingEnabled = true;
            this.connStrComboBox.Location = new System.Drawing.Point(12, 12);
            this.connStrComboBox.Name = "connStrComboBox";
            this.connStrComboBox.Size = new System.Drawing.Size(892, 21);
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
            this.resultsTextbox.Size = new System.Drawing.Size(777, 302);
            this.resultsTextbox.TabIndex = 3;
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.BackColor = System.Drawing.Color.PaleGreen;
            this.runButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.runButton.Location = new System.Drawing.Point(910, 10);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Run query";
            this.toolTip1.SetToolTip(this.runButton, "Run the query or selection (F5)");
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // connStrTextBox
            // 
            this.connStrTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStrTextBox.Location = new System.Drawing.Point(12, 39);
            this.connStrTextBox.Multiline = true;
            this.connStrTextBox.Name = "connStrTextBox";
            this.connStrTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.connStrTextBox.Size = new System.Drawing.Size(892, 48);
            this.connStrTextBox.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 93);
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
            this.splitContainer1.Size = new System.Drawing.Size(892, 589);
            this.splitContainer1.SplitterDistance = 223;
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
            this.queryTextbox.AutoScrollMinSize = new System.Drawing.Size(191, 14);
            this.queryTextbox.BackBrush = null;
            this.queryTextbox.CharHeight = 14;
            this.queryTextbox.CharWidth = 8;
            this.queryTextbox.CommentPrefix = "--";
            this.queryTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.queryTextbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.queryTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTextbox.IsReplaceMode = false;
            this.queryTextbox.Language = FastColoredTextBoxNS.Language.SQL;
            this.queryTextbox.LeftBracket = '(';
            this.queryTextbox.Location = new System.Drawing.Point(0, 0);
            this.queryTextbox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.queryTextbox.Name = "queryTextbox";
            this.queryTextbox.Paddings = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.queryTextbox.RightBracket = ')';
            this.queryTextbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.queryTextbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("queryTextbox.ServiceColors")));
            this.queryTextbox.Size = new System.Drawing.Size(892, 223);
            this.queryTextbox.TabIndex = 3;
            this.queryTextbox.Text = "fastColoredTextBox1";
            this.queryTextbox.Zoom = 100;
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
            this.tabControl1.Size = new System.Drawing.Size(892, 362);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.resultsDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(884, 336);
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
            this.resultsDataGridView.Size = new System.Drawing.Size(878, 330);
            this.resultsDataGridView.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.resultsTextbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(783, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Messages";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(910, 37);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save conn";
            this.toolTip1.SetToolTip(this.saveButton, "Add or update connection string");
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
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
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.deleteButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.deleteButton.Location = new System.Drawing.Point(910, 64);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Delete conn";
            this.toolTip1.SetToolTip(this.deleteButton, "Delete connection string except those from machine.config");
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveQueryButton
            // 
            this.saveQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveQueryButton.BackColor = System.Drawing.Color.Wheat;
            this.saveQueryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveQueryButton.Location = new System.Drawing.Point(910, 93);
            this.saveQueryButton.Name = "saveQueryButton";
            this.saveQueryButton.Size = new System.Drawing.Size(75, 23);
            this.saveQueryButton.TabIndex = 11;
            this.saveQueryButton.Text = "Save query";
            this.toolTip1.SetToolTip(this.saveQueryButton, "Save query to history");
            this.saveQueryButton.UseVisualStyleBackColor = false;
            this.saveQueryButton.Click += new System.EventHandler(this.saveQueryButton_Click);
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
            // saveResultsButton
            // 
            this.saveResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveResultsButton.BackColor = System.Drawing.Color.LightPink;
            this.saveResultsButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveResultsButton.Location = new System.Drawing.Point(910, 645);
            this.saveResultsButton.Name = "saveResultsButton";
            this.saveResultsButton.Size = new System.Drawing.Size(83, 23);
            this.saveResultsButton.TabIndex = 13;
            this.saveResultsButton.Text = "Save Results";
            this.toolTip1.SetToolTip(this.saveResultsButton, "Add or update connection string");
            this.saveResultsButton.UseVisualStyleBackColor = false;
            this.saveResultsButton.Click += new System.EventHandler(this.saveResultsButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(19, 684);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(881, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
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
            // 
            // Form1
            // 
            this.AcceptButton = this.runButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 718);
            this.Controls.Add(this.firstHistoryButton);
            this.Controls.Add(this.lastHistoryButton);
            this.Controls.Add(this.leftHistoryButton);
            this.Controls.Add(this.rightHistoryButton);
            this.Controls.Add(this.saveResultsButton);
            this.Controls.Add(this.deleteQueryButton);
            this.Controls.Add(this.saveQueryButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.wipeHistoryButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.connStrTextBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.connStrComboBox);
            this.Controls.Add(this.statusBar1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox connStrComboBox;
        private System.Windows.Forms.TextBox resultsTextbox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox connStrTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button wipeHistoryButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.Button saveQueryButton;
        private System.Windows.Forms.Button deleteQueryButton;
        private System.Windows.Forms.Button saveResultsButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private FastColoredTextBoxNS.FastColoredTextBox queryTextbox;
        private System.Windows.Forms.Button rightHistoryButton;
        private System.Windows.Forms.Button leftHistoryButton;
        private System.Windows.Forms.Button lastHistoryButton;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel historyPositionLabel;
        private System.Windows.Forms.Button firstHistoryButton;
    }
}

