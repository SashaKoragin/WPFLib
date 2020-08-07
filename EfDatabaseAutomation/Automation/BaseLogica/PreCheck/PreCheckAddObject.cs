﻿using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;

namespace EfDatabaseAutomation.Automation.BaseLogica.PreCheck
{
   public class PreCheckAddObject
    {
        public Base.Automation Automation { get; set; }

        public PreCheckAddObject()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }

        /// <summary>
        /// Добавление Юридического лица
        /// </summary>
        /// <param name="ulFace">Юридическое лицо</param>
        public void AddUlFace(UlFace ulFace)
        {
            if (!(from ulFaces in Automation.UlFaces where ulFaces.IdNum == ulFace.IdNum select new { UlFaces = ulFaces }).Any())
            {
                Automation.UlFaces.Add(ulFace);
                Automation.SaveChanges();
            }
            else
            {
                using(var context = new Base.Automation())
                {
                    var select = (from ulFaces in context.UlFaces where ulFaces.IdNum == ulFace.IdNum select new { UlFaces = ulFaces }).FirstOrDefault();
                    ulFace.IdUl = select.UlFaces.IdUl;
                    Automation.Entry(ulFace).State = EntityState.Modified;
                    Automation.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Добавление сведений об учете организации
        /// </summary>
        /// <param name="svedAccoutingUlFace">Сведения об учете объектов</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        public void AddSvedAccoutingUlFace(SvedAccoutingUlFace svedAccoutingUlFace, string innUl)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                svedAccoutingUlFace.IdUl = idUl;
            }
            if (svedAccoutingUlFace.IdUl != 0)
            {
                if (!(from svedAccoutingUlFaces in Automation.SvedAccoutingUlFaces where svedAccoutingUlFaces.IdNum == svedAccoutingUlFace.IdNum select new { SvedAccoutingUlFaces = svedAccoutingUlFaces }).Any())
                {
                    Automation.SvedAccoutingUlFaces.Add(svedAccoutingUlFace);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from svedAccoutingUlFaces in context.SvedAccoutingUlFaces where svedAccoutingUlFaces.IdNum == svedAccoutingUlFace.IdNum select new { SvedAccoutingUlFaces = svedAccoutingUlFaces }).FirstOrDefault();
                        svedAccoutingUlFace.Id = select.SvedAccoutingUlFaces.Id;
                        Automation.Entry(svedAccoutingUlFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }

        /// <summary>
        /// Добавление Истории Юридического лица
        /// </summary>
        /// <param name="historyUl">История ЮЛ</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        public void AddHistoryUlFace(HistoriUlFace historyUl, string innUl)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                historyUl.IdUl = idUl;
            }
            if(historyUl.IdUl != 0)
            {
                if (!(from historiUlFaces in Automation.HistoriUlFaces where historiUlFaces.IdNum == historyUl.IdNum select new { HistoriUlFaces = historiUlFaces }).Any())
                {
                    Automation.HistoriUlFaces.Add(historyUl);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from historiUlFaces in context.HistoriUlFaces where historiUlFaces.IdNum == historyUl.IdNum select new { HistoriUlFaces = historiUlFaces }).FirstOrDefault();
                        historyUl.Id = select.HistoriUlFaces.Id;
                        Automation.Entry(historyUl).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }
        /// <summary>
        /// Добавление обособленных подразделений
        /// </summary>
        /// <param name="branchFace">Обособленные подразделения</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        public void AddBranchUlFace(BranchUlFace branchFace, string innUl)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                branchFace.IdUl = idUl;
            }
            if (branchFace.IdUl != 0)
            {
                if (!(from branchUlFaces in Automation.BranchUlFaces where branchUlFaces.IdNum == branchFace.IdNum select new { BranchUlFaces = branchUlFaces }).Any())
                {
                   Automation.BranchUlFaces.Add(branchFace);
                   Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from branchUlFaces in context.BranchUlFaces where branchUlFaces.IdNum == branchFace.IdNum select new { BranchUlFaces = branchUlFaces }).FirstOrDefault();
                        branchFace.Id = select.BranchUlFaces.Id;
                        Automation.Entry(branchFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }

        /// <summary>
        /// Добавление имущества Юридических лиц
        /// </summary>
        /// <param name="transportUlFace">(Транспорт земля имущество)</param>
        /// <param name="innUl">ИНН</param>
        /// <param name="typeObject">Выбор типа объекта</param>
        public void AddImZmTrUl(ImZmTrUl imZmTrUl, string innUl, string typeObject)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                var idUl = (from users in Automation.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                imZmTrUl.IdUl = idUl;
            }
            //Тип объекта
            using (var context = new Base.Automation())
            {
                var idObject = (from type in Automation.TypeObjects where type.TypeObject_ == typeObject select type.IdObject).SingleOrDefault();
                imZmTrUl.IdObject = idObject;
            }
            if (imZmTrUl.IdUl != 0)
            {
                if (!(from imZmTrUls in Automation.ImZmTrUls where imZmTrUls.IdNum == imZmTrUl.IdNum select new { ImZmTrUl = imZmTrUls }).Any())
                {
                    Automation.ImZmTrUls.Add(imZmTrUl);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from imZmTrUls in context.ImZmTrUls where imZmTrUls.IdNum == imZmTrUl.IdNum select new { ImZmTrUl = imZmTrUls }).FirstOrDefault();
                        imZmTrUl.Id = select.ImZmTrUl.Id;
                        Automation.Entry(imZmTrUl).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }

        /// <summary>
        /// Добавление имущество транспорт земля физических лиц 
        /// </summary>
        /// <param name="imZmTrFl">Модель транспорта земли имущества</param>
        /// <param name="innFl">ИНН ФЛ</param>
        /// <param name="typeObject">Выбор типа объекта</param>
        public void AddImZmTrFl(ImZmTrFl imZmTrFl,string innFl,string typeObject)
        {
            using (var context = new Base.Automation())
            {
                var idFl = (from users in context.FlFaces where users.Inn == innFl select users.IdFl).SingleOrDefault();
                imZmTrFl.IdFl = idFl;
            }
            //Тип объекта
            using (var context = new Base.Automation())
            {
                var idObject = (from type in context.TypeObjects where type.TypeObject_ == typeObject select type.IdObject).SingleOrDefault();
                imZmTrFl.IdObject = idObject;
            }
            if (imZmTrFl.IdFl != 0)
            {
                if (!(from imZmTrFls in Automation.ImZmTrFls where imZmTrFls.IdNum == imZmTrFl.IdNum select new { ImZmTrFl = imZmTrFls }).Any())
                {
                    Automation.ImZmTrFls.Add(imZmTrFl);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                       var select = (from imZmTrFls in context.ImZmTrFls where imZmTrFls.IdNum == imZmTrFl.IdNum select new { ImZmTrFl = imZmTrFls }).FirstOrDefault();
                       imZmTrFl.Id = select.ImZmTrFl.Id;
                       Automation.Entry(imZmTrFl).State = EntityState.Modified;
                       Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }



        /// <summary>
        /// Добавление среднегодовой численности
        /// </summary>
        /// <param name="strngthUlFace">Среднегодовая чиленность</param>
        /// <param name="innUl">ИНН</param>
        public void AddStrngthUlFace(StrngthUlFace strngthUlFace, string innUl)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                strngthUlFace.IdUl = idUl;
            }
            if (strngthUlFace.IdUl != 0)
            {
                if (!(from strngthUlFaces in Automation.StrngthUlFaces where strngthUlFaces.IdNum == strngthUlFace.IdNum select new { StrngthUlFace = strngthUlFaces }).Any())
                {
                    Automation.StrngthUlFaces.Add(strngthUlFace);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from strngthUlFaces in context.StrngthUlFaces where strngthUlFaces.IdNum == strngthUlFace.IdNum select new { StrngthUlFace = strngthUlFaces }).FirstOrDefault();
                        strngthUlFace.Id = select.StrngthUlFace.Id;
                        Automation.Entry(strngthUlFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }

        /// <summary>
        /// Добавление Налоговое администрирование\Банковские и лицевые счета\09. Картотека счетов\01. Картотека счетов РО, ИО, ИП
        /// </summary>
        /// <param name="cashUiFace">Картотека счетов</param>
        /// <param name="innUl">ИНН</param>
        public void AddCashUlFace(CashUlFace cashUiFace, string innUl)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                cashUiFace.IdUl = idUl;
            }
            if (cashUiFace.IdUl != 0)
            {
                if (!(from cashUlFaces in Automation.CashUlFaces where cashUlFaces.IdNum == cashUiFace.IdNum select new { CashUlFace = cashUlFaces }).Any())
                {
                   Automation.CashUlFaces.Add(cashUiFace);
                   Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from cashUlFaces in context.CashUlFaces where cashUlFaces.IdNum == cashUiFace.IdNum select new { CashUlFace = cashUlFaces }).FirstOrDefault();
                        cashUiFace.Id = select.CashUlFace.Id;
                        Automation.Entry(cashUiFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }
        /// <summary>
        /// Добавление ОКВЕД
        /// </summary>
        /// <param name="individualCardsUlFace">Карточка ОКВЕД в xml</param>
        /// <param name="innUl">ИНН</param>
        public void AddIndividualCardsUlFace(IndividualCardsUlFace individualCardsUlFace, string innUl)
        {
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                individualCardsUlFace.IdUl = idUl;
            }
            if (individualCardsUlFace.IdUl != 0)
            {
                if (!(from individualCardsUlFaces in Automation.IndividualCardsUlFaces where individualCardsUlFaces.IdUl == individualCardsUlFace.IdUl select new { IndividualCardsUlFace = individualCardsUlFaces }).Any())
                {
                    Automation.IndividualCardsUlFaces.Add(individualCardsUlFace);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from individualCardsUlFaces in context.IndividualCardsUlFaces where individualCardsUlFaces.IdUl == individualCardsUlFace.IdUl select new { IndividualCardsUlFace = individualCardsUlFaces }).FirstOrDefault();
                        individualCardsUlFace.Id = select.IndividualCardsUlFace.Id;
                        Automation.Entry(individualCardsUlFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 10);
            Automation.Database.SqlQuery<string>(logicModel.SelectUser, new SqlParameter(logicModel.SelectedParametr.Split(',')[0], innUl)).FirstOrDefault();
            //Отсутствует лицо сохранение не возможно
        }
        /// <summary>
        /// Проверка на содержание в БД номера декларации что бы не отбирать
        /// </summary>
        /// <param name="regNumDecl">Рег номер декларации</param>
        /// <returns></returns>
        public bool IsExistsDeclaration(long regNumDecl)
        {
            if ((from declarationUls in Automation.DeclarationUls where declarationUls.RegNumDecl == regNumDecl select new { DeclarationUls = declarationUls }).Any())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Добавление деклараций на все
        /// </summary>
        /// <param name="declaration">Основа декларации</param>
        /// <param name="innUl">ИНН</param>
        public void AddDeclarationModel(DeclarationUl declarationUl, string innUl)
        {
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                declarationUl.IdUl = idUl;
            }
            if (declarationUl.IdUl != 0)
            {
                if (!(from declarationUls in Automation.DeclarationUls
                      where declarationUls.RegNumDecl == declarationUl.RegNumDecl
                      select new { DeclarationUls = declarationUls }).Any())
                {
                    var declarationDates = declarationUl.DeclarationDatas;
                    declarationUl.DeclarationDatas = null;
                    Automation.DeclarationUls.Add(declarationUl);
                    try
                    {
                        Automation.SaveChanges();
                        Automation.BulkInsert<DeclarationData>(declarationDates);
                    }
                    catch(DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            Trace.WriteLine(validationError.Entry.Entity.ToString());
                            Trace.WriteLine("");
                             foreach (DbValidationError err in validationError.ValidationErrors)
                             {
                                Trace.WriteLine(err.ErrorMessage);
                             }
                        }
                    }
                }
                //Обновление данных и внутренних полей не требуется
            }
            //Отсутствует лицо сохранение не возможно
        }
        /// <summary>
        /// Добавление выписок в БД 
        /// </summary>
        /// <param name="cashBankAllUlFace">Выписки</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        public void AddCashBankAllUlFace(CashBankAllUlFace cashBankAllUlFace, string innUl)
        {
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                cashBankAllUlFace.IdUl = idUl;
            }
            if (cashBankAllUlFace.IdUl != 0)
            {
                if (!(from сashBankAllUlFaces in Automation.CashBankAllUlFaces where сashBankAllUlFaces.IdUl == cashBankAllUlFace.IdUl
                      && сashBankAllUlFaces.NumberCash == cashBankAllUlFace.NumberCash
                      && сashBankAllUlFaces.IdNum == cashBankAllUlFace.IdNum
                      && сashBankAllUlFaces.DateFinishPeriod == cashBankAllUlFace.DateFinishPeriod
                      && сashBankAllUlFaces.DateStartPeriod == cashBankAllUlFace.DateStartPeriod
                      && сashBankAllUlFaces.CashScoreStartPeriod == cashBankAllUlFace.CashScoreStartPeriod
                      && сashBankAllUlFaces.CashScoreFinishPeriod == cashBankAllUlFace.CashScoreFinishPeriod
                      select new { CashBankAllUlFace = сashBankAllUlFaces }).Any())
                {
                    Automation.CashBankAllUlFaces.Add(cashBankAllUlFace);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from сashBankAllUlFaces in context.CashBankAllUlFaces where сashBankAllUlFaces.IdUl == cashBankAllUlFace.IdUl
                                        && сashBankAllUlFaces.NumberCash == cashBankAllUlFace.NumberCash
                                        && сashBankAllUlFaces.IdNum == cashBankAllUlFace.IdNum
                                        && сashBankAllUlFaces.DateFinishPeriod == cashBankAllUlFace.DateFinishPeriod
                                        && сashBankAllUlFaces.DateStartPeriod == cashBankAllUlFace.DateStartPeriod
                                        && сashBankAllUlFaces.CashScoreStartPeriod == cashBankAllUlFace.CashScoreStartPeriod
                                        && сashBankAllUlFaces.CashScoreFinishPeriod == cashBankAllUlFace.CashScoreFinishPeriod
                                      select new { CashBankAllUlFace = сashBankAllUlFaces }).FirstOrDefault();
                        cashBankAllUlFace.Id = select.CashBankAllUlFace.Id;
                        Automation.Entry(cashBankAllUlFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно

        }
    }
}