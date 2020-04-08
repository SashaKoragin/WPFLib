using System.Data.Entity;
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
        /// Добавление имущества ЮЛ
        /// </summary>
        /// <param name="propertyUlFace">Имущество</param>
        /// <param name="innUl">ИНН</param>
        public void AddPropertyUlFace(PropertyUlFace propertyUlFace, string innUl)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                propertyUlFace.IdUl = idUl;
            }
            if (propertyUlFace.IdUl != 0)
            {
                if (!(from propertyUlFaces in Automation.PropertyUlFaces where propertyUlFaces.IdNum == propertyUlFace.IdNum select new { PropertyUlFace = propertyUlFaces }).Any())
                {
                    Automation.PropertyUlFaces.Add(propertyUlFace);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from propertyUlFaces in context.PropertyUlFaces where propertyUlFaces.IdNum == propertyUlFace.IdNum select new { PropertyUlFace = propertyUlFaces }).FirstOrDefault();
                        propertyUlFace.Id = select.PropertyUlFace.Id;
                        Automation.Entry(propertyUlFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }

        /// <summary>
        /// Добавление имущества Земля
        /// </summary>
        /// <param name="landUlFace">Имущество</param>
        /// <param name="innUl">ИНН</param>
        public void AddLandUlFace(LandUlFace landUlFace, string innUl)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                landUlFace.IdUl = idUl;
            }
            if (landUlFace.IdUl != 0)
            {
                 if (!(from landUlFaces in Automation.LandUlFaces where landUlFaces.IdNum == landUlFace.IdNum select new { LandUlFace = landUlFaces }).Any())
                 {
                     Automation.LandUlFaces.Add(landUlFace);
                     Automation.SaveChanges();
                 }
                 else
                 {
                    using (var context = new Base.Automation())
                    {
                        var select = (from landUlFaces in context.LandUlFaces where landUlFaces.IdNum == landUlFace.IdNum select new { LandUlFace = landUlFaces }).FirstOrDefault();
                        landUlFace.Id = select.LandUlFace.Id;
                        Automation.Entry(landUlFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }
        /// <summary>
        /// Добавление имущества Транспорт
        /// </summary>
        /// <param name="transportUlFace">Транспорт</param>
        /// <param name="innUl">ИНН</param>
        public void AddTransportUlFace(TransportUlFace transportUlFace, string innUl)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                transportUlFace.IdUl = idUl;
            }
            if (transportUlFace.IdUl != 0)
            {
                if (!(from transportUlFaces in Automation.TransportUlFaces where transportUlFaces.IdNum == transportUlFace.IdNum select new { TransportUlFace = transportUlFaces }).Any())
                {
                    Automation.TransportUlFaces.Add(transportUlFace);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from transportUlFaces in context.TransportUlFaces where transportUlFaces.IdNum == transportUlFace.IdNum select new { TransportUlFace = transportUlFaces }).FirstOrDefault();
                        transportUlFace.Id = select.TransportUlFace.Id;
                        Automation.Entry(transportUlFace).State = EntityState.Modified;
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
        /// <param name="individualCardsUlFace">Карточка ОКВЕД</param>
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
            //Отсутствует лицо сохранение не возможно
        }

        public void AddIndividualNameParametr(IndividualNameParametr individualNameParametr, string innUl)
        {
            using (var context = new Base.Automation())
            {
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                individualNameParametr.IdUl = idUl;
            }
            if (individualNameParametr.IdUl != 0)
            {
                if (!(from individualNameParametrs in Automation.IndividualNameParametrs 
                      where individualNameParametrs.Years == individualNameParametr.Years 
                      && individualNameParametrs.NameParametr == individualNameParametr.NameParametr 
                      && individualNameParametrs.IdUl == individualNameParametr.IdUl
                      select new { IndividualNameParametrs = individualNameParametrs }).Any())
                {
                    Automation.IndividualNameParametrs.Add(individualNameParametr);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        var select = (from individualNameParametrs in context.IndividualNameParametrs where individualNameParametrs.Years == individualNameParametr.Years 
                                      && individualNameParametrs.NameParametr == individualNameParametr.NameParametr
                                      && individualNameParametrs.IdUl == individualNameParametr.IdUl
                                      select new { IndividualNameParametrs = individualNameParametrs }).FirstOrDefault();
                        individualNameParametr.Id = select.IndividualNameParametrs.Id;
                        Automation.Entry(individualNameParametr).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            //Отсутствует лицо сохранение не возможно
        }
    }
}
