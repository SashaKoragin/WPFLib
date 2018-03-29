
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.ExitLogica;
using LibaryXMLAutoModelXmlAuto.ModelSnuOne;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using System.Threading;
using GalaSoft.MvvmLight.Threading;

namespace LibaryCommandPublic.TestAutoit.Okp4.SnuOneAuto.AutoCommand
{
   public class AutoCklicsAisCommand
    {
        /// <summary>
        /// Авто кликер для ветки 
        /// Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\
        /// 1. Создание заявки на формирование СНУ для единичной печати
        /// </summary>
        public void AutoClicerSnuOneForm(StatusButtonMethod statusButton,string pathfileinn,string pathjurnalerror,string pathjurnalok)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathfileinn))
            {
                Task.Run(delegate
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    Exit exit = new Exit();
                    LibaryAIS3Windows.Window.Windows ais3 = new LibaryAIS3Windows.Window.Windows();
                    LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                    object obj = read.ReadXml(pathfileinn, typeof(SnuOneForm));
                    SnuOneForm snumodel = (SnuOneForm)obj;
                    if (ais3.WinexistsAis3() == 1)
                    {
                        foreach (var inn in snumodel.INN)
                        {
                            if (statusButton.Iswork)
                            {
                                clickerButton.Click1(pathjurnalerror, pathjurnalok, inn.INN1);
                                read.DeleteAtributXml(pathfileinn, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtributeInn(inn.INN1));
                                statusButton.Count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        var status = exit.Exitfunc(statusButton.Count, snumodel.INN.Length,statusButton.Iswork);
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
