using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.Okp1;
using LibraryAIS3Windows.Window;
using System;
using System.IO;
using System.Linq;
using System.Windows.Automation;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp1Function
{
    public class EasJournalAutomation
    {
        /// <summary>
        /// Путь Сохранения Документа как правило Temp Пользователя
        /// По формам КНД 1151085 и КНД 1151006
        /// </summary>
        private string PathTempSave { get; }

        /// <summary>
        /// <param name="pathTemp">Путь Сохранения Документа как правило Temp Пользователя</param>
        /// </summary>
        public EasJournalAutomation(string pathTemp)
        {
            PathTempSave = pathTemp;
        }

        /// <summary>
        /// Запуск процесса подписание и отправка документа 114. ЕАЭС-обмен
        /// </summary>
        /// <param name="statusButton">Кнопка запустить</param>
        public void SubscribeDocument(StatusButtonMethod statusButton)
        {
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var senderSelect = new SelectAll().SelectSenderJournal(Environment.UserName);
            if (senderSelect == null)
            {
                throw new InvalidOperationException("Пользователь подписывающий документ не определен!");
            }
            AutomationElement automationElement;
            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(ModelElementName.SelectRow, 1), null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    var easJournal = new EasJournal
                    {
                        LoginUser = Environment.UserName,
                        RegNumber = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер")))),
                        RegNumberZ = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem =>
                                    elem.Current.Name.Contains(
                                        "Регистрационный номер Заявления, присвоенный налоговым органом")))),
                        Knd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КНД"))),
                        NameKnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Документ"))),
                        DateDocument = Convert.ToDateTime(
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Дата документа")))),
                        Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН"))),
                        Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП"))),
                        NameNp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Налогоплательщик")))
                    };
                    var status = libraryAutomation.SelectAutomationColrction(automationElement)
                                 .Cast<AutomationElement>().Where(automationElements => automationElements.Current.Name == "").ToList();
                    easJournal.Color = libraryAutomation.GetColorPixel(status[0]);
                    easJournal.Color1 = libraryAutomation.GetColorPixel(status[1]);
                    //Если цвет серый то подписываем
                    if(easJournal.Color == "808080")
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementName.Subscribe);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(ModelElementName.WinSubscribe, null, true) != null)
                            {
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(ModelElementName.WinSubscribe), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementName.OkSubscribe);
                                AutoItX.Sleep(10000);
                                PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, ModelElementName.Grid);
                                break;
                            }
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementName.Print);
                    AddFile(ref easJournal);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementName.Send);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementName.SendDocument);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementName.WinOk);
                    automationElement.SetFocus();
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementName.Update);
                    var count = 3;
                    while (true)
                    {
                        var grid = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, ModelElementName.Grid);
                        if (string.IsNullOrWhiteSpace(grid))
                        {
                            break;
                        }
                        if (grid == "Данные, удовлетворяющие заданным условиям не найдены.")
                        {
                            break;
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementName.Update);
                        if (count == 0)
                        {
                            break;
                        }
                        count--;
                    }
                    SaveDocument(easJournal);
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Добавление файлов в Журнал
        /// </summary>
        /// <param name="easJournal">Журнал ЕАС</param>
        private void AddFile(ref EasJournal easJournal)
        {
            AutoItX.Sleep(5000);
            PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("AcroRd32", true);
            PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("FoxitPhantom", true);
            PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("Foxit Phantom", true);
            var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(PathTempSave, "*.pdf");
            easJournal.Mime = "application/pdf";
            easJournal.Extensions = file.ExtensionsFile;
            easJournal.NameFile = file.NameFile;
            byte[] byteFile;
            using (FileStream stream = new FileStream(file.NamePath, FileMode.Open))
            {
                byteFile = new byte[stream.Length];
                stream.Read(byteFile, 0, byteFile.Length);
            }
            easJournal.Document = byteFile;
        }

        /// <summary>
        /// Сохранение документа в БД
        /// </summary>
        /// <param name="easJournal">Добавление в ЕАС Журнал</param>
        private void SaveDocument(EasJournal easJournal)
        {
            var dbAutomation = new AddObjectDb();
            dbAutomation.AddEasJournal(easJournal);
            dbAutomation.Dispose();
        }

    }
}
