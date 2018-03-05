using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lotuslib.LotusModel;
using LotusNotes.ModelDialogs;
using LotusNotes.ParamFormula;
using ViewModelLib.ViewModelPage.CalendarModel;

namespace LotusNotes.SeathDb
{
   public class SeathDb
    {
        public void SeathDbZg(ObservableCollection<ModelZg> sheme,string dbpath, ModelImnsOtdel otdel, CalendarModel calendar)
        {



                if (!otdel.IsValidation()||!calendar.IsValidation())
                {
                    MessageBox.Show("Не прошли");
                }
                else
                {
                try
                {
                    MessageBox.Show("Прошли");
                    //    sheme.Clear();
                    //    var db = Lotuslib.ConectDb.ConectDb.Databaseconect(Lotuslib.ConectionString.ConectionString.Pass, Lotuslib.ConectionString.ConectionString.ServerLocal, dbpath, false);
                    //    var col = db.Search(ParamFormula.Formula.FormulaSeath(otdel.OtdelDepartament, start, finish), null, 0);
                    //    var docum = col.GetFirstDocument();
                    //    while (docum != null)
                    //    {
                    //        sheme.Add(new ModelZg
                    //        {
                    //            StatusZg = docum.GetItemValue(Lotuslib.LotusItem.DbZgItem.StatusZg)[0],
                    //            Num = docum.GetItemValue(Lotuslib.LotusItem.DbZgItem.NumZg)[0],
                    //            Datareg = docum.GetItemValue(Lotuslib.LotusItem.DbZgItem.DataregZg)[0],
                    //            DepartamentZg = docum.GetItemValue(Lotuslib.LotusItem.DbZgItem.DepartamentZg)[0],
                    //            Incardrespoutnum = docum.GetItemValue(Lotuslib.LotusItem.DbZgItem.InCardRespOutNum)[0],
                    //            Incardrespdi = Convert.ToString(docum.GetItemValue(Lotuslib.LotusItem.DbZgItem.InCardRespDi)[0]),
                    //            Extofiledate = Convert.ToString(docum.GetItemValue(Lotuslib.LotusItem.DbZgItem.ExToFileDate)[0])
                    //        });
                    //        docum = col.GetNextDocument(docum);
                    //    }
                }
               catch (Exception e)
               {
                  MessageBox.Show(e.Message);
               }
        }
               
        }
    }
}
