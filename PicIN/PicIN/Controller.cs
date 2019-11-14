using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PicIN
{
    public class Controller
    {
        #region Singleton Members
        private static readonly Controller instance = new Controller();
        public static Controller Instance => instance;
        static Controller() { }
        private Controller()
        {
            ImageListAll.ImageSize = new Size(108, 108);
            ImageListAll.ColorDepth = ColorDepth.Depth32Bit;
            ImageListSearchResults.ImageSize = new Size(108, 108);
            ImageListSearchResults.ColorDepth = ColorDepth.Depth32Bit;
        }
        #endregion

        #region Private Properties  
        Logger mLogger = Logger.Instance;
        FSHelper mFSHelper = new FSHelper();
        #endregion

        #region Public Properties
        public DirectoryInfo TargetDirectory;
        public ConcurrentBag<ImageData> ImagesConcurrentBag = new ConcurrentBag<ImageData>();
        public List<ImageData> ImagesSearchResults = new List<ImageData>();
        public ImageList ImageListAll = new ImageList();
        public ImageList ImageListSearchResults = new ImageList();
        #endregion        

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion        
    }
}