using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ViewModelLib.ViewModelPage.LoadingString;
using Lotuslib.ConectionString;
using Lotuslib.ConectDb;
using Lotuslib.Formula.Otdel;
using MaterialDesignThemes.Wpf;
using Lotuslib.LotusModel;
using Lotuslib.Seath.SeathZg;
using Lotuslib.StatusZG;
using LotusNotes.ParamFormula;
using Prism.Commands;
using Prism.Mvvm;
using ViewModelLib.ViewModelPage;
using ViewModelLib.ViewModelPage.CalendarModel;
using ViewModelLib.ViewModelPage.ViewModel;

namespace LotusNotes.ModelDialogs
{
    class DialogsmodelGlobal : BindableBase
    {

        public LinkCommutator[] LinkZg { get; }


        /// <summary>
        /// Наша модель глобальных страниц можно добавлять
        /// </summary>
        /// <param name="messageQueue"></param>
        public DialogsmodelGlobal(ISnackbarMessageQueue messageQueue)
        {
            if (messageQueue == null) throw new ArgumentException(nameof(messageQueue));
            LinkZg = new[]
            {
                new LinkCommutator("Отделы",
                    new Dialogs.Global.Commutator {DataContext = new ComutatorModel()},
                    new[]
                    {
                        Link.Pageses<Dialogs.Global.Commutator>()
                    })
            };
        }
    }

    public class ComutatorModel : BindableBase
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

    public class ZgDialogModel : BindableBase
    {
        //   public SeathDb.SeathDb Seath =new SeathDb.SeathDb();
        public SwithFormul FormulaSwithFormul = new SwithFormul();
        public LinkCommutator[] ZgOtdel { get; }
        public static string Zg { get; set; }
        public ModelImnsOtdel Sheme { get; }
        public Status Status { get; }
        public OtdelFormul FormulsOtdel { get; }
        public ModelZg ShemeZg { get; }
        public DelegateCommand GetChange { get; }
        public CalendarModel Calendar { get; }
        public Loading Load { get; }

        /// <summary>
        /// Наша модель глобальных страниц можно добавлять
        /// </summary>
        public ZgDialogModel(string zg)
        {
            ZgOtdel = new[]
            {
                new LinkCommutator("Полная выборка на отдел",
                    new Dialogs.Local.Zg.Local.Zg.ZgOtdel(),
                    new[]
                    {
                        Link.Pageses<Dialogs.Local.Zg.Local.Zg.ZgOtdel>()
                    }),
                new LinkCommutator("Выборка на пользователя", new Dialogs.Local.Zg.Local.Zg.ZgUsers(), new[]
                {
                    Link.Pageses<Dialogs.Local.Zg.Local.Zg.ZgUsers>()
                })
            };
            Zg = zg;
            Sheme = LoadOtdUser();
            FormulsOtdel = Lotuslib.LoadingModel.LoadingFormuls.Formuls();
            Status = Lotuslib.LoadingModel.LoadStatus.Status();
            ShemeZg = new ModelZg();
            GetChange = new DelegateCommand(()=>Dispatcher.CurrentDispatcher.Invoke(() => FormulaSwithFormul.FormulSwith(ShemeZg, Zg, Sheme, Calendar, Status, FormulsOtdel,Load)));
            Calendar = new CalendarModel();
            Load = new Loading("", 0);
        }

        public ModelImnsOtdel LoadOtdUser()
        {
            ModelImnsOtdel shemeotdel = new ModelImnsOtdel();

            try
            {
                var db = ConectDb.Databaseconect(ConectionString.Pass,ConectionString.ServerLocal, ConectionString.Imns,false);
                shemeotdel = Lotuslib.Seath.SeathImns.SeathImns.ShemeSeathImns(db, shemeotdel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return shemeotdel;
        }
    }
}
    
