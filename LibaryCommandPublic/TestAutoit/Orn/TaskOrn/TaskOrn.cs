﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

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

    }
}
