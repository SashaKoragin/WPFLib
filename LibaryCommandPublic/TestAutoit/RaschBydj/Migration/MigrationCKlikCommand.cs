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
   public class MigrationClickCommand
    {

        /// <summary>
        /// Миграция НП
        /// </summary>
        /// <param name="statusButton">Кнопка передачи старта</param>
        /// <param name="select">Выборка данных</param>
        /// <param name="reportMigration">Путь к отчету парсинга миграции</param>
        /// <param name="code">Код налогового органа</param>
        /// <param name="collectionException">Исключенные ИНН</param>
        public void AutoClickMigration(StatusButtonMethod statusButton, SelectVibor select, string reportMigration, string code, ObservableCollection<string> collectionException)
        {
            DispatcherHelper.Initialize();
            if (select.IsValidation())
            {
                Task.Run(delegate
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    if (File.Exists(reportMigration))  { File.Delete(reportMigration); }
                    KclicerButton clickerButton = new KclicerButton();
                    WindowsAis3 ais3 = new WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click11(statusButton, select, reportMigration, code, collectionException);
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                    }
                });
            }
        }
    }
}
