using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using LibaryXMLAuto.ModelXmlAuto.MigrationReport;

namespace LibaryXMLAuto.ReadOrWrite
{
   public class XmlReadOrWrite
    {
        /// <summary>
        /// Дессериализация файла xml в объект
        /// </summary>
        /// <param name="filename">путь к файлу xml</param>
        /// <param name="objType">Тип объекта сериализации cs файла</param>
        public object ReadXml(string filename, Type objType)
        {
            using (Stream fs = new FileStream(filename, FileMode.Open))
            {
                XmlReader reader = new XmlTextReader(fs);
                XmlSerializer serializer = new XmlSerializer(objType);
                if (serializer.CanDeserialize(reader))
                {
                    var o = serializer.Deserialize(reader);
                    return o;
                }
            }
            return null;
        }

        /// <summary>
        /// Дессериализация текста xml из БД в объект
        /// </summary>
        /// <param name="text">Текст xml</param>
        /// <param name="objType">Тип объекта сериализации cs файла</param>
        /// <returns></returns>
        public object ReadXmlText(string text, Type objType)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            using (var stream = new MemoryStream()) {
                var writer = new StreamWriter(stream);
                writer.Write(text);
                writer.Flush();
                stream.Position = 0;
                XmlReader reader = new XmlTextReader(stream);
                XmlSerializer serializer = new XmlSerializer(objType);
                if (serializer.CanDeserialize(reader))
                {
                    object o = serializer.Deserialize(reader);
                    return o;
                }
            };
            return null;
        }
        /// <summary>
        /// Конвертация класса в XML
        /// </summary>
        /// <param name="classType">Класс объект</param>
        /// <param name="objType">Тип объекта</param>
        /// <returns></returns>
        public string ClassToXml(object classType, Type objType)
        {
            string xmlString;
            using (var stringWriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(objType);
                
                serializer.Serialize(stringWriter, classType);
                xmlString = stringWriter.ToString();
                stringWriter.GetStringBuilder().Clear();
                stringWriter.Flush();
                stringWriter.Close();
                stringWriter.Dispose();
            }
            return xmlString;
        }
        /// <summary>
        /// Создание xml файла
        /// </summary>
        /// <param name="pathToFullNameSave">Полный путь с расширением xml DeclarationData.xml</param>
        /// <param name="classType">Класс для сериализации</param>
        /// <param name="objType">Тип объекта</param>
        public void CreateXmlFile(string pathToFullNameSave, object classType, Type objType)
        {
            XmlSerializer writer = new XmlSerializer(objType);
            FileStream file = File.Create(pathToFullNameSave);
            writer.Serialize(file, classType);
            file.Close();
            file.Dispose();
        }


        /// <summary>
        /// Удаление Атрибута Образец поиска /players/player[@name="значение"]
        /// </summary>
        /// <param name="pathxml"></param>
        /// <param name="atribut"></param>
        public void DeleteAtributXml(string pathxml, string atribut)
        {
                var doc = LogicaXml.LogicaXml.Document(pathxml);
                XmlNode node = doc.SelectSingleNode(atribut);
                node.ParentNode.RemoveChild(node);
                doc.Save(pathxml);
        }
        /// <summary>
        /// Метод Добавление в журнал ошибки по схеме ErrorJurnal.xsd
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="znacenieinn">Значение в котором ошибка</param>
        /// <param name="branch">Ветка автоматизации</param>
        /// <param name="err">Ошибка</param>
        public void AddElementError(string path , string znacenieinn, string branch, string err)
        {
            var doc = LogicaXml.LogicaXml.Document(path);
            XmlElement xRoot = doc.DocumentElement;
            XmlElement error = doc.CreateElement("Error");
            error.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc,"Inn", znacenieinn));
            error.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Error", err));
            error.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "System", branch));
            error.Attributes.Append(CreateElement.CreteElement.AtributeAddDateNow(doc, "DateTimeUse"));
            xRoot.AppendChild(error);
            doc.Save(path);
        }
        /// <summary>
        /// Метод Добавление в журнал отработаных значений по схеме OkJurnal.xsd
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="znacenie">Значение</param>
        /// <param name="ok">Отработано</param>
        public void AddElementOk(string path, string znacenie,  string ok)
        {
            var doc = LogicaXml.LogicaXml.Document(path);
            XmlElement xRoot = doc.DocumentElement;
            XmlElement okey = doc.CreateElement("Ok");
            okey.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Inn", znacenie));
            okey.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Message", ok));
            okey.Attributes.Append(CreateElement.CreteElement.AtributeAddDateNow(doc, "DateTimeUse"));
            xRoot.AppendChild(okey);
            doc.Save(path);
        }
        /// <summary>
        /// Отчет ошибок по миграции НП
        /// </summary>
        /// <param name="path">Путь к xml отчету</param>
        /// <param name="report">Модель добавления в отчет</param>
        public void AddReportMigrationElemrnt(string path, MigrationParse report)
        {
            var doc = LogicaXml.LogicaXml.Document(path);
            XmlElement xRoot = doc.DocumentElement;
            XmlElement reportMigration = doc.CreateElement("ReportMigration");
            reportMigration.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "NameOrg", report.ReportMigration[0].NameOrg));
            reportMigration.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Inn", report.ReportMigration[0].Inn));
            reportMigration.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Kpp", report.ReportMigration[0].Kpp));
            reportMigration.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "CodeIfns", report.ReportMigration[0].CodeIfns));
            reportMigration.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Fid", report.ReportMigration[0].Fid));
            reportMigration.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Date", report.ReportMigration[0].Date));
            reportMigration.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Stage", report.ReportMigration[0].Stage));
            reportMigration.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Problem", report.ReportMigration[0].Problem));
            xRoot.AppendChild(reportMigration);
            doc.Save(path);
        }
        /// <summary>
        /// Модель пользователей и ролей xml
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="userRules">Модель парсинга</param>
        public void AddRuleUsers(string path, UserRules userRules)
        {
            var doc = LogicaXml.LogicaXml.Document(path);
            XmlElement xRoot = doc.DocumentElement;
            XmlElement userrules = doc.CreateElement("User");
            foreach (var user in userRules.User)
            {
                userrules.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Number",user.Number));
                userrules.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Dates", user.Dates));
                userrules.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Fio", user.Fio));
                userrules.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Dolj", user.Dolj));
                userrules.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Otdel", user.Otdel));
                userrules.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "SysName", user.SysName));
                foreach (var rule in user.Rule)
                {
                    var rulexml = doc.CreateElement("Rule");
                    rulexml.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", rule.Name));
                    rulexml.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Types", rule.Types));
                    rulexml.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Pushed", rule.Pushed));
                    rulexml.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "DateStart", rule.DateStart));
                    rulexml.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "DateFinish", rule.DateFinish));
                    rulexml.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Context", rule.Context));
                    userrules.AppendChild(rulexml);
                }
                xRoot.AppendChild(userrules);
            }
            doc.Save(path);
        }
        /// <summary>
        /// Метод добавление в файл Шаблонов ролей в отчет
        /// </summary>
        /// <param name="path">Путь сохранения</param>
        /// <param name="infoRuleTemplate">Шаблон ролей</param>
        public void AddInfoRuleTemplate(string path, InfoRuleTemplate infoRuleTemplate)
        {
            var doc = LogicaXml.LogicaXml.Document(path);
            XmlElement xRoot = doc.DocumentElement;
            XmlElement infoRule = doc.CreateElement("SystemAis");
            foreach (var systemAis in infoRuleTemplate.SystemAis)
            {
                infoRule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", systemAis.Name));
                foreach (var systemAisFolder in systemAis.Folders)
                {
                    var folder = doc.CreateElement("Folders");
                    folder.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", systemAisFolder.Name));
                    infoRule.AppendChild(folder);
                    foreach (var tasks in systemAisFolder.Tasks)
                    {
                        var task = doc.CreateElement("Tasks");
                        task.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", tasks.Name));
                        task.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Curator", tasks.Curator));
                        task.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "TypeTask", tasks.TypeTask));
                        folder.AppendChild(task);
                        foreach (var rolesTemplates in tasks.RolesTemplate)
                        {
                             var rolesTemplate = doc.CreateElement("RolesTemplate");
                             rolesTemplate.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", rolesTemplates.Name));
                             task.AppendChild(rolesTemplate);
                             foreach (var templates in rolesTemplates.Templates)
                             {
                                 var template = doc.CreateElement("Templates");
                                 template.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", templates.Name));
                                 template.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Category", templates.Category));
                                 rolesTemplate.AppendChild(template);
                             }
                        }
                    }
                }
                xRoot.AppendChild(infoRule);
            }
            doc.Save(path);
        }
        /// <summary>
        /// Метод добавление в файл пользователй и их ролей с шаблонами
        /// </summary>
        /// <param name="path">Путь сохранения</param>
        /// <param name="infoUserTemlateAndRule">Шаблоны пользователей и ролей</param>
        public void AddInfoUserRuleTemplate(string path, InfoUserTemlateAndRule infoUserTemlateAndRule)
        {
            var doc = LogicaXml.LogicaXml.Document(path);
            XmlElement xRoot = doc.DocumentElement;
            XmlElement infoUserRule = doc.CreateElement("Users");
            foreach (var user in infoUserTemlateAndRule.Users)
            {
                infoUserRule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", user.Name));
                infoUserRule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Code", user.Code.ToString()));
                infoUserRule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "TabelNumber", user.TabelNumber));
                infoUserRule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Department", user.Department));
                infoUserRule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Position", user.Position));
                infoUserRule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Organization", user.Organization));
                infoUserRule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Bloking", user.Bloking));
                infoUserRule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "NumberActiveDirectory", user.NumberActiveDirectory));
                foreach (var templates in user.Template)
                {
                    XmlElement template = doc.CreateElement("Template");
                    template.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "NameTemplate", templates.NameTemplate));
                    template.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Info", templates.Info));
                    template.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Category", templates.Category));
                    infoUserRule.AppendChild(template);
                }
                foreach(var segments in user.Sigment)
                {
                    XmlElement segment = doc.CreateElement("Sigment");
                    segment.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", segments.Name));
                    foreach(var app in segments.Applications)
                    {
                        XmlElement application = doc.CreateElement("Applications");
                        application.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", app.Name));
                            foreach(var rules in app.RuleTemplate)
                            {
                                XmlElement rule = doc.CreateElement("RuleTemplate");
                                rule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "NameRule", rules.NameRule));
                                rule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Context", rules.Context));
                                rule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Info", rules.Info));
                                rule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Category", rules.Category));
                                application.AppendChild(rule);
                            }
                        segment.AppendChild(application);
                    }
                    infoUserRule.AppendChild(segment);
                }
                xRoot.AppendChild(infoUserRule);
            }
            doc.Save(path);
        }
        /// <summary>
        /// Создание модели Шаблонов и ролей в них
        /// </summary>
        /// <param name="path">Путь сохранения</param>
        /// <param name="infoUserTemlateAndRule">Шаблоны пользователей и ролей</param>
        public void AddInfoRuleTemplate(string path, InfoUserTemlateAndRule infoUserTemlateAndRule)
        {
            var doc = LogicaXml.LogicaXml.Document(path);
            XmlElement xRoot = doc.DocumentElement;
            foreach (var templates in infoUserTemlateAndRule.Template)
            {
                XmlElement template = doc.CreateElement("Template");
                template.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "NameTemplate", templates.NameTemplate));
                template.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Info", templates.Info));
                template.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Category", templates.Category));
                foreach(var segments in templates.Sigment)
                {
                    XmlElement segment = doc.CreateElement("Sigment");
                    segment.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", segments.Name));
                    foreach (var app in segments.Applications)
                    {
                        XmlElement application = doc.CreateElement("Applications");
                        application.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Name", app.Name));
                        foreach (var rules in app.RuleTemplate)
                        {
                            XmlElement rule = doc.CreateElement("RuleTemplate");
                            rule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "NameRule", rules.NameRule));
                            rule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Info", rules.Info));
                            rule.Attributes.Append(CreateElement.CreteElement.AtributeAddString(doc, "Category", rules.Category));
                            application.AppendChild(rule);
                        }
                        segment.AppendChild(application);
                    }
                    template.AppendChild(segment);
                }
                xRoot.AppendChild(template);
            }
            doc.Save(path);
        }

    }
}
