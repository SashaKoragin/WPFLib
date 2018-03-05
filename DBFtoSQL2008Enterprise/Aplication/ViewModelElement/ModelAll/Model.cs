using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using DBFtoSQL2008Enterprise.Aplication.ResourceDBFtoSQL;
using DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ViewModel;

namespace DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ModelAll
{
   public class Model
    {
        public ObservableCollection<Dbf> DbfModel(FileInfo fullInfo, Dbf model)
        {
            Dbf.ShemeClass sheme = new Dbf.ShemeClass { Sheme = new ObservableCollection<Dbf.ShemeClass>() };
            using (var con = new OleDbConnection(ConectionString.ConectString.DbfConect))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Select top 1 * From " + fullInfo.FullName;
                    using (var myReader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        if (myReader != null)
                        {
                            for (int i = 0; i < myReader.FieldCount; i++)
                            {
                                sheme.Sheme.Add(new Dbf.ShemeClass
                                {
                                    Indexcolums = i,
                                    Namecolums = myReader.GetName(i).ToUpper(),
                                    Typecolums = TypeDbftoSql.TypeSql(myReader.GetDataTypeName(i)),
                                    
                                });
                            }
                        }
                        if (myReader != null) myReader.Dispose();
                    }
                }
                    model.Shemes.Add(new Dbf
                    {
                        Nametable = Path.GetFileNameWithoutExtension(fullInfo.Name),
                        Fullname = fullInfo.FullName,
                        Sheme = sheme.Sheme,
                        
                    });
                con.Close();
            }
            return model.Shemes;
        }
    }
}
