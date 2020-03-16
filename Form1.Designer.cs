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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.wipeHistoryButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.queryTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryTextbox.Location = new System.Drawing.Point(0, 0);
            this.queryTextbox.MaxLength = 1048576;
            this.queryTextbox.Multiline = true;
            this.queryTextbox.Name = "queryTextbox";
            this.queryTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.queryTextbox.Size = new System.Drawing.Size(872, 191);
            this.queryTextbox.TabIndex = 2;
            this.queryTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.queryTextbox_KeyUp);
            // 
            // resultsTextbox
            // 
            this.resultsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsTextbox.Location = new System.Drawing.Point(0, 3);
            this.resultsTextbox.Multiline = true;
            this.resultsTextbox.Name = "resultsTextbox";
            this.resultsTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextbox.Size = new System.Drawing.Size(872, 300);
            this.resultsTextbox.TabIndex = 3;
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.runButton.Location = new System.Drawing.Point(809, 10);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Run";
            this.toolTip1.SetToolTip(this.runButton, "Run the query");
            this.runButton.UseVisualStyleBackColor = true;
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
            this.connStrTextBox.Size = new System.Drawing.Size(791, 77);
            this.connStrTextBox.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 141);
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
            this.splitContainer1.Panel2.Controls.Add(this.resultsTextbox);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(872, 497);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(788, 122);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Save to history";
            this.toolTip1.SetToolTip(this.checkBox1, "Navigate using Alt + Arrow (Left and Right)");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(809, 37);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.toolTip1.SetToolTip(this.saveButton, "Add or update connection string");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // wipeHistoryButton
            // 
            this.wipeHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wipeHistoryButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.wipeHistoryButton.Location = new System.Drawing.Point(809, 93);
            this.wipeHistoryButton.Name = "wipeHistoryButton";
            this.wipeHistoryButton.Size = new System.Drawing.Size(75, 23);
            this.wipeHistoryButton.TabIndex = 9;
            this.wipeHistoryButton.Text = "Wipe history";
            this.toolTip1.SetToolTip(this.wipeHistoryButton, "Delete history from file");
            this.wipeHistoryButton.UseVisualStyleBackColor = true;
            this.wipeHistoryButton.Click += new System.EventHandler(this.wipeHistoryButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.deleteButton.Location = new System.Drawing.Point(809, 64);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Delete";
            this.toolTip1.SetToolTip(this.deleteButton, "Delete connection string except those from machine.config");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 122);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(770, 13);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.runButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 650);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.wipeHistoryButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.connStrTextBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.connStrComboBox);
            this.Controls.Add(this.checkBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DbChecker";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button wipeHistoryButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

