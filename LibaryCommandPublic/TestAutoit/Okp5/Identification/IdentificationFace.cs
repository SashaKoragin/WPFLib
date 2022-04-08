using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace LibraryCommandPublic.TestAutoit.Okp5.Identification
{
   public class IdentificationFace
    {
        /// <summary>
        /// Запуск автомата для идентификации лиц по списку из БД
        /// </summary>
        /// <param name="statusButton">Кнопка статуса</param>
        /// <param name="modelSelect">Модель выборки</param>
        public void StartIdentification<T>(StatusButtonMethod statusButton, PublicModelCollectionSelect<T> modelSelect)
        {
            DispatcherHelper.Initialize();
            if (modelSelect.IsValidation())
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
                            clickerButton.Click32(statusButton, (modelSelect.SelectModel as UniversalCollection)?.Parameter);
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
                    }
                });
            }
        }

        /// <summary>
        /// Налоговое администрирование\Контрольная работа(налоговые проверки)\
        /// 121. Камеральная налоговая проверка\03. Реестр налоговых деклараций(расчетов), сведения о КНП(все)
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        /// <param name="pathPdfTemp">Genm к Temp</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        public void StartRegisterDeclarations(StatusButtonMethod statusButton, string pathPdfTemp, DatePickerAdd datePicker)
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
                        clickerButton.Click28(statusButton, pathPdfTemp, datePicker);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.ToString());
                }
            });
        }

        /// <summary>
        /// Налоговое администрирование\Контрольная работа(налоговые проверки)\
        /// 121. Камеральная налоговая проверка\03. Реестр налоговых деклараций(расчетов), сведения о КНП(все)
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        /// <param name="pathPdfTemp">Genm к Temp</param>
        public void StartRegisterDeclarationsErrorOkp1(StatusButtonMethod statusButton, string pathPdfTemp)
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
                        clickerButton.Click40(statusButton, pathPdfTemp);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.ToString());
                }
            });
        }

        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\114. ЕАЭС-обмен\03. Реестр исходящих документов для обработки и отправки
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        /// <param name="pathPdfTemp">Путь к Temp</param>
        public void StartSubscribe(StatusButtonMethod statusButton, string pathPdfTemp)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    var clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click44(statusButton, pathPdfTemp);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.ToString());
                }
            });
        }

    }
}
