
using System.Reflection;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.ProcedureParametr;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
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
            var t = select.SelectSqlAll(logica);
        }
        [TestMethod]
        public void ServerTestModel()
        {
            ModelGetPost model = new ModelGetPost();
            var result = model.LoadModelPreCheck("2");
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


    }
}
