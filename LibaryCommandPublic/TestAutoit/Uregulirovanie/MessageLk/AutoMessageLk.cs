using System;
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
                    clickerButton.Click24(statusButton);
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
        public void FormRequirementUplTax(StatusButtonMethod statusButton)
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
        public void AutoStatementOfficeNote(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click25(statusButton);
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
        public void AutoSignatureOfficeNote(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click26(statusButton);
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
        /// Функция утверждение решений
        /// Общие задания\Урегулирование задолженности\05.09 Формирование решения об отказе по заявлению\Утверждение решений об отказе
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        public void StatementDecisionApplication(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click44(statusButton);
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
        /// Запуск задание на ветку
        /// Налоговое администрирование\Урегулирование задолженности\Взыскание задолженности за счет имущества НП ФЛ\Ввод данных судебного акта
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathList">Полный путь к списку с ИНН</param>
        public void StartProcessAct(StatusButtonMethod statusButton, string pathList)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathList))
            {
                Task.Run(delegate
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click50(statusButton, pathList);
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
        /// <summary>
        /// Автомат на ветку Налоговое администрирование\Урегулирование задолженности\Техническая корректировка\Техническая корректировка. Ввод заявок
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathListStatement">Полный путь к списку с заявлениями о тех корректировки</param>
        public void TechAdjustmentStatement(StatusButtonMethod statusButton, string pathListStatement)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathListStatement))
            {
                Task.Run(delegate
                {
                    try
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                        KclicerButton clickerButton = new KclicerButton();
                        LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                        if (ais3.WinexistsAis3() == 1)
                        {
                            clickerButton.Click54(statusButton, pathListStatement);
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        }
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });
            }
        }
        /// <summary>
        /// Автомат на ветку Налоговое администрирование\Урегулирование задолженности\Техническая корректировка\Техническая корректировка. Согласование заявок
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        public void TechAdjustmentAgreement(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click55(statusButton);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }

        /// <summary>
        /// Очистка состояния обработки заявления
        /// </summary>
        /// <param name="statusButton"></param>
        public void StartClearStatusStatementNp(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click48(statusButton);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }

        /// <summary>
        /// Автомат на ветку
        /// Общие задания\Урегулирование задолженности\05.09 Ручное формирование решений на зачет/возврат/возврат процентов\05.09 Заявления НП для ручной обработки
        /// </summary>
        /// <param name="statusButton">Кнопка автомата</param>
        public void ApplicationManualProcessing(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click45(statusButton);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }
        /// <summary>
        /// Автомат на ветку
        /// Общие задания\Урегулирование задолженности\05.09.01(06.01) Формирование сообщения о факте излишней уплаты (излишнего взыскания)\05.09.01(06.01) Формирование сообщения об излишней уплате (взыскании)\Утверждение сообщений
        /// А так же на ветку 
        /// Общие задания\Урегулирование задолженности\05.09.01(06.01) Формирование сообщения о факте излишней уплаты (излишнего взыскания)\05.09.01(06.01) Формирование сообщения об излишней уплате (взыскании)\05.09.01(06.01) Формирование решений о зачете по инициативе НО\Утверждение решений о зачете
        /// </summary>
        /// <param name="statusButton">Кнопка автомата</param>
        public void MessageApprovalAndDecisionsApproval(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click46(statusButton);
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
