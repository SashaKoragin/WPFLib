using System.IO;
using LibaryXMLAuto.ReadOrWrite;
using LibaryXMLAutoModelXmlAuto.MigrationReport;

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
    }
}
