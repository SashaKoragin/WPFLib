using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DBFtoSQL2008Enterprise.Aplication.Page;
using DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ModelAll;
using DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ViewModel;
using Microsoft.Win32;


namespace DBFtoSQL2008Enterprise.Aplication.Commands
{
   public class CommandsText
    {

        public void LoadFileDbfText(object parameter)
        {
            ListView list = (ListView)Convert.ChangeType(parameter, typeof(ListView));
            var dbfModel = new Dbf { Shemes = new ObservableCollection<Dbf>() };
            Model model = new Model();
            var win = new OpenFileDialog { Filter = "Файлы dbf|*.dbf", Multiselect = true };
            win.Multiselect = true;
            if (win.ShowDialog() == true)
            {
                FileInfo[] files = win.FileNames.Select(f => new FileInfo(f)).ToArray();
                foreach (FileInfo file in files)
                {
                    if (list != null)
                     
                  list.Dispatcher.Invoke(() => list.ItemsSource = model.DbfModel(file, dbfModel));
                }
            }
        }
    }
}
