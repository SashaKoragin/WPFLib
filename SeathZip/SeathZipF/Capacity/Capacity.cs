using System;

namespace SeathZip.SeathZipF.Capacity
{
    public class Capacity
    {
        public static string GetOsBit()
        {
            if(Environment.Is64BitOperatingSystem)
            { return "x64"; }
            else
            { return "x32"; }
        }
    }
}