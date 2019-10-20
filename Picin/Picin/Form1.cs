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
        
        #endregion

        #region Event Handlers

        private void OnClick_Process(object sender, EventArgs e)
        {
            Task.Run(() => ProcessAsync(inputFilePath.Text).ConfigureAwait(false));
        }

        private async Task ProcessAsync(string path)
        {
            if (await mImageProcessing.ProcessDirectoryAsync(inputFilePath.Text))
            {
                string writePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Results.txt";
                StreamWriter osStreamWriter = new StreamWriter(writePath);

                foreach (ImageData image in mController.mImageList)
                    osStreamWriter.WriteLine(image.mPath);

                osStreamWriter.Flush();
                osStreamWriter.Close();
            }

            label1.Text = "Done";
        }

        #endregion        
    }
}
