using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using LibaryXMLAuto.Converts.ConvettToXml;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.CheckBoxModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModelXml;
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
        public void SelectFileSlsx(TextBoxModelMethod modelTextBox, ModelSnuOneFormNameListMethod modelSnuOne)
        {
            var dialog = new PublicLogicaFull.FileLogica.DialogWindowSelect.DialogFileSelect();
            var file = dialog.OpenFileDialog();
            if (file.Exists)
            {
                modelTextBox.NewFileXsls(file);
                modelSnuOne.AddParseXsls(file);
            }
        }
        /// <summary>
        /// Формирование списков xml по схеме!!! 
        /// </summary>
        /// <param name="modelsnuone">Модель схем</param>
        /// <param name="textboxfilemodel"></param>
        /// <param name="shemedocument"></param>
        /// <param name="checkBoxModel"></param>
        /// <param name="path"></param>
        /// <param name="xmlmodel"></param>
        public  void  FormirovanieXml(ModelSnuOneFormNameListProperty modelsnuone, TextBoxModelMethod textboxfilemodel,ShemeMethod shemedocument, CheckBoxModel checkBoxModel,string path, ListViewModelXmlFileGenerateMethod xmlmodel)
        {
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
                                             convert.ConvertListSnuOneForm(textboxfilemodel.Path,
                                             modelsnuone.SelectList.Listletter,
                                             modelsnuone.SelectColumnLetter.ColumnName, checkBoxModel.IsCheced, path);
                                             xmlmodel.AddXmlFile(path);
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
    }
}
