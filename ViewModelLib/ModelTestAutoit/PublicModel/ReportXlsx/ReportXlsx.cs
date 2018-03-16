using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModel;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;

namespace ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx
{
   public class ReportXlsx
    {
        public ObservableCollection<ReportXlsx> _reportxlsxel = new ObservableCollection<ReportXlsx>();

        public ObservableCollection<ReportXlsx> ReportXlsxel
        {
            get { return _reportxlsxel; }
        }
        private ReportXlsx _xlsx;
        private Icon _icon;
        private string _name;
        private string _path;
        public ReportXlsx Xlsx
        {
            get { return _xlsx; }
            set
            {
                _xlsx = value;
            }
        }

        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        //public void AddFile(string path)
        //{
        //    if (Directory.Exists(path))
        //    {
        //        foreach (var file in Fileinfo(path))
        //        {
        //            ReportXlsxel.XmlFiles.Add(new ListViewModelXmlFileGenerate() { Icon = PublicAdd.IconsFile.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName });
        //        }
        //    }
        //}
}
}
