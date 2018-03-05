using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotusClient.ServiceReference1;
using MaterialDesignThemes.Wpf;
using ViewModelLib.ViewModelPage;
using ViewModelLib.ViewModelPage.ViewModel;

namespace LotusClient.DataContextModel
{
   public class ModelUseCommutator
    {
        public LinkCommutator[] LinkZg { get; }
        public ObservableCollection<ModelComutator> ColectionDb { get; }
        /// <summary>
        /// Наша модель глобальных страниц можно добавлять
        /// </summary>
        /// <param name="messageQueue"></param>
        public ModelUseCommutator()
        {
            LinkZg = new[]
            {
                new LinkCommutator("Отделы",
                    new Dialog.Global.Commutator {DataContext = new  ComutatorModel()},
                    new[]
                    {
                        Link.Pageses<Dialog.Global.Commutator>()
                    })
            };
        }
    }
    public class ComutatorModel
    {
        /// <summary>
        /// Данный класс служит для подгрузки данных в Коммутатор
        /// </summary>
        public ComutatorModel()
        {
            ColectionDb = LoadDb();
        }

        public ModelComutator ColectionDb { get; }

        public ModelComutator LoadDb()
        {
            var client = new ServiceLotusNotesClient("BasicHttpBinding_IServiceLotusNotes");
            var r = client.Col();

            return r;
        }
    }
}
