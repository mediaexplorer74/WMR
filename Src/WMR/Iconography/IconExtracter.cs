﻿using System.Drawing;
using System.Runtime.InteropServices;

namespace WMR.Iconography
{
    public static class IconExtractor
    {
        public static Icon ExtractIcon(string file, int number, bool largeIcon)
        {
            var outInt = ExtractIconEx(file, number, out IntPtr large, out IntPtr small, 1);
            return ValueAssigner.TryAssign(
                () => Icon.FromHandle(largeIcon ? large : small),
                () => null);
        }
        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);
    }
}
