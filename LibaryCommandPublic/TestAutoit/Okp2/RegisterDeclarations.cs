using System;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace LibraryCommandPublic.TestAutoit.Okp2
{
   public class RegisterDeclarations
    {
        /// <summary>
        /// Налоговое администрирование\Контрольная работа(налоговые проверки)\
        /// 121. Камеральная налоговая проверка\03. Реестр налоговых деклараций(расчетов), сведения о КНП(все)
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        /// <param name="pathPdfTemp">Genm к Temp</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        public void StartRegisterDeclarations(StatusButtonMethod statusButton, string pathPdfTemp, DatePickerAdd datePicker)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                   DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click28(statusButton, pathPdfTemp, datePicker);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            });
        }
    }
}
