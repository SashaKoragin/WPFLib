
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
