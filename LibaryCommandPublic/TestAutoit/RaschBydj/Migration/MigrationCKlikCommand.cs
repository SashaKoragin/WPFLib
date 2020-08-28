using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.RaschetBuh;

namespace LibraryCommandPublic.TestAutoit.RaschBydj.Migration
{
   public class MigrationCKlikCommand
    {

        /// <summary>
        /// Миграция НП
        /// </summary>
        /// <param name="statusButton">Кнопка передачи старта</param>
        /// <param name="reportMigration">Путь к отчету парсинга миграции</param>
        /// <param name="collectionExeption">Исключенные ИНН</param>
        public void AutoCklikMigration(StatusButtonMethod statusButton, string reportMigration, ObservableCollection<string> collectionExeption)
        {
            DispatcherHelper.Initialize();
                Task.Run(delegate
                {
                    string copyid = null;
         
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    if (File.Exists(reportMigration)){ File.Delete(reportMigration);}
                        KclicerButton clickerButton = new KclicerButton();
                        WindowsAis3 ais3 = new WindowsAis3();
                        ais3.StartNMigration();
                        if (ais3.WinexistsAis3() == 1)
                        {
                           while (statusButton.Iswork)
                           {

                                var id = clickerButton.Click11(statusButton.IsChekcs, reportMigration, copyid, collectionExeption);
                                if (id.Equals(copyid))
                                {
                                   DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusYellow);
                                   return;
                                }
                                copyid = id;
                           }
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                        }
                });
            
        }
        /// <summary>
        /// Выборки 
        /// </summary>
        /// <param name="select">Параметры выборки</param>
        /// <param name="ifns">Номер инспекции из Конфига</param>
        public void SendParametr(SelectVibor select,string ifns)
        {
            if (select.IsValidation())
            {
                WindowsAis3 ais3 = new WindowsAis3();
                if (select.Sel.Num == 1)
                {
                    ais3.SendParametrsPriem(ifns);
                }
                else
                {
                    ais3.SendParametrsPeredahca(ifns);
                }
            }
        }
    }
}
