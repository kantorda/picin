using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PicIN
{
    public partial class Form1 : Form
    {
        #region Private Properties        
        Controller mController = Controller.Instance;
        ImageProcessing mImageProcessing = new ImageProcessing();
        FolderBrowserDialog mFolderBrowserDialog = new FolderBrowserDialog();
        Search mSearch = new Search();

        #endregion

        #region Public Properties

        #endregion

        #region Initializer
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private Image getThumbnail(Image img)
        {
            int width = mController.ImageListAll.ImageSize.Width;
            Image thumb = new Bitmap(width, width);
            Image tmp = null;

            if (img.Width < width && img.Height < width)
            {
                using (Graphics graphics = Graphics.FromImage(thumb))
                {
                    int xOffset = (int)((width - img.Width) / 2);
                    int yOffset = (int)((width - img.Height) / 2);
                    graphics.DrawImage(img, xOffset, yOffset, img.Width, img.Height);
                }
            }
            else
            {
                Image.GetThumbnailImageAbort abort = new Image.GetThumbnailImageAbort(ThumbnailAbort);

                if (img.Width == img.Height)
                {
                    thumb = img.GetThumbnailImage(width, width, ThumbnailAbort, IntPtr.Zero);
                }
                else
                {
                    int k = 0, xOffset = 0, yOffset = 0;

                    if (img.Width < img.Height)
                    {
                        k = (int)(width * img.Width / img.Height);
                        tmp = img.GetThumbnailImage(k, width, ThumbnailAbort, IntPtr.Zero);
                        xOffset = (int)((width - k) / 2);
                    }
                    if (img.Width > img.Height)
                    {
                        k = (int)(width * img.Height / img.Width);
                        tmp = img.GetThumbnailImage(width, k, ThumbnailAbort, IntPtr.Zero);
                        yOffset = (int)((width - k) / 2);
                    }
                    using (Graphics graphics = Graphics.FromImage(thumb))
                    {
                        graphics.DrawImage(tmp, xOffset, yOffset, tmp.Width, tmp.Height);
                    }

                }
            }

            return thumb;
        }

        private bool ThumbnailAbort()
        {
            return true;
        }

        private async void doSearchAsync()
        {
            Invoke(new Action(async () =>
            {
                enableButtons(false);

                configureSearch();

                await mSearch.SearchAsync();

                mImageListView.Clear();

                foreach (ImageData image in mController.ImagesSearchResults)
                {
                    Image img = Image.FromFile(image.mPath);
                    mController.ImageListSearchResults.Images.Add(getThumbnail(img));
                }

                for (int i = 0; i < mController.ImageListSearchResults.Images.Count; ++i)
                {
                    mImageListView.Items.Add("", i);
                }

                mImageListView.View = View.LargeIcon;
                mImageListView.LargeImageList = mController.ImageListSearchResults;

                enableButtons(true);
            }));
        }

        private void configureSearch()
        {
            // Clean Search Parameters
            mSearch.MainColors.Clear();
            mSearch.SecondaryColors.Clear();
            mSearch.Luminocities.Clear();
            mSearch.ComplexityLevels.Clear();

            // Main colors
            foreach (object color in mMainColorsCheckedListBox.CheckedItems)
            {
                mSearch.MainColors.Add(ImageData.ColorStringToEnum(color.ToString()));
            }

            // Secondary colors
            foreach (object color in mSecondaryColorsCheckedListBox.CheckedItems)
            {
                mSearch.SecondaryColors.Add(ImageData.ColorStringToEnum(color.ToString()));
            }

            // Luminocity
            foreach (object lum in mLuminocityCheckedListBox.CheckedItems)
            {
                mSearch.Luminocities.Add(ImageData.LuminocityStringToEnum(lum.ToString()));
            }

            // Complexity
            foreach (object complexity in mComplexityCheckedListBox.CheckedItems)
            {
                switch (complexity.ToString())
                {
                    case "Simple":
                        mSearch.ComplexityLevels.Add(ComplexityLevel.Simple);
                        break;
                    case "Medium":
                        mSearch.ComplexityLevels.Add(ComplexityLevel.Medium);
                        break;
                    case "Complex":
                        mSearch.ComplexityLevels.Add(ComplexityLevel.Complex);
                        break;
                }
            }

            // Color Search Type
            if (mAndRadioButton.Checked)
                mSearch.ActiveSearchType = SearchType.And;
            else
                mSearch.ActiveSearchType = SearchType.Or;
        }

        private void enableButtons(bool enable)
        {
            mFolderSelectButton.Enabled = enable;
            mSearchButton.Enabled = enable;
            mClearButton.Enabled = enable;
        }

        private async void doSelectFolderAsync()
        {
            Invoke(new Action(async () =>
            {
                enableButtons(false);

                if (mFolderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    mController.TargetDirectory = new DirectoryInfo(mFolderBrowserDialog.SelectedPath);

                    await mImageProcessing.ProcessDirectoryAsync(mController.TargetDirectory.FullName);

                    foreach (FileInfo file in mController.TargetDirectory.GetFiles())
                    {
                        Image img = Image.FromFile(file.FullName);
                        mController.ImageListAll.Images.Add(getThumbnail(img));
                    }

                    for (int i = 0; i < mController.ImageListAll.Images.Count; ++i)
                    {
                        mImageListView.Items.Add("", i);
                    }

                    mImageListView.View = View.LargeIcon;
                    mImageListView.LargeImageList = mController.ImageListAll;
                }

                enableButtons(true);
            }));
        }

        private async void doClearAsync()
        {
            Invoke(new Action(() =>
            { 
                enableButtons(false);
                // Clear Search Criteria
                foreach (int i in mMainColorsCheckedListBox.CheckedIndices)
                    mMainColorsCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
                foreach (int i in mSecondaryColorsCheckedListBox.CheckedIndices)
                    mSecondaryColorsCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
                foreach (int i in mLuminocityCheckedListBox.CheckedIndices)
                    mLuminocityCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
                foreach (int i in mComplexityCheckedListBox.CheckedIndices)
                    mComplexityCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);

                // Reset ImageList to all images
                mImageListView.Clear();

                for (int i = 0; i < mController.ImageListAll.Images.Count; ++i)
                {
                    mImageListView.Items.Add("", i);
                }

                mImageListView.View = View.LargeIcon;
                mImageListView.LargeImageList = mController.ImageListAll;

                enableButtons(true);
            }));
        }
        #endregion

        #region Event Handlers

        private void FolderSelectButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => doSelectFolderAsync()).ConfigureAwait(false);
        }

        private void SearchButton_click(object sender, EventArgs e)
        {
            Task.Run(() => doSearchAsync()).ConfigureAwait(false);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => doClearAsync()).ConfigureAwait(false);
        }

        private void MAndRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //mAndRadioButton.Checked = true;

            //RadioButton rb = sender as RadioButton;
            //if (rb != null)
            //{
                mOrRadioButton.Checked = false;
            //}
        }

        private void MOrRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //mOrRadioButton.Checked = true;
            //RadioButton rb = sender as RadioButton;
            //if (rb != null)
            //{
                mAndRadioButton.Checked = false;
            //}
        }
        #endregion
    }
}
