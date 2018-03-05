using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows;
using DBFtoSQL2008Enterprise.Aplication.ResourceDBFtoSQL;
using DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ViewModel;
using MaterialDesignThemes.Wpf;
using MigSharp;

namespace DBFtoSQL2008Enterprise.Aplication.Logic
{
   public class LogicApplication
    {
        public static ICreatedTableBase CreateTableSql(IDatabase basetable, Dbf shemaViewModel)
        {
            var createtable = basetable.CreateTable(shemaViewModel.NameTable);
            foreach (var shemeClass in shemaViewModel.Sheme)
            {
                createtable.WithNullableColumn(shemeClass.Namecolums, shemeClass.Typecolums);
            }
            return createtable;
        }

        public static void SaveContentsToSqlTable(Dbf shema)
        {
            try
            {
                DbfCoding coding = new DbfCoding();
                if (coding.GetDbfCodepage(shema.Fullname) != 38)
                {
                    coding.SetDbfCodepage(shema.Fullname, 866);
                }
                using (var con = new OleDbConnection(ConectionString.ConectString.DbfConect))
                {
                    con.Open();
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "Select * From " + shema.FullName;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                using (var loader = new SqlBulkCopy(ConectionString.ConectString.SqlConection, SqlBulkCopyOptions.Default))
                                {
                                    loader.DestinationTableName = $"dbo.[{shema.NameTable}]";
                                    loader.BulkCopyTimeout = 9999;
                                    loader.WriteToServer(reader);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
