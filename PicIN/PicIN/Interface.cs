using System;
using System.Runtime.InteropServices;

namespace PicIN
{
    public class Interface
    {
        [DllImport("Library", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string processDirectory([MarshalAs(UnmanagedType.LPStr)] String data);

        [DllImport("Library", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string processImage([MarshalAs(UnmanagedType.LPStr)] String path);

        [DllImport("Library", SetLastError = true)]
        public static extern void TestOutParams([MarshalAs(UnmanagedType.LPStr)] String inParam, [MarshalAs(UnmanagedType.BStr)] ref String outParam);
    }
}