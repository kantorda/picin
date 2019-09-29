using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace PicIN
{
    public class ImageProcessing
    {
        #region Private Properties
        private FSHelper mFSHelper = new FSHelper();
        private ConcurrentDictionary<string, string> mImageData = new ConcurrentDictionary<string, string>();
        #endregion

        #region Public Properties

        public ConcurrentDictionary<string, string> ImageData { get; }
        #endregion

        #region Private Methods

        private void ProcessImage(string path)
        {
            string serializedData = Interface.processImage(path);
            if (!string.IsNullOrEmpty(serializedData))
                mImageData.TryAdd(Path.GetFileName(path), serializedData);
        }
        #endregion

        #region Public Methods
        public async Task<bool> ProcessDirectoryAsync(string path)
        {
            if (!mFSHelper.FindImages(path))
                return false;

             _ = Parallel.ForEach(mFSHelper.ImageList, img => ProcessImage(img.FullName));

            return !mImageData.IsEmpty;
        }

        #endregion
    }
}