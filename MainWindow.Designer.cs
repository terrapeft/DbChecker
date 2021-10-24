
using BackofficeTools.Controls;

namespace BackofficeTools
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateInsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateFromValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snippetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.groupNamesComboBox = new System.Windows.Forms.ComboBox();
            this.connStrComboBox = new System.Windows.Forms.ComboBox();
            this.runButton = new System.Windows.Forms.Button();
            this.resultsGridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.queryAndResultsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.resultsBox = new BackofficeTools.Controls.ResultsBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.resultsGridContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryAndResultsSplitContainer)).BeginInit();
            this.queryAndResultsSplitContainer.Panel2.SuspendLayout();
            this.queryAndResultsSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.YellowGreen;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.snippetsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1379, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.saveAllToolStripMenuItem.Text = "&Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveResultsToolStripMenuItem,
            this.saveAllResultsToolStripMenuItem,
            this.generateInsertToolStripMenuItem,
            this.generateFromValuesToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // saveResultsToolStripMenuItem
            // 
            this.saveResultsToolStripMenuItem.Name = "saveResultsToolStripMenuItem";
            this.saveResultsToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.saveResultsToolStripMenuItem.Text = "Save Selected Result";
            this.saveResultsToolStripMenuItem.Click += new System.EventHandler(this.saveResultsToolStripMenuItem_Click);
            // 
            // saveAllResultsToolStripMenuItem
            // 
            this.saveAllResultsToolStripMenuItem.Name = "saveAllResultsToolStripMenuItem";
            this.saveAllResultsToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.saveAllResultsToolStripMenuItem.Text = "Save All Results";
            this.saveAllResultsToolStripMenuItem.Click += new System.EventHandler(this.saveAllResultsToolStripMenuItem_Click);
            // 
            // generateInsertToolStripMenuItem
            // 
            this.generateInsertToolStripMenuItem.Name = "generateInsertToolStripMenuItem";
            this.generateInsertToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.generateInsertToolStripMenuItem.Text = "Generate Insert";
            this.generateInsertToolStripMenuItem.Click += new System.EventHandler(this.generateInsertToolStripMenuItem_Click);
            // 
            // generateFromValuesToolStripMenuItem
            // 
            this.generateFromValuesToolStripMenuItem.Name = "generateFromValuesToolStripMenuItem";
            this.generateFromValuesToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.generateFromValuesToolStripMenuItem.Text = "Generate From Values";
            this.generateFromValuesToolStripMenuItem.Click += new System.EventHandler(this.generateFromValuesToolStripMenuItem_Click);
            // 
            // snippetsToolStripMenuItem
            // 
            this.snippetsToolStripMenuItem.Name = "snippetsToolStripMenuItem";
            this.snippetsToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.snippetsToolStripMenuItem.Text = "Snippets";
            // 
            // startLabel
            // 
            this.startLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(163, 833);
            this.startLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(71, 17);
            this.startLabel.TabIndex = 11;
            this.startLabel.Text = "startLabel";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(1244, 838);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 8;
            this.progressBar.Visible = false;
            // 
            // resultsLabel
            // 
            this.resultsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(15, 833);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(85, 17);
            this.resultsLabel.TabIndex = 10;
            this.resultsLabel.Text = "resultsLabel";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 835);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1379, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.valueTextBox);
            this.panel1.Controls.Add(this.groupNamesComboBox);
            this.panel1.Controls.Add(this.connStrComboBox);
            this.panel1.Controls.Add(this.runButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1379, 66);
            this.panel1.TabIndex = 13;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.ImageIndex = 0;
            this.saveButton.Location = new System.Drawing.Point(1124, 38);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(65, 25);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteButton.ImageIndex = 1;
            this.deleteButton.Location = new System.Drawing.Point(1197, 38);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(65, 25);
            this.deleteButton.TabIndex = 19;
            this.deleteButton.Text = "Del";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTextBox.Location = new System.Drawing.Point(4, 38);
            this.valueTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(1111, 22);
            this.valueTextBox.TabIndex = 17;
            this.valueTextBox.Enter += new System.EventHandler(this.valueTextBox_Enter);
            // 
            // groupNamesComboBox
            // 
            this.groupNamesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNamesComboBox.FormattingEnabled = true;
            this.groupNamesComboBox.Location = new System.Drawing.Point(931, 7);
            this.groupNamesComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupNamesComboBox.Name = "groupNamesComboBox";
            this.groupNamesComboBox.Size = new System.Drawing.Size(441, 24);
            this.groupNamesComboBox.TabIndex = 9;
            this.groupNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.groupNamesComboBox_SelectedIndexChanged);
            this.groupNamesComboBox.Enter += new System.EventHandler(this.groupNamesComboBox_Enter);
            this.groupNamesComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBox_KeyUp);
            // 
            // connStrComboBox
            // 
            this.connStrComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStrComboBox.FormattingEnabled = true;
            this.connStrComboBox.Location = new System.Drawing.Point(4, 7);
            this.connStrComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connStrComboBox.Name = "connStrComboBox";
            this.connStrComboBox.Size = new System.Drawing.Size(920, 24);
            this.connStrComboBox.TabIndex = 1;
            this.connStrComboBox.SelectedIndexChanged += new System.EventHandler(this.connStrComboBox_SelectedIndexChanged);
            this.connStrComboBox.Enter += new System.EventHandler(this.connStrComboBox_Enter);
            this.connStrComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBox_KeyUp);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.BackColor = System.Drawing.Color.YellowGreen;
            this.runButton.ImageIndex = 1;
            this.runButton.Location = new System.Drawing.Point(1272, 38);
            this.runButton.Margin = new System.Windows.Forms.Padding(5);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(101, 25);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // resultsGridContextMenuStrip
            // 
            this.resultsGridContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resultsGridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.resultsGridContextMenuStrip.Name = "resultsGridContextMenuStrip";
            this.resultsGridContextMenuStrip.Size = new System.Drawing.Size(154, 28);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.saveToolStripMenuItem.Text = "Save Result";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // queryAndResultsSplitContainer
            // 
            this.queryAndResultsSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.queryAndResultsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryAndResultsSplitContainer.Location = new System.Drawing.Point(0, 94);
            this.queryAndResultsSplitContainer.Margin = new System.Windows.Forms.Padding(4);
            this.queryAndResultsSplitContainer.Name = "queryAndResultsSplitContainer";
            this.queryAndResultsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // queryAndResultsSplitContainer.Panel2
            // 
            this.queryAndResultsSplitContainer.Panel2.Controls.Add(this.resultsBox);
            this.queryAndResultsSplitContainer.Size = new System.Drawing.Size(1379, 741);
            this.queryAndResultsSplitContainer.SplitterDistance = 344;
            this.queryAndResultsSplitContainer.SplitterWidth = 5;
            this.queryAndResultsSplitContainer.TabIndex = 14;
            // 
            // resultsBox
            // 
            this.resultsBox.ContextMenuStrip = this.resultsGridContextMenuStrip;
            this.resultsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsBox.Location = new System.Drawing.Point(0, 0);
            this.resultsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(1379, 392);
            this.resultsBox.TabIndex = 1;
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(292, 833);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(100, 17);
            this.messageLabel.TabIndex = 15;
            this.messageLabel.Text = "messageLabel";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 857);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.queryAndResultsSplitContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "Backoffice Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.resultsGridContextMenuStrip.ResumeLayout(false);
            this.queryAndResultsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queryAndResultsSplitContainer)).EndInit();
            this.queryAndResultsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateInsertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateFromValuesToolStripMenuItem;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox connStrComboBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.ComboBox groupNamesComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.ContextMenuStrip resultsGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer queryAndResultsSplitContainer;
        private System.Windows.Forms.Label messageLabel;
        private Controls.ResultsBox resultsBox;
        private System.Windows.Forms.ToolStripMenuItem snippetsToolStripMenuItem;
    }
}