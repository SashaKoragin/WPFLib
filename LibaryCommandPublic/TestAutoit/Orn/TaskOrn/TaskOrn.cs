using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace LibraryCommandPublic.TestAutoit.Orn.TaskOrn
{
   public class TaskOrn
    {

        public void ConfirmationSendNbo(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    while (statusButton.Iswork)
                    {
                        string status = clickerButton.Click13();

                        if (status.Equals(LibraryAIS3Windows.Status.StatusAis.Status6))
                        {
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }
        /// <summary>
        /// Автомат на ветку Налоговое администрирование\ИОН\Информационное обслуживание\Формирование справки о наличии сальдо по инициативе НО
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        public void FaceRegistryReference(StatusButtonMethod statusButton)
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
                        clickerButton.Click60(statusButton);
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
        /// <summary>
        /// Автомат на ветку Налоговое администрирование\ИОН\Информационное обслуживание\Журнал учета запросов НО
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        public void FaceRegistryReferenceSend(StatusButtonMethod statusButton)
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
                        clickerButton.Click61(statusButton);
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
