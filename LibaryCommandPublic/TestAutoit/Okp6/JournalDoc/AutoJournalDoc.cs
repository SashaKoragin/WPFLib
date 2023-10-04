using System;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListYearReport;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryCommandPublic.TestAutoit.Okp6.JournalDoc
{
    public class AutoJournalDoc
    {
        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\121. Камеральная налоговая проверка\04. Журнал документов, выписанных в ходе налоговой проверки
        /// </summary>
        /// <param name="statusButton">Кнопка проставить Даты вручения</param>
        public void StartDateJournalDoc(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click34(statusButton);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }

        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        /// <param name="pathPdfTemp">Путь к выгрузке файлов для анализа</param>
        public void StartRegistryDeclaration(StatusButtonMethod statusButton, string pathPdfTemp)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click28(statusButton, pathPdfTemp, null);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }
            });
        }

        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)
        /// Закрытие комплекса мероприятий
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        public void StartDeclarationComplexClosed(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click51(statusButton);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }
            });
        }

        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)
        /// Проверить завершить закрыть декларацию
        /// </summary>
        /// <param name="statusButton">Кнопка проставить Даты вручения</param>
        /// <param name="pathTemp">Путь к папке с выгрузкой</param>
        public void StartCheckDeclaration(StatusButtonMethod statusButton, string pathTemp)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click47(statusButton, pathTemp);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }
            });
        }

        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)
        /// Проставить срок проверки декларации
        /// </summary>
        /// <param name="statusButton">Кнопка проставить Даты вручения</param>
        public void StartAddTerm(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click49(statusButton);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }
            });
        }

        /// <summary>
        /// Выставление решения
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\04. Реестр расчетов по продаже и(или) дарению объектов недвижимости в подлежащих КНП в соответствии с п.1.2 ст. 88НК
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        /// <param name="pathPdfTemp">Путь к выгрузке файлов для анализа</param>
        public void StartDeclarationCalculation(StatusButtonMethod statusButton, string pathPdfTemp)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click52(statusButton, pathPdfTemp, null);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }
            });
        }

        /// <summary>
        /// Выставление требований
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\04. Реестр расчетов по продаже и(или) дарению объектов недвижимости в подлежащих КНП в соответствии с п.1.2 ст. 88НК
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        /// <param name="pathPdfTemp">Путь к выгрузке файлов для анализа</param>
        public void StartAddRequirements(StatusButtonMethod statusButton, string pathPdfTemp)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click53(statusButton, pathPdfTemp);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }
            });
        }

        /// <summary>
        /// Автомат на поиск фактов владения и документов к ним Налоговое администрирование\Собственность\01. Картотека собственности ФБД\07. КС – ЗУ – Факты владения на земельные участки – ФЛ
        /// Поиск сведений о земле
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="listYearReport">Отчетный год</param>
        /// <param name="pathListStatement">Полный путь к списку с ИНН</param>
        /// <param name="pathTemp">Путь к папке Temp</param>
        public void FindOwnerFactFlZm(StatusButtonMethod statusButton, ListYearReport listYearReport,
            string pathListStatement, string pathTemp)
        {
            DispatcherHelper.Initialize();
            if (listYearReport.IsValidation())
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
                            clickerButton.Click58(statusButton, pathListStatement, pathTemp, listYearReport.YearReport);
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        throw;
                    }
                });
            }
        }

        /// <summary>
        /// Автомат на поиск фактов владения и документов к ним Налоговое администрирование\\Собственность\\01. Картотека собственности ФБД\\23. КС – ОН – Факты владения на объекты недвижимости – ФЛ
        /// Поиск сведений о имуществе
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="listYearReport">Отчетный год</param>
        /// <param name="pathListStatement">Полный путь к списку с ИНН</param>
        /// <param name="pathTemp">Путь к папке Temp</param>
        public void FindOwnerFactFlIm(StatusButtonMethod statusButton, ListYearReport listYearReport, string pathListStatement, string pathTemp)
        {
            DispatcherHelper.Initialize();
            if (listYearReport.IsValidation())
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
                            clickerButton.Click59(statusButton, pathListStatement, pathTemp, listYearReport.YearReport);
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        throw;
                    }
                });
            }
        }
    }
}