using System.IO;
using System.Threading.Tasks;
using LibaryXMLAutoModelServiceWcfCommand.TestIfnsService;
using SqlLibaryIfns.SqlSelect.ModelSqlFullService;
using SqlLibaryIfns.SqlZapros.SqlConnections;

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
            var sqlconnect = new SqlConnectionType();
            var xlsx = new ReportExcel();
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
                    xlsx.ReportSave(path, "Бдк", "Бдк", sqlconnect.ReportQbe(conectionstring, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(conectionstring, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("6"))).ServiceWcfCommand.Command));
                    if (File.Exists(Path.Combine(path, filename)))
                    {
                        return
                               await Task.Factory.StartNew<Stream>(
                                   () => DonloadFile(Path.Combine(path, filename)));
                    }
                    return null;
                case "Истребование.xlsx":
                    xlsx.ReportSave(path,"Истребование","Не доделки по документам",sqlconnect.ReportQbe(conectionstring,((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(conectionstring,ModelSqlFullService.ProcedureSelectParametr,typeof(ServiceWcf),ModelSqlFullService.ParamCommand("18"))).ServiceWcfCommand.Command));
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
