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
            this.queryTextbox = new System.Windows.Forms.TextBox();
            this.resultsTextbox = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.connStrTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveResultsButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connStrComboBox
            // 
            this.connStrComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStrComboBox.FormattingEnabled = true;
            this.connStrComboBox.Location = new System.Drawing.Point(12, 12);
            this.connStrComboBox.Name = "connStrComboBox";
            this.connStrComboBox.Size = new System.Drawing.Size(791, 21);
            this.connStrComboBox.TabIndex = 0;
            this.connStrComboBox.SelectedIndexChanged += new System.EventHandler(this.connStrComboBox_SelectedIndexChanged);
            // 
            // queryTextbox
            // 
            this.queryTextbox.AcceptsReturn = true;
            this.queryTextbox.AcceptsTab = true;
            this.queryTextbox.AllowDrop = true;
            this.queryTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTextbox.Location = new System.Drawing.Point(0, 0);
            this.queryTextbox.MaxLength = 1048576;
            this.queryTextbox.Multiline = true;
            this.queryTextbox.Name = "queryTextbox";
            this.queryTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.queryTextbox.Size = new System.Drawing.Size(791, 207);
            this.queryTextbox.TabIndex = 2;
            this.queryTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.queryTextbox_KeyUp);
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
            this.runButton.Location = new System.Drawing.Point(809, 10);
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
            this.connStrTextBox.Size = new System.Drawing.Size(791, 48);
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
            this.splitContainer1.Size = new System.Drawing.Size(791, 545);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(791, 334);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.resultsDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(783, 308);
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
            this.resultsDataGridView.Size = new System.Drawing.Size(777, 302);
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
            this.saveButton.Location = new System.Drawing.Point(809, 37);
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
            this.wipeHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wipeHistoryButton.BackColor = System.Drawing.Color.Wheat;
            this.wipeHistoryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.wipeHistoryButton.Location = new System.Drawing.Point(809, 151);
            this.wipeHistoryButton.Name = "wipeHistoryButton";
            this.wipeHistoryButton.Size = new System.Drawing.Size(75, 23);
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
            this.deleteButton.Location = new System.Drawing.Point(809, 64);
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
            this.saveQueryButton.Location = new System.Drawing.Point(809, 93);
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
            this.deleteQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteQueryButton.BackColor = System.Drawing.Color.Wheat;
            this.deleteQueryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.deleteQueryButton.Location = new System.Drawing.Point(809, 122);
            this.deleteQueryButton.Name = "deleteQueryButton";
            this.deleteQueryButton.Size = new System.Drawing.Size(75, 23);
            this.deleteQueryButton.TabIndex = 12;
            this.deleteQueryButton.Text = "Delete query";
            this.toolTip1.SetToolTip(this.deleteQueryButton, "Delete query from history");
            this.deleteQueryButton.UseVisualStyleBackColor = false;
            this.deleteQueryButton.Click += new System.EventHandler(this.deleteQueryButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 637);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(787, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // saveResultsButton
            // 
            this.saveResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveResultsButton.BackColor = System.Drawing.Color.LightPink;
            this.saveResultsButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveResultsButton.Location = new System.Drawing.Point(805, 608);
            this.saveResultsButton.Name = "saveResultsButton";
            this.saveResultsButton.Size = new System.Drawing.Size(83, 23);
            this.saveResultsButton.TabIndex = 13;
            this.saveResultsButton.Text = "Save Results";
            this.toolTip1.SetToolTip(this.saveResultsButton, "Add or update connection string");
            this.saveResultsButton.UseVisualStyleBackColor = false;
            this.saveResultsButton.Click += new System.EventHandler(this.saveResultsButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.runButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 650);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Database Lookup";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox connStrComboBox;
        private System.Windows.Forms.TextBox queryTextbox;
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
    }
}

