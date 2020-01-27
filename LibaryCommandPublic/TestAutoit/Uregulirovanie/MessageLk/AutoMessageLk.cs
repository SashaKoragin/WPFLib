using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.Uregulirovanie.MessageLk
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
                LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click24(statusButton, pathJournalError, pathJournalOk);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);

                }
                else
                {
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
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
                LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click23(statusButton,pathjurnalerror, pathjurnalok);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);

                }
                else
                {
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
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
                LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    while (statusButton.Iswork)
                    {
                        var strexit = clickerButton.Click16(pathjurnalerror, pathjurnalok);
                        
                        if (strexit.Equals(LibaryAIS3Windows.Status.StatusAis.Status6))
                        {
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                    }

                }
                else
                {
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
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
                LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
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
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
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
                LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click22(statusButton, pathJournalError, pathJournalOk);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
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
                LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click25(statusButton, pathJournalError, pathJournalOk);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }

        /// <summary>
        /// Функция подписание служебной записки
        /// </summary>
        /// <param name="statusButton">Кнопка старт </param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал хороших (обработанных)</param>
        public void AutoSignatureOfficeNote(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click26(statusButton, pathJournalError, pathJournalOk);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }
    }
}
