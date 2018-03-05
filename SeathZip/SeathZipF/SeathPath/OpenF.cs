using System.Diagnostics;

namespace SeathZip.SeathZipF.OpenFile
{
    public class OpenF
    {
        public static void Openxls(string fileName)
        {
            var startInfo = new ProcessStartInfo(fileName)
            {
                UseShellExecute = true,
            };
            Process.Start(startInfo);
        }

    }
}