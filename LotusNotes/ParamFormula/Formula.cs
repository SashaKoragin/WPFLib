using System;
using System.Windows;
using System.Xml.Schema;

namespace LotusNotes.ParamFormula
{
   public class Formula
    {
        public static string GenerateFormula(string formula, string otdel, DateTime start, DateTime finish,string status = null)
        {
            var f = string.Format(formula, otdel,start.ToString("yyyy;MM;dd"), finish.ToString("yyyy;MM;dd"), status);
            return f;
        }
    }
}
