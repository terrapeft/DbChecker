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
            this.groupsControl = new DbChecker.Controls.GroupControl();
            this.connStrComboBox = new System.Windows.Forms.ComboBox();
            this.itemEditor = new DbChecker.Controls.ItemEditor();
            this.runButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateInsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.queryAndResultsSplitContainer)).BeginInit();
            this.queryAndResultsSplitContainer.Panel1.SuspendLayout();
            this.queryAndResultsSplitContainer.Panel2.SuspendLayout();
            this.queryAndResultsSplitContainer.SuspendLayout();
            this.groupsTabControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryAndResultsSplitContainer
            // 
            this.queryAndResultsSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.queryAndResultsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryAndResultsSplitContainer.Location = new System.Drawing.Point(0, 97);
            this.queryAndResultsSplitContainer.Margin = new System.Windows.Forms.Padding(4);
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
            this.queryAndResultsSplitContainer.Size = new System.Drawing.Size(1173, 581);
            this.queryAndResultsSplitContainer.SplitterDistance = 292;
            this.queryAndResultsSplitContainer.SplitterWidth = 5;
            this.queryAndResultsSplitContainer.TabIndex = 0;
            // 
            // groupsTabControl
            // 
            this.groupsTabControl.Controls.Add(this.addNewTabPage);
            this.groupsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupsTabControl.ItemSize = new System.Drawing.Size(50, 18);
            this.groupsTabControl.Location = new System.Drawing.Point(0, 0);
            this.groupsTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.groupsTabControl.Name = "groupsTabControl";
            this.groupsTabControl.SelectedIndex = 0;
            this.groupsTabControl.Size = new System.Drawing.Size(1173, 292);
            this.groupsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.groupsTabControl.TabIndex = 0;
            // 
            // addNewTabPage
            // 
            this.addNewTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.addNewTabPage.Location = new System.Drawing.Point(4, 22);
            this.addNewTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.addNewTabPage.Name = "addNewTabPage";
            this.addNewTabPage.Size = new System.Drawing.Size(1165, 266);
            this.addNewTabPage.TabIndex = 1;
            this.addNewTabPage.Text = "+";
            this.addNewTabPage.UseVisualStyleBackColor = true;
            // 
            // resultsBox
            // 
            this.resultsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsBox.Location = new System.Drawing.Point(0, 0);
            this.resultsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(1173, 284);
            this.resultsBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupsControl);
            this.panel1.Controls.Add(this.connStrComboBox);
            this.panel1.Controls.Add(this.itemEditor);
            this.panel1.Controls.Add(this.runButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 69);
            this.panel1.TabIndex = 2;
            // 
            // groupsControl
            // 
            this.groupsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupsControl.Location = new System.Drawing.Point(556, 7);
            this.groupsControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupsControl.Name = "groupsControl";
            this.groupsControl.Size = new System.Drawing.Size(612, 26);
            this.groupsControl.TabIndex = 2;
            // 
            // connStrComboBox
            // 
            this.connStrComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStrComboBox.FormattingEnabled = true;
            this.connStrComboBox.Location = new System.Drawing.Point(4, 7);
            this.connStrComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connStrComboBox.Name = "connStrComboBox";
            this.connStrComboBox.Size = new System.Drawing.Size(545, 24);
            this.connStrComboBox.TabIndex = 1;
            this.connStrComboBox.SelectedIndexChanged += new System.EventHandler(this.connStrComboBox_SelectedIndexChanged);
            // 
            // itemEditor
            // 
            this.itemEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            editableItem1.Id = null;
            editableItem1.ItemType = DbChecker.ItemType.ConnectionString;
            editableItem1.Value = "";
            this.itemEditor.Item = editableItem1;
            this.itemEditor.Location = new System.Drawing.Point(0, 32);
            this.itemEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditor.Name = "itemEditor";
            this.itemEditor.Size = new System.Drawing.Size(1116, 36);
            this.itemEditor.TabIndex = 3;
            this.itemEditor.DeletingItem += new System.EventHandler<DbChecker.Models.EditableItem>(this.itemEditor_OnDelete);
            this.itemEditor.SavingItem += new System.EventHandler<DbChecker.Models.EditableItem>(this.itemEditor_OnSave);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.Image = global::DbChecker.Properties.Resources.iconfinder_database_run_103471;
            this.runButton.Location = new System.Drawing.Point(1132, 34);
            this.runButton.Margin = new System.Windows.Forms.Padding(5);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(37, 34);
            this.runButton.TabIndex = 7;
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1173, 28);
            this.menuStrip1.TabIndex = 3;
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
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveResultsToolStripMenuItem,
            this.saveAllResultsToolStripMenuItem,
            this.generateInsertToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // saveResultsToolStripMenuItem
            // 
            this.saveResultsToolStripMenuItem.Name = "saveResultsToolStripMenuItem";
            this.saveResultsToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.saveResultsToolStripMenuItem.Text = "Save Selected Result";
            this.saveResultsToolStripMenuItem.Click += new System.EventHandler(this.saveResultsToolStripMenuItem_Click);
            // 
            // saveAllResultsToolStripMenuItem
            // 
            this.saveAllResultsToolStripMenuItem.Name = "saveAllResultsToolStripMenuItem";
            this.saveAllResultsToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.saveAllResultsToolStripMenuItem.Text = "Save All Results";
            this.saveAllResultsToolStripMenuItem.Click += new System.EventHandler(this.saveAllResultsToolStripMenuItem_Click);
            // 
            // generateInsertToolStripMenuItem
            // 
            this.generateInsertToolStripMenuItem.Name = "generateInsertToolStripMenuItem";
            this.generateInsertToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.generateInsertToolStripMenuItem.Text = "Generate Insert";
            this.generateInsertToolStripMenuItem.Click += new System.EventHandler(this.generateInsertToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordWrapToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.wordWrapToolStripMenuItem.Text = "Word Wrap";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1173, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // resultsLabel
            // 
            this.resultsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(12, 681);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(0, 17);
            this.resultsLabel.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(1051, 684);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 700);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.queryAndResultsSplitContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private ItemEditor itemEditor;
        private ResultsBox resultsBox;
        private System.Windows.Forms.ToolStripMenuItem saveAllResultsToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}