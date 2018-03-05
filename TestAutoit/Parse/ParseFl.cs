using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutoit.Parse
{
   public class ParseFl
   {
       public string _fio { get; set; }
       public string _inn { get; set; }
        public string _adress { get; set; }

        public void FuncParse()
        {
            _fio = null;
            _inn = null;
            _adress = null;
            while (true)
            {
                if (String.IsNullOrWhiteSpace(_fio) || String.IsNullOrWhiteSpace(_inn) || String.IsNullOrWhiteSpace(_adress))
                {
                    AutoIt.AutoItX.ControlFocus("АИС Налог-3 ПРОМ ", "", "[NAME:txtN18]");
                    AutoIt.AutoItX.Sleep(500);
                    AutoIt.AutoItX.Send("^c");
                    _fio = AutoIt.AutoItX.ClipGet();
                    AutoIt.AutoItX.ControlFocus("АИС Налог-3 ПРОМ ", "", "[NAME:txtN134]");
                    AutoIt.AutoItX.Sleep(500);
                    AutoIt.AutoItX.Send("^c");
                    _inn = AutoIt.AutoItX.ClipGet();
                    AutoIt.AutoItX.ControlFocus("АИС Налог-3 ПРОМ ", "", "[NAME:txtN320]");
                    AutoIt.AutoItX.Sleep(500);
                    AutoIt.AutoItX.Send("^c");
                    _adress = AutoIt.AutoItX.ClipGet();
                }
                else
                {
                    AutoIt.AutoItX.ClipPut(null);
                    AutoIt.AutoItX.Send("{Tab}");
                    break;
                }
            }
        }

       public void SaveLkYes()
       {
            var file = new StreamWriter(@"UseFiles\OtchetLkYes.txt",true, Encoding.Default);
            file.WriteLine(String.Format(@"{0}?{1}?{2}",_fio,_inn,_adress));
            file.Close();
            file.Dispose();
       }
        public void SaveLkNo()
        {
            var file = new StreamWriter(@"UseFiles\OtchetLkNo.txt", true, Encoding.Default);
            file.WriteLine(String.Format(@"{0}?{1}?{2}", _fio, _inn, _adress));
            file.Close();
            file.Dispose();
        }
    }
}
