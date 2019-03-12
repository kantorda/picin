using System;
using System.Runtime.InteropServices;

namespace PicIN
{
    public class Interface
    {
        [DllImport("Library", SetLastError = true)]
        public static extern int processImagePrintStatistics([MarshalAs(UnmanagedType.LPStr)] String data);
    }
}