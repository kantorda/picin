using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace PicIN
{
    public class Controller
    {
        #region Singleton Members
        private static readonly Controller instance = new Controller();
        public static Controller Instance => instance;
        static Controller() { }
        private Controller() { }
        #endregion

        #region Private Properties  
        Logger mLogger = Logger.Instance;
        FSHelper mFSHelper = new FSHelper();
        #endregion

        #region Public Properties
        public DirectoryInfo TargetDirectory;
        public ConcurrentBag<ImageData> ImageListAll = new ConcurrentBag<ImageData>();
        public List<ImageData> ImageListSearchResults = new List<ImageData>();
        #endregion        

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion        
    }
}