using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using AisPoco.UserLoginScan;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.ExitLogica;
using LibraryAIS3Windows.Window;
using LibaryXMLAutoModelXmlAuto.FileVisualId;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace LibraryCommandPublic.TestAutoit.Reg.VisualTreatmentFace
{
   public class VisualTreatmentFace
    {
        /// <summary>
        /// Обработка визуальной идентификации
        /// </summary>
        /// <param name="statusButton">Модель кнопки</param>
        /// <param name="pathfileid">Путь к файлу с УН</param>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к журналу со сделанными</param>
        public void VisualFace(StatusButtonMethod statusButton, string pathfileid, string pathjurnalerror, string pathjurnalok)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathfileid))
            {
                Task.Run(delegate
                {
                    try
                    {
                    KclicerButton clickerButton = new KclicerButton();
                    Exit exit = new Exit();
                    WindowsAis3 ais = new WindowsAis3();
                    LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                    object obj = read.ReadXml(pathfileid, typeof(VisualIdent));
                    VisualIdent idmodel = (VisualIdent)obj;
                    if (idmodel.IdZapros != null)
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                        if (ais.WinexistsAis3() == 1)
                        {

                            foreach (var fpd in idmodel.IdZapros)
                            {
                                if (statusButton.Iswork)
                                {
                                    clickerButton.Click12(fpd.VisualId, pathjurnalerror, pathjurnalok,
                                         statusButton.IsChekcs, statusButton.IsLk2);
                                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.IsCheker);
                                    read.DeleteAtributXml(pathfileid,
                                        LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtributeIdIden(
                                            fpd.VisualId));
                                    statusButton.Count++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                        }
                        var status = exit.Exitfunc(statusButton.Count, idmodel.IdZapros.Length, statusButton.Iswork);
                        statusButton.Count = status.IsCount;
                        statusButton.Iswork = status.IsWork;
                        DispatcherHelper.CheckBeginInvokeOnUI(
                            delegate { statusButton.StatusGrinandYellow(status.Stat); });
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status7);
                    }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                });
            }
            else
            {
                MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status5);
            }
        }
        /// <summary>
        /// Автомат на ветку Налоговое администрирование\Централизованный учет налогоплательщиков\18. Действия к выполнению\2.09. Ручная идентификация физического лица
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathListStatement">Полный путь к списку с уникальными номерами</param>
        public void IdentificationFl(StatusButtonMethod statusButton, string pathListStatement)
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
                        WindowsAis3 ais3 = new WindowsAis3();
                        if (ais3.WinexistsAis3() == 1)
                        {
                            clickerButton.Click57(statusButton, pathListStatement);
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });
            }
        }
        /// <summary>
        /// Сканирование документов
        /// Налоговое администрирование\Централизованная система регистрации\Электронный архив\Запросить электронные образы документов дела из архива(преобразование) 
        ///
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="modelUser">Модель пользователей</param>
        public void ScanDocuments(StatusButtonMethod statusButton, PublicModelCollectionSelect<UserLoginDatabaseModel> modelUser)
        {
            DispatcherHelper.Initialize();
            if (modelUser.IsValidation())
            {
                Task.Run(delegate()
                {
                    try
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                        KclicerButton clickerButton = new KclicerButton();
                        WindowsAis3 ais3 = new WindowsAis3();
                        if (ais3.WinexistsAis3() == 1)
                        {
                            clickerButton.Click64(statusButton, modelUser);
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });
            }
        }
        /// <summary>
        /// Автоматизация комплектования Тары
        /// </summary>
        /// <param name="statusButton">Кнопка Старт автомат</param>
        public void ScanAddContainer(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate ()
            {
                 try
                 {
                     DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                     KclicerButton clickerButton = new KclicerButton();
                     WindowsAis3 ais3 = new WindowsAis3();
                     if (ais3.WinexistsAis3() == 1)
                     {
                         clickerButton.Click65(statusButton);
                         DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                     }
                     else
                     {
                         MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                     }
                 }
                 catch (Exception e)
                 {
                     MessageBox.Show(e.Message);
                 }
                });
            }
    }
}
