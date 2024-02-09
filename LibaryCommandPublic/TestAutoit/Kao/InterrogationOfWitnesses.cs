using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AisPoco.Ifns51.ToAis;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace LibraryCommandPublic.TestAutoit.Kao
{
    public class InterrogationOfWitnesses
    {


        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)
        /// Опрос свидетелей
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        ///<param name="templateSender">УН подписанта</param>
        public void StartInterrogationOfWitnesses(StatusButtonMethod statusButton, PublicModelCollectionSelect<TemplateModel> templateSender)
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
                            clickerButton.Click62(statusButton, templateSender.SelectModel.IdTemplate);
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        }
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
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
