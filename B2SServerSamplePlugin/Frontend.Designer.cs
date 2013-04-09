namespace B2SServerSamplePluginCSharp
{
    partial class Frontend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frontend));
            this.label1 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.DocuLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "B2S.Server Sample Plugin C#";
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CloseButton.Location = new System.Drawing.Point(0, 172);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(489, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Location = new System.Drawing.Point(16, 58);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(461, 23);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VersionLabel.Click += new System.EventHandler(this.VersionLabel_Click);
            // 
            // DocuLinkLabel
            // 
            this.DocuLinkLabel.AutoSize = true;
            this.DocuLinkLabel.Location = new System.Drawing.Point(78, 126);
            this.DocuLinkLabel.Name = "DocuLinkLabel";
            this.DocuLinkLabel.Size = new System.Drawing.Size(332, 13);
            this.DocuLinkLabel.TabIndex = 3;
            this.DocuLinkLabel.TabStop = true;
            this.DocuLinkLabel.Text = "Follow this link for the documention on the B2S.Server Sample Plugin";
            this.DocuLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DocuLinkLabel_LinkClicked);
            // 
            // Frontend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 195);
            this.Controls.Add(this.DocuLinkLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frontend";
            this.Text = "B2S.Server sample plugin C# frontend";
            this.Load += new System.EventHandler(this.Frontend_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.LinkLabel DocuLinkLabel;
    }
}