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
        ImageList mImageListAll = new ImageList();
        ImageList mImageListSearchResults = new ImageList();

        #endregion

        #region Public Properties

        #endregion

        #region Initializer
        public Form1()
        {
            InitializeComponent();
            mImageListAll.ImageSize = new Size(108, 108);
            mImageListAll.ColorDepth = ColorDepth.Depth32Bit;
            mImageListSearchResults.ImageSize = new Size(108, 108);
            mImageListSearchResults.ColorDepth = ColorDepth.Depth32Bit;
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private Image getThumbnail(Image img)
        {
            int width = mImageListAll.ImageSize.Width;
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
        #endregion

        #region Event Handlers

        private void FolderSelectButton_Click(object sender, EventArgs e)
        {
            if (mFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                mController.TargetDirectory = new DirectoryInfo(mFolderBrowserDialog.SelectedPath);

                Task.Run(() => ProcessAsync(mController.TargetDirectory.FullName).ConfigureAwait(false));

                foreach (FileInfo file in mController.TargetDirectory.GetFiles())
                {
                    Image img = Image.FromFile(file.FullName);
                    mImageListAll.Images.Add(getThumbnail(img));                    
                }

                for (int i = 0; i < mImageListAll.Images.Count; ++i)
                {
                    mImageListView.Items.Add("", i);
                }

                mImageListView.View = View.LargeIcon;
                mImageListView.LargeImageList = mImageListAll;
            }
        }

        private void SearchButton_click(object sender, EventArgs e)
        {
            mController.ImageListSearchResults = mController.ImageListAll.ToList<ImageData>();
            mImageListSearchResults.Images.Clear();

            foreach (object color in mMainColorsCheckedListBox.CheckedItems)
            {
                mController.ImageListSearchResults = mController.ImageListSearchResults.Where(img 
                    => img.mMainColors.Contains(img.ColorStringToEnum(color.ToString()))).ToList<ImageData>();
            }

            if (mMainColorsCheckedListBox.CheckedItems.Count == 1)
            {
                mController.ImageListSearchResults.Sort(delegate (ImageData left, ImageData right)
                {
                    string color = "";

                    if (mMainColorsCheckedListBox.CheckedItems.Contains("Red"))
                    {
                        color = "Red";
                    }
                    else if (mMainColorsCheckedListBox.CheckedItems.Contains("Blue"))
                    {
                        color = "Blue";
                    }
                    else if (mMainColorsCheckedListBox.CheckedItems.Contains("Green"))
                    {
                        color = "Green";
                    }
                    else if (mMainColorsCheckedListBox.CheckedItems.Contains("Cyan"))
                    {
                        color = "Cyan";
                    }
                    else if (mMainColorsCheckedListBox.CheckedItems.Contains("Purple"))
                    {
                        color = "Purple";
                    }
                    else if (mMainColorsCheckedListBox.CheckedItems.Contains("Yellow"))
                    {
                        color = "Yellow";
                    }
                    else if (mMainColorsCheckedListBox.CheckedItems.Contains("Black"))
                    {
                        color = "Black";
                    }
                    else if (mMainColorsCheckedListBox.CheckedItems.Contains("Gray"))
                    {
                        color = "Gray";
                    }
                    else if (mMainColorsCheckedListBox.CheckedItems.Contains("White"))
                    {
                        color = "White";
                    }
                  
                    if (!String.IsNullOrEmpty(color))
                    {
                        ImageData.Color colorT = left.ColorStringToEnum(color);

                        if (left.mColorWeight[colorT] < right.mColorWeight[colorT])
                            return 1;
                        if (left.mColorWeight[colorT] > right.mColorWeight[colorT])
                            return -1;
                        return 0;
                    }
                    return 0;
                });
            }

            mImageListView.Clear();

            foreach (ImageData image in mController.ImageListSearchResults)
            {
                Image img = Image.FromFile(image.mPath);
                mImageListSearchResults.Images.Add(getThumbnail(img));
            }

            for (int i = 0; i < mImageListSearchResults.Images.Count; ++i)
            {
                mImageListView.Items.Add("", i);
            }

            mImageListView.View = View.LargeIcon;
            mImageListView.LargeImageList = mImageListSearchResults;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            mImageListView.Clear();

            for (int i = 0; i < mImageListAll.Images.Count; ++i)
            {
                mImageListView.Items.Add("", i);
            }

            mImageListView.View = View.LargeIcon;
            mImageListView.LargeImageList = mImageListAll;

        }

        private void OnClick_Process(object sender, EventArgs e)
        {
            Task.Run(() => ProcessAsync(mController.TargetDirectory.FullName).ConfigureAwait(false));
        }

        private async Task ProcessAsync(string path)
        {
            await mImageProcessing.ProcessDirectoryAsync(path);

            //if (await mImageProcessing.ProcessDirectoryAsync(path))
            //{
            //    string writePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Results.txt";
            //    StreamWriter osStreamWriter = new StreamWriter(writePath);

            //    foreach (ImageData image in mController.ImageListAll)
            //        osStreamWriter.WriteLine(image.mPath);

            //    osStreamWriter.Flush();
            //    osStreamWriter.Close();
            //}
        }

        #endregion
    }
}
