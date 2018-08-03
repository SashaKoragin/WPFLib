using System.IO;
using System.Threading.Tasks;
using SqlLibaryIfns.SqlSelect.SqlBdkIt;
using SqlLibaryIfns.SqlZapros.Report;

namespace SqlLibaryIfns.ExcelReport.Report
{
    public class DonloadsFile
    {
        /// <summary>
        /// Выбор файла для передачи
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="filename">Имя файла</param>
        /// <param name="conectionstring">Строка соединения с БД для формирования таблицы</param>
        /// <returns></returns>
        public async Task<Stream> SelectDonloadsFile( string path, string filename, string conectionstring = null)
        {
            switch (filename)
            {
                case "Требования.xlsx":
                    if (File.Exists(Path.Combine(path, filename)))
                    {
                        return
                               await Task.Factory.StartNew<Stream>(
                                   () => DonloadFile(Path.Combine(path, filename)));
                    }
                    return null;
                case "Бдк.xlsx":
                    var sql = new ReportSqlQbe();
                    var xlsx = new ReportExcel();
                    xlsx.ReportSave(path, "Бдк", "Бдк", sql.ReportQbe(conectionstring, SqlBdkIt.SelectXlsx));
                    if (File.Exists(Path.Combine(path, filename)))
                    {
                        return
                               await Task.Factory.StartNew<Stream>(
                                   () => DonloadFile(Path.Combine(path, filename)));
                    }
                    return null;
                default:
                    return null;
            }
        }
        /// <summary>
        /// Конвертация файла в массив данных
        /// </summary>
        /// <param name="paht">Путь к файлу</param>
        /// <returns></returns>
        private Stream DonloadFile(string paht)
          {
            return File.OpenRead(paht);
          }
    }
}
