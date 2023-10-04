using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;
using LibaryXMLAuto.ReadOrWrite;
using System.Configuration;
using EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData;


namespace EfDatabaseAutomation.Automation.BaseLogica.PreCheck
{
   public class PreCheckAddObject : IDisposable
    {
        public Base.Automation Automation { get; set; }

        public PreCheckAddObject()
        {
            Automation = new Base.Automation();
            Automation.Database.CommandTimeout = 120000;
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
                    context.Database.CommandTimeout = 120000;
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
                context.Database.CommandTimeout = 120000;
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
                        context.Database.CommandTimeout = 120000;
                        var select = (from svedAccoutingUlFaces in context.SvedAccoutingUlFaces where svedAccoutingUlFaces.IdNum == svedAccoutingUlFace.IdNum select new { SvedAccoutingUlFaces = svedAccoutingUlFaces }).FirstOrDefault();
                        svedAccoutingUlFace.Id = select.SvedAccoutingUlFaces.Id;
                        Automation.Entry(svedAccoutingUlFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
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
                context.Database.CommandTimeout = 120000;
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
                        context.Database.CommandTimeout = 120000;
                        var select = (from historiUlFaces in context.HistoriUlFaces where historiUlFaces.IdNum == historyUl.IdNum select new { HistoriUlFaces = historiUlFaces }).FirstOrDefault();
                        historyUl.Id = select.HistoriUlFaces.Id;
                        Automation.Entry(historyUl).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
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
                context.Database.CommandTimeout = 120000;
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                branchFace.IdUl = idUl;
            }
            if (branchFace.IdUl != 0)
            {
                if (!(from branchUlFaces in Automation.BranchUlFaces where branchUlFaces.IdNum == branchFace.IdNum
                      && branchUlFaces.RegionAddress == branchFace.RegionAddress
                      && branchUlFaces.DistrictAddress == branchFace.DistrictAddress
                      && branchUlFaces.TownAddress == branchFace.TownAddress
                      && branchUlFaces.LocalityAddress == branchFace.LocalityAddress
                      && branchUlFaces.StreetAddress == branchFace.StreetAddress
                      && branchUlFaces.HouseAddress == branchFace.HouseAddress
                      && branchUlFaces.BodyAddress == branchFace.BodyAddress
                      && branchUlFaces.IdUl == branchFace.IdUl
                      select new { BranchUlFaces = branchUlFaces }).Any())
                {
                   Automation.BranchUlFaces.Add(branchFace);
                   Automation.SaveChanges();
                }
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
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
                context.Database.CommandTimeout = 120000;
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
                        context.Database.CommandTimeout = 120000;
                        var select = (from imZmTrUls in context.ImZmTrUls where imZmTrUls.IdNum == imZmTrUl.IdNum select new { ImZmTrUl = imZmTrUls }).FirstOrDefault();
                        imZmTrUl.Id = select.ImZmTrUl.Id;
                        Automation.Entry(imZmTrUl).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
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
                context.Database.CommandTimeout = 120000;
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
                        context.Database.CommandTimeout = 120000;
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
                context.Database.CommandTimeout = 120000;
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
                        context.Database.CommandTimeout = 120000;
                        var select = (from strngthUlFaces in context.StrngthUlFaces where strngthUlFaces.IdNum == strngthUlFace.IdNum select new { StrngthUlFace = strngthUlFaces }).FirstOrDefault();
                        strngthUlFace.Id = select.StrngthUlFace.Id;
                        Automation.Entry(strngthUlFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
            }
            //Отсутствует лицо сохранение не возможно
        }

        /// <summary>
        /// Добавление Налоговое администрирование\Банковские и лицевые счета\09. Картотека счетов\01. Картотека счетов РО, ИО, ИП
        /// </summary>
        /// <param name="cashFull">Картотека счетов</param>
        /// <param name="innUl">ИНН</param>
        public void AddCashUlFace(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc cashFull, string innUl)
        {
            //ИНН Есть ли лицо
            int idUl;
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                cashFull.CashUlFace.ToList().ForEach(cash=>cash.IdUl = idUl);
            }
            if (cashFull.CashUlFace[0].IdUl != 0)
            {
                //Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.Database.CommandTimeout = 120000;
                    contextDelete.CashUlFaces.RemoveRange(contextDelete.CashUlFaces.Where(x => x.IdUl == idUl));
                    contextDelete.SaveChanges();
                }
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}CashData.xml";
                xml.CreateXmlFile(xmlFile, cashFull, typeof(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
            }
            //Отсутствует лицо сохранение не возможно
        }

        /// <summary>
        /// Добавление Налоговое администрирование\Физические лица\2.01. Сведения о доходах ФЛ\4.01. Доходы и вычеты по месяцам
        /// </summary>
        /// <param name="ndfl">Картотека счетов</param>
        /// <param name="innUl">ИНН</param>
        public void AddNdflDataBase(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc ndfl, string innUl)
        {
            //ИНН Есть ли лицо
            int idUl;
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                ndfl.NdflFl.ToList().ForEach(ndFl => ndFl.IdUl = idUl);
            }
            if (ndfl.NdflFl[0].IdUl != 0)
            {
                //Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.Database.CommandTimeout = 120000;
                    contextDelete.NdflFls.RemoveRange(contextDelete.NdflFls.Where(x => x.IdUl == idUl));
                    contextDelete.SaveChanges();
                }
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}CashData.xml";
                xml.CreateXmlFile(xmlFile, ndfl, typeof(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
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
                context.Database.CommandTimeout = 120000;
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
                        context.Database.CommandTimeout = 120000;
                        var select = (from individualCardsUlFaces in context.IndividualCardsUlFaces where individualCardsUlFaces.IdUl == individualCardsUlFace.IdUl select new { IndividualCardsUlFace = individualCardsUlFaces }).FirstOrDefault();
                        individualCardsUlFace.Id = select.IndividualCardsUlFace.Id;
                        Automation.Entry(individualCardsUlFace).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
            }
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
        /// Проверка наличия кники покупок и книгги продаж если нет наш клиент
        /// </summary>
        /// <param name="idBook">Регистрационный номер кники покупок продажи</param>
        /// <returns></returns>
        public bool IsExistsBook(long idBook)
        {
            if ((from book in Automation.Books where book.IdBook == idBook & (book.IsBookSalesParse == true & book.IsBookPurchase == true) select new {Books = book }).Any())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Добавление сведений о книги Покупки продажи
        /// </summary>
        /// <param name="books">Книга покупки продажи</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        public Book AddBook(Book books, string innUl)
        {
            //ИНН Есть ли лицо
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                books.IdUl = idUl;
            }
            if (books.IdUl != 0)
            {
                if (!(from book in Automation.Books where book.IdBook == books.IdBook select new { Book = book }).Any())
                {
                    Automation.Books.Add(books);
                    Automation.SaveChanges();
                }
                else
                {
                    using (var context = new Base.Automation())
                    {
                        context.Database.CommandTimeout = 120000;
                        var select = (from book in context.Books where book.IdBook == books.IdBook select new { Book = book }).FirstOrDefault();
                        books.Id = select.Book.Id;
                        books.IsBookPurchase = select.Book.IsBookPurchase;
                        books.IsBookSalesParse = select.Book.IsBookSalesParse;
                        Automation.Entry(books).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
            }
            return books;
            //Отсутствует лицо сохранение не возможно
        }
        /// <summary>
        /// Обновление признака 
        /// </summary>
        /// <param name="books">Книга Покупок обновление признака</param>
        public void UpdeteBookSalesParse(ref Book books)
        {
            var book = books;
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                var select = (from b in context.Books where b.IdBook == book.IdBook select new { Book = b }).FirstOrDefault();
                books.Id = select.Book.Id;
                books.IsBookSalesParse = true;
                Automation.Entry(books).State = EntityState.Modified;
                Automation.SaveChanges();
            }
        }
        /// <summary>
        /// Обновление признака 
        /// </summary>
        /// <param name="books">Книга продаж обновление признака</param>
        public void UpdeteBookPurchase(ref Book books)
        {
            var book = books;
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                var select = (from b in context.Books where b.IdBook == book.IdBook select new { Book = b }).FirstOrDefault();
                books.Id = select.Book.Id;
                books.IsBookPurchase = true;
                Automation.Entry(books).State = EntityState.Modified;
                Automation.SaveChanges();
            }
        }


        /// <summary>
        /// Добавление в БД Книги Покупок
        /// </summary>
        /// <param name="books">Книга</param>
        /// <param name="bookSales">Книга покупок</param>
        public void AddBookSales(ref Book books, ArrayBodyDoc bookSales)
        {
            var book = books;
            bookSales.BookSales.ToList().ForEach(sales => sales.IdBook = book.IdBook);
            using (var contextDelete = new Base.Automation())
            {
                contextDelete.Database.CommandTimeout = 120000;
                contextDelete.BookSales.RemoveRange(contextDelete.BookSales.Where(x => x.IdBook == book.IdBook));
                contextDelete.SaveChanges();
            }
            XmlReadOrWrite xml = new XmlReadOrWrite();
            var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
            var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}BookSales.xml";
            xml.CreateXmlFile(xmlFile, bookSales, typeof(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc));
            BulkInsertIntoDb(xsdFile, xmlFile);
            UpdeteBookSalesParse(ref books);

        }

        /// <summary>
        /// Добавление в БД Книги Продаж
        /// </summary>
        /// <param name="books">Книга</param>
        /// <param name="bookPurchase">Книга продаж</param>
        public void AddBookPurchase(ref Book books, ArrayBodyDoc bookPurchase)
        {
            var book = books;
            bookPurchase.BookPurchase.ToList().ForEach(sales => sales.IdBook = book.IdBook);
            using (var contextDelete = new Base.Automation())
            {
                contextDelete.Database.CommandTimeout = 120000;
                contextDelete.BookPurchases.RemoveRange(contextDelete.BookPurchases.Where(x => x.IdBook == book.IdBook));
                contextDelete.SaveChanges();
            }
            XmlReadOrWrite xml = new XmlReadOrWrite();
            var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
            var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}bookPurchase.xml";
            xml.CreateXmlFile(xmlFile, bookPurchase, typeof(ArrayBodyDoc));
            BulkInsertIntoDb(xsdFile, xmlFile);
            UpdeteBookPurchase(ref books);
        }

        /// <summary>
        /// Добавление контрагентов
        /// </summary>
        /// <param name="counterpartyCashBankModelFace">Основа декларации</param>
        /// <param name="innUl">ИНН</param>
        public void AddCounterpartyCashBankModel(ArrayBodyDoc counterpartyCashBankModelFace, string innUl)
        {
            //ИНН Есть ли лицо
            int idUl;
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                counterpartyCashBankModelFace.CounterpartyCashBank.ToList().ForEach(сounterpartyCashBank => сounterpartyCashBank.IdUl = idUl);
            }
            if (counterpartyCashBankModelFace.CounterpartyCashBank[0].IdUl != 0)
            {
                //Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.Database.CommandTimeout = 120000;
                    contextDelete.CounterpartyCashBanks.RemoveRange(contextDelete.CounterpartyCashBanks.Where(x => x.IdUl == idUl));
                    contextDelete.SaveChanges();
                }
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}CashDataBank.xml";
                xml.CreateXmlFile(xmlFile, counterpartyCashBankModelFace, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
            }
            //Отсутствует лицо сохранение не возможно
        }


        /// <summary>
        /// Добавление деклараций на все
        /// </summary>
        /// <param name="declarationUl">Основа декларации</param>
        /// <param name="declarationData">Массив строк декларации</param>
        /// <param name="innUl">ИНН</param>
        public void AddDeclarationModel(DeclarationUl declarationUl, ArrayBodyDoc declarationData,  string innUl)
        {
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                var idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                declarationUl.IdUl = idUl;
            }
            if (declarationUl.IdUl != 0)
            {
                if (!(from declarationUls in Automation.DeclarationUls
                      where declarationUls.RegNumDecl == declarationUl.RegNumDecl
                      select new { DeclarationUls = declarationUls }).Any())
                {
                    XmlReadOrWrite xml = new XmlReadOrWrite();
                    var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                    var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}DeclarationData.xml";
                    xml.CreateXmlFile(xmlFile, declarationData, typeof(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc));
                    Automation.DeclarationUls.Add(declarationUl);
                    try
                    {
                        Automation.SaveChanges();
                        BulkInsertIntoDb(xsdFile, xmlFile);
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
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
            }
            //Отсутствует лицо сохранение не возможно
        }
        /// <summary>
        /// Загрузка деклараций всех в БД
        /// </summary>
        /// <param name="declarationAll">Декларации</param>
        /// <param name="declarationData">Массив строк декларации</param>
        public void AddDeclarationAllModel(DeclarationAll declarationAll, ArrayBodyDoc declarationData)
        {
            if (!(from declarationAlls in Automation.DeclarationAlls
                  where declarationAlls.RegNumDecl == declarationAll.RegNumDecl
                select new { DeclarationAlls = declarationAlls }).Any())
            {
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}DeclarationDataAll.xml";
                xml.CreateXmlFile(xmlFile, declarationData, typeof(ArrayBodyDoc));
                Automation.DeclarationAlls.Add(declarationAll);
                try
                {
                    Automation.SaveChanges();
                    BulkInsertIntoDb(xsdFile, xmlFile);
                }
                catch (DbEntityValidationException ex)
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
        /// <summary>
        /// Получить информацию по декларации расхождения
        /// </summary>
        /// <param name="regNumDecl"></param>
        /// <returns></returns>
        public decimal SumDeclaration(int regNumDecl)
        {
          return Automation.Database.SqlQuery<decimal>(
                @"Select SUM(CONVERT(decimal(28,2),ISNULL(Error,0))) as Error From DeclarationDataAll " +
                " Where CodeString in ('П0743', 'П0043', 'П0044') and RegNumDecl = " +
                regNumDecl).FirstOrDefault();
        }
        /// <summary>
        /// Добавление выписок в БД 
        /// </summary>
        /// <param name="cashBankAllUlFace">Выписки</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        public void AddCashBankAllUlFace(ArrayBodyDoc cashBankAllUlFace, string innUl)
        {
            //ИНН Есть ли лицо
            int idUl;
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                cashBankAllUlFace.CashBankAllUlFace.ToList().ForEach(cashBank=>cashBank.IdUl = idUl);
            }
            if (cashBankAllUlFace.CashBankAllUlFace[0].IdUl != 0)
            {
                //Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.Database.CommandTimeout = 120000;
                    contextDelete.CashBankAllUlFaces.RemoveRange(contextDelete.CashBankAllUlFaces.Where(x => x.IdUl == idUl));
                    contextDelete.SaveChanges();
                }
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}CashDataBank.xml";
                xml.CreateXmlFile(xmlFile, cashBankAllUlFace, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
            }
            //Отсутствует лицо сохранение не возможно
        }
        /// <summary>
        /// Добавление Заголовка блока Выписки
        /// </summary>
        /// <param name="headingStatement">Заголовок блока</param>
        /// <returns></returns>
        public HeadingStatement AddHeadingStatement(HeadingStatement headingStatement)
        {
            if (!(from head in Automation.HeadingStatements where head.NameIndex == headingStatement.NameIndex select new { Head = head }).Any())
            {
                Automation.HeadingStatements.Add(headingStatement);
                Automation.SaveChanges();
            }
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                var headingStatementFirst = (from head in context.HeadingStatements where head.NameIndex == headingStatement.NameIndex select head).SingleOrDefault();
                return headingStatementFirst;
            }
        }
        /// <summary>
        /// Добавление данных  в выписку Внутрянка
        /// </summary>
        /// <param name="statementFull">Body Statement</param>
        /// <param name="innUl">ИНН</param>
        public void AddStatementFull(ArrayBodyDoc statementFull, string innUl)
        {
            //ИНН Есть ли лицо
            int idUl;
            using (var context = new Base.Automation())
            {
                context.Database.CommandTimeout = 120000;
                idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                statementFull.StatementData.ToList().ForEach(state=>state.IdUl= idUl);
            }
            if (statementFull.StatementData[0].IdUl != 0)
            {
                ////Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.Database.CommandTimeout = 120000;
                    contextDelete.StatementFulls.RemoveRange(contextDelete.StatementFulls.Where(x => x.IdUl == idUl));
                    contextDelete.SaveChanges();
                }
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}DeclarationData.xml";
                xml.CreateXmlFile(xmlFile, statementFull, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
            else
            {
                throw new InvalidOperationException($"Фатальная ошибка: Лицо c ИНН: {innUl} по шаблону 'Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации' не загруженно соответственно все предыдущие шаблоны не загруженны. Откатите шаблоны или уберите с загрузки данное лицо.");
            }
            //Процедура вытягивания учредителей и Руководителей Цель Выписки и Карточки организации
            var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 9);
            if (logicModel != null)
                using (var context = new Base.Automation())
                {
                    context.Database.CommandTimeout = 120000;
                    var resultDb = context.Database.SqlQuery<string>(logicModel.SelectUser, new SqlParameter(logicModel.SelectedParametr.Split(',')[0], innUl)).FirstOrDefault();
                }
        }

        /// <summary>
        /// Выгрузка первых 1000 удовлетворяющих условию
        /// </summary>
        /// <returns></returns>
        public IsPatentParse[] PatentExportFull()
        {
           return Automation.IsPatentParses.Where(patent => patent.IsParseFullPatent == false
                                                            || patent.IsParseDocPatent == false
                                                            || patent.IsParsePlaceOfBusiness == false
                                                            || patent.IsParseSvedTr == false
                                                            || patent.IsParseSvedObject == false
                                                            || patent.IsParseParametrNalog == false
                                                            || patent.IsParseSvedFactPatent == false).Take(150).ToArray();
        }
        /// <summary>
        /// Выборка первых 100 в которых нет ошибок
        /// </summary>
        /// <returns></returns>
        public FlFaceMainRegistration[] FlSelect100()
        {
            return Automation.FlFaceMainRegistrations.Where(fl => fl.IdStatus == 1 || fl.IdStatus == 2 || fl.IdStatus == 3
                                                                  && fl.IdError == null).Take(100).ToArray();
        }
        /// <summary>
        /// Выборка пола м/ж 
        /// </summary>
        /// <param name="name">Имя испытуемого</param>
        /// <returns></returns>
        public HName SelectName(string name)
        {
            return Automation.HNames.Where(fl => fl.N142 == name).FirstOrDefault();
        }

        /// <summary>
        /// Добавление лица и патента в БД
        /// </summary>
        /// <param name="face">Лицо ФЛ</param>
        /// <param name="patent">Патент</param>
        public IsPatentParse AddFlFaceAndPatent(FlFaceMain face, ref Patent patent)
        {
            var p = patent;
            if (!(from flFaceMain in Automation.FlFaceMains where flFaceMain.Inn == face.Inn select new { FlFaceMains = flFaceMain }).Any())
            {
                Automation.FlFaceMains.Add(face);
                Automation.SaveChanges();
            }
            if (!(from patents in Automation.Patents where patents.RegNumInfo == p.RegNumInfo && patents.RegNumPatent == p.RegNumPatent select new { Patents = patents }).Any())
            {
                var select = (from flFaceMain in Automation.FlFaceMains where flFaceMain.Inn == face.Inn select new { FlFaceMains = flFaceMain }).FirstOrDefault();
                patent.IdFl = select.FlFaceMains.IdFl;
                Automation.Patents.Add(patent);
                Automation.SaveChanges();
            }
            else
            {
                var selectFace = (from FlFaceMain in Automation.FlFaceMains where FlFaceMain.Inn == face.Inn select new { FlFaceMains = FlFaceMain }).FirstOrDefault();
                var selectPatent = (from Patent in Automation.Patents where Patent.RegNumInfo == p.RegNumInfo && Patent.RegNumPatent == p.RegNumPatent select new { Patents = Patent }).FirstOrDefault();
                patent.IdFl = selectFace.FlFaceMains.IdFl;
                patent.IdPatent = selectPatent.Patents.IdPatent;
                using (var contextUpdate = new Base.Automation())
                {
                    contextUpdate.Entry<Patent>(patent).State = EntityState.Modified;
                    contextUpdate.SaveChanges();
                }
            }
            return Automation.IsPatentParses.First(x => x.RegNumPatent == p.RegNumPatent);
        }
        /// <summary>
        /// Обновление модели патента
        /// </summary>
        /// <param name="isParsePatent">Модель в работе</param>
        public void UpdateIsParsePatent(IsPatentParse isParsePatent)
        {
            var isPatentParse = new IsPatentParse()
            {
                IdNum =isParsePatent.IdNum,
                RegNumPatent = isParsePatent.RegNumPatent,
                IsParseFullPatent = isParsePatent.IsParseFullPatent,
                IsParseDocPatent = isParsePatent.IsParseDocPatent,
                IsParsePlaceOfBusiness = isParsePatent.IsParsePlaceOfBusiness,
                IsParseSvedObject = isParsePatent.IsParseSvedObject,
                IsParseSvedTr = isParsePatent.IsParseSvedTr,
                IsParseParametrNalog = isParsePatent.IsParseParametrNalog,
                IsParseSvedFactPatent = isParsePatent.IsParseSvedFactPatent
            };
            Automation.Entry(isPatentParse).State = EntityState.Modified;
            Automation.SaveChanges();
        }
        /// <summary>
        /// Загрузка документов патента
        /// </summary>
        /// <param name="docPatent">Модель для загрузки документа патента</param>
        public void AddDocPatent(ArrayBodyDoc docPatent)
        {
            var index = docPatent.DocPatent[0].IdPatent;
            if (index != 0)
            {
                Automation.DocPatents.RemoveRange(Automation.DocPatents.Where(x => x.IdPatent == index));
                Automation.SaveChanges();
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}DocPatent.xml";
                xml.CreateXmlFile(xmlFile, docPatent, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
        }
        /// <summary>
        /// Загрузка сведений о месте осуществления деятельности
        /// </summary>
        /// <param name="docPatent">Модель для загрузки сведений о месте осуществления деятельности</param>
        public void AddPlaceOfBusiness(ArrayBodyDoc docPatent)
        {
            var index = docPatent.PlaceOfBusiness[0].IdPatent;
            if (index != 0)
            {
                Automation.PlaceOfBusinesses.RemoveRange(Automation.PlaceOfBusinesses.Where(x => x.IdPatent == index));
                Automation.SaveChanges();
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}PlaceOfBusiness.xml";
                xml.CreateXmlFile(xmlFile, docPatent, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
        }
        /// <summary>
        /// Загрузка сведений о транспортных средствах
        /// </summary>
        /// <param name="docPatent">Модель для загрузки сведений о транспортных средствах</param>
        public void AddSvedTr(ArrayBodyDoc docPatent)
        {
            var index = docPatent.SvedTr[0].IdPatent;
            if (index != 0)
            {
                Automation.SvedTrs.RemoveRange(Automation.SvedTrs.Where(x => x.IdPatent == index));
                Automation.SaveChanges();
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}SvedTr.xml";
                xml.CreateXmlFile(xmlFile, docPatent, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
        }

        /// <summary>
        /// Загрузка сведений об обособленных объектах
        /// </summary>
        /// <param name="docPatent">Модель для загрузки сведений об обособленных объектах</param>
        public void AddSvedObject(ArrayBodyDoc docPatent)
        {
            var index = docPatent.SvedObject[0].IdPatent;
            if (index != 0)
            {
                Automation.SvedObjects.RemoveRange(Automation.SvedObjects.Where(x => x.IdPatent == index));
                Automation.SaveChanges();
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}SvedObject.xml";
                xml.CreateXmlFile(xmlFile, docPatent, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
        }
        /// <summary>
        /// Загрузка параметров расчета налога
        /// </summary>
        /// <param name="docPatent">Модель для загрузки параметров расчета налога</param>
        public void AddParametrNalog(ArrayBodyDoc docPatent)
        {
            var index = docPatent.ParametrNalog[0].IdPatent;
            if (index != 0)
            {
                Automation.ParametrNalogs.RemoveRange(Automation.ParametrNalogs.Where(x => x.IdPatent == index));
                Automation.SaveChanges();
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}ParametrNalog.xml";
                xml.CreateXmlFile(xmlFile, docPatent, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
        }
        /// <summary>
        /// Загрузка сведений по фактическому действию патента
        /// </summary>
        /// <param name="docPatent">Модель для загрузки сведений по фактическому действию патента</param>
        public void AddSvedFactPatent(ArrayBodyDoc docPatent)
        {
            var index = docPatent.SvedFactPatent[0].IdPatent;
            if (index != 0)
            {
                Automation.SvedFactPatents.RemoveRange(Automation.SvedFactPatents.Where(x => x.IdPatent == index));
                Automation.SaveChanges();
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}SvedFactPatent.xml";
                xml.CreateXmlFile(xmlFile, docPatent, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }
        }
        /// <summary>
        /// Загрузка декларации ФЛ в БД
        /// </summary>
        /// <param name="declarationFl">Декларация ФЛ</param>
        /// <param name="declarationData">Данные декларации ФЛ</param>
        public void AddDeclarationFlModel(ref DeclarationFl declarationFl, ArrayBodyDoc declarationData)
        {
            var sum = declarationData.DeclarationDataFl.Where(model => model.CodeString == "П0388").Select(cash => Convert.ToDouble(cash.Error)).Sum();
            var inn = declarationFl.InnNp;
            var regNumDecl = declarationFl.RegNumDecl;
            var flSelect = from flFaces in Automation.FlFaces
                                           where flFaces.Inn == inn
                                           select new { FlFaces = flFaces };
            var fl = new FlFace()
            {
                IdFl = flSelect.FirstOrDefault() != null ? flSelect.FirstOrDefault().FlFaces.IdFl : 0,
                Inn = declarationFl.InnNp,
                NameFl = declarationFl.NameNp
            };
            using (var context = new Base.Automation())
            {
                if (!(flSelect).Any()) { context.FlFaces.Add(fl); } else { context.Entry(fl).State = EntityState.Modified; }
                context.SaveChanges();
            }
            declarationFl.IdFl = fl.IdFl;
            declarationFl.SummSignOfDevialion = sum;
            declarationFl.SignOfDevialion = sum != 0;
            if (!(from declarationFls in Automation.DeclarationFls
                  where declarationFls.RegNumDecl == regNumDecl
                  select new { DeclarationFls = declarationFls }).Any())
            {
                Automation.DeclarationFls.Add(declarationFl);
                Automation.SaveChanges();
            }
            else
            {
                Automation.Entry(declarationFl).State = EntityState.Modified;
                Automation.SaveChanges();
            }
            //Удаляем старые записи по выписке заполняем новыми
            using (var contextDelete = new Base.Automation())
            {
                contextDelete.Database.CommandTimeout = 120000;
                contextDelete.Database.ExecuteSqlCommand("Delete From DeclarationDataFl Where RegNumDecl = "+regNumDecl);
            }
            XmlReadOrWrite xml = new XmlReadOrWrite();
            var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
            var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}DeclarationDataAll.xml";
            xml.CreateXmlFile(xmlFile, declarationData, typeof(ArrayBodyDoc));
            BulkInsertIntoDb(xsdFile, xmlFile);
        }

        /// <summary>
        /// Загрузка декларации ФЛ в БД
        /// </summary>
        /// <param name="declaration3NdflFl">Декларация Автоматическая 3 НДФЛ ФЛ</param>
        /// <param name="declarationData">Данные декларации ФЛ</param>
        public void AddDeclaration3NdflFlModel(ref Declaration3NdflFl declaration3NdflFl, ArrayBodyDoc declarationData)
        {
            var inn = declaration3NdflFl.InnNp;
            var regNumDecl = declaration3NdflFl.RegNumDecl;
            var flSelect = from flFaces in Automation.FlFaces
                           where flFaces.Inn == inn
                           select new { FlFaces = flFaces };
            var fl = new FlFace()
            {
                IdFl = flSelect.FirstOrDefault() != null ? flSelect.FirstOrDefault().FlFaces.IdFl : 0,
                Inn = declaration3NdflFl.InnNp,
                NameFl = declaration3NdflFl.NameNp
            };
            using (var context = new Base.Automation())
            {
                if (!(flSelect).Any()) { context.FlFaces.Add(fl); } else { context.Entry(fl).State = EntityState.Modified; }
                context.SaveChanges();
            }
            declaration3NdflFl.IdFl = fl.IdFl;
            SaveAndEdit3Ndfl(ref declaration3NdflFl, regNumDecl);

            //Удаляем старые записи по выписке заполняем новыми
            using (var contextDelete = new Base.Automation())
            {
                contextDelete.Database.CommandTimeout = 120000;
                contextDelete.Database.ExecuteSqlCommand("Delete From DeclarationData3NdflFl Where RegNumDecl = " + regNumDecl);
            }
            XmlReadOrWrite xml = new XmlReadOrWrite();
            var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
            var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}DeclarationDataAll.xml";
            xml.CreateXmlFile(xmlFile, declarationData, typeof(ArrayBodyDoc));
            BulkInsertIntoDb(xsdFile, xmlFile);
        }
        /// <summary>
        /// Сохранение 3 НДФЛ
        /// </summary>
        /// <param name="declaration3Ndfl">Декларация 3 НДФЛ</param>
        /// <param name="regNumber">Регистрационный номер</param>
        public void SaveAndEdit3Ndfl(ref Declaration3NdflFl declaration3Ndfl, long regNumber)
        {
            
            if (!(from declaration3NdflFl in Automation.Declaration3NdflFl
                where declaration3NdflFl.RegNumDecl == regNumber
                  select new { Declaration3NdflFl = declaration3NdflFl }).Any())
            {
                Automation.Declaration3NdflFl.Add(declaration3Ndfl);
                Automation.SaveChanges();
            }
            else
            {
                Automation.Entry(declaration3Ndfl).State = EntityState.Modified;
                Automation.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flFace">Налогоплательщик</param>
        /// <param name="factOfOwner">Факт владения</param>
        /// <param name="documentOwnerFace">Документы факта владения</param>
        public void SaveFactOwnerAllDocument(FlFace flFace, FactOfOwnershipImZmTrFl factOfOwner, ArrayBodyDoc documentOwnerFace)
        {
            var flSelect = from flFaces in Automation.FlFaces
                           where flFaces.Inn == flFace.Inn
                           select new { FlFaces = flFaces };
            flFace.IdFl = flSelect.FirstOrDefault() != null ? flSelect.FirstOrDefault().FlFaces.IdFl : 0;
            using (var context = new Base.Automation())
            {
                if (!flSelect.Any()) { context.FlFaces.Add(flFace); } else { context.Entry(flFace).State = EntityState.Modified; }
                context.SaveChanges();
            }
            factOfOwner.IdFl = flFace.IdFl;
            SaveFactOwner(ref factOfOwner, factOfOwner.FidObject);
            if (documentOwnerFace != null)
            {
                //Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.Database.CommandTimeout = 120000;
                    contextDelete.Database.ExecuteSqlCommand("Delete From DocumentOwnershipImZmTrFl Where FidObject = " + factOfOwner.FidObject);
                }
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}DeclarationDataAll.xml";
                xml.CreateXmlFile(xmlFile, documentOwnerFace, typeof(ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
            }

        }
        /// <summary>
        /// Поиск и обновление данных о факте владения
        /// </summary>
        /// <param name="factOfOwner">Факт владения</param>
        /// <param name="fidFidObject">Фид факта владения</param>
        private void SaveFactOwner(ref FactOfOwnershipImZmTrFl factOfOwner, long fidFidObject)
        {
            if (!(from factOfOwnershipImZmTrFls in Automation.FactOfOwnershipImZmTrFls
                  where factOfOwnershipImZmTrFls.FidObject == fidFidObject
                  select new { FactOfOwnershipImZmTrFls = factOfOwnershipImZmTrFls }).Any())
            {
                Automation.FactOfOwnershipImZmTrFls.Add(factOfOwner);
                Automation.SaveChanges();
            }
            else
            {
                Automation.Entry(factOfOwner).State = EntityState.Modified;
                Automation.SaveChanges();
            }
        }

        /// <summary>
        /// Загрузка 
        /// </summary>
        /// <param name="fullPathXsdScheme">Полный путь к схеме xsd для загрузки данных</param>
        /// <param name="fullPathXml">Полный путь к xml для загрузки</param>
        public void BulkInsertIntoDb(string fullPathXsdScheme, string fullPathXml)
        {
            var bulkLoader = new SQLXMLBULKLOADLib.SQLXMLBulkLoad4
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["BulkCopyXml"].ConnectionString,
                ForceTableLock = true,
                BulkLoad = true,
                Transaction = false,
                KeepIdentity = false,
            };
            bulkLoader.Execute(fullPathXsdScheme, fullPathXml);
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
