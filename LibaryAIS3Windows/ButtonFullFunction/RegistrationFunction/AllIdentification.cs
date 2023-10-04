using AutoIt;
using LibaryXMLAuto.XsdModelAutoGenerate;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.Registration;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.RegistrationFunction
{
    public class IdentificationFl
    {
        /// <summary>
        /// Ветка Налоговое администрирование\Централизованный учет налогоплательщиков\18. Действия к выполнению\2.09. Ручная идентификация физического лица
        /// </summary>
        private string TreeIdentification = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\18. Действия к выполнению\\2.09. Ручная идентификация физического лица";


        /// <summary>
        /// Автомат на ветку Налоговое администрирование\Централизованный учет налогоплательщиков\18. Действия к выполнению\2.09. Ручная идентификация физического лица
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathListStatement">Полный путь к списку с уникальными номерами</param>
        public void IdentificationFlStart(StatusButtonMethod statusButton, string pathListStatement)
        {
            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
            object obj = read.ReadXml(pathListStatement, typeof(AutoGenerateSchemes));
            AutoGenerateSchemes modelListIncomeJournal = (AutoGenerateSchemes)obj;
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            var sw = TreeIdentification.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeIdentification);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            if (modelListIncomeJournal.IdentytiFace != null)
            {
                foreach (var id in modelListIncomeJournal.IdentytiFace)
                {
                    if (statusButton.Iswork)
                    {
                        parametersModel.DataAreaIdentificationFl.Parameters.First(parameters => parameters.NameParameters == "УН входящего документа").ParametersGrid = id.Id.ToString();
                        foreach (var dataAreaParameters in parametersModel.DataAreaIdentificationFl.Parameters)
                        {
                            while (true)
                            {
                                if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataAreaIdentificationFl.FullPathDataArea, parametersModel.DataAreaIdentificationFl.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                                {
                                    libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                                    libraryAutomation.FindElement.SetFocus();
                                    SendKeys.SendWait("{ENTER}");
                                    AutoItX.Sleep(1000);
                                    SendKeys.SendWait(dataAreaParameters.ParametersGrid);
                                    SendKeys.SendWait("{ENTER}");
                                    while (true)
                                    {
                                        libraryAutomation.FindFirstElement("Name:Условие", libraryAutomation.FindFirstElement(string.Concat(
                                                    parametersModel.DataAreaIdentificationFl.FullPathDataArea,
                                                    parametersModel.DataAreaIdentificationFl.ListRowDataArea,
                                                    dataAreaParameters.IndexParameters), null, true), true);
                                        libraryAutomation.ClickElement(libraryAutomation.FindElement);
                                        if (libraryAutomation.FindFirstElement("Name:DropDown") != null)
                                        {
                                            var memo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                                            var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == dataAreaParameters.FindSelectParameter);
                                            libraryAutomation.ClickElement(elemClick);
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaIdentificationFl.Update);
                        PublicGlobalFunction.PublicGlobalFunction.IsWaitLoadtatuBar(libraryAutomation, PublicGlobalFunction.PublicGlobalFunction.StatusBar);
                        var findElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(parametersModel.DataAreaIdentificationFl.FullPathGrid)).Cast<AutomationElement>().Where(elem => elem.Current.Name == parametersModel.DataAreaIdentificationFl.ListRowDataGrid).Distinct().FirstOrDefault();
                        if (findElement != null)
                        {
                            while (true)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IdentificationDocument.StartEvent);
                                var isError = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, IdentificationDocument.GridIsError);
                                if (isError == null || isError.Equals(""))
                                {
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IdentificationDocument.SelectFl);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IdentificationDocument.QwesionYes);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IdentificationDocument.Ok);
                                    break;
                                }
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IdentificationDocument.Closed);
                            }
                        }
                        read.DeleteAtributXml(pathListStatement, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemesDeleteIdDoc(id.Id.ToString()));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaIdentificationFl.Filters);
                    }
                }
            }
            MouseCloseFormRsb(1);
        }



        /// <summary>
        /// Закрыть подчиненные формы
        /// </summary>
        private void MouseCloseFormRsb(int countClose)
        {
            var win = new WindowsAis3();
            while (countClose > 0)
            {
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                countClose--;
            }
        }
    }
}
