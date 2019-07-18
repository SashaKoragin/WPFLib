using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.RaschetBuh;

namespace LibaryCommandPublic.TestAutoit.RaschBydj.Migration
{
   public class MigrationCKlikCommand
    {

        /// <summary>
        /// Миграция НП
        /// </summary>
        /// <param name="statusButton">Кнопка передачи старта</param>
        /// <param name="reportMigration">Путь к отчету парсинга миграции</param>
        public void AutoCklikMigration(StatusButtonMethod statusButton, string reportMigration)
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
                              var id = clickerButton.Click11(statusButton.IsChekcs, reportMigration, copyid);
                               if (id.Equals(copyid))
                               {
                                  DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusYellow);
                               }
                               copyid = id;
                           }
                        }
                        else
                        {
                            MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                        }
                });
            
        }

        public void SendParametr(SelectVibor select)
        {
            if (select.IsValidation())
            {
                WindowsAis3 ais3 = new WindowsAis3();
                if (select.Sel.Num == 1)
                {
                    ais3.SendParametrsPriem();
                }
                else
                {
                    ais3.SendParametrsPeredahca();
                }
            }
        }
    }
}
