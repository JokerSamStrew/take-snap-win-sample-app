namespace TakeWebCamSnapshotForge
{
    partial class Form
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.button = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.listBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.actionPanel);
            this.splitContainer.Panel1.Controls.Add(this.panel);
            this.splitContainer.Size = new System.Drawing.Size(1010, 455);
            this.splitContainer.SplitterDistance = 286;
            this.splitContainer.TabIndex = 0;
            // 
            // actionPanel
            // 
            this.actionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.actionPanel.Controls.Add(this.listBox);
            this.actionPanel.Controls.Add(this.button);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionPanel.Location = new System.Drawing.Point(0, 0);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Padding = new System.Windows.Forms.Padding(10);
            this.actionPanel.Size = new System.Drawing.Size(286, 263);
            this.actionPanel.TabIndex = 1;
            // 
            // button
            // 
            this.button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button.Dock = System.Windows.Forms.DockStyle.Top;
            this.button.Location = new System.Drawing.Point(10, 10);
            this.button.Margin = new System.Windows.Forms.Padding(0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(266, 41);
            this.button.TabIndex = 1;
            this.button.Text = "make snap";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // panel
            // 
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 263);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(286, 192);
            this.panel.TabIndex = 0;
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(10, 145);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(266, 108);
            this.listBox.TabIndex = 2;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 455);
            this.Controls.Add(this.splitContainer);
            this.Name = "Form";
            this.Text = "TakeWebCamSnapshot - AForge";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.ListBox listBox;
    }
}

