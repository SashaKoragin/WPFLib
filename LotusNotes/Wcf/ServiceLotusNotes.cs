using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Windows;
using Lotuslib.ConectDb;
using Lotuslib.ConectionString;
using Lotuslib.LotusModel;
using LotusNotes.Dialogs.Global;
using LotusNotes.LotusPage;
using LotusNotes.ModelDialogs;
using MaterialDesignThemes.Wpf;
using ViewModelLib.ViewModelPage;
using ViewModelLib.ViewModelPage.ViewModel;

namespace LotusNotes.Wcf
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceLotusNotes" в коде и файле конфигурации.
    [ServiceBehavior(UseSynchronizationContext = true)]
    public class ServiceLotusNotes : IServiceLotusNotes
    {
        public ModelComutator Col()
        {
            var sheme = new ModelComutator();
            try
            {
                var db = ConectDb.Databaseconect(ConectionString.Pass, ConectionString.ServerLocal,
                    ConectionString.Komutator, false);
                var doc = db.AllDocuments;
                var docum = doc.GetFirstDocument();
                while (docum != null)
                {
                    sheme.ShemeDbCom.Add(new ModelComutator
                    {
                        Title = docum.GetItemValue(Lotuslib.LotusItem.DbComutatorItem.Title)[0],
                        Path = docum.GetItemValue(Lotuslib.LotusItem.DbComutatorItem.Adress)[1]
                    });

                    docum = doc.GetNextDocument(docum);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sheme;
        }
    }
}
