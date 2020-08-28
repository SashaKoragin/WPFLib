using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.ExitLogica;
using LibraryAIS3Windows.Window;
using LibaryXMLAutoModelXmlAuto.FileVisualId;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryCommandPublic.TestAutoit.Reg.VisualTreatmentFace
{
   public class VisualTreatmentFace
    {
        /// <summary>
        /// Обработка визуальной идентификации
        /// </summary>
        /// <param name="statusButton">Модель кнопки</param>
        /// <param name="pathfileid">Путь к файлу с УН</param>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к журналу со сделанными</param>
        public void VisualFace(StatusButtonMethod statusButton, string pathfileid, string pathjurnalerror, string pathjurnalok)
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

                            foreach (var fpd in idmodel.IdZapros)
                            {
                                if (statusButton.Iswork)
                                {
                                    clickerButton.Click12(fpd.VisualId, pathjurnalerror, pathjurnalok,
                                         statusButton.IsChekcs, statusButton.IsLk2);
                                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.IsCheker);
                                    read.DeleteAtributXml(pathfileid,
                                        LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtributeIdIden(
                                            fpd.VisualId));
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
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                        }
                        var status = exit.Exitfunc(statusButton.Count, idmodel.IdZapros.Length, statusButton.Iswork);
                        statusButton.Count = status.IsCount;
                        statusButton.Iswork = status.IsWork;
                        DispatcherHelper.CheckBeginInvokeOnUI(
                            delegate { statusButton.StatusGrinandYellow(status.Stat); });
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status7);
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
                MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status5);
            }
        }
    }
}
