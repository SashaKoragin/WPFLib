using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DBFtoSQL2008Enterprise.Aplication.Page;
using DBFtoSQL2008Enterprise.Aplication.ViewModelElement.UpdateModel;
using DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ViewModel;
using MigSharp;

namespace DBFtoSQL2008Enterprise.Aplication.Sobytie
{
   public class TextSobytie
    {
        public void CreateLoadTableText(ConvertDbFtoSql xamlconvert)
        {
            UpdateModel modelupdate = new UpdateModel();
            modelupdate.UpdateModelProgressBarProgress(xamlconvert);
            float proc = 100.0f / xamlconvert.ListViewDbfView.Dispatcher.Invoke(()=>xamlconvert.ListViewDbfView.SelectedItems.Count);
            if (xamlconvert.ListViewDbfView != null)
                foreach (Dbf shema in xamlconvert.ListViewDbfView.Dispatcher.Invoke(() => xamlconvert.ListViewDbfView.SelectedItems))
                {
                    try
                    {
                        modelupdate.UpdateModelProgressBarProgress(xamlconvert,shema.NameTable,proc);
                        DbSchema shem = new DbSchema(ConectionString.ConectString.SqlConection, DbPlatform.SqlServer2008);
                        shem.Alter(basetable => Logic.LogicApplication.CreateTableSql(basetable, shema));
                        Logic.LogicApplication.SaveContentsToSqlTable(shema);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
              modelupdate.UpdateModelProgressBarProgress(xamlconvert);
        }

        //public void OnGroup(LotusConf xamLotusConf)
        //{
        //    CollectionView views = (CollectionView)CollectionViewSource.GetDefaultView(xamLotusConf.ListViewDbfViewLotus.ItemsSource);
        //    views.GroupDescriptions.Add(new PropertyGroupDescription("OtdelText"));
        //    views.Refresh();
        //}
    }
}
