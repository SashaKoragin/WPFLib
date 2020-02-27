using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.ButtonFullFunction.PublicGlobalFunction
{
    public class PublicGlobalFunction
    {
        /// <summary>
        /// Поиск последнего файла в папке
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="seathPattern">Патерн поиска</param>
        /// <returns>Возврат последнего файла</returns>
        public static GetFile RaturNameLastFileTemp(string path,string seathPattern)
        {
            var listFile = new List<GetFile>();
            var pdf = Directory.GetFiles(path, seathPattern);
            foreach (var pathing in pdf)
            {
                listFile.Add(new GetFile
                {
                    DateWrite = Directory.GetLastWriteTime(pathing),
                    NameFile = Path.GetFileName(pathing),
                    NamePath = pathing,
                    ExtensionsFile = Path.GetExtension(pathing)
                });
            }
            var list = listFile.Where(file => file.DateWrite == listFile.Max(files => files.DateWrite)).FirstOrDefault();
            return list;
        }



    }

    public class GetFile
    {
        public string NameFile { get; set; }
        public string NamePath { get; set; }
        public DateTime DateWrite { get; set; }
        public string ExtensionsFile { get; set; }
    }
}
