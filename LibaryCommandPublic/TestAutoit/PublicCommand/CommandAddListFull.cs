using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using System.Windows;
using AttributeHelperModelXml;
using ClosedXML;
using LibaryXMLAuto.Converts.ConvettToXml;
using LibaryXMLAuto.XsdModelAutoGenerate;
using ViewModelLib.ModelTestAutoit.AutoGenerateList.ModelGenerate;
using ViewModelLib.ModelTestAutoit.AutoGenerateList.ModelXlsxGenerate;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModelXml;

namespace LibraryCommandPublic.TestAutoit.PublicCommand
{
    /// <summary>
    /// Класс по формированию списка
    /// </summary>
   public class CommandAddListFull
    {
        /// <summary>
        /// Создание списка xml объектов
        /// </summary>
        /// <param name="modelAuto">Модель схемы по которой делаем список</param>
        /// <param name="modelXlsx">Xlsx файлы откуда тянем список</param>
        /// <param name="xmlModel">Модель файлов xml</param>
        /// <param name="pathSaveXml">Путь сохранения файла xml</param>
        public void CreateListModel(GenerateSchemesAutoModel modelAuto, ModelXlsxGenerate modelXlsx, ListViewModelXmlFileGenerateMethod xmlModel, string pathSaveXml)
        {
            if (modelAuto.IsValidationScheme() && modelXlsx.IsValidationXlsx())
            {
                xmlModel.UpdateOn();
                modelXlsx.UpdateOn();
                Task.Run((delegate
                {
                    try
                    {
                        var xmlConvert = new XmlConvert();
                        var instanceList = Activator.CreateInstance(typeof(List<>).MakeGenericType(modelAuto.Schemes.TypeObject));
                        var instanceMapper = Activator.CreateInstance(typeof(DataNamesMapper<>).MakeGenericType(modelAuto.Schemes.TypeObject));
                        LibraryAIS3Windows.XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new LibraryAIS3Windows.XlsxToDataTable.XlsxToDataTable();
                        foreach (var modelScheme in modelXlsx.SchemesXlsx)
                        {
                            var dataTable = xlsxToDataTable.GetDateTableXslx(modelScheme.FullPathFile, modelScheme.SelectionSheet,1, (uint)modelScheme.NumberMemoRow);
                            if (dataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).Any(col => modelAuto.Schemes.DescriptionMemo.Contains(col)))
                            {
                                var dataMapType = instanceMapper.GetType().GetMethod("Map")?.Invoke(instanceMapper, new object[] { dataTable });
                                instanceList.GetType().GetMethod("AddRange")?.Invoke(instanceList, new[] { dataMapType });
                            }
                            else
                            {
                                modelScheme.ErrorXml = $"Отсутствуют заголовки {string.Join(",", modelAuto.Schemes.DescriptionMemo)}";
                            }
                        }
                        var instanceAutoGenerate = Activator.CreateInstance(typeof(AutoGenerateSchemes));
                        var property = typeof(AutoGenerateSchemes).GetProperty(modelAuto.Schemes.NameSchemes);
                        if (property != null)
                            property.SetValue(instanceAutoGenerate, instanceMapper.GetType().GetMethod("ListToClass")?.Invoke(instanceMapper, new [] { instanceList }), null);
                        //Генерация файла
                        xmlConvert.SerializerClassToXml($"{pathSaveXml}AutoGenerateSchemes.xml", instanceAutoGenerate, instanceAutoGenerate.GetType());
                        //Добавление в модель
                        xmlModel.AddXmlFile(pathSaveXml);
                        modelXlsx.UpdateOff();
                        xmlModel.UpdateOff();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }));
            }
        }

    }
}
