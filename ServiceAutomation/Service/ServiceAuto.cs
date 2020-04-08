using System.IO;
using System.Threading.Tasks;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.ProcedureParametr;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
using ServiceAutomation.LoginAD.XsdShemeLogin;
using LogicsSelectAutomation = EfDatabaseAutomation.Automation.SelectParametrSheme.LogicsSelectAutomation;

namespace ServiceAutomation.Service
{
    public class ServiceAuto : IServiceAuto
    {
        /// <summary>
        /// Авторизация через домен и роли
        /// </summary>
        /// <param name="identification">Класс идентификации</param>
        /// <returns></returns>
        public async Task<Identification> Identification(Identification identification)
        {
            return await Task.Factory.StartNew(() =>
            {
                var login = new LoginAD.Login.LoginIdentificationUser();
                return login.AuthUserService(identification);
            });
        }

        /// <summary>
        /// Генерация выборки на клиенте 
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        public async Task<ModelSelect> GenerateSqlSelect(ModelSelect model)
        {
           var select = new SqlSelect();
           return await Task.Factory.StartNew(() => select.SelectSql(model));
        }
        /// <summary>
        /// Выборка
        /// </summary>
        /// <param name="sqlSelect">Запрос</param>
        /// <returns></returns>
        public async Task<string> Select(LogicsSelectAutomation sqlSelect)
        {
            var selectAll = new SelectAll();
            return await Task.Factory.StartNew(() => selectAll.SelectSqlAll(sqlSelect));
        }

        /// <summary>
        /// Выгрузка 129 файла из БД
        /// </summary>
        /// <param name="numberElement"></param>
        /// <returns></returns>
        public async Task<Stream> LoadFileTaxJournal(int numberElement)
        {
            var selectAll = new SelectAll();
            return await Task.Factory.StartNew(() => selectAll.LoadFilePdf(numberElement));
        }

        public async Task<Stream> LoadFileTax121(int numberElement)
        {
            var selectAll = new SelectAll();
            return await Task.Factory.StartNew(() => selectAll.LoadFile121(numberElement));
        }

    }
}