using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AddModelProject.TestAutoit.AddModel;
using LibaryXMLAuto.ConvettToXml;
using Microsoft.Win32;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.CheckBoxModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ShemeXsd;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.StackPanelModel.ShemeSnuOneForm;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.TextBoxModel;

namespace LibaryCommandPublic.TestAutoit.SnuOneAuto.PublicCommand
{
   /// <summary>
   /// Библиотека для команд связана с библиотекой AddModelProject
   /// т.к. некоторые модели чтобы заполнить требуется логика выбора
   /// </summary>
   public class CommandFormirovanie
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

        public  void  FormirovanieXml(ModelSnuOneFormNameList modelsnuone, TextBoxModel textboxfilemodel,Sheme shemedocument, CheckBoxModel checkBoxModel,string path, ListViewModelXmlFileGenerate xmlmodel)
        {
                    var sheme = new AddModelTestAutoit();
                    XmlConvert convert = new XmlConvert();
                    if (shemedocument.IsValidation())
                    {
                        switch (shemedocument.Shema.Shemes)
                        {
                            case "SnuOneForm":
                                if (textboxfilemodel.IsValidation() && modelsnuone.IsValidation())
                                {
                                  xmlmodel.UpdateOn();
                                    Task.Run((delegate
                                       {
                                        try
                                           {
                                             xmlmodel.UpdateOn();
                                             convert.ConvertListSnuOneForm(textboxfilemodel.Path,
                                             modelsnuone.SelectList.Listletter,
                                             modelsnuone.SelectColumnLetter.ColumnName, checkBoxModel.IsCheced, path);
                                             sheme.UpdateXmlFile(xmlmodel, path);
                                             xmlmodel.UpdateOff();
                                           }
                                        catch (Exception e)
                                           {
                                             MessageBox.Show(e.Message);
                                           }
                                        }));
                                }
                                break;
                        }
                    }
        }

        public void Nransferes(string pathold,string pathnew)
        {
            if (File.Exists(pathnew))
            {
                File.Delete(pathnew);
            }
            File.Move(pathold,pathnew);
        }
    }
}
