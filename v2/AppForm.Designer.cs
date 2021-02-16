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
            this.groundSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveQueryButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.queryAndResultsSplitContainer)).BeginInit();
            this.queryAndResultsSplitContainer.Panel1.SuspendLayout();
            this.queryAndResultsSplitContainer.SuspendLayout();
            this.groupsTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groundSplitContainer)).BeginInit();
            this.groundSplitContainer.Panel1.SuspendLayout();
            this.groundSplitContainer.Panel2.SuspendLayout();
            this.groundSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryAndResultsSplitContainer
            // 
            this.queryAndResultsSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.queryAndResultsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryAndResultsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.queryAndResultsSplitContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.queryAndResultsSplitContainer.Name = "queryAndResultsSplitContainer";
            this.queryAndResultsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // queryAndResultsSplitContainer.Panel1
            // 
            this.queryAndResultsSplitContainer.Panel1.Controls.Add(this.groupsTabControl);
            this.queryAndResultsSplitContainer.Size = new System.Drawing.Size(1090, 916);
            this.queryAndResultsSplitContainer.SplitterDistance = 518;
            this.queryAndResultsSplitContainer.SplitterWidth = 5;
            this.queryAndResultsSplitContainer.TabIndex = 0;
            // 
            // groupsTabControl
            // 
            this.groupsTabControl.Controls.Add(this.addNewTabPage);
            this.groupsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupsTabControl.ItemSize = new System.Drawing.Size(50, 18);
            this.groupsTabControl.Location = new System.Drawing.Point(0, 0);
            this.groupsTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupsTabControl.Name = "groupsTabControl";
            this.groupsTabControl.SelectedIndex = 0;
            this.groupsTabControl.Size = new System.Drawing.Size(1090, 518);
            this.groupsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.groupsTabControl.TabIndex = 0;
            // 
            // addNewTabPage
            // 
            this.addNewTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.addNewTabPage.Location = new System.Drawing.Point(4, 22);
            this.addNewTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addNewTabPage.Name = "addNewTabPage";
            this.addNewTabPage.Size = new System.Drawing.Size(1082, 492);
            this.addNewTabPage.TabIndex = 1;
            this.addNewTabPage.Text = "+";
            this.addNewTabPage.UseVisualStyleBackColor = true;
            // 
            // groundSplitContainer
            // 
            this.groundSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groundSplitContainer.Location = new System.Drawing.Point(0, 38);
            this.groundSplitContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groundSplitContainer.Name = "groundSplitContainer";
            // 
            // groundSplitContainer.Panel1
            // 
            this.groundSplitContainer.Panel1.Controls.Add(this.queryAndResultsSplitContainer);
            // 
            // groundSplitContainer.Panel2
            // 
            this.groundSplitContainer.Panel2.Controls.Add(this.comboBox1);
            this.groundSplitContainer.Size = new System.Drawing.Size(1363, 916);
            this.groundSplitContainer.SplitterDistance = 1090;
            this.groundSplitContainer.SplitterWidth = 5;
            this.groundSplitContainer.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveQueryButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1363, 38);
            this.panel1.TabIndex = 2;
            // 
            // saveQueryButton
            // 
            this.saveQueryButton.Location = new System.Drawing.Point(5, 6);
            this.saveQueryButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveQueryButton.Name = "saveQueryButton";
            this.saveQueryButton.Size = new System.Drawing.Size(100, 28);
            this.saveQueryButton.TabIndex = 0;
            this.saveQueryButton.Text = "Save";
            this.saveQueryButton.UseVisualStyleBackColor = true;
            this.saveQueryButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 954);
            this.Controls.Add(this.groundSplitContainer);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AppForm";
            this.Text = "AppForm";
            this.queryAndResultsSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queryAndResultsSplitContainer)).EndInit();
            this.queryAndResultsSplitContainer.ResumeLayout(false);
            this.groupsTabControl.ResumeLayout(false);
            this.groundSplitContainer.Panel1.ResumeLayout(false);
            this.groundSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groundSplitContainer)).EndInit();
            this.groundSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer queryAndResultsSplitContainer;
        private System.Windows.Forms.TabControl groupsTabControl;
        private System.Windows.Forms.SplitContainer groundSplitContainer;
        private System.Windows.Forms.TabPage addNewTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveQueryButton;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}