using System.IO;
using System.Windows.Forms;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;


namespace LibaryCommandPublic.TestAutoit.SnuOneAuto.PublicCommand
{
    public class CommandSnuOneAuto
    {
        public void UpdateStatus(XmlUse xml, string path)
        {
            if (File.Exists(path))
            {
                var xmllibary = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                FileInfo file = new FileInfo(path);
                xml.Name = file.Name;
                xml.Count = xmllibary.CountAtribute(path);
                xml.Icon = AddModelProject.PublicAdd.IconsFile.Extracticonfile(file.FullName);
            }
            else
            {
                MessageBox.Show("Не существует файла по пути " + path);
            }
        }

        public void OpenFile(string path)
        {
           AddModelProject.OpenFile.OpenFilesPath.Openxls(path);
           
        }

        public void ConvertXslToXml(string path)
        {
            AddModelProject.OpenFile.OpenFilesPath.ConvertXmlToXls(path);
        }
    }

   
}
