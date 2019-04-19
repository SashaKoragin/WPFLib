using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.ExitLogica;
using LibaryAIS3Windows.Window;
using LibaryXMLAutoModelXmlAuto.ModelSnuOne;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.RaschBydj.Migration
{
   public class MigrationCKlikCommand
    {


        public void AutoCklikMigration(StatusButtonMethod statusButton, string pathfileinn, string pathjurnalerror, string pathjurnalok)
        {
            DispatcherHelper.Initialize();
                Task.Run(delegate
                {
                    string copyid = null;
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                        KclicerButton clickerButton = new KclicerButton();
                        WindowsAis3 ais3 = new WindowsAis3();
                        ais3.StartNMigration();
                        if (ais3.WinexistsAis3() == 1)
                        {
                           while (statusButton.Iswork)
                           {
                              var id = clickerButton.Click11(pathjurnalerror, pathjurnalok,copyid);
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

    }
}
