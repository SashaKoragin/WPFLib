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
        /// <param name="cashFull">Картотека счетов</param>
        /// <param name="innUl">ИНН</param>
        public void AddCashUlFace(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc cashFull, string innUl)
        {
            //ИНН Есть ли лицо
            int idUl;
            using (var context = new Base.Automation())
            {
                idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                cashFull.CashUlFace.ToList().ForEach(cash=>cash.IdUl = idUl);
            }
            if (cashFull.CashUlFace[0].IdUl != 0)
            {
                //Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.CashUlFaces.RemoveRange(contextDelete.CashUlFaces.Where(x => x.IdUl == idUl));
                    contextDelete.SaveChanges();
                }
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}CashData.xml";
                xml.CreateXmlFile(xmlFile, cashFull, typeof(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
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
                idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                ndfl.NdflFl.ToList().ForEach(ndFl => ndFl.IdUl = idUl);
            }
            if (ndfl.NdflFl[0].IdUl != 0)
            {
                //Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.NdflFls.RemoveRange(contextDelete.NdflFls.Where(x => x.IdUl == idUl));
                    contextDelete.SaveChanges();
                }
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}CashData.xml";
                xml.CreateXmlFile(xmlFile, ndfl, typeof(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
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
                        var select = (from book in context.Books where book.IdBook == books.IdBook select new { Book = book }).FirstOrDefault();
                        books.Id = select.Book.Id;
                        books.IsBookPurchase = select.Book.IsBookPurchase;
                        books.IsBookSalesParse = select.Book.IsBookSalesParse;
                        Automation.Entry(books).State = EntityState.Modified;
                        Automation.SaveChanges();
                    }
                }
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
                contextDelete.BookPurchases.RemoveRange(contextDelete.BookPurchases.Where(x => x.IdBook == book.IdBook));
                contextDelete.SaveChanges();
            }
            XmlReadOrWrite xml = new XmlReadOrWrite();
            var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
            var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}bookPurchase.xml";
            xml.CreateXmlFile(xmlFile, bookPurchase, typeof(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc));
            BulkInsertIntoDb(xsdFile, xmlFile);
            UpdeteBookPurchase(ref books);

        }


        /// <summary>
        /// Добавление деклараций на все
        /// </summary>
        /// <param name="declarationUl">Основа декларации</param>
        /// <param name="declarationData">Массив строк декларации</param>
        /// <param name="innUl">ИНН</param>
        public void AddDeclarationModel(DeclarationUl declarationUl, XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc declarationData,  string innUl)
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
            //Отсутствует лицо сохранение не возможно
        }
        /// <summary>
        /// Добавление выписок в БД 
        /// </summary>
        /// <param name="cashBankAllUlFace">Выписки</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        public void AddCashBankAllUlFace(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc cashBankAllUlFace, string innUl)
        {
            //ИНН Есть ли лицо
            int idUl;
            using (var context = new Base.Automation())
            {
                idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                cashBankAllUlFace.CashBankAllUlFace.ToList().ForEach(cashBank=>cashBank.IdUl = idUl);
            }
            if (cashBankAllUlFace.CashBankAllUlFace[0].IdUl != 0)
            {
                //Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.CashBankAllUlFaces.RemoveRange(contextDelete.CashBankAllUlFaces.Where(x => x.IdUl == idUl));
                    contextDelete.SaveChanges();
                }
                XmlReadOrWrite xml = new XmlReadOrWrite();
                var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}CashDataBank.xml";
                xml.CreateXmlFile(xmlFile, cashBankAllUlFace, typeof(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc));
                BulkInsertIntoDb(xsdFile, xmlFile);
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
                var headingStatementFirst = (from head in context.HeadingStatements where head.NameIndex == headingStatement.NameIndex select head).SingleOrDefault();
                return headingStatementFirst;
            }
        }
        /// <summary>
        /// Добавление данных  в выписку Внутрянка
        /// </summary>
        /// <param name="statementFull">Body Statement</param>
        /// <param name="innUl">ИНН</param>
        public void AddStatementFull(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc statementFull, string innUl)
        {
            //ИНН Есть ли лицо
            int idUl;
            using (var context = new Base.Automation())
            {
                idUl = (from users in context.UlFaces where users.Inn == innUl select users.IdUl).SingleOrDefault();
                statementFull.StatementData.ToList().ForEach(state=>state.IdUl= idUl);
            }
            if (statementFull.StatementData[0].IdUl != 0)
            {
                //Удаляем старые записи по выписке заполняем новыми
                using (var contextDelete = new Base.Automation())
                {
                    contextDelete.StatementFulls.RemoveRange(contextDelete.StatementFulls.Where(x => x.IdUl == idUl));
                    contextDelete.SaveChanges();
                }
                    XmlReadOrWrite xml = new XmlReadOrWrite();
                    var xsdFile = $"{ConfigurationManager.AppSettings["PathXsdScheme"]}XsdAllBodyData.xsd";
                    var xmlFile = $"{ConfigurationManager.AppSettings["PathDownloadTempXml"]}DeclarationData.xml";
                    xml.CreateXmlFile(xmlFile, statementFull, typeof(XsdShemeSqlLoad.XsdAllBodyData.ArrayBodyDoc));
                    BulkInsertIntoDb(xsdFile, xmlFile);
            }
            //Процедура вытягивания учредителей и Руководителей Цель Выписки и Карточки организации
            var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 10);
            if (logicModel != null)
                using (var context = new Base.Automation())
                {
                    var resultDb = context.Database.SqlQuery<string>(logicModel.SelectUser, new SqlParameter(logicModel.SelectedParametr.Split(',')[0], innUl)).FirstOrDefault();
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
