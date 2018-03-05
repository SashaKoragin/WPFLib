using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DBFtoSQL2008Enterprise.Aplication.ResourceDBFtoSQL
{
   public class DbfCoding
    {
        /// <summary>
        /// Возвращает байт кодовой страницы по номеру кодовой страницы
        /// </summary>
        /// <param name="codePage">Кодовая страница</param>
        /// <returns></returns>
        public byte GetByteCodePage(int codePage)
        {
            byte cp = 0;
            switch (codePage)
            {
                case 437: return 0x01; //DOS USA code page 437 
                case 850: cp = 0x02; break; // DOS Multilingual code page 850 
                case 1252: cp = 0x03; break; // Windows ANSI code page 1252 
                case 10000: cp = 0x04; break; // Standard Macintosh 
                case 865: cp = 0x08; break; // Danish OEM
                case 932: cp = 0x13; break; // Japanese Shift-JIS
                case 863: cp = 0x1C; break; // French OEM (Canada)
                case 852: cp = 0x1F; break; // Czech OEM
                case 860: cp = 0x24; break; // Portuguese OEM
                case 936: cp = 0x4D; break; // Chinese GBK (PRC)
                case 949: cp = 0x4E; break; // Korean (ANSI/OEM)
                case 950: cp = 0x4F; break; // Chinese Big5 (Taiwan)
                case 874: cp = 0x50; break; // Thai (ANSI/OEM)
                case 861: cp = 0x67; break; // Icelandic MS–DOS
                case 895: cp = 0x68; break; // Kamenicky (Czech) MS-DOS 
                case 620: cp = 0x69; break; // Mazovia (Polish) MS-DOS 
                case 737: cp = 0x6A; break; // Greek MS–DOS (437G)
                case 857: cp = 0x6B; break; // Turkish MS–DOS
                case 1255: cp = 0x7D; break; // Hebrew Windows 
                case 1256: cp = 0x7E; break; // Arabic Windows 
                case 10007: cp = 0x96; break; // Russian Macintosh 
                case 10029: cp = 0x97; break; // Eastern European Macintosh 
                case 10006: cp = 0x98; break; // Greek Macintosh 
                case 1250: cp = 0xC8; break; // Eastern European Windows
                case 1254: cp = 0xCA; break; // Turkish Windows
                case 1253: cp = 0xCB; break; // Greek Windows
                case 1257: cp = 0xCC; break; // Baltic Windows
                case 866: cp = 0x26; break; // Russian DOS
                case 1251: cp = 0x87; break; // Russian Windows
                default: cp = 0x26; break;
            }
            return cp;
        }
        /// <summary>
        /// Проверка байта кодовой страницы таблицы
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Байт-код кодовой страницы таблицы</returns>
        public byte GetDbfCodepage(string fileName)
        {
            byte cp = 0;
            using (FileStream file = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                try
                {
                    file.Seek(29, SeekOrigin.Begin); // 29 байт содержит значение кодовой страницы
                    cp = Convert.ToByte(file.ReadByte());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return cp;
        }

        /// <summary>
        /// Установка кодовой страницы таблицы
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="codepage">Кодовая страница</param>
        public void SetDbfCodepage(string fileName, int codepage)
        {
            byte cp = GetByteCodePage(codepage);
            using (FileStream file = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                try
                {
                    file.Seek(29, SeekOrigin.Begin); // 29 байт содержит значение кодовой страницы
                    file.WriteByte(cp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
