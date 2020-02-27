using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using LibaryXMLAutoModelXmlAuto.MigrationReport;

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
                    object o = serializer.Deserialize(reader);
                    return o;
                }
            }
            return null;
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
        /// <param name="userrule">Модель парсинга</param>
        public void AddRuleUsers(string path, UserRules userrule)
        {
             var doc = LogicaXml.LogicaXml.Document(path);
            XmlElement xRoot = doc.DocumentElement;
            XmlElement userrules = doc.CreateElement("User");
            foreach (var user in userrule.User)
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
    }
}
