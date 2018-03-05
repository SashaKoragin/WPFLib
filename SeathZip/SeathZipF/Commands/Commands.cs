using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SeathZip.SeathZipF.Forms.Pages;

namespace SeathZip.SeathZipF.Commands
{
    public class Commands
    {
        static Commands()
        {
           
            Delite = new RoutedCommand("Delete", typeof(SeathArg));
            Find = new RoutedCommand("Find", typeof(SeathFullPath));

        }
        public static RoutedCommand Delite { get; set; }
        public static RoutedCommand Find { get; set; }
    }
}