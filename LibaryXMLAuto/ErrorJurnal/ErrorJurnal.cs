using System;
using System.IO;
using LibaryXMLAuto.ReadOrWrite;

namespace LibaryXMLAuto.ErrorJurnal
{
    /// <summary>
    /// Класс Журналирование ошибок в xml файл
    /// </summary>
   public class ErrorJurnal
    {
        /// <summary>
        ///  Проверка наличия журнала ошибок
        /// </summary>
        /// <param name="pathjurnal">Путь к журналу</param>
        /// <param name="znacenie">Обрабоатываемое значение</param>
        /// <param name="branch">Ветка в которой отрабатывае</param>
        /// <param name="error">Ошибка</param>
        public static void JurnalError(string pathjurnal, string znacenie,string branch,string error)
        {
                if (File.Exists(pathjurnal))
                {
                    XmlReadOrWrite read = new XmlReadOrWrite();
                    read.AddElementError(pathjurnal, znacenie, branch, error);
                }
                else
                {
                    var convert = new Converts.ConvettToXml.XmlConvert();
                    convert.CreateJurnalError(pathjurnal, znacenie, branch, error);
                }
        }
    }
}
