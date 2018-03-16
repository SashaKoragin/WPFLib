using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ShemeXsd;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;
using Run = System.Windows.Documents.Run;


namespace AddModelProject.TestAutoit.AddModel
{
    public class AddModelTestAutoit
    {
        public static FileInfo[] Fileinfo(string path)
        {
            var dir = new DirectoryInfo(path);
            var files = dir.GetFiles();
            return files;
        }


        public ListViewModelXmlFileGenerate AddXmlFile(ListViewModelXmlFileGenerate xmlmodel,string path)
        {
            xmlmodel.XmlFiles.Clear();
            lock (xmlmodel._lock)
            {
                if (Directory.Exists(path))
                {

                    foreach (var file in Fileinfo(path))
                    {
                        xmlmodel.XmlFiles.Add(new ListViewModelXmlFileGenerate() {Icon = PublicAdd.IconsFile.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName});
                    }
                }
            }
            return xmlmodel;
        }

        public void UpdateXmlFile(ListViewModelXmlFileGenerate xmlmodel, string path)
        {
            xmlmodel.XmlFiles.Clear();
            lock (xmlmodel._lock)
            { 
                    if (Directory.Exists(path))
                    {
                        foreach (var file in Fileinfo(path))
                        {
                            xmlmodel.XmlFiles.Add(new ListViewModelXmlFileGenerate() { Icon = PublicAdd.IconsFile.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName });
                        }
                    }
            }
        }

        public void AddJurnals(ReportJurnal jurnal, string pathjurnal,string pathfile)
        {
            if (Directory.Exists(pathjurnal))
            {
                foreach (var file in Fileinfo(pathjurnal))
                {
                    jurnal.XmlReportJurnal.Add(new ReportJurnal {Icon = PublicAdd.IconsFile.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName});
                }
            }
            if (Directory.Exists(pathfile))
            {
                foreach (var file in Fileinfo(pathfile))
                {
                    jurnal.XmlFile.Add(new ReportJurnal { Icon = PublicAdd.IconsFile.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName });
                }
            }
        }

        public Sheme AddShemeUse(UserControl[] test)
        {
           var  sheme = new Sheme();
            sheme.Shemefulllist.Add(new Sheme() {Document = AddDocument.DocumentSnuOneForm(ExampleXml.ExampleXaml.SnuOneForm), Shemes = "SnuOneForm", UserContr = test[0] });
            sheme.Shemefulllist.Add(new Sheme() { Document = AddDocument.DocumentSnuOneForm("sdsddsadsadsa"), Shemes = "Новый список" , UserContr = test[1]});
            return sheme;
        }

    }


    public class AddDocument
    {
        internal static FlowDocument DocumentSnuOneForm(string example)
        {
            var document = new FlowDocument();
            document.Blocks.Add(new Paragraph(new Run("Образец на выходе!!!")) {TextIndent = 48, FontSize = 20, Foreground = Brushes.Red } );
            document.Blocks.Add(new Paragraph(new Run(example) {FontSize = 12}));
            return document;
        }
    }
}
