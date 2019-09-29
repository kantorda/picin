using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace PicIN
{
    public class FSHelper
    {
        #region Private Properties

        private string mDirectoryPath;
        private DirectoryInfo mTargetDirectory;
        private List<FileInfo> mImageList = new List<FileInfo>();
        private static Logger mLogger = Logger.Instance;

        #endregion

        #region Public Properties        

        public string DirectoryPath
        {
            get => mDirectoryPath;
            set => mDirectoryPath = value;

        }

        public DirectoryInfo TargetDirectory
        {
            get => mTargetDirectory;
            set => mTargetDirectory = value;
        }

        public FileInfo[] Images
        {
            get => mImageList.ToArray();            
        }

        public List<FileInfo> ImageList
        {
            get => mImageList;
        }

        #endregion

        #region Private Methods

        #endregion
    

        #region Public Methods

        public bool FindImages(string directoryPath)
        {
            if (!string.IsNullOrEmpty(directoryPath) && Directory.Exists(directoryPath))
            {
                DirectoryPath = directoryPath;
                TargetDirectory = new DirectoryInfo(DirectoryPath);
            }
            else
            {
                //mLogger.Write("Requested directory string was either empty or could not be found: " + directoryPath);
                return false;
            }

            mImageList = TargetDirectory.GetFiles().Where(x => (x.Extension == ".jpg" || x.Extension == ".png"))
                .ToList();

            if (!Images.Any())
            {
                //mLogger.Write("No .jpg or .png files found in target directory");
                return false;
            }

            return true;
        }

        #endregion
    }
}