using System.Collections.Concurrent;

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
        private string mDirectoryPath;
        #endregion

        #region Public Properties        
        public ConcurrentBag<ImageData> ImageList = new ConcurrentBag<ImageData>();
        #endregion        

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion        
    }
}