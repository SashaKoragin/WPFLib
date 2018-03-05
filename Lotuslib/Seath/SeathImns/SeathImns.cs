using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Domino;
using Lotuslib.LotusItem;
using Lotuslib.LotusModel;


namespace Lotuslib.Seath.SeathImns
{
   public class SeathImns
    {
        /// <summary>
        /// Данный метод возвращает заполненую колекцию отделов и сотрудников из IMNS
        /// </summary>
        /// <param name="db">Соединение с Базой данных IMNS</param>
        /// <param name="shemeotdel">Схема из библиотеки данных ImnsLotusOtdelValue</param>
        /// <returns></returns>
        public static ModelImnsOtdel ShemeSeathImns(NotesDatabase db, ModelImnsOtdel shemeotdel)
        {
            var colOtdel = db.Search(String.Format("Select(Form= \"" + DbImnsItem.Departament + "\")"), null, 0);
            var docOtdel = colOtdel.GetFirstDocument();
            while (docOtdel != null)
            {
                //ModelImnsOtdel.ModelImnsUsers shemeusers = new ModelImnsOtdel.ModelImnsUsers();
                string repOtd = docOtdel.GetItemValue(DbImnsItem.Abbreviation)[0];
                var colectUsers = db.Search(String.Format("Select (" + DbImnsItem.Abbreviation + "= \"" + repOtd + "\"&Form= \"" + DbImnsItem.Departament + "\"| @AllChildren)"), null, 0);
                var docUsers = colectUsers.GetFirstDocument();
                while (docUsers != null)
                {
                    string namenull = docUsers.GetItemValue(DbImnsItem.Abbreviation)[0];
                    if (docUsers.GetItemValue(ImnsLotusUsers.Dismissal)[0]!= "1" && namenull.Length == 0)
                    {
                       shemeotdel.ShemeUsers.Add(new ModelImnsOtdel.ModelImnsUsers { Username = docUsers.GetItemValue(ImnsLotusUsers.User)[0] });
                    }
                    docUsers = colectUsers.GetNextDocument(docUsers);
                }
                shemeotdel.ShemeOtdel.Add(new ModelImnsOtdel { Otdeldepartament = Regex.Replace(docOtdel.GetItemValue(DbImnsItem.NameOtdel)[0], "[0-9]+[\\s]", String.Empty), _shemeousers = shemeotdel.ShemeUsers });
                docOtdel = colOtdel.GetNextDocument(docOtdel);
            }
            return shemeotdel;
        }

        //public static ObservableCollection<ModelImnsOtdel> ShemeSeathImns(NotesDatabase db, ObservableCollection<ModelImnsOtdel> shemeotdel)
        //{
        //    var colOtdel = db.Search(String.Format("Select(Form= \"" + DbImnsItem.Departament + "\")"), null, 0);
        //    var docOtdel = colOtdel.GetFirstDocument();
        //    while (docOtdel != null)
        //    {
            
        //        ModelImnsOtdel.ModelImnsUsers shemeusers = new ModelImnsOtdel.ModelImnsUsers();
        //        string repOtd = docOtdel.GetItemValue(DbImnsItem.Abbreviation)[0];
        //        var colectUsers = db.Search(String.Format("Select (" + DbImnsItem.Abbreviation + "= \"" + repOtd + "\"&Form= \"" + DbImnsItem.Departament + "\"| @AllChildren)"), null, 0);
        //        var docUsers = colectUsers.GetFirstDocument();
        //        while (docUsers != null)
        //        {
        //            string namenull = docUsers.GetItemValue(DbImnsItem.Abbreviation)[0];
        //            if (docUsers.GetItemValue(ImnsLotusUsers.Dismissal)[0] != "1" && namenull.Length == 0)
        //            {
        //                shemeusers.ShemeUsers.Add(new ModelImnsOtdel.ModelImnsUsers { UserName = docUsers.GetItemValue(ImnsLotusUsers.User)[0] });
        //            }
        //            docUsers = colectUsers.GetNextDocument(docUsers);
        //        }
        //        shemeotdel.Add(new ModelImnsOtdel { OtdelDepartament = docOtdel.GetItemValue(DbImnsItem.NameOtdel)[0], _shemeousers = shemeusers.ShemeUsers });
        //        docOtdel = colOtdel.GetNextDocument(docOtdel);
        //    }
        //    return shemeotdel;
        //}

    }
}
