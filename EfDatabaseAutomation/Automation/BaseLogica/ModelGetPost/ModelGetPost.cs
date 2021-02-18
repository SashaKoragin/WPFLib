using LibaryXMLAuto.ReadOrWrite;
using LibaryXMLAutoModelXmlSql.PreCheck.ModelCard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using AisPoco.Ifns51.FromAis;
using AisPoco.Ifns51.ToAis;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
using LibaryXMLAutoModelXmlSql.PreCheck.Ifns51.FromAis;

namespace EfDatabaseAutomation.Automation.BaseLogica.ModelGetPost
{
    public class ModelGetPost : IDisposable
    {
        public Base.Automation Automation { get; set; }
        public ModelGetPost()
        {
            Automation = new Base.Automation();
        }


        /// <summary>
        /// Добавление ИНН модели для отработки
        /// </summary>
        /// <param name="templateModel">Шаблон для добавления</param>
        /// <param name="guidUsers">GUID Пользователя</param>
        public void AddInnModel(TemplateProcedure templateModel, string guidUsers)
        {
            DataTable tableInn = new DataTable();
            try
            {
                tableInn.Columns.Add(new DataColumn("Inn", typeof(string)));
                foreach (var inn in templateModel.Inn)
                {
                    tableInn.Rows.Add(inn);
                }
                var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 4);
                if (logicModel != null)
                {
                    EventSqlEf.EventSqlEf eventMessage = new EventSqlEf.EventSqlEf() {UserNameGuid = guidUsers };
                    var con = (SqlConnection)Automation.Database.Connection;
                    con.FireInfoMessageEventOnUserErrors = true;
                    con.InfoMessage += eventMessage.Con_InfoMessageSignalR;
                    Automation.Database.ExecuteSqlCommand(logicModel.SelectUser,
                             new SqlParameter
                             {
                                 ParameterName = logicModel.SelectedParametr.Split(',')[0],
                                 Value = tableInn,
                                 TypeName = "dbo.ListInn",
                                 SqlDbType = SqlDbType.Structured
                             },
                             new SqlParameter(logicModel.SelectedParametr.Split(',')[1], templateModel.IdTemplate));
                }
            }
            catch (Exception ex)
            {
                Loggers.Log4NetLogger.Error(ex);
            }
            finally
            {
                tableInn.Clear();
                tableInn.Dispose();
            }
        }
        /// <summary>
        /// Выгрузка всех шаблонов в БД
        /// </summary>
        /// <returns></returns>
        public List<TemplateModel> LoadAllTemplateDb()
        {
            try
            {
                var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 21);
                if (logicModel != null)
                {
                    var result = Automation.Database.SqlQuery<TemplateModel>(logicModel.SelectUser).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Loggers.Log4NetLogger.Error(ex);
            }
            return null;
        }

        /// <summary>
        /// Получение данных для клиента на парсинг значений
        /// </summary>
        /// <param name="idTemplate">Уникальные номера шаблонов</param>
        /// <returns></returns>
        public List<LibaryXMLAutoModelXmlSql.PreCheck.Ifns51.FromAis.SrvToLoad> LoadModelPreCheck(string idTemplate)
        {
            try
            {
                var xml = new XmlReadOrWrite();
                var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 6);
                if (logicModel != null)
                {
                    var sqlSelectModel = logicModel.SelectUser.Replace(logicModel.SelectedParametr.Split(',')[0], idTemplate);
                    var result = Automation.Database.SqlQuery<string>(sqlSelectModel)?.ToArray();
                    if (result?[0] != null)
                    {
                        var resultServer = ((ArrayOfSrvToLoad)xml.ReadXmlText(string.Join("", result), typeof(ArrayOfSrvToLoad))).SrvToLoad.ToList();
                        return resultServer;
                    }
                }
            }
            catch (Exception ex)
            {
                Loggers.Log4NetLogger.Error(ex);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Модель ответа от клиента</param>
        /// <returns></returns>
        public string LoadModelPreCheck(AisParsedData model)
        {
            try
            {
                var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 7);
                if (logicModel != null)
                {
                    int result;
                    using (var context = new Base.Automation())
                    {
                         result = context.Database.SqlQuery<int>(logicModel.SelectUser,
                            new SqlParameter(logicModel.SelectedParametr.Split(',')[0], model.N134),
                            new SqlParameter(logicModel.SelectedParametr.Split(',')[1], model.Tree),
                            new SqlParameter(logicModel.SelectedParametr.Split(',')[2], model.IdTemplate)).FirstOrDefault();
                    }
                    if (result != 0)
                    {
                        using (var context = new Base.Automation())
                        {
                            var select = (from faceModelTemplateGetPosts in context.FaceModelTemplateGetPosts where faceModelTemplateGetPosts.Id == result select new { FaceModelTemplateGetPosts = faceModelTemplateGetPosts }).FirstOrDefault();
                            if (select != null)
                            {
                                var modelUpdate = new Base.FaceModelTemplateGetPost()
                                {
                                    Id = select.FaceModelTemplateGetPosts.Id,
                                    IdUl = select.FaceModelTemplateGetPosts.IdUl,
                                    IdTemplate = select.FaceModelTemplateGetPosts.IdTemplate,
                                    IdTree = select.FaceModelTemplateGetPosts.IdTree,
                                    StatusModel = "Ок!"
                                };
                                Automation.Entry(modelUpdate).State = EntityState.Modified;
                                Automation.SaveChanges();
                                Base.LogicsSelectAutomation logicModelFullStatus;
                                using (var context2 = new Base.Automation())
                                {
                                    logicModelFullStatus = context2.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 11);
                                }
                                if (logicModelFullStatus != null)
                                {
                                    using (var context3 = new Base.Automation())
                                    {
                                       var resultDb = context3.Database.SqlQuery<string>(logicModelFullStatus.SelectUser,
                                            new SqlParameter(logicModelFullStatus.SelectedParametr.Split(',')[0],
                                                select.FaceModelTemplateGetPosts.Id)).FirstOrDefault();
                                    }
                                }
                            }
                        }
                    }
                }
                return "Ok!";
            }
            catch (Exception ex)
            {
                Loggers.Log4NetLogger.Error(ex);
            }
            return null;
        }

        /// <summary>
        /// Метод для снятия статуса для повторной отработки
        /// </summary>
        /// <param name="idModels">Уникальные номера моделей</param>
        /// <param name="status">Статус обработки ветки</param>
        public void CheckStatus(List<int> idModels, string status)
        {
            try
            {
                using (var context = new Base.Automation())
                {
                    var selectModels = (from faceModelTemplateGetPosts in context.FaceModelTemplateGetPosts where idModels.Contains(faceModelTemplateGetPosts.Id)  select new { FaceModelTemplateGetPosts = faceModelTemplateGetPosts });
                    foreach (var selectModel in selectModels)
                    {
                        var modelUpdate = new Base.FaceModelTemplateGetPost()
                        {
                            Id = selectModel.FaceModelTemplateGetPosts.Id,
                            IdUl = selectModel.FaceModelTemplateGetPosts.IdUl,
                            IdTemplate = selectModel.FaceModelTemplateGetPosts.IdTemplate,
                            IdTree = selectModel.FaceModelTemplateGetPosts.IdTree,
                            StatusModel = status
                        };
                        Automation.Entry(modelUpdate).State = EntityState.Modified;
                        Automation.SaveChanges();
                        var parameterControl = string.IsNullOrWhiteSpace(status) ? 12 : 11; //Если null или Empty то УН 12 в противном случае 11;
                        var logicModelOnFullStatus = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == parameterControl);
                        if (logicModelOnFullStatus != null)
                        {
                            var resultFullOnBlockStatus = Automation.Database
                                .SqlQuery<string>(logicModelOnFullStatus.SelectUser,
                                    new SqlParameter(logicModelOnFullStatus.SelectedParametr.Split(',')[0], selectModel.FaceModelTemplateGetPosts.Id))
                                .FirstOrDefault();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Loggers.Log4NetLogger.Error(ex);
            }
        }

        /// <summary>
        /// Собираем модель карточки (полная)
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="year">Год выгрузки</param>
        /// <returns></returns>
        public CardFaceUl CardUi(string inn, int year)
        {
            try
            {
                var xml = new XmlReadOrWrite();
                var cardFace = new CardFaceUl() {Card = new Card()};
                var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 9);
                if (logicModel != null)
                {
                    cardFace.FaceUl = Automation.Database.SqlQuery<FaceUl>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 1),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).FirstOrDefault();
                    cardFace.BranchUlFace = Automation.Database.SqlQuery<BranchUlFace>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 2),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.Card.List1Card = Automation.Database.SqlQuery<List1Card>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 3),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.HistoriUlFace = Automation.Database.SqlQuery<HistoriUlFace>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 4),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.CashUlFace = Automation.Database.SqlQuery<CashUlFace>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 5),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.CashBankSpr = Automation.Database.SqlQuery<CashBankSpr>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 6),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.Card.List2Card = Automation.Database.SqlQuery<List2Card>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 7),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    var rukAndUcrh = Automation.Database.SqlQuery<string>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 8),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    if (rukAndUcrh[0] != null)
                    {
                        var res = (CardFaceUl)xml.ReadXmlText(string.Join("", rukAndUcrh), typeof(CardFaceUl));
                        cardFace.RukAndUcrh = res.RukAndUcrh;
                    }
                    cardFace.ImZmTrUl = Automation.Database.SqlQuery<ImZmTrUl>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 9),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.Active = Automation.Database.SqlQuery<Active>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 10),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.Balans = Automation.Database.SqlQuery<Balans>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 11),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.Profit = Automation.Database.SqlQuery<Profit>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 12),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.Nds = Automation.Database.SqlQuery<Nds>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 13),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.FlRukUcrh = Automation.Database.SqlQuery<FlRukUcrh>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 14),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.SummaryBankSales = Automation.Database.SqlQuery<SummaryBankSales>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 15),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                    cardFace.SummaryBankPurchase = Automation.Database.SqlQuery<SummaryBankPurchase>(logicModel.SelectUser,
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 16),
                        new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                }
                return cardFace;
            }
            catch (Exception ex)
            {
                Loggers.Log4NetLogger.Error(ex);
            }
            return null;
        }
        /// <summary>
        /// Book Sales Книги покупок продаж на банк
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="year">ГОД Данных</param>
        /// <returns></returns>
        public CardFaceUl CardUiBookSales(string inn, int year)
        {
            try
            {
                var cardFace = new CardFaceUl() { Card = new Card() };
                var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 9);
                cardFace.FaceUl = Automation.Database.SqlQuery<FaceUl>(logicModel.SelectUser,
                    new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                                 new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 1),
                                 new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).FirstOrDefault();
                cardFace.SummaryBankSales = Automation.Database.SqlQuery<SummaryBankSales>(logicModel.SelectUser, 
                    new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                                 new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 15),
                                 new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                cardFace.SummaryBankPurchase = Automation.Database.SqlQuery<SummaryBankPurchase>(logicModel.SelectUser,
                new SqlParameter(logicModel.SelectedParametr.Split(',')[0], inn),
                             new SqlParameter(logicModel.SelectedParametr.Split(',')[1], 16),
                             new SqlParameter(logicModel.SelectedParametr.Split(',')[2], year)).ToArray();
                return cardFace;
            }
            catch (Exception ex)
            {
                Loggers.Log4NetLogger.Error(ex);
            }
            return null;
        }


        /// <summary>
        /// Disposing
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Automation?.Dispose();
                Automation = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
