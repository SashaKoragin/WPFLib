using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm;
using ViewModelLib.ModelTestAutoit.TextBoxModel;

namespace LibaryCommandPublic.TestAutoit
{
   public class CommandTestAutoit
    {
        public void SelectFileSlsx(TextBoxModel modelTextBox, ModelSnuOneFormNameList modelSnuOne)
        {
            var win = new OpenFileDialog { Filter = "Файлы xlsx|*.xlsx", Multiselect = false };
            if (win.ShowDialog() == true)
            {
                FileInfo[] files = win.FileNames.Select(file => new FileInfo(file)).ToArray();
                AddModelProject.TestAutoit.CommandAddModel.CommandAddModel.AddTextBoxFile(files,ref modelTextBox,ref modelSnuOne); 
            }
        }
    }
}
