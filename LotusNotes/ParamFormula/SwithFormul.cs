using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Lotuslib.Seath.SeathZg;
using Lotuslib.Formula.Otdel;
using Lotuslib.LotusModel;
using Lotuslib.StatusZG;
using ViewModelLib.ViewModelPage.CalendarModel;
using ViewModelLib.ViewModelPage.LoadingString;

namespace LotusNotes.ParamFormula
{
   public class SwithFormul
   {


       public void FormulSwith(ModelZg modelZg, string databasepath, ModelImnsOtdel otdel, CalendarModel calendar, Status status, OtdelFormul formul, Loading Load)
       {
           SeathZg seathzg = new SeathZg();
           if ( !formul.IsValidation())
           {
           }
            else
            {
                switch ( formul.SelectfFormul.Index)
                {
                    case 1:
                        if (!otdel.IsValidation() || !calendar.IsValidation())
                        { break; }
                        {
                         seathzg.SeathZgOtdel(databasepath, modelZg, Formula.GenerateFormula(formul.SelectfFormul.Formula, otdel.SelectOtdel.OtdelDepartament,
                               calendar.Stardatetime, calendar.EndDateTime), Load); break;
                        }
                    case 2:
                        if ( !otdel.IsValidation() || !calendar.IsValidation() ||  !status.IsValidation())
                        { break; }
                        {
                          seathzg.SeathZgOtdel(databasepath, modelZg, Formula.GenerateFormula(formul.SelectfFormul.Formula, otdel.SelectOtdel.OtdelDepartament,
                              calendar.Stardatetime, calendar.EndDateTime, status.Selectstatus.StatusZg), Load); break;
                        }
                }
            }


        }

    }
    
}
