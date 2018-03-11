using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibaryXMLAuto.ConvettToXml;
using Microsoft.Win32;
using ViewModelLib.Annotations;
using ViewModelLib.ModelTestAutoit.CheckBoxModel;
using ViewModelLib.ModelTestAutoit.ShemeXsd;
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
            modelTextBox.IsValidation();
        }

        public void FormirovanieXml(ModelSnuOneFormNameList modelsnuone, TextBoxModel textboxfilemodel,Sheme shemedocument, CheckBoxModel checkBoxModel)
        {
           XmlConvert convert = new XmlConvert();
            if (shemedocument.IsValidation())
            {
                switch (shemedocument.Shema.Shemes)
                {
                    case "SnuOneForm":
                        if (textboxfilemodel.IsValidation() && modelsnuone.IsValidation())
                        {
                          convert.ConvertListSnuOneForm(textboxfilemodel.Path,modelsnuone.SelectList.Listletter,modelsnuone.SelectColumnLetter.ColumnName,checkBoxModel.IsCheced);
                        }
                        break;
                }
            }
        }
    }
}
