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
   /// <summary>
   /// Библиотека для команд связана с библиотекой AddModelProject
   /// т.к. некоторые модели чтобы заполнить требуется логика выбора
   /// </summary>
   public class CommandTestAutoit
    {
        /// <summary>
        /// Команда Выбрать файл дальше направлям файл в коллекцию для дальнейшего разбора
        /// </summary>
        /// <param name="modelTextBox">Модель modelTextBox</param>
        /// <param name="modelSnuOne">Модель modelSnuOne</param>
        public void SelectFileSlsx(TextBoxModel modelTextBox, ModelSnuOneFormNameList modelSnuOne)
        {
            var win = new OpenFileDialog { Filter = "Файлы xlsx|*.xlsx", Multiselect = false };
            if (win.ShowDialog() == true)
            {
                FileInfo[] files = win.FileNames.Select(file => new FileInfo(file)).ToArray();
                AddModelProject.TestAutoit.CommandAddModel.CommandAddModel.AddTextBoxFile(files,ref modelTextBox,ref modelSnuOne); 
            }
        }

        public void FormirovanieXml(ModelSnuOneFormNameList modelsnuone, TextBoxModel textboxfilemodel)
        {
            if (!textboxfilemodel.IsValidation() & !modelsnuone.IsValidation())
            {
                
            }
            
        }
    }
}
