using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm;
using ViewModelLib.ModelTestAutoit.TextBoxModel;

namespace AddModelProject.TestAutoit.CommandAddModel
{
   public class CommandAddModel
    {
        public static void AddTextBoxFile(FileInfo[] files,ref TextBoxModel textBoxModel,ref ModelSnuOneFormNameList modelSnuOne)
        {
            foreach (var file in files)
            {
                textBoxModel.Icon = PublicAdd.IconsFile.Extracticonfile(file.FullName);
                textBoxModel.Name = file.Name;
                textBoxModel.Path = file.FullName;
                new Logica.Parsexlsx.ParseXlsx().ParseXls(file.FullName,ref modelSnuOne);
            }
        }
    }
}
