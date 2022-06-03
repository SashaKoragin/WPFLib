using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibaryXMLAuto.XsdModelAutoGenerate;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryCommandPublic.TestAutoit.Reg.AcceptanceDocuments
{
   public class AcceptanceDocuments
    {
        /// <summary>
        /// Налоговое администрирование\Учет документов\Прием документов учета НП\Прием документов учета НП (ФЛ)
        /// по форме 1185
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        public void StartAcceptanceDocuments(StatusButtonMethod statusButton)
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
                        clickerButton.Click41(statusButton);
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
        /// Налоговое администрирование\Учет документов\Прием документов учета НП\Прием документов учета НП (ФЛ)
        /// по форме 1512
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        /// <param name="pathList">Путь к спискам</param>
        public void StartAcceptanceDocuments(StatusButtonMethod statusButton, string pathList)
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
                        foreach (var modelAddress in modelList.AddressModel)
                        {
                            if (statusButton.Iswork)
                            {
                                clickerButton.Click41(statusButton, modelAddress);
                                read.DeleteAtributXml(pathList, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemesDeleteFid(modelAddress.Fid));
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
    }
}
