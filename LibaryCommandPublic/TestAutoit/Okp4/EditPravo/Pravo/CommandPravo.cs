﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.ExitLogica;
using LibaryCommandPublic.EventQbe.OKp4;
using LibaryCommandPublic.EventQbe.Reg;
using LibaryXMLAutoModelXmlAuto.ModelFidZorI;
using LibaryXMLAutoModelXmlAuto.ModelSnuOne;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.Okp4.EditPravo.Pravo
{
    /// <summary>
    /// Для команд ОКП 4 Земля Имущество
    /// </summary>
   public class CommandPravo
    {
        /// <summary>
        ///Налоговое администрирование\Собственность\02. Доопределение данных об объектах собственности\
        ///14. КС – Корректировка сведений о правах не зарегистрированных  в органах Росреестра и правах наследования на ОН и ЗУ
        /// </summary>
        /// <param name="statusButton">Кнопка контроля состояний</param>
        /// <param name="pathfilefid">Путь к файлу с Фидами</param>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к отаботаным спискам</param>
        public void AutoClicerEditPravo(StatusButtonMethod statusButton, string pathfilefid, string pathjurnalerror, string pathjurnalok)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathfilefid))
            {
                Task.Run(delegate
                {
                    LibaryAIS3Windows.ButtonsClikcs.SelectQbe.EventOkp.EventOkp eventqbe = new LibaryAIS3Windows.ButtonsClikcs.SelectQbe.EventOkp.EventOkp();
                    EventOkp selectevent = new EventOkp();
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    Exit exit = new Exit();
                    LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                    LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                    object obj = read.ReadXml(pathfilefid, typeof(FidFactZemlyOrImushestvo));
                    FidFactZemlyOrImushestvo fidmodel = (FidFactZemlyOrImushestvo)obj;
                    if (ais3.WinexistsAis3() == 1)
                    {
                        foreach (var fid in fidmodel.Fid)
                        {
                            if (statusButton.Iswork)
                              {
                                if (statusButton.IsChekcs)
                                {
                                    selectevent.AddEvent(eventqbe);
                                    selectevent.RemoveEvent(eventqbe);
                                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.IsCheker);
                                }
                                clickerButton.Click5(pathjurnalerror, pathjurnalok, fid.FidZemlyOrImushestvo);
                                read.DeleteAtributXml(pathfilefid, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtributeFid(fid.FidZemlyOrImushestvo));
                                statusButton.Count++;
                              }
                            else
                              {
                                break;
                              }
                        }
                        var status = exit.Exitfunc(statusButton.Count, fidmodel.Fid.Length, statusButton.Iswork);
                        statusButton.Count = status.IsCount;
                        statusButton.Iswork = status.IsWork;
                        DispatcherHelper.CheckBeginInvokeOnUI(delegate { statusButton.StatusGrinandYellow(status.Stat); });
                    }
                    else
                    {
                        MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
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
