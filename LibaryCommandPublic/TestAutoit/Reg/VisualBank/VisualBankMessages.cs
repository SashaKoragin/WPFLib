using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.ExitLogica;
using LibaryAIS3Windows.Window;
using LibaryXMLAutoModelXmlAuto.FileVisualId;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.Reg.VisualBank
{
   public class VisualBankMessages
    {
        public void StartVisualBank(StatusButtonMethod statusButton, string pathfileid, string pathjurnalerror, string pathjurnalok)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathfileid))
            {
                Task.Run(delegate
                {
                    try
                    {
                        KclicerButton clickerButton = new KclicerButton();
                        Exit exit = new Exit();
                        WindowsAis3 ais = new WindowsAis3();
                        LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                        object obj = read.ReadXml(pathfileid, typeof(VisualIdent));
                        VisualIdent idmodel = (VisualIdent)obj;
                        if (idmodel.IdZapros != null)
                        {
                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                            if (ais.WinexistsAis3() == 1)
                            {

                                foreach (var id in idmodel.IdZapros)
                                {
                                    if (statusButton.Iswork)
                                    {
                                        clickerButton.Click21(id.VisualId, pathjurnalerror, pathjurnalok);
                                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.IsCheker);
                                        read.DeleteAtributXml(pathfileid,LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtributeIdIden(id.VisualId));
                                        statusButton.Count++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                            }
                            var status = exit.Exitfunc(statusButton.Count, idmodel.IdZapros.Length, statusButton.Iswork);
                            statusButton.Count = status.IsCount;
                            statusButton.Iswork = status.IsWork;
                            DispatcherHelper.CheckBeginInvokeOnUI(delegate { statusButton.StatusGrinandYellow(status.Stat); });
                        }
                        else
                        {
                            MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status7);
                        }
                    }
                    catch (Exception e)
                    {
                       MessageBox.Show(e.ToString());
                    }
                });
            }
            else
            {
                MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status5);
            }
        }
    }
}
