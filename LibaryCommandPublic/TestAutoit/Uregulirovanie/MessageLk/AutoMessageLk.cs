using System.IO;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibaryXMLAuto.XsdModelAutoGenerate;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk
{
  public class AutoMessageLk
    {
        /// <summary>
        /// Автоматизация ветки подписание руководителем за счет имущества ветка 05.08.09.02.03.06. Подпись руководителями Заявлений о взыскании за счет имущества ФЛ
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал хороших (обработанных)</param>
        public void SignatureHeadProperty(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click24(statusButton, pathJournalError, pathJournalOk);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);

                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }


        /// <summary>
        /// Обработка отказов по ЛК 2 ветка 05.09 Сообщения о принятом решении об отказе  подлежащие выгрузке в ЛК
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал хороших (обработанных)</param>
        public void RecouncementLk(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click23(statusButton,pathjurnalerror, pathjurnalok);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);

                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }


        /// <summary>
        /// Обработка сообщений ЛК2
        /// </summary>
        /// <param name="statusButton">Кнопка старт </param>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал хороших (обработанных)</param>
        public void MessageLk(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok)
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
                        var strexit = clickerButton.Click16(pathjurnalerror, pathjurnalok);
                        
                        if (strexit.Equals(LibraryAIS3Windows.Status.StatusAis.Status6))
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
        /// </summary>
        /// <param name="statusButton">Кнопка старт </param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал хороших (обработанных)</param>
        public void FormTrebUplNaloga(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
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
                        clickerButton.Click17(statusButton);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }
        /// <summary>
        /// Подстановка даты вручения в ветке 
        /// Налоговое администрирование\Урегулирование задолженности\Требования об уплате\Журнал требований об уплате
        /// </summary>
        /// <param name="statusButton">Кнопка старт </param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал хороших (обработанных)</param>
        public void AutoRequirementsLog(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click22(statusButton, pathJournalError, pathJournalOk);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }

        /// <summary>
        /// Функция утверждения служебной записки
        /// </summary>
        /// <param name="statusButton">Кнопка старт </param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал хороших (обработанных)</param>
        public void AutoStatementOfficeNote(StatusButtonMethod statusButton, string pathJournalError,string pathJournalOk)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click25(statusButton, pathJournalError, pathJournalOk);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }

        /// <summary>
        /// Функция подписание служебной записки
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал хороших (обработанных)</param>
        public void AutoSignatureOfficeNote(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click26(statusButton, pathJournalError, pathJournalOk);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }
        /// <summary>
        /// Функция подписания по ветки
        /// Общие задания\Урегулирование задолженности\05.09 Формирование решения об отказе по заявлению\Подписание руководителем НО
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        public void SigningDecisionApplication(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click31(statusButton);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }

        /// <summary>
        /// Запуск БП
        /// Налоговое администрирование\Урегулирование задолженности\Взыскание задолженности за счет ден. средств\Запуск БП
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathList">Полный путь к списку с ИНН</param>
        public void StartProcess(StatusButtonMethod statusButton, string pathList)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathList))
            {
                Task.Run(delegate
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                    object obj = read.ReadXml(pathList, typeof(AutoGenerateSchemes));
                    AutoGenerateSchemes modelList = (AutoGenerateSchemes)obj;
                    if (ais3.WinexistsAis3() == 1)
                    {
                        foreach (var modelListTaxArr in modelList.TaxArrears)
                        {
                            if (statusButton.Iswork)
                            {
                                clickerButton.Click35(modelListTaxArr.Inn, modelListTaxArr.Kpp);
                                read.DeleteAtributXml(pathList, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemes(modelListTaxArr.Inn));
                            }
                        }
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                });
            }
        }
        /// <summary>
        /// Заявление о зачете возврате
        /// </summary>
        /// <param name="statusButton">Кнопка автомата</param>
        public void StartProcessStatementNp(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click43(statusButton);
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
