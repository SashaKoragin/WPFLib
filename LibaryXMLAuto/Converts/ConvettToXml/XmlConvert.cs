using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LibaryXMLAutoModelXmlAuto.ModelJurnal;
using LibaryXMLAutoModelXmlAuto.ModelSnuOne;

namespace LibaryXMLAuto.Converts.ConvettToXml
{
    /// <summary>
    /// Класс конвертации xlsx то xmlSheme
    /// </summary>
    public class XmlConvert
    {

        /// <summary>
        /// Метод конвертации xlsx по xml sheme SnuOneForm.xsd
        /// </summary>
        /// <param name="pathFilexlsx">Путь к файлу xlsx</param>
        /// <param name="listfile">Выбранный лист</param>
        /// <param name="letter">Буква в xlsx</param>
        /// <param name="isOneUseRows">Параметр указывающий Используем 1 строку или нет</param>
        /// <param name="path">Параметр пути сохранения</param>
        public void ConvertListSnuOneForm(string pathFilexlsx,string listfile,string letter,bool isOneUseRows,string path)
        {
            var worbook = new ClosedXML.Excel.XLWorkbook(pathFilexlsx);
            var ws = worbook.Worksheets.Worksheet(listfile);
            var countcell = ws.Columns(letter).Cells().Count(inn => !inn.IsEmpty());
            List<string> listinn = new List<string>();
            for (int i = Convert.ToInt32(isOneUseRows)+1; i <= countcell; i++)
            {
                    listinn.Add(ws.Cell(letter + i).Value.ToString());
            }
            SerializSnuOneForm(listinn, path);
        }
        /// <summary>
        /// Метод конвертации в xml файл по схеме SnuOneForm.xsd
        /// <![CDATA[
        /// <?xml version="1.0"?>
        ///<SnuOneForm xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        ///    <INN INN ="504602844980" />
        ///    <INN INN="772576444844" />
        /// </SnuOneForm> ]]>
        /// </summary>
        /// <param name="masivInnStrings">Параметр список</param>
        /// <param name="path">Параметр пути сохранения</param>
        public void SerializSnuOneForm(List<string> masivInnStrings,string path)
        {
            int i = 0;
            SnuOneForm snu = new SnuOneForm() {INN = new INN[masivInnStrings.Count] };
            foreach (var inn in masivInnStrings)
            {
                INN k = new INN() {INN1 = inn};
                snu.INN[i] = k;
                i++;
            }
            XmlSerializer formatter = new XmlSerializer(typeof(SnuOneForm));
            using (FileStream fs = new FileStream(path+ "Inn.xml", FileMode.Create))
            {
                formatter.Serialize(fs, snu);
            }
        }

        /// <summary>
        /// Метод отрабатывает если Журнал с ошибками не создан дольше будеь добавлять элементы
        /// </summary>
        public void CreateJurnalError(string pathjurnal, string znacenie, string branch, string errors)
        {
            JurnalError error = new JurnalError() {Error = new Error[1]};
            Error er = new Error() { Inn = znacenie, Error1 = errors, System = branch, DateTimeUse = DateTime.Now, DateTimeUseSpecified = true};
            error.Error[0] = er;
            XmlSerializer formatter = new XmlSerializer(typeof(JurnalError));
            using (FileStream fs = new FileStream(pathjurnal, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, error);
            }
        }

        /// <summary>
        /// Метод отрабатывает если Журнал с ок не создан дольше будеь добавлять элементы
        /// </summary>
        public void CreateJurnalOk(string pathjurnal, string znacenie, string okeys)
        {
            OkJurnal okey = new OkJurnal() { Ok = new Ok[1] };
            Ok ok = new Ok() { Inn = znacenie, Message = okeys, DateTimeUse = DateTime.Now, DateTimeUseSpecified = true};
            okey.Ok[0] = ok;
            XmlSerializer formatter = new XmlSerializer(typeof(OkJurnal));
            using (FileStream fs = new FileStream(pathjurnal, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, okey);
            }
        }
    }
}