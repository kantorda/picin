namespace PicIN
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
            this.mFolderSelectButton = new System.Windows.Forms.Button();
            this.mMainColorsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.mSearchButton = new System.Windows.Forms.Button();
            this.mClearButton = new System.Windows.Forms.Button();
            this.mMainLabel = new System.Windows.Forms.Label();
            this.mSecondaryColorsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.mSecondaryLabel = new System.Windows.Forms.Label();
            this.mLuminocityCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.mLuminictyLabel = new System.Windows.Forms.Label();
            this.mComplexityCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.mComplexityLabel = new System.Windows.Forms.Label();
            this.mSearchTypeLabel = new System.Windows.Forms.Label();
            this.mAndRadioButton = new System.Windows.Forms.RadioButton();
            this.mOrRadioButton = new System.Windows.Forms.RadioButton();
            this.mFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // mFolderSelectButton
            // 
            this.mFolderSelectButton.Location = new System.Drawing.Point(1048, 918);
            this.mFolderSelectButton.Name = "mFolderSelectButton";
            this.mFolderSelectButton.Size = new System.Drawing.Size(122, 23);
            this.mFolderSelectButton.TabIndex = 1;
            this.mFolderSelectButton.Text = "Open Folder";
            this.mFolderSelectButton.UseVisualStyleBackColor = true;
            this.mFolderSelectButton.Click += new System.EventHandler(this.FolderSelectButton_Click);
            // 
            // mMainColorsCheckedListBox
            // 
            this.mMainColorsCheckedListBox.CheckOnClick = true;
            this.mMainColorsCheckedListBox.FormattingEnabled = true;
            this.mMainColorsCheckedListBox.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "Green",
            "Cyan",
            "Purple",
            "Yellow",
            "Black",
            "White",
            "Gray"});
            this.mMainColorsCheckedListBox.Location = new System.Drawing.Point(12, 33);
            this.mMainColorsCheckedListBox.Name = "mMainColorsCheckedListBox";
            this.mMainColorsCheckedListBox.Size = new System.Drawing.Size(102, 174);
            this.mMainColorsCheckedListBox.TabIndex = 3;
            // 
            // mSearchButton
            // 
            this.mSearchButton.Location = new System.Drawing.Point(1014, 184);
            this.mSearchButton.Name = "mSearchButton";
            this.mSearchButton.Size = new System.Drawing.Size(75, 23);
            this.mSearchButton.TabIndex = 4;
            this.mSearchButton.Text = "Search";
            this.mSearchButton.UseVisualStyleBackColor = true;
            this.mSearchButton.Click += new System.EventHandler(this.SearchButton_click);
            // 
            // mClearButton
            // 
            this.mClearButton.Location = new System.Drawing.Point(1095, 184);
            this.mClearButton.Name = "mClearButton";
            this.mClearButton.Size = new System.Drawing.Size(75, 23);
            this.mClearButton.TabIndex = 5;
            this.mClearButton.Text = "Clear";
            this.mClearButton.UseVisualStyleBackColor = true;
            this.mClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // mMainLabel
            // 
            this.mMainLabel.AutoSize = true;
            this.mMainLabel.Location = new System.Drawing.Point(12, 12);
            this.mMainLabel.Name = "mMainLabel";
            this.mMainLabel.Size = new System.Drawing.Size(38, 17);
            this.mMainLabel.TabIndex = 6;
            this.mMainLabel.Text = "Main";
            // 
            // mSecondaryColorsCheckedListBox
            // 
            this.mSecondaryColorsCheckedListBox.CheckOnClick = true;
            this.mSecondaryColorsCheckedListBox.FormattingEnabled = true;
            this.mSecondaryColorsCheckedListBox.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "Green",
            "Cyan",
            "Purple",
            "Yellow",
            "Black",
            "White",
            "Gray"});
            this.mSecondaryColorsCheckedListBox.Location = new System.Drawing.Point(120, 33);
            this.mSecondaryColorsCheckedListBox.Name = "mSecondaryColorsCheckedListBox";
            this.mSecondaryColorsCheckedListBox.Size = new System.Drawing.Size(102, 174);
            this.mSecondaryColorsCheckedListBox.TabIndex = 7;
            // 
            // mSecondaryLabel
            // 
            this.mSecondaryLabel.AutoSize = true;
            this.mSecondaryLabel.Location = new System.Drawing.Point(117, 12);
            this.mSecondaryLabel.Name = "mSecondaryLabel";
            this.mSecondaryLabel.Size = new System.Drawing.Size(76, 17);
            this.mSecondaryLabel.TabIndex = 8;
            this.mSecondaryLabel.Text = "Secondary";
            // 
            // mLuminocityCheckedListBox
            // 
            this.mLuminocityCheckedListBox.FormattingEnabled = true;
            this.mLuminocityCheckedListBox.Items.AddRange(new object[] {
            "Bright",
            "Neutral",
            "Dark"});
            this.mLuminocityCheckedListBox.Location = new System.Drawing.Point(229, 33);
            this.mLuminocityCheckedListBox.Name = "mLuminocityCheckedListBox";
            this.mLuminocityCheckedListBox.Size = new System.Drawing.Size(102, 89);
            this.mLuminocityCheckedListBox.TabIndex = 9;
            // 
            // mLuminictyLabel
            // 
            this.mLuminictyLabel.AutoSize = true;
            this.mLuminictyLabel.Location = new System.Drawing.Point(229, 12);
            this.mLuminictyLabel.Name = "mLuminictyLabel";
            this.mLuminictyLabel.Size = new System.Drawing.Size(75, 17);
            this.mLuminictyLabel.TabIndex = 10;
            this.mLuminictyLabel.Text = "Luminocity";
            // 
            // mComplexityCheckedListBox
            // 
            this.mComplexityCheckedListBox.FormattingEnabled = true;
            this.mComplexityCheckedListBox.Items.AddRange(new object[] {
            "Simple",
            "Medium",
            "Complex"});
            this.mComplexityCheckedListBox.Location = new System.Drawing.Point(340, 33);
            this.mComplexityCheckedListBox.Name = "mComplexityCheckedListBox";
            this.mComplexityCheckedListBox.Size = new System.Drawing.Size(102, 89);
            this.mComplexityCheckedListBox.TabIndex = 11;
            // 
            // mComplexityLabel
            // 
            this.mComplexityLabel.AutoSize = true;
            this.mComplexityLabel.Location = new System.Drawing.Point(337, 12);
            this.mComplexityLabel.Name = "mComplexityLabel";
            this.mComplexityLabel.Size = new System.Drawing.Size(75, 17);
            this.mComplexityLabel.TabIndex = 12;
            this.mComplexityLabel.Text = "Complexity";
            // 
            // mSearchTypeLabel
            // 
            this.mSearchTypeLabel.AutoSize = true;
            this.mSearchTypeLabel.Location = new System.Drawing.Point(232, 129);
            this.mSearchTypeLabel.Name = "mSearchTypeLabel";
            this.mSearchTypeLabel.Size = new System.Drawing.Size(159, 17);
            this.mSearchTypeLabel.TabIndex = 13;
            this.mSearchTypeLabel.Text = "Main Color Search Style";
            // 
            // mAndRadioButton
            // 
            this.mAndRadioButton.AutoSize = true;
            this.mAndRadioButton.Location = new System.Drawing.Point(229, 150);
            this.mAndRadioButton.Name = "mAndRadioButton";
            this.mAndRadioButton.Size = new System.Drawing.Size(54, 21);
            this.mAndRadioButton.TabIndex = 14;
            this.mAndRadioButton.TabStop = true;
            this.mAndRadioButton.Text = "And";
            this.mAndRadioButton.UseVisualStyleBackColor = true;
            this.mAndRadioButton.CheckedChanged += new System.EventHandler(this.MAndRadioButton_CheckedChanged);
            // 
            // mOrRadioButton
            // 
            this.mOrRadioButton.AutoSize = true;
            this.mOrRadioButton.Checked = true;
            this.mOrRadioButton.Location = new System.Drawing.Point(303, 150);
            this.mOrRadioButton.Name = "mOrRadioButton";
            this.mOrRadioButton.Size = new System.Drawing.Size(45, 21);
            this.mOrRadioButton.TabIndex = 15;
            this.mOrRadioButton.TabStop = true;
            this.mOrRadioButton.Text = "Or";
            this.mOrRadioButton.UseVisualStyleBackColor = true;
            this.mOrRadioButton.CheckedChanged += new System.EventHandler(this.MOrRadioButton_CheckedChanged);
            // 
            // mFlowLayoutPanel
            // 
            this.mFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mFlowLayoutPanel.AutoScroll = true;
            this.mFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mFlowLayoutPanel.Location = new System.Drawing.Point(15, 214);
            this.mFlowLayoutPanel.Name = "mFlowLayoutPanel";
            this.mFlowLayoutPanel.Size = new System.Drawing.Size(1155, 698);
            this.mFlowLayoutPanel.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.Controls.Add(this.mFlowLayoutPanel);
            this.Controls.Add(this.mOrRadioButton);
            this.Controls.Add(this.mAndRadioButton);
            this.Controls.Add(this.mSearchTypeLabel);
            this.Controls.Add(this.mComplexityLabel);
            this.Controls.Add(this.mComplexityCheckedListBox);
            this.Controls.Add(this.mLuminictyLabel);
            this.Controls.Add(this.mLuminocityCheckedListBox);
            this.Controls.Add(this.mSecondaryLabel);
            this.Controls.Add(this.mSecondaryColorsCheckedListBox);
            this.Controls.Add(this.mMainLabel);
            this.Controls.Add(this.mClearButton);
            this.Controls.Add(this.mSearchButton);
            this.Controls.Add(this.mMainColorsCheckedListBox);
            this.Controls.Add(this.mFolderSelectButton);
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button mFolderSelectButton;
        private System.Windows.Forms.CheckedListBox mMainColorsCheckedListBox;
        private System.Windows.Forms.Button mSearchButton;
        private System.Windows.Forms.Button mClearButton;
        private System.Windows.Forms.Label mMainLabel;
        private System.Windows.Forms.CheckedListBox mSecondaryColorsCheckedListBox;
        private System.Windows.Forms.Label mSecondaryLabel;
        private System.Windows.Forms.CheckedListBox mLuminocityCheckedListBox;
        private System.Windows.Forms.Label mLuminictyLabel;
        private System.Windows.Forms.CheckedListBox mComplexityCheckedListBox;
        private System.Windows.Forms.Label mComplexityLabel;
        private System.Windows.Forms.Label mSearchTypeLabel;
        private System.Windows.Forms.RadioButton mAndRadioButton;
        private System.Windows.Forms.RadioButton mOrRadioButton;
        private System.Windows.Forms.FlowLayoutPanel mFlowLayoutPanel;
    }
}

