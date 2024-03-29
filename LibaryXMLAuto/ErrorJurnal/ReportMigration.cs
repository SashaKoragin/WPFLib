﻿using System.IO;
using LibaryXMLAuto.ReadOrWrite;
using LibaryXMLAuto.ModelXmlAuto.MigrationReport;

namespace LibaryXMLAuto.ErrorJurnal
{
   public class ReportMigration
    {
        /// <summary>
        ///  Проверка наличия журнала сделаных
        /// </summary>
        /// <param name="reportMigration">Путь к отчету с ошибками о миграции</param>
        /// <param name="report">Модель отчета о миграциии</param>
        public static void CreateReportMigration(string reportMigration, MigrationParse report)
        {
            if (File.Exists(reportMigration))
            {
                XmlReadOrWrite read = new XmlReadOrWrite();
                read.AddReportMigrationElemrnt(reportMigration,report);
            }
            else
            {
                var convert = new Converts.ConvettToXml.XmlConvert();
                convert.SerializerClassToXml(reportMigration, report, typeof(MigrationParse));
            }
        }
        /// <summary>
        /// Сохранение Отчета по миграции
        /// </summary>
        /// <param name="pathreport">Путь сохранения файла с ролями</param>
        /// <param name="userrule">Роли и пользователи</param>
        public static void CreateFileRule(string pathreport, UserRules userrule)
        {
            if (File.Exists(pathreport))
            {
                XmlReadOrWrite read = new XmlReadOrWrite();
                read.AddRuleUsers(pathreport, userrule);
            }
            else
            {
                var convert = new Converts.ConvettToXml.XmlConvert();
                convert.SerializerClassToXml(pathreport, userrule, typeof(UserRules));
            }
        }
        /// <summary>
        /// Сохранение отчета по Информации о ролях и ветках
        /// </summary>
        /// <param name="pathReport">Путь сохранения файла с информацией о ролями</param>
        /// <param name="infoRuleTemplate">Шаблон Подсистем</param>
        public static void CreateFileInfoRuleTemplate(string pathReport, InfoRuleTemplate infoRuleTemplate)
        {
            if (File.Exists(pathReport))
            {
                XmlReadOrWrite read = new XmlReadOrWrite();
                read.AddInfoRuleTemplate(pathReport, infoRuleTemplate);
            }
            else
            {
                var convert = new Converts.ConvettToXml.XmlConvert();
                convert.SerializerClassToXml(pathReport, infoRuleTemplate, typeof(InfoRuleTemplate));
            }
        }

        /// <summary>
        /// Сохранение отчета по Информации о пользователях и их ролях и шаблонах
        /// </summary>
        /// <param name="path">Путь сохранения</param>
        /// <param name="infoUserTemlateAndRule">Шаблоны пользователей и ролей</param>
        public static void CreateFileInfoUserRuleTemplate(string pathReport, InfoUserTemlateAndRule infoUserTemlateAndRule)
        {
            if (File.Exists(pathReport))
            {
                XmlReadOrWrite read = new XmlReadOrWrite();
                if (infoUserTemlateAndRule.Users != null)
                {
                 
                    read.AddInfoUserRuleTemplate(pathReport, infoUserTemlateAndRule);
                }
                if (infoUserTemlateAndRule.Template != null)
                {
                    read.AddInfoRuleTemplate(pathReport, infoUserTemlateAndRule);
                }
            }
            else
            {
                var convert = new Converts.ConvettToXml.XmlConvert();
                convert.SerializerClassToXml(pathReport, infoUserTemlateAndRule, typeof(InfoUserTemlateAndRule));
            }
        }


    }
}
