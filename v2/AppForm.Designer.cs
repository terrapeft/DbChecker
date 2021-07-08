using DbChecker.Controls;

namespace DbChecker
{
    partial class AppForm
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
            DbChecker.Models.EditableItem editableItem1 = new DbChecker.Models.EditableItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.queryAndResultsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupsTabControl = new System.Windows.Forms.TabControl();
            this.addNewTabPage = new System.Windows.Forms.TabPage();
            this.resultsBox = new DbChecker.Controls.ResultsBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemEditor = new DbChecker.Controls.ItemEditor();
            this.groupsControl = new DbChecker.Controls.GroupControl();
            this.connStrComboBox = new System.Windows.Forms.ComboBox();
            this.runButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateInsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateFromValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.startLabel = new System.Windows.Forms.Label();
            this.resultsGridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.queryAndResultsSplitContainer)).BeginInit();
            this.queryAndResultsSplitContainer.Panel1.SuspendLayout();
            this.queryAndResultsSplitContainer.Panel2.SuspendLayout();
            this.queryAndResultsSplitContainer.SuspendLayout();
            this.groupsTabControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.resultsGridContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryAndResultsSplitContainer
            // 
            this.queryAndResultsSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.queryAndResultsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryAndResultsSplitContainer.Location = new System.Drawing.Point(0, 78);
            this.queryAndResultsSplitContainer.Name = "queryAndResultsSplitContainer";
            this.queryAndResultsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // queryAndResultsSplitContainer.Panel1
            // 
            this.queryAndResultsSplitContainer.Panel1.Controls.Add(this.groupsTabControl);
            // 
            // queryAndResultsSplitContainer.Panel2
            // 
            this.queryAndResultsSplitContainer.Panel2.Controls.Add(this.resultsBox);
            this.queryAndResultsSplitContainer.Size = new System.Drawing.Size(880, 469);
            this.queryAndResultsSplitContainer.SplitterDistance = 234;
            this.queryAndResultsSplitContainer.TabIndex = 0;
            // 
            // groupsTabControl
            // 
            this.groupsTabControl.Controls.Add(this.addNewTabPage);
            this.groupsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupsTabControl.ItemSize = new System.Drawing.Size(50, 18);
            this.groupsTabControl.Location = new System.Drawing.Point(0, 0);
            this.groupsTabControl.Name = "groupsTabControl";
            this.groupsTabControl.SelectedIndex = 0;
            this.groupsTabControl.Size = new System.Drawing.Size(880, 234);
            this.groupsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.groupsTabControl.TabIndex = 0;
            // 
            // addNewTabPage
            // 
            this.addNewTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.addNewTabPage.Location = new System.Drawing.Point(4, 22);
            this.addNewTabPage.Name = "addNewTabPage";
            this.addNewTabPage.Size = new System.Drawing.Size(872, 208);
            this.addNewTabPage.TabIndex = 1;
            this.addNewTabPage.Text = "+";
            this.addNewTabPage.UseVisualStyleBackColor = true;
            // 
            // resultsBox
            // 
            this.resultsBox.ContextMenuStrip = this.resultsGridContextMenuStrip;
            this.resultsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsBox.Location = new System.Drawing.Point(0, 0);
            this.resultsBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(880, 231);
            this.resultsBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.itemEditor);
            this.panel1.Controls.Add(this.groupsControl);
            this.panel1.Controls.Add(this.connStrComboBox);
            this.panel1.Controls.Add(this.runButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 54);
            this.panel1.TabIndex = 2;
            // 
            // itemEditor
            // 
            this.itemEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            editableItem1.Id = null;
            editableItem1.ItemType = DbChecker.ItemType.ConnectionString;
            editableItem1.Value = "";
            this.itemEditor.Item = editableItem1;
            this.itemEditor.Location = new System.Drawing.Point(3, 31);
            this.itemEditor.Margin = new System.Windows.Forms.Padding(2);
            this.itemEditor.Name = "itemEditor";
            this.itemEditor.Size = new System.Drawing.Size(791, 20);
            this.itemEditor.TabIndex = 8;
            this.itemEditor.DeletingItem += new System.EventHandler<DbChecker.Models.EditableItem>(this.itemEditor_OnDelete);
            this.itemEditor.SavingItem += new System.EventHandler<DbChecker.Models.EditableItem>(this.itemEditor_OnSave);
            // 
            // groupsControl
            // 
            this.groupsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupsControl.Location = new System.Drawing.Point(417, 6);
            this.groupsControl.Margin = new System.Windows.Forms.Padding(2);
            this.groupsControl.Name = "groupsControl";
            this.groupsControl.Size = new System.Drawing.Size(459, 21);
            this.groupsControl.TabIndex = 2;
            // 
            // connStrComboBox
            // 
            this.connStrComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStrComboBox.FormattingEnabled = true;
            this.connStrComboBox.Location = new System.Drawing.Point(3, 6);
            this.connStrComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.connStrComboBox.Name = "connStrComboBox";
            this.connStrComboBox.Size = new System.Drawing.Size(410, 21);
            this.connStrComboBox.TabIndex = 1;
            this.connStrComboBox.SelectedIndexChanged += new System.EventHandler(this.connStrComboBox_SelectedIndexChanged);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.BackColor = System.Drawing.Color.LightGreen;
            this.runButton.ImageIndex = 1;
            this.runButton.Location = new System.Drawing.Point(800, 31);
            this.runButton.Margin = new System.Windows.Forms.Padding(4);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(76, 20);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGreen;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.saveAllToolStripMenuItem.Text = "&Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveResultsToolStripMenuItem,
            this.saveAllResultsToolStripMenuItem,
            this.generateInsertToolStripMenuItem,
            this.generateFromValuesToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // saveResultsToolStripMenuItem
            // 
            this.saveResultsToolStripMenuItem.Name = "saveResultsToolStripMenuItem";
            this.saveResultsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveResultsToolStripMenuItem.Text = "Save Selected Result";
            this.saveResultsToolStripMenuItem.Click += new System.EventHandler(this.saveResultsToolStripMenuItem_Click);
            // 
            // saveAllResultsToolStripMenuItem
            // 
            this.saveAllResultsToolStripMenuItem.Name = "saveAllResultsToolStripMenuItem";
            this.saveAllResultsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveAllResultsToolStripMenuItem.Text = "Save All Results";
            this.saveAllResultsToolStripMenuItem.Click += new System.EventHandler(this.saveAllResultsToolStripMenuItem_Click);
            // 
            // generateInsertToolStripMenuItem
            // 
            this.generateInsertToolStripMenuItem.Name = "generateInsertToolStripMenuItem";
            this.generateInsertToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.generateInsertToolStripMenuItem.Text = "Generate Insert";
            this.generateInsertToolStripMenuItem.Click += new System.EventHandler(this.generateInsertToolStripMenuItem_Click);
            // 
            // generateFromValuesToolStripMenuItem
            // 
            this.generateFromValuesToolStripMenuItem.Name = "generateFromValuesToolStripMenuItem";
            this.generateFromValuesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.generateFromValuesToolStripMenuItem.Text = "Generate From Values";
            this.generateFromValuesToolStripMenuItem.Click += new System.EventHandler(this.generateFromValuesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordWrapToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.CheckOnClick = true;
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.wordWrapToolStripMenuItem.Text = "Word Wrap";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(880, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // resultsLabel
            // 
            this.resultsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(9, 553);
            this.resultsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(63, 13);
            this.resultsLabel.TabIndex = 5;
            this.resultsLabel.Text = "resultsLabel";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(788, 556);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(75, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // startLabel
            // 
            this.startLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(153, 553);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(53, 13);
            this.startLabel.TabIndex = 6;
            this.startLabel.Text = "startLabel";
            // 
            // resultsGridContextMenuStrip
            // 
            this.resultsGridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.resultsGridContextMenuStrip.Name = "resultsGridContextMenuStrip";
            this.resultsGridContextMenuStrip.Size = new System.Drawing.Size(181, 48);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save Result";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveResultsToolStripMenuItem_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 569);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.queryAndResultsSplitContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "AppForm";
            this.Text = "DB Helper 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppForm_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AppForm_KeyUp);
            this.queryAndResultsSplitContainer.Panel1.ResumeLayout(false);
            this.queryAndResultsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queryAndResultsSplitContainer)).EndInit();
            this.queryAndResultsSplitContainer.ResumeLayout(false);
            this.groupsTabControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.resultsGridContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer queryAndResultsSplitContainer;
        private System.Windows.Forms.TabControl groupsTabControl;
        private System.Windows.Forms.TabPage addNewTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox connStrComboBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateInsertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private GroupControl groupsControl;
        private ResultsBox resultsBox;
        private System.Windows.Forms.ToolStripMenuItem saveAllResultsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private ItemEditor itemEditor;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.ToolStripMenuItem generateFromValuesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip resultsGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}