using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibaryXMLAuto.ReadOrWrite;

namespace LibaryXMLAuto.ErrorJurnal
{
    /// <summary>
    /// Класс Журналирование сделаных в xml файл
    /// </summary>
    public class OkJurnal
    {
        /// <summary>
        ///  Проверка наличия журнала сделаных
        /// </summary>
        /// <param name="pathjurnal">Путь к журналу</param>
        /// <param name="znacenie">Обрабоатываемое значение</param>
        /// <param name="ok">Параметр что сделали</param>
        public static void JurnalOk(string pathjurnal, string znacenie, string ok)
        {
            if (File.Exists(pathjurnal))
            {
                XmlReadOrWrite read = new XmlReadOrWrite();
                read.AddElementOk(pathjurnal,znacenie,ok);
            }
            else
            {
                ConvettToXml.XmlConvert convert = new ConvettToXml.XmlConvert();
                convert.CreateJurnalOk(pathjurnal, znacenie, ok);
            }
        }
    }
}
