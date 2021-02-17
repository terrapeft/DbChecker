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
            this.queryAndResultsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupsTabControl = new System.Windows.Forms.TabControl();
            this.addNewTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recycleButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.connStrTextBox = new System.Windows.Forms.TextBox();
            this.connStrComboBox = new System.Windows.Forms.ComboBox();
            this.saveQueryButton = new System.Windows.Forms.Button();
            this.resultsBox = new DbChecker.Controls.ResultsBox();
            this.groupsControl = new DbChecker.Controls.GroupsControl();
            ((System.ComponentModel.ISupportInitialize)(this.queryAndResultsSplitContainer)).BeginInit();
            this.queryAndResultsSplitContainer.Panel1.SuspendLayout();
            this.queryAndResultsSplitContainer.Panel2.SuspendLayout();
            this.queryAndResultsSplitContainer.SuspendLayout();
            this.groupsTabControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryAndResultsSplitContainer
            // 
            this.queryAndResultsSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.queryAndResultsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryAndResultsSplitContainer.Location = new System.Drawing.Point(0, 69);
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
            this.queryAndResultsSplitContainer.Size = new System.Drawing.Size(1173, 668);
            this.queryAndResultsSplitContainer.SplitterDistance = 340;
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
            this.groupsTabControl.Size = new System.Drawing.Size(1173, 340);
            this.groupsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.groupsTabControl.TabIndex = 0;
            // 
            // addNewTabPage
            // 
            this.addNewTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.addNewTabPage.Location = new System.Drawing.Point(4, 22);
            this.addNewTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.addNewTabPage.Name = "addNewTabPage";
            this.addNewTabPage.Size = new System.Drawing.Size(1165, 314);
            this.addNewTabPage.TabIndex = 1;
            this.addNewTabPage.Text = "+";
            this.addNewTabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.recycleButton);
            this.panel1.Controls.Add(this.runButton);
            this.panel1.Controls.Add(this.groupsControl);
            this.panel1.Controls.Add(this.connStrTextBox);
            this.panel1.Controls.Add(this.connStrComboBox);
            this.panel1.Controls.Add(this.saveQueryButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 69);
            this.panel1.TabIndex = 2;
            // 
            // recycleButton
            // 
            this.recycleButton.Location = new System.Drawing.Point(847, 4);
            this.recycleButton.Margin = new System.Windows.Forms.Padding(4);
            this.recycleButton.Name = "recycleButton";
            this.recycleButton.Size = new System.Drawing.Size(100, 28);
            this.recycleButton.TabIndex = 8;
            this.recycleButton.Text = "Recycle";
            this.recycleButton.UseVisualStyleBackColor = true;
            this.recycleButton.Click += new System.EventHandler(this.recycleButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(379, 4);
            this.runButton.Margin = new System.Windows.Forms.Padding(4);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(100, 28);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // connStrTextBox
            // 
            this.connStrTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStrTextBox.Location = new System.Drawing.Point(4, 37);
            this.connStrTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.connStrTextBox.Name = "connStrTextBox";
            this.connStrTextBox.Size = new System.Drawing.Size(1165, 22);
            this.connStrTextBox.TabIndex = 6;
            // 
            // connStrComboBox
            // 
            this.connStrComboBox.FormattingEnabled = true;
            this.connStrComboBox.Location = new System.Drawing.Point(4, 6);
            this.connStrComboBox.Name = "connStrComboBox";
            this.connStrComboBox.Size = new System.Drawing.Size(368, 24);
            this.connStrComboBox.TabIndex = 1;
            this.connStrComboBox.SelectedIndexChanged += new System.EventHandler(this.connStrComboBox_SelectedIndexChanged);
            // 
            // saveQueryButton
            // 
            this.saveQueryButton.Location = new System.Drawing.Point(487, 4);
            this.saveQueryButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveQueryButton.Name = "saveQueryButton";
            this.saveQueryButton.Size = new System.Drawing.Size(100, 28);
            this.saveQueryButton.TabIndex = 0;
            this.saveQueryButton.Text = "Save";
            this.saveQueryButton.UseVisualStyleBackColor = true;
            this.saveQueryButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // resultsBox
            // 
            this.resultsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsBox.Location = new System.Drawing.Point(0, 0);
            this.resultsBox.Messages = null;
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(1173, 323);
            this.resultsBox.TabIndex = 0;
            // 
            // groupsControl
            // 
            this.groupsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupsControl.Location = new System.Drawing.Point(954, 7);
            this.groupsControl.Name = "groupsControl";
            this.groupsControl.Size = new System.Drawing.Size(215, 26);
            this.groupsControl.TabIndex = 0;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 737);
            this.Controls.Add(this.queryAndResultsSplitContainer);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AppForm";
            this.Text = "AppForm";
            this.queryAndResultsSplitContainer.Panel1.ResumeLayout(false);
            this.queryAndResultsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queryAndResultsSplitContainer)).EndInit();
            this.queryAndResultsSplitContainer.ResumeLayout(false);
            this.groupsTabControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer queryAndResultsSplitContainer;
        private System.Windows.Forms.TabControl groupsTabControl;
        private System.Windows.Forms.TabPage addNewTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveQueryButton;
        private System.Windows.Forms.ComboBox connStrComboBox;
        private System.Windows.Forms.TextBox connStrTextBox;
        private GroupsControl groupsControl;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button recycleButton;
        private ResultsBox resultsBox;
    }
}