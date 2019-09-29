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
        
        #endregion        

        #region Private Methods

        //private bool SplitWork()
        //{
        //    int numThreads = ((mFSHelper.Images.Length / 10) < 1) ? 1 : (mFSHelper.Images.Length / 10);
        //    int threeQuartersThreadCount = std::thread::hardware_concurrency();
        //    if (threeQuartersThreadCount > 0)
        //    {
        //        threeQuartersThreadCount = ((threeQuartersThreadCount * 3) / 4);
        //        if (threeQuartersThreadCount < numThreads)
        //        {
        //            numThreads = threeQuartersThreadCount;
        //        }
        //    }

        //    const int filesPerWorker = int(files.size() / numThreads);

        //    std::vector<std::vector<fs::directory_entry>> fileVectors;
        //    unsigned int startIndx = 0, endIndx = 0;
        //    bool pushLast = false;
        //    for (int i = 0; i < numThreads; ++i)
        //    {
        //        if (startIndx >= files.size())
        //            break;

        //        endIndx = startIndx + filesPerWorker;
        //        if ((endIndx >= files.size()) || (i == (numThreads - 1)))
        //        {
        //            fileVectors.emplace_back(&files[startIndx], &files.back());
        //            pushLast = true;
        //        }
        //        else
        //        {
        //            fileVectors.emplace_back(&files[startIndx], &files[endIndx]);
        //            if (endIndx == (files.size() - 1))
        //                pushLast = true;
        //        }
        //        startIndx = endIndx;
        //    }

        //    if (pushLast)
        //        fileVectors.back().push_back(files.back());
        //    return true;
        //}
        #endregion

        #region Public Methods

        //public void EntryPoint(string targetPath)
        //{
        //    mDirectoryPath = targetPath;

        //    if (!mFSHelper.FindImages(mDirectoryPath))
        //        return;


        //}
        #endregion        
    }
}