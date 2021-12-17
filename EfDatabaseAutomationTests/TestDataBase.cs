
using System.Reflection;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.ProcedureParametr;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
using LibaryDocumentGenerator.Documents.TemplateExcel;
using LibraryAIS3Windows.ButtonFullFunction.PreCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelGetPost = EfDatabaseAutomation.Automation.BaseLogica.ModelGetPost.ModelGetPost;

namespace EfDatabaseAutomationTests
{
    [TestClass]
   public class TestDataBase
    {

        [TestMethod]
        public void TestReturnObjectJson()
        {
            var logica = new EfDatabaseAutomation.Automation.SelectParametrSheme.LogicsSelectAutomation();
            logica.SelectUser = "Select * From TaxJournalAutoWebPage";
            var select = new SelectAll();
         //   var t = select.SqlModelAutomation<>(logica);
        }
        [TestMethod]
        public void ServerTestModel()
        {
            System.DateTime date1 = new System.DateTime(2021,4,26);
            System.DateTime date2 = new System.DateTime(2021, 4, 28);
            var ratchet = ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month;
            ratchet = ratchet == 0 ? 1 : ratchet;

            //var senderSelect = new SelectAll().SelectSenderJournal("7751-00-469");
        }
        [TestMethod]
        public void TestProcedure()
        {
            ModelSelect model = new ModelSelect() {ParametrsSelect = new ParametrsSelect() {Id = 1,IdCodeProcedure = 1,Inn = "7727280875",RegNumber = 0 } };
            model = (ModelSelect)typeof(SqlSelect).GetMethod("ParameterSelect")?.Invoke(new SqlSelect(), new object[] { model });
            Assembly db = typeof(DataBaseUlSelect).Assembly;
            if (model != null)
            {
                var type = db.GetType($"EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme.{model.ParameterProcedureWeb.ModelClassFind}");
                model = (ModelSelect)typeof(SqlSelect).GetMethod("ResultSelectProcedure")?.MakeGenericMethod(type).Invoke(new SqlSelect(), new object[] {model});
            }
        }
        [TestMethod]
        public void TestExcels()
        {
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            dataBaseAdd.AddDocPatent(new EfDatabaseAutomation.Automation.Base.Patent() { IdPatent = 1}, "C:\\Users\\7751-00-491\\Desktop\\tmp3C43.xlsx", "1");
        }

    }
}
