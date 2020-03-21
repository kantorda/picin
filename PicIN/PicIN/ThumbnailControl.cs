using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PicIN
{
    public partial class ThumbnailControl : UserControl
    {
        private FileInfo mFile;
        public ThumbnailControl()
        {
            InitializeComponent();
        }

        public void setImage(Image img, string path)
        {
            if (thumbnailPictureBox.Image != null)
                thumbnailPictureBox.Image.Dispose();

            thumbnailPictureBox.Image = img;
            thumbnailLabel.Text = Path.GetFileName(path);
            mFile = new FileInfo(path); 
        }

        private void thumbnailPictureBox_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(mFile.FullName);
        }
    }
}
