using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;


namespace LibaryCommandPublic.TestAutoit.PublicCommand
{
    public class CommandSnuOneAuto
    {
        /// <summary>
        /// Команда Update вынесена в отдельный клас чтобы не загромождать логику MVVM
        /// </summary>
        /// <param name="xmlusemethod">XmlUseMethod Метод файла xml</param>
        /// <param name="reportjurnalmethod">ReportJurnalMethod метод журнала файла xml</param>
        /// <param name="pathfileinn">Путь к файлу FullName</param>
        /// <param name="pathjurnal">Просто путь к журналу</param>
        /// <param name="pathinn">Просто путь к ИНН</param>
        public void UpdateModel(XmlUseMethod xmlusemethod, ReportJurnalMethod reportjurnalmethod, string pathfileinn,string pathjurnal,string pathinn)
        {
            xmlusemethod.UpdateFileXml(pathfileinn);
            reportjurnalmethod.AddFileXml(pathinn);
            reportjurnalmethod.AddJurnal(pathjurnal);
        }
        /// <summary>
        /// Коммонда конвертации xml в Excel и открытия файла Excel
        /// </summary>
        /// <param name="reportexcel">отч</param>
        /// <param name="reportjurnal"></param>
        /// <param name="pathreport"></param>
        public void ConvertXslToXmlAndOpen(ReportXlsxMethod reportexcel, ReportJurnalMethod reportjurnal, string pathreport )
        {
            var filefullpath = LibaryXMLAuto.Converts.ConvertXmlToXslx.ConvertXmltoXlsx.ConvertXmlToXls(reportjurnal.XmlFile.Path, pathreport);
            reportexcel.UpdateColectFile(filefullpath.DirectoryName);
            reportjurnal.OpenFile(filefullpath.FullName);
        }
    }

   
}
