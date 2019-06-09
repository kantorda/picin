using System;
using System.Runtime.InteropServices;

namespace PicIN
{
    public class Interface
    {
        [DllImport("Library", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string processDirectory([MarshalAs(UnmanagedType.LPStr)] String data);
    }
}