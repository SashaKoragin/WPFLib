using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DBFtoSQL2008Enterprise.Aplication.Page;

namespace DBFtoSQL2008Enterprise.Aplication.Sobytie
{
   public class Sobytie
    {
        public static void CreateLoadTable(object sender, RoutedEventArgs e, ConvertDbFtoSql xaml)
        {
            TextSobytie commandtext = new TextSobytie();
            commandtext.CreateLoadTableText(xaml);
        }

        //public static void OnGroup(object sender, RoutedEventArgs e, LotusConf xaml)
        //{
        //    TextSobytie commandSobytie = new TextSobytie();
        //    commandSobytie.OnGroup(xaml);
        //}
    }
}
