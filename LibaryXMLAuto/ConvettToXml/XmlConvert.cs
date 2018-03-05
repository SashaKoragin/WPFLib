using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LibaryXMLAutoModelXmlAuto.ModelJurnal;
using LibaryXMLAutoModelXmlAuto.ModelSnuOne;

namespace LibaryXMLAuto.ConvettToXml
{
   public class XmlConvert
    {
        /// <summary>
        /// Метод конвертации в xml файл по схеме SnuOneForm.xsd
        /// <![CDATA[
        /// <?xml version="1.0"?>
        ///<SnuOneForm xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        ///    <INN INN ="504602844980" />
        ///    <INN INN="772576444844" />
        /// </SnuOneForm> ]]>
        /// 
        /// </summary>
        /// <param name="masivInnStrings">Параметр список</param>
        public void Serializ(List<string> masivInnStrings)
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
            using (FileStream fs = new FileStream("C:\\Inn.xml", FileMode.OpenOrCreate))
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
            Error er = new Error() { Inn = znacenie, Error1 = errors, System = branch };
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
            Ok ok = new Ok() { Inn = znacenie, Message = okeys };
            okey.Ok[0] = ok;
            XmlSerializer formatter = new XmlSerializer(typeof(OkJurnal));
            using (FileStream fs = new FileStream(pathjurnal, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, okey);
            }
        }
    }
}
