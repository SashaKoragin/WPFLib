using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DBFtoSQL2008Enterprise.Aplication.Page;

namespace DBFtoSQL2008Enterprise.Aplication.Sobytie
{
   public class EnumSob
    {
        internal static void EnumSobytie(object sender, RoutedEventArgs e, ConvertDbFtoSql sobconvert)
        {
            if (Equals(e.OriginalSource, sobconvert.Button1))
            {
                Sobytie.CreateLoadTable(sender, e, sobconvert);
            }
        }

        //internal static void EnumSobytieLotus(object sender, RoutedEventArgs e, LotusConf sobconvert)
        //{
        //    if (Equals(e.OriginalSource, sobconvert.OnGroping))
        //    {
        //        Sobytie.OnGroup(sender, e, sobconvert);
        //    }
        //}

    }
}
