using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule;
using ViewModelLib.ModelTestAutoit.PublicModel.QbeSelect;

namespace LibraryCommandPublic.TestAutoit.Okp3.Patent
{
   public class Patent
    {
        /// <summary>
        /// Функция сбора патентов
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>

        /// <param name="pathTemp">Путь сохранения Temp</param>
        public void PatentParsing(StatusButtonMethod statusButton, string pathTemp)
        {  
                DispatcherHelper.Initialize();
                Task.Run(delegate
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click39(statusButton, pathTemp);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                });
        }
    }
}
