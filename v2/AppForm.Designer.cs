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
            DbChecker.Models.EditableItem editableItem1 = new DbChecker.Models.EditableItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.queryAndResultsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupsTabControl = new System.Windows.Forms.TabControl();
            this.addNewTabPage = new System.Windows.Forms.TabPage();
            this.resultsBox = new DbChecker.Controls.ResultsBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupsControl = new DbChecker.Controls.GroupsControl();
            this.connStrComboBox = new System.Windows.Forms.ComboBox();
            this.itemEditor = new DbChecker.Controls.ItemEditor();
            this.runButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateInsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.queryAndResultsSplitContainer.Location = new System.Drawing.Point(0, 80);
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
            this.queryAndResultsSplitContainer.Size = new System.Drawing.Size(880, 489);
            this.queryAndResultsSplitContainer.SplitterDistance = 247;
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
            this.groupsTabControl.Size = new System.Drawing.Size(880, 247);
            this.groupsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.groupsTabControl.TabIndex = 0;
            // 
            // addNewTabPage
            // 
            this.addNewTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.addNewTabPage.Location = new System.Drawing.Point(4, 22);
            this.addNewTabPage.Name = "addNewTabPage";
            this.addNewTabPage.Size = new System.Drawing.Size(872, 221);
            this.addNewTabPage.TabIndex = 1;
            this.addNewTabPage.Text = "+";
            this.addNewTabPage.UseVisualStyleBackColor = true;
            // 
            // resultsBox
            // 
            this.resultsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsBox.Location = new System.Drawing.Point(0, 0);
            this.resultsBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(880, 238);
            this.resultsBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupsControl);
            this.panel1.Controls.Add(this.connStrComboBox);
            this.panel1.Controls.Add(this.itemEditor);
            this.panel1.Controls.Add(this.runButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 56);
            this.panel1.TabIndex = 2;
            // 
            // groupsControl
            // 
            this.groupsControl.Location = new System.Drawing.Point(417, 6);
            this.groupsControl.Margin = new System.Windows.Forms.Padding(2);
            this.groupsControl.Name = "groupsControl";
            this.groupsControl.Size = new System.Drawing.Size(459, 21);
            this.groupsControl.TabIndex = 2;
            // 
            // connStrComboBox
            // 
            this.connStrComboBox.FormattingEnabled = true;
            this.connStrComboBox.Location = new System.Drawing.Point(3, 6);
            this.connStrComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.connStrComboBox.Name = "connStrComboBox";
            this.connStrComboBox.Size = new System.Drawing.Size(410, 21);
            this.connStrComboBox.TabIndex = 1;
            this.connStrComboBox.SelectedIndexChanged += new System.EventHandler(this.connStrComboBox_SelectedIndexChanged);
            // 
            // itemEditor
            // 
            editableItem1.ItemType = DbChecker.ItemType.ConnectionString;
            editableItem1.Name = null;
            editableItem1.Value = "";
            this.itemEditor.Item = editableItem1;
            this.itemEditor.Location = new System.Drawing.Point(0, 26);
            this.itemEditor.Margin = new System.Windows.Forms.Padding(2);
            this.itemEditor.Name = "itemEditor";
            this.itemEditor.Size = new System.Drawing.Size(837, 29);
            this.itemEditor.TabIndex = 3;
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.Image = global::DbChecker.Properties.Resources.iconfinder_database_run_103471;
            this.runButton.Location = new System.Drawing.Point(849, 28);
            this.runButton.Margin = new System.Windows.Forms.Padding(4);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(28, 28);
            this.runButton.TabIndex = 7;
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.scriptToolStripMenuItem,
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
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.removeSelectedToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveToolStripMenuItem.Text = "Save Selected";
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedToolStripMenuItem2,
            this.saveGroupToolStripMenuItem});
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.groupToolStripMenuItem.Text = "Group";
            // 
            // removeSelectedToolStripMenuItem2
            // 
            this.removeSelectedToolStripMenuItem2.Name = "removeSelectedToolStripMenuItem2";
            this.removeSelectedToolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.removeSelectedToolStripMenuItem2.Text = "Remove Selected";
            // 
            // saveGroupToolStripMenuItem
            // 
            this.saveGroupToolStripMenuItem.Name = "saveGroupToolStripMenuItem";
            this.saveGroupToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveGroupToolStripMenuItem.Text = "Save Group";
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedToolStripMenuItem1});
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.scriptToolStripMenuItem.Text = "Script";
            // 
            // removeSelectedToolStripMenuItem1
            // 
            this.removeSelectedToolStripMenuItem1.Name = "removeSelectedToolStripMenuItem1";
            this.removeSelectedToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.removeSelectedToolStripMenuItem1.Text = "Remove Selected";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveResultsToolStripMenuItem,
            this.generateInsertToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // saveResultsToolStripMenuItem
            // 
            this.saveResultsToolStripMenuItem.Name = "saveResultsToolStripMenuItem";
            this.saveResultsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveResultsToolStripMenuItem.Text = "Save Results";
            // 
            // generateInsertToolStripMenuItem
            // 
            this.generateInsertToolStripMenuItem.Name = "generateInsertToolStripMenuItem";
            this.generateInsertToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.generateInsertToolStripMenuItem.Text = "Generate Insert";
            this.generateInsertToolStripMenuItem.Click += new System.EventHandler(this.generateInsertToolStripMenuItem_Click);
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
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.wordWrapToolStripMenuItem.Text = "Word Wrap";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 569);
            this.Controls.Add(this.queryAndResultsSplitContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
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
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateInsertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveGroupToolStripMenuItem;
        private GroupsControl groupsControl;
        private ItemEditor itemEditor;
        private ResultsBox resultsBox;
    }
}