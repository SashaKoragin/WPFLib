using System.Diagnostics;

namespace PublicLogicaFull.FileLogica.OpenFile
{
   public class OpenFile
    {
        public static void Openxls(string filepath)
        {
            var startInfo = new ProcessStartInfo(filepath)
            {
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }
    }
}
