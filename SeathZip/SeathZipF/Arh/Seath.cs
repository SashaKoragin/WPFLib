using System;
using System.IO;
using System.Linq;

namespace SeathZip.SeathZipF.Arh
{
   public class Seath
    {

        public static String[] Seatharj(String st,String st2)
        {
            string[] files = new DirectoryInfo(Path.Combine(st,st2)).GetFiles("*.arj", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
            return files;
        }

        public static void Delet()
        {
            string[] f = new DirectoryInfo(Configuration.Conf.RunTimeDerectory).GetFiles().Select(fi =>fi.FullName).ToArray();
            foreach(String file in f)
            {
                File.Delete(file);
            }
        }

        public static String[] Seatharj(String st)
        {
            string[] files = new DirectoryInfo(Path.Combine(st)).GetFiles("*.arj", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
            return files;
        }
    }
}
