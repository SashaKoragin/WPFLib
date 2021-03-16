using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using System.Windows.Forms;
using LibaryXMLAutoModelXmlAuto.MigrationReport;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.It;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.ItFunctionAutomation
{
    public class ItFunctionAutomation
    {
        /// <summary>
        /// Ветка мои роли
        /// </summary>
        private string modelTreeMyRule = "Налоговое администрирование\\ЦСУД\\Управление ролевой принадлежностью\\Мои роли";
        /// <summary>
        /// Ветка Просмотр ролей
        /// </summary>
        private string modelSettingRule = "Налоговое администрирование\\ЦСУД\\Управление ролевой принадлежностью\\Просмотр ролей";

        /// <summary>
        /// Сбор информации о шаблонах папках и ветках и ролях по ветке modelTree
        /// </summary>
        /// <param name="statusButton">Кнопка запуска</param>
        /// <param name="pathJournalInfoRule">Путь сохранения информации</param>
        public void SelectAllTemplateAndRule(StatusButtonMethod statusButton, string pathJournalInfoRule)
        {
            var rowNumber = 1;
            var sw = modelTreeMyRule.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (!libraryAutomation.IsEnableExpandTree(modelTreeMyRule)) return;
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.ApplicationTab);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.ButtonAdd);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.AutoInfo);
            libraryAutomation.IsEnableElement(ItElementName.GridRule);

            if (File.Exists(pathJournalInfoRule))
            {
                var readFileInfoRule = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                var fileInfoRuleTemplate = (InfoRuleTemplate)readFileInfoRule.ReadXml(pathJournalInfoRule, typeof(InfoRuleTemplate));
                var nameAttributes = fileInfoRuleTemplate.SystemAis.Last().Name;
                var index = 0;
                libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>()
                   .Where(elem => elem.Current.Name.Contains("List`"))
                   .ToList().ForEach(element =>
                   {
                       if (libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(element)
                                  .Cast<AutomationElement>()
                                  .First(elem => elem.Current.Name.Contains("Подсистема"))) == nameAttributes)
                       {
                           rowNumber = index;
                       }
                       index++;
                   });
                readFileInfoRule.DeleteAtributXml(pathJournalInfoRule, $"/InfoRuleTemplate/SystemAis[@Name=\"{nameAttributes}\"]"); //?? Сомнительная операция!!! Надо проверять
            }

            AutomationElement automationElementRow;
            while ((automationElementRow = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListRow, rowNumber), null, true, 30)) != null)
            {
                if (statusButton.Iswork)
                {
                    var infoRuleTemplate = new InfoRuleTemplate() { SystemAis = new SystemAis[1] };
                    automationElementRow.SetFocus();
                    SendKeys.SendWait(ButtonConstant.Plus);
                    infoRuleTemplate.SystemAis[0] = new SystemAis()
                    {
                        Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                             libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Подсистема")))
                    };

                    var foldersNumber = 1;
                    var listFolder = libraryAutomation
                        .SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                        .Where(elem => elem.Current.Name.Contains("Folders row"));
                    infoRuleTemplate.SystemAis[0].Folders = new Folders[listFolder.Count()];

                    AutomationElement automationElementFolder;
                    while ((automationElementFolder = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListFolders, rowNumber, foldersNumber), null, true, 30)) != null)
                    {
                        automationElementFolder.SetFocus();
                        SendKeys.SendWait(ButtonConstant.Plus);

                        infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1] = new Folders()
                        {
                            Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElementFolder)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Папка")))
                        };

                        var tasksNumber = 1;
                        var listTask = libraryAutomation
                           .SelectAutomationColrction(automationElementFolder).Cast<AutomationElement>()
                           .Where(elem => elem.Current.Name.Contains("Tasks row"));

                        infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks = new Tasks[listTask.Count()];

                        AutomationElement automationElementTask;
                        while ((automationElementTask = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListTasks, rowNumber, foldersNumber, tasksNumber), null, true, 1)) != null)
                        {
                            automationElementTask.SetFocus();
                            SendKeys.SendWait(ButtonConstant.Plus);

                            infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks[tasksNumber - 1] = new Tasks()
                            {
                                Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElementTask)
                                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Задача"))),
                                TypeTask = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElementTask)
                                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Тип"))),
                                Curator = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElementTask)
                                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Куратор")))
                            };

                            var rolesNumber = 1;

                            var listRole = libraryAutomation
                                .SelectAutomationColrction(automationElementTask).Cast<AutomationElement>()
                                .Where(elem => elem.Current.Name.Contains("Roles row"));
                            infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks[tasksNumber - 1]
                                .RolesTemplate = new RolesTemplate[listRole.Count()];


                            AutomationElement automationElementRole;
                            while ((automationElementRole = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListRoles, rowNumber, foldersNumber, tasksNumber, rolesNumber), null, true, 1)) != null)
                            {
                                automationElementRole.SetFocus();
                                SendKeys.SendWait(ButtonConstant.Plus);

                                infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks[tasksNumber - 1]
                                    .RolesTemplate[rolesNumber - 1] = new RolesTemplate()
                                    {
                                        Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElementRole)
                                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Роль")))
                                    };
                                var taskTemplateNumber = 1;

                                var listTaskTemplate = libraryAutomation
                                    .SelectAutomationColrction(automationElementRole).Cast<AutomationElement>()
                                    .Where(elem => elem.Current.Name.Contains("TaskTemplates row"));
                                infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks[tasksNumber - 1]
                                    .RolesTemplate[rolesNumber - 1].Templates = new Templates[listTaskTemplate.Count()];

                                AutomationElement automationElementTaskTemplate;
                                while ((automationElementTaskTemplate = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListTaskTemplates, rowNumber, foldersNumber, tasksNumber, rolesNumber, taskTemplateNumber), null, true, 1)) != null)
                                {
                                    automationElementTaskTemplate.SetFocus();

                                    infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1]
                                        .Tasks[tasksNumber - 1].RolesTemplate[rolesNumber - 1]
                                        .Templates[taskTemplateNumber - 1] = new Templates()
                                        {
                                            Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.SelectAutomationColrction(automationElementTaskTemplate)
                                                .Cast<AutomationElement>()
                                                .First(elem => elem.Current.Name.Contains("Шаблон"))),
                                            Category = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.SelectAutomationColrction(automationElementTaskTemplate)
                                                .Cast<AutomationElement>()
                                                .First(elem => elem.Current.Name.Contains("Категории")))
                                        };
                                    taskTemplateNumber++;
                                }
                                automationElementRole.SetFocus();
                                SendKeys.SendWait(ButtonConstant.Minus);
                                rolesNumber++;
                            }
                            automationElementTask.SetFocus();
                            SendKeys.SendWait(ButtonConstant.Minus);
                            tasksNumber++;
                        }
                        automationElementFolder.SetFocus();
                        SendKeys.SendWait(ButtonConstant.Minus);
                        foldersNumber++;
                    }
                    automationElementRow.SetFocus();
                    SendKeys.SendWait(ButtonConstant.Minus);
                    LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateFileInfoRuleTemplate(pathJournalInfoRule, infoRuleTemplate);
                    rowNumber++;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Сбор информации о пользователях и их ролей с шаблонами
        /// </summary>
        /// <param name="statusButton">Кнопка запуска</param>
        /// <param name="pathJournalInfoUserTemplateRule">Путь сохранения информации по пользователям и их ролям с шаблонами</param>
        public void SelectAllUserTemplateAndRule(StatusButtonMethod statusButton, string pathJournalInfoUserTemplateRule)
        {
            var rowNumber = 1;
            var sw = modelSettingRule.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (!libraryAutomation.IsEnableExpandTree(modelSettingRule)) return;
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.ApplicationTabUsers);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.FindUsers);
            libraryAutomation.IsEnableElement(ItElementName.ListRowUsersGrid);

            if (File.Exists(pathJournalInfoUserTemplateRule))
            {
                var readFileInfoRule = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                var fileInfoRuleTemplate = (InfoUserTemlateAndRule)readFileInfoRule.ReadXml(pathJournalInfoUserTemplateRule, typeof(InfoUserTemlateAndRule));
                var nameAttributes = fileInfoRuleTemplate.Users.Last().Name;
                var elementNumbers = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)
                    .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List`")).ToList()
                    .FirstOrDefault(element => libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(element)
                    .Cast<AutomationElement>()
                    .First(elem => elem.Current.Name.Contains("Пользователь"))) == nameAttributes);
                if (elementNumbers != null)
                    rowNumber = Convert.ToInt32(Regex.Matches(elementNumbers.Current.Name, @"(\d{1,4})").Cast<Match>()
                        .Select(m => m.Value).ToArray().Last());
                readFileInfoRule.DeleteAtributXml(pathJournalInfoUserTemplateRule, $"/InfoUserTemlateAndRule/Users[@Name=\"{nameAttributes}\"]"); //?? Сомнительная операция!!! вроде +1 делать надо Надо проверять
            }



            AutomationElement automationElementRow;
            while ((automationElementRow = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListRowUsers, rowNumber), null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    var infoRuleTemplate = new InfoUserTemlateAndRule() { Users = new Users[1] };
                    automationElementRow.SetFocus();
                    AutoIt.AutoItX.Sleep(1000);
                    infoRuleTemplate.Users[0] = new Users()
                    {
                        Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Пользователь"))),
                        Code = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Код НО")))),
                        TabelNumber = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Табельный номер"))),
                        Department = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Отдел"))),
                        Position = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Должность"))),
                        Organization = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Организация"))),
                        Bloking = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Блокировка"))),
                        NumberActiveDirectory = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Учетная запись"))),
                        DateIn = string.IsNullOrWhiteSpace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Дата входа в ЕКП"))))
                                ? (DateTime?)null
                                : Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("Дата входа в ЕКП"))))
                    };
                    var containerTab = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(ItElementName.ApplicationContainerTab, null, true));
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.ApplicationTabTemplate, containerTab[1]);
                    var templatesNumber = 1;

                    List<AutomationElement> listTemplate = libraryAutomation.SelectAutomationColrction(
                                            libraryAutomation.IsEnableElements(ItElementName.ListAllTemplatesUsers, containerTab[1], true, 1)).Cast<AutomationElement>()
                                            .Where(elem => elem.Current.Name.Contains("List`1 row")).ToList();
                   infoRuleTemplate.Users[0].Template = new Template[listTemplate.Count()];

                    foreach(AutomationElement automationElement in listTemplate)
                    { 
                        automationElement.SetFocus();
                        infoRuleTemplate.Users[0].Template[templatesNumber - 1] = new Template()
                        {
                            NameTemplate = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElement)
                                    .Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Шаблон"))),

                            DateStart = string.IsNullOrWhiteSpace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElement)
                                    .Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Дата начала"))))
                                ? (DateTime?)null
                                : Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation.SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("Дата начала")))),

                            DateFinish = string.IsNullOrWhiteSpace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElement)
                                    .Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Дата окончания"))))
                                ? (DateTime?)null
                                : Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation.SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("Дата окончания")))),

                            Info = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElement)
                                    .Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Описание"))),

                            Category = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElement)
                                    .Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Категории"))),
                        };
                        templatesNumber++;
                    }

                    var sigmentNumber = 1;
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.ApplicationTabRule, containerTab[1]);

                    List<AutomationElement> listSegment = libraryAutomation.SelectAutomationColrction(
                                          libraryAutomation.IsEnableElements(ItElementName.ListAllRulesUsers, containerTab[1], true, 1)).Cast<AutomationElement>()
                                          .Where(elem => elem.Current.Name.Contains("List`1 row")).ToList();
                        infoRuleTemplate.Users[0].Sigment = new Sigment[listSegment.Count()];
                    foreach(AutomationElement automationElementTemplates in listSegment)
                    {

                        automationElementTemplates.SetFocus();
                        SendKeys.SendWait(ButtonConstant.Plus);

                        infoRuleTemplate.Users[0].Sigment[sigmentNumber - 1] = new Sigment()
                        {
                            Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElementTemplates)
                                    .Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Сегмент")))
                        };

                        List<AutomationElement> listApp = libraryAutomation.SelectAutomationColrction(automationElementTemplates).Cast<AutomationElement>()
                                                          .Where(elem => elem.Current.Name.Contains("Apps row")).ToList();
                        infoRuleTemplate.Users[0].Sigment[sigmentNumber - 1].Applications = new Applications[listApp.Count()];

                        var rulesAppNumber = 1;
                        foreach (AutomationElement automationElementTemplatesRulesApp in listApp)
                        {
                            automationElementTemplatesRulesApp.SetFocus();
                            SendKeys.SendWait(ButtonConstant.Plus);
                            infoRuleTemplate.Users[0].Sigment[sigmentNumber - 1].Applications[rulesAppNumber - 1] = new Applications()
                            {
                                Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation.SelectAutomationColrction(automationElementTemplatesRulesApp)
                                        .Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("Приложение")))
                            };

                            List<AutomationElement> listRole = libraryAutomation.SelectAutomationColrction(automationElementTemplatesRulesApp).Cast<AutomationElement>()
                                          .Where(elem => elem.Current.Name.Contains("RoleList row")).ToList();
                            infoRuleTemplate.Users[0].Sigment[sigmentNumber - 1].Applications[rulesAppNumber - 1].RuleTemplate = new RuleTemplate[listRole.Count()];

                            var rulesRulesAppRuleNumber = 1;
                            foreach (AutomationElement automationElementTemplatesRulesAppRule in listRole)
                            {
                                infoRuleTemplate.Users[0].Sigment[sigmentNumber - 1].Applications[rulesAppNumber - 1].RuleTemplate[rulesRulesAppRuleNumber - 1] = new RuleTemplate()
                                {
                                    NameRule = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElementTemplatesRulesAppRule)
                                            .Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("Роль"))),
                                 
                                    DateStart = string.IsNullOrWhiteSpace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElementTemplatesRulesAppRule)
                                            .Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("Дата начала"))))
                                        ? (DateTime?)null
                                        : Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.SelectAutomationColrction(automationElementTemplatesRulesAppRule)
                                                .Cast<AutomationElement>()
                                                .First(elem => elem.Current.Name.Contains("Дата начала")))),

                                    DateFinish = string.IsNullOrWhiteSpace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElementTemplatesRulesAppRule)
                                            .Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("Дата окончания"))))
                                        ? (DateTime?)null
                                        : Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.SelectAutomationColrction(automationElementTemplatesRulesAppRule)
                                                .Cast<AutomationElement>()
                                                .First(elem => elem.Current.Name.Contains("Дата окончания")))),

                                    Info = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElementTemplatesRulesAppRule)
                                            .Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("Описание"))),

                                    Category = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElementTemplatesRulesAppRule)
                                            .Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("Категории"))),
                                };
                                rulesRulesAppRuleNumber++;
                            }
                            automationElementTemplatesRulesApp.SetFocus();
                            AutoIt.AutoItX.Sleep(500);
                            SendKeys.SendWait(ButtonConstant.Minus);
                            rulesAppNumber++;
                        }
                        automationElementTemplates.SetFocus();
                        AutoIt.AutoItX.Sleep(500);
                        SendKeys.SendWait(ButtonConstant.Minus);
                        sigmentNumber++;
                    }
                    LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateFileInfoUserRuleTemplate(pathJournalInfoUserTemplateRule, infoRuleTemplate);
                    rowNumber++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
