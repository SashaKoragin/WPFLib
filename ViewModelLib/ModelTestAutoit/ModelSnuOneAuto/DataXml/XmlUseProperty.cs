using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.PeerResolvers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml
{
    /// <summary>
    /// Наш файл со списком для обработки
    /// </summary>
   public class XmlUseProperty : BindableBase
   {
        private string _name;
        private Icon _icon;
        private int _count;
        /// <summary>
        /// Имя файла
        /// </summary>
       public string Name
       {
           get { return _name; }
           set
           {
               _name = value; 
               RaisePropertyChanged();
           }
       }
        /// <summary>
        /// Количество для отработки
        /// </summary>
       public int Count
       {
           get { return _count; }
           set
           {
               _count = value;
               RaisePropertyChanged();
           }
       }
        /// <summary>
        /// Иконка файл
        /// </summary>
       public Icon Icon
       {
           get { return _icon; }
           set
           {
               _icon = value; 
               RaisePropertyChanged();
           }
       }
        
   }
    /// <summary>
    /// Методы для обработки документа
    /// </summary>
    public class XmlUseMethod : XmlUseProperty
    {
        /// <summary>
        /// Обновление файла команда
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void UpdateFileXml(string path)
        {
            if (File.Exists(path))
            {
                var xmllibary = new LibaryXMLAuto.ReadOrWrite.LogicaXml.LogicaXml();
                FileInfo file = new FileInfo(path);
                Name = file.Name;
                Count = xmllibary.CountAtribute(LibaryXMLAuto.ReadOrWrite.LogicaXml.LogicaXml.Document(path));
                Icon = PublicLogicaFull.FileLogica.FileInfoLogica.FileLogica.Extracticonfile(file.FullName);
            }
            else
            {
                MessageBox.Show("Нет Списков для обработки по пути: " + path);
            }
        }
    }
}
