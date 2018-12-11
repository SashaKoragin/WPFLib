using System;
using PublicLogicaFull.FileLogica.FileInfoLogica;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx
{
   public class ReportXlsxProperty
    {
        public ObservableCollection<ReportXlsxProperty> ReportXlsxel { get; } = new ObservableCollection<ReportXlsxProperty>();
        private ReportXlsxProperty _xlsx;
        private Icon _icon;
        private string _name;
        private string _path;
        public ReportXlsxProperty Xlsx
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
}

    public class ReportXlsxMethod : ReportXlsxProperty
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="pathdirectoryreport">Путь к файлу отчета Excel</param>
        public ReportXlsxMethod(string pathdirectoryreport)
        {
            UpdateColectFile(pathdirectoryreport);
        }
        /// <summary>
        /// Добавление Отчета Excel
        /// </summary>
        /// <param name="pathdirectoryreport">Полный путь ук файлу</param>
        public void UpdateColectFile(string pathdirectoryreport)
        {
            if (Directory.Exists(pathdirectoryreport))
            {
                var filelogica = new FileLogica();
                ReportXlsxel.Clear();
                foreach (var file in FileLogica.FileinfoMass(pathdirectoryreport))
                {
                    ReportXlsxel.Add(new ReportXlsxProperty { Icon = filelogica.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName });
                }
            }
        }
        /// <summary>
        /// Удаление отчета файла Excel
        /// </summary>
        public void DeleteReportFile()
        {
            File.Delete(Xlsx.Path);
            ReportXlsxel.Remove(ReportXlsxel.Single(name => name.Path == Xlsx.Path));
        }
        /// <summary>
        /// Открытие отчета Report Excel
        /// </summary>
        public void OpenReport()
        {
            PublicLogicaFull.FileLogica.OpenFile.OpenFile.Openxls(Xlsx.Path);
        }
    }
}
