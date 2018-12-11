using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.ButtonsClikcs.SelectQbe.EventReg;
using LibaryAIS3Windows.ExitLogica;
using LibaryAIS3Windows.Window;
using LibaryCommandPublic.EventQbe.Reg;
using LibaryXMLAutoModelXmlAuto.ModelFaceFid;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.Reg.Status
{
   public class StatusReg
    {
        /// <summary>
        /// Автомат Актуальные состояния
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        /// <param name="pathfileinn">Путь к значениям</param>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к  отработаным значениям</param>
        public void StateReg(StatusButtonMethod statusButton, string pathfileinn,string pathjurnalerror, string pathjurnalok)
        {
            try
            {
           DispatcherHelper.Initialize();
           if (File.Exists(pathfileinn))
            {
              Task.Run(delegate
               {
                 LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                 var snumodelmass = (Face)read.ReadXml(pathfileinn, typeof(Face));
                 if (snumodelmass.Fid != null)
                 {
                   DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                   KclicerButton clickerButton = new KclicerButton();
                   EventReg eventqbe = new EventReg();
                   EventFid regevent = new EventFid();
                   Exit exit = new Exit();
                   WindowsAis3 ais3 = new WindowsAis3();
                   if (ais3.WinexistsAis3() == 1)
                      {
                       foreach (var fid in snumodelmass.Fid)
                        {
                         if (statusButton.Iswork)
                           {
                               if (statusButton.IsChekcs)
                               {
                                   regevent.AddEvent(eventqbe);
                                   regevent.RemoveEvent(eventqbe);
                                   DispatcherHelper.CheckBeginInvokeOnUI(statusButton.IsCheker);
                                   
                               }
                            clickerButton.Click8( pathjurnalerror, pathjurnalok, fid.FidFace);
                            read.DeleteAtributXml(pathfileinn,LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtributeFaceFid(fid.FidFace));
                            statusButton.Count++;
                           }
                         else
                           {
                            break;
                           }
                        }
                       var status = exit.Exitfunc(statusButton.Count, snumodelmass.Fid.Length,statusButton.Iswork);
                       statusButton.Count = status.IsCount;
                       statusButton.Iswork = status.IsWork;
                       DispatcherHelper.CheckBeginInvokeOnUI( delegate { statusButton.StatusGrinandYellow(status.Stat); });
                      }
                  else
                      {
                       MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                       DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                      }
                }
              else
                {
                  MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status7);
                }
             });
             }
             else
              {
               MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status5);
              }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
