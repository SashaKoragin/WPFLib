using System;
using System.IO;
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
            try
            {
                if (File.Exists(pathjurnal))
                {
                    XmlReadOrWrite read = new XmlReadOrWrite();
                    read.AddElementOk(pathjurnal, znacenie, ok);
                }
                else
                {
                    var convert = new Converts.ConvettToXml.XmlConvert();
                    convert.CreateJurnalOk(pathjurnal, znacenie, ok);
                }
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
