namespace PicIN
{
    partial class ThumbnailControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.thumbnailPictureBox = new System.Windows.Forms.PictureBox();
            this.thumbnailLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // thumbnailPictureBox
            // 
            this.thumbnailPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailPictureBox.Location = new System.Drawing.Point(3, 3);
            this.thumbnailPictureBox.Name = "thumbnailPictureBox";
            this.thumbnailPictureBox.Padding = new System.Windows.Forms.Padding(6);
            this.thumbnailPictureBox.Size = new System.Drawing.Size(144, 97);
            this.thumbnailPictureBox.TabIndex = 0;
            this.thumbnailPictureBox.TabStop = false;
            this.thumbnailPictureBox.DoubleClick += new System.EventHandler(this.thumbnailPictureBox_DoubleClick);
            // 
            // thumbnailLabel
            // 
            this.thumbnailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailLabel.AutoEllipsis = true;
            this.thumbnailLabel.AutoSize = true;
            this.thumbnailLabel.Location = new System.Drawing.Point(3, 103);
            this.thumbnailLabel.Name = "thumbnailLabel";
            this.thumbnailLabel.Size = new System.Drawing.Size(0, 17);
            this.thumbnailLabel.TabIndex = 1;
            this.thumbnailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThumbnailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.thumbnailLabel);
            this.Controls.Add(this.thumbnailPictureBox);
            this.Name = "ThumbnailControl";
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbnailPictureBox;
        private System.Windows.Forms.Label thumbnailLabel;
    }
}
