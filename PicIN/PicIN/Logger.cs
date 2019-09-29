using System.ComponentModel;
using System.IO;

namespace PicIN
{
    public sealed class Logger
    {
        #region Singleton Members
        private static readonly Logger instance = new Logger();
        public static Logger Instance => instance;
        static Logger() { }
        private Logger() { }

        #endregion

        #region private properties    

        private const string mLogFilePath = @"..\..\..\..\logs\log.txt";
        private StreamWriter mLogFile = null;

        #endregion

        #region public properties

        public StreamWriter LogFile => mLogFile ?? (mLogFile = new StreamWriter(mLogFilePath, false));

        #endregion

        #region public methods

        public void Write(string data)
        {
            LogFile.WriteLineAsync(data);
        }
        #endregion



    }
}