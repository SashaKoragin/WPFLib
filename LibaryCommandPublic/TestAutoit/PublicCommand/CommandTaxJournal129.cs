using System;
using System.Threading.Tasks;
using System.Windows;
using AisPoco.Ifns51.ToAis;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace LibraryCommandPublic.TestAutoit.PublicCommand
{
    public class CommandTaxJournal129
    {
        /// <summary>
        /// Автоматизация ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\
        /// 129. Налоговые правонарушения\
        /// 2. Журнал налоговых правонарушений
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        /// <param name="pathPdfTemp">Путь к Temp</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        /// <param name="templateSender">Модель шаблона к номеру</param>
        public void StartTaxJournal(StatusButtonMethod statusButton, string pathPdfTemp, DatePickerAdd datePicker, PublicModelCollectionSelect<TemplateModel> templateSender)
        {
            DispatcherHelper.Initialize();
            if (templateSender.IsValidation())
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
                            clickerButton.Click27(statusButton, pathPdfTemp, datePicker, templateSender.SelectModel);
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
    }
}
