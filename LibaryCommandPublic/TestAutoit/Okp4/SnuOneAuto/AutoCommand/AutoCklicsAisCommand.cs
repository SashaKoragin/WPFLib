
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAIS3Windows.Window;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.ExitLogica;
using LibaryXMLAutoModelXmlAuto.ModelSnuOne;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using System.Threading;
using GalaSoft.MvvmLight.Threading;
using LibaryXMLAutoModelXmlAuto.FullInnCount;
using ViewModelLib.ModelTestAutoit.PublicModel.DatePicker;

namespace LibraryCommandPublic.TestAutoit.Okp4.SnuOneAuto.AutoCommand
{
   public class AutoCklicsAisCommand
    {

        /// <summary>
        /// Авто кликер для ветки 
        /// Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\
        /// 1. Создание заявки на формирование СНУ для единичной печати
        /// </summary>
        /// <param name="statusButton">Кнопка контроля состояний</param>
        /// <param name="pathfileinn">Путь к файлу с массовыми ИНН</param>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к отаботаным спискам</param>
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
                    WindowsAis3 ais3 = new WindowsAis3();
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
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                    }
                });
            }
            else
            {
                MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status5);
            }
        }

        /// <summary>
        /// Авто кликер для ветки 
        /// Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\
        /// 1. Создание заявки на формирование СНУ для массовой печати
        /// </summary>
        /// <param name="statusButton">Кнопка контроля состояний</param>
        /// <param name="pathfileinn">Путь к файлу с массовыми ИНН</param>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к отаботаным спискам</param>
        public void AutoClicerSnuMassInnForm(StatusButtonMethod statusButton, string pathfileinn, string pathjurnalerror,string pathjurnalok)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathfileinn))
            {
                Task.Run(delegate
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    Exit exit = new Exit();
                    WindowsAis3 ais3 = new WindowsAis3();
                    LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                    object obj = read.ReadXml(pathfileinn, typeof(INNList));
                    INNList snumodelmass = (INNList)obj;
                    if (ais3.WinexistsAis3() == 1)
                    {
                        foreach (var inn in snumodelmass.ListInn)
                        {
                            if (statusButton.Iswork)
                            {
                                clickerButton.Click4(pathjurnalerror, pathjurnalok, inn.MyInnn);
                                read.DeleteAtributXml(pathfileinn, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtributeMassNumCollection(inn.NumColection.ToString()));
                                statusButton.Count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        var status = exit.Exitfunc(statusButton.Count, snumodelmass.ListInn.Length, statusButton.Iswork);
                        statusButton.Count = status.IsCount;
                        statusButton.Iswork = status.IsWork;
                        DispatcherHelper.CheckBeginInvokeOnUI(delegate { statusButton.StatusGrinandYellow(status.Stat); });
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                    }
                });
            }
            else
            {
                MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status5);
            }
        }

        /// <summary>
        /// Печать документа с анализом есть ли ЛК2
        /// </summary>
        /// <param name="date">Дата регистрации СНУ</param>
        /// <param name="statusButton">Кнопка контроля состояний</param>
        /// <param name="pathfileinn">Путь к файлу с массовыми ИНН</param>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к отаботаным спискам</param>
        /// <param name="conectionstring">Строка соединения с нашей БД</param>
        public void PrintSnu(DatePickerPub date, StatusButtonMethod statusButton, string pathfileinn,
            string pathjurnalerror, string pathjurnalok, string conectionstring)
        {
            try
            {
                if (date.IsValidation())
                {
                    DispatcherHelper.Initialize();
                    if (File.Exists(pathfileinn))
                    {
                        Task.Run(delegate
                        {
                            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read =new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                            object obj = read.ReadXml(pathfileinn, typeof(INNList));
                            INNList snumodelmass = (INNList) obj;
                            if (snumodelmass.ListInn != null)
                            {
                                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                                KclicerButton clickerButton = new KclicerButton();
                                Exit exit = new Exit();
                                WindowsAis3 ais3 = new WindowsAis3();
                                if (ais3.WinexistsAis3() == 1)
                                {
                                    foreach (var inn in snumodelmass.ListInn)
                                    {
                                        if (statusButton.Iswork)
                                        {
                                            clickerButton.Click7(date.Date, pathjurnalerror, pathjurnalok, inn.MyInnn,
                                                conectionstring,statusButton.IsChekcs,statusButton.IsLk2);
                                            read.DeleteAtributXml(pathfileinn,
                                                LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute
                                                    .GenerateAtributeMassNumCollection(inn.NumColection.ToString()));
                                            statusButton.Count++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                            statusButton.IsCheker();
                                    }
                                    var status = exit.Exitfunc(statusButton.Count, snumodelmass.ListInn.Length,
                                        statusButton.Iswork);
                                    statusButton.Count = status.IsCount;
                                    statusButton.Iswork = status.IsWork;
                                    DispatcherHelper.CheckBeginInvokeOnUI(
                                        delegate { statusButton.StatusGrinandYellow(status.Stat); });
                                }
                                else
                                {
                                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                                }
                            }
                            else
                            {
                                MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status7);
                            }
                        });

                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status5);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}