using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.ButtonsClikcs.SelectQbe;
using LibraryAIS3Windows.ExitLogica;
using LibaryXMLAutoModelXmlAuto.FpdReg;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using LibraryAIS3Windows.Window;
using LibraryCommandPublic.EventQbe.Reg;
using ViewModelLib.ModelTestAutoit.PublicModel.QbeSelect;
using ViewModelLib.ModelTestAutoit.PublicModel.SelectBranch;

namespace LibraryCommandPublic.TestAutoit.Reg.TreatmentFPD.Zemly
{
   public class Zemly
    {
        /// <summary>
        /// Команда отработки пользовательского задания Регистрациии 
        /// Налоговое администрирование\Собственность\05. Взаимодействие с органами Росреестра – Земельные участки\03. Обработка ФПД  от РР - ФЛ - Анализ результатов обработки документов
        /// Можно пропустить и другие ветки логика меняется только в  Click3
        /// </summary>
        /// <param name="qbeselect">Значения ФПД </param>
        /// <param name="branch">Ветка для обработки режима</param>
        /// <param name="statusButton">Модель кнопки </param>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал ОК</param>
        /// <param name="pathfilefpd">Значения ФПД </param>
        public void ZemlyAuto(QbeClass qbeselect, Branch branch,StatusButtonMethod statusButton,string pathfilefpd, string pathjurnalerror, string pathjurnalok)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathfilefpd))
            {
                if (branch.IsValidation())
                {
                    Task.Run(delegate
                    {
                        try
                        {
                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                            KclicerButton clickerButton = new KclicerButton();
                            SelectEventQbe selectQbe = new SelectEventQbe();
                            SelectQbe qbeselectmethod = new SelectQbe();
                            Exit exit = new Exit();
                            WindowsAis3 ais = new WindowsAis3();
                            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read =
                            new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                            object obj = read.ReadXml(pathfilefpd, typeof(LibaryXMLAutoModelXmlAuto.FpdReg.TreatmentFPD));
                            LibaryXMLAutoModelXmlAuto.FpdReg.TreatmentFPD fpdmodel = (LibaryXMLAutoModelXmlAuto.FpdReg.TreatmentFPD) obj;
                            if (ais.WinexistsAis3() == 1)
                            {
                                foreach (var fpd in fpdmodel.Fpd)
                                {
                                    if (statusButton.Iswork)
                                    {
                                        if (statusButton.IsChekcs)
                                        {
                                            selectQbe.AddEvent(qbeselect, branch, qbeselectmethod);
                                            selectQbe.RemoveEvent(branch, qbeselectmethod);
                                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.IsCheker);
                                        }
                                        clickerButton.Click3(fpd.FpdId, pathjurnalerror, pathjurnalok);
                                        read.DeleteAtributXml(pathfilefpd,
                                            LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtributeFpd(
                                                fpd.FpdId));
                                        statusButton.Count++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                var status = exit.Exitfunc(statusButton.Count, fpdmodel.Fpd.Length, statusButton.Iswork);
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
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                    });
                }
            }
            else
            {
                MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status5);
            }
        }
    }
}
