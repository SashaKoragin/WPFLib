using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Xsl;
using ClosedXML.Excel;
using LibaryXMLAutoModelXmlAuto.FileVisualId;
//using LibaryXMLAutoModelXmlAuto.ModelFaceFid;
using LibaryXMLAutoModelXmlAuto.FpdReg;
using LibaryXMLAutoModelXmlAuto.FullInnCount;
using LibaryXMLAutoModelXmlAuto.ModelFaceFid;
using LibaryXMLAutoModelXmlAuto.ModelFidZorI;
using LibaryXMLAutoModelXmlAuto.ModelJurnal;
using LibaryXMLAutoModelXmlAuto.ModelSnuOne;

namespace LibaryXMLAuto.Converts.ConvettToXml
{
    /// <summary>
    /// Класс конвертации xlsx то xmlSheme
    /// </summary>
    public class XmlConvert
    {
        /// <summary>
        /// Возвращает выбранный лист в Excel
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="list">Наименование листа</param>
        /// <returns>Лист</returns>
        private IXLWorksheet ListXlsx(string path, string list)
        {
            var worbook = new XLWorkbook(path);
            var ws = worbook.Worksheets.Worksheet(list);
            return ws;
        }
        /// <summary>
        /// Функция возвращает количество используемых строк 
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="letter">Название листа</param>
        /// <returns>Количество строк в столбце</returns>
        private int CountUseRow(IXLWorksheet list, string letter)
        {
            var countcell = list.Columns(letter).Cells().Count(inn => !inn.IsEmpty());
            return countcell;
        }
        /// <summary>
        /// Метод конвертации xlsx по xml sheme SnuOneForm.xsd
        /// Убирает повторяющиеся значения
        /// </summary>
        /// <param name="pathFilexlsx">Путь к файлу xlsx</param>
        /// <param name="listfile">Выбранный лист</param>
        /// <param name="letter">Буква в xlsx</param>
        /// <param name="isOneUseRows">Параметр указывающий Используем 1 строку или нет</param>
        /// <returns>Возвращаем List из столбца Excel</returns>
        private List<string> ListRowExcel(string pathFilexlsx, string listfile, string letter, bool isOneUseRows)
        {
            var ws = ListXlsx(pathFilexlsx, listfile);
            var countcell = CountUseRow(ws, letter);
            
            List<string> listinn = new List<string>();
            for (int i = Convert.ToInt32(isOneUseRows) + 1; i <= countcell; i++)
            {
                listinn.Add(ws.Cell(letter + i).Value.ToString());
            }
            return listinn.Distinct().ToList();
        }

        /// <summary>
        /// Метод конвертации xlsx по xml sheme SnuOneForm.xsd
        /// </summary>
        /// <param name="pathFilexlsx">Путь к файлу xlsx</param>
        /// <param name="listfile">Выбранный лист</param>
        /// <param name="letter">Буква в xlsx</param>
        /// <param name="isOneUseRows">Параметр указывающий Используем 1 строку или нет</param>
        /// <param name="path">Параметр пути сохранения</param>
        public void ConvertListSnuOneForm(string pathFilexlsx,string listfile,string letter,bool isOneUseRows,string path)
        {
            SerializSnuOneForm(ListRowExcel(pathFilexlsx,listfile,letter,isOneUseRows), path);
        }
        /// <summary>
        /// Метод конвертации xlsx по xml sheme FaceFid.xsd
        /// </summary>
        /// <param name="pathFilexlsx">Путь к файлу xlsx</param>
        /// <param name="listfile">Выбранный лист</param>
        /// <param name="letter">Буква в xlsx</param>
        /// <param name="isOneUseRows">Параметр указывающий Используем 1 строку или нет</param>
        /// <param name="path">Параметр пути сохранения</param>
        public void ConvertFidFace(string pathFilexlsx, string listfile, string letter, bool isOneUseRows, string path)
        {
            SerializFidFace(ListRowExcel(pathFilexlsx, listfile, letter, isOneUseRows), path);
        }

        /// <summary>
        /// Метод конвертации xlsx по xml sheme FaceFid.xsd
        /// </summary>
        /// <param name="pathFilexlsx">Путь к файлу xlsx</param>
        /// <param name="listfile">Выбранный лист</param>
        /// <param name="letter">Буква в xlsx</param>
        /// <param name="isOneUseRows">Параметр указывающий Используем 1 строку или нет</param>
        /// <param name="path">Параметр пути сохранения</param>
        public void ConvertIdVisual(string pathFilexlsx, string listfile, string letter, bool isOneUseRows, string path)
        {
            SerializIdVisual(ListRowExcel(pathFilexlsx, listfile, letter, isOneUseRows), path);
        }

        ///<summary>
        /// Метод конвертации xlsx по xml sheme FullInnCount.xsd
        /// <![CDATA[
        /// <?xml version="1.0" encoding="UTF-8"?>
        ///<INNList xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="FullInnCount.xsd">
        ///   <ListInn NumColection = "1" CountInn="4">
        ///      <MyInnn>d500306578530/503009784020/504601612560/772904428090</MyInnn>
        ///   </ListInn>
        ///   <ListInn NumColection = "2" CountInn="2">
	    ///      <MyInnn>500303703461/775101147891/</MyInnn>
        ///   </ListInn>
        ///   <ListInn NumColection = "3" CountInn="3">
	    ///      <MyInnn >500303703461/775101147891/772809074772</MyInnn>
        ///   </ListInn>
        ///</INNList>]]>
        /// </summary>
        /// <param name="pathFilexlsx">Выбранный файл</param>
        /// <param name="listfile">Выбранный лист</param>
        /// <param name="letter">Буква в xlsx</param>
        /// <param name="numrow">Номер строки</param>
        /// <param name="countinn">Количество по сколько формируем списки</param>
        /// <param name="path">Путь сохранения</param>
        public void ConvertInnMassList(string pathFilexlsx, string listfile, string letter, int numrow,int countinn, string path)
        {
            var j = 1; //Количество в массиве
            var m = 0; //Номер коллекции
            var ws = ListXlsx(pathFilexlsx, listfile);
            var countcell = CountUseRow(ws, letter);
            var maxmassiv = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(countcell) / Convert.ToDecimal(countinn))); //расчет максимального массива округлить в большую сторону
            List<string> listinn = new List<string>();
            var fullinn = new INNList() { ListInn = new ListInn[maxmassiv] }; 
            for (int i = numrow; i <= countcell; i++)
            {
                listinn.Add(ws.Cell(letter + i).Value.ToString());
                if ((j == countinn)||(i==countcell))
                {
                    ListInn list = new ListInn() {CountInn = j, NumColection = m, MyInnn = string.Join("/", listinn.ToArray()), CountInnSpecified = true, NumColectionSpecified = true};
                    fullinn.ListInn[m] = list;
                    listinn.Clear();
                    m++;
                    j = 0;
                }
                j++;
            }
            SerializerClassToXml(path, fullinn, typeof(INNList));
        }

        /// <summary>
        /// Подготовка значениий фид для сериализации по схеме
        /// <![CDATA[
        /// <?xml version="1.0" encoding="UTF-8"?>
        ///<FidFactZemlyOrImushestvo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="FidZemlyOrImushestvo.xsd">
        ///   <Fid FidZemlyOrImushestvo="72428058864"/>
        ///   <Fid FidZemlyOrImushestvo="71470728214"/>
        ///</FidFactZemlyOrImushestvo>]]>
        /// </summary>
        /// <param name="pathFilexlsx">Путь к файлу xlsx</param>
        /// <param name="listfile">Выбранный лист</param>
        /// <param name="letter">Буква в xlsx</param>
        /// <param name="isOneUseRows">Параметр указывающий Используем 1 строку или нет</param>
        /// <param name="path">Параметр пути сохранения</param>
        public void SerializFidZorI(string pathFilexlsx, string listfile, string letter, bool isOneUseRows, string path)
        {
            List<string> liststringrow = ListRowExcel(pathFilexlsx, listfile, letter, isOneUseRows);
            int i = 0;
            FidFactZemlyOrImushestvo fid = new FidFactZemlyOrImushestvo() {Fid = new LibaryXMLAutoModelXmlAuto.ModelFidZorI.Fid[liststringrow.Count]};
            foreach (var fidid in liststringrow)
            {
                LibaryXMLAutoModelXmlAuto.ModelFidZorI.Fid f = new LibaryXMLAutoModelXmlAuto.ModelFidZorI.Fid() {FidZemlyOrImushestvo = fidid};
                fid.Fid[i] = f;
                i++;
            }
            SerializerClassToXml(path, fid, typeof(FidFactZemlyOrImushestvo));
        }

        /// <summary>
        /// Метод конвертации в xml файл по схеме SnuOneForm.xsd
        /// <![CDATA[
        /// <?xml version="1.0"?>
        ///<SnuOneForm xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        ///    <INN INN ="504602844980" />
        ///    <INN INN="772576444844" />
        /// </SnuOneForm> ]]>
        /// </summary>
        /// <param name="masivInnStrings">Параметр список</param>
        /// <param name="path">Параметр пути сохранения</param>
        public void SerializSnuOneForm(List<string> masivInnStrings,string path)
        {
            int i = 0;
            SnuOneForm snu = new SnuOneForm() {INN = new INN[masivInnStrings.Count] };
            foreach (var inn in masivInnStrings)
            {
                INN k = new INN() {INN1 = inn};
                snu.INN[i] = k;
                i++;
            }
            SerializerClassToXml(path, snu, typeof(SnuOneForm));
        }

        /// <summary>
        /// Метод конвертации в xml файл по схеме SnuOneForm.xsd
        /// <![CDATA[
        /// <?xml version="1.0"?>
        ///<Face xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        ///    <Fid FidFace="100031408033" />
        ///    <Fid FidFace="100221670111" />
        /// </Face> ]]>
        /// </summary>
        /// <param name="masivInnStrings">Параметр список</param>
        /// <param name="path">Параметр пути сохранения</param>
        public void SerializFidFace(List<string> masivInnStrings, string path)
        {
            int i = 0;
            Face face = new Face() {Fid=new LibaryXMLAutoModelXmlAuto.ModelFaceFid.Fid[masivInnStrings.Count]};
            foreach (var fid in masivInnStrings)
            {
                var f = new LibaryXMLAutoModelXmlAuto.ModelFaceFid.Fid() { FidFace = fid };
                face.Fid[i] = f;
                i++;
            }
            SerializerClassToXml(path, face, typeof(Face));
        }
        /// <summary>
        /// Метод конвертации в xml файл по схеме SnuOneForm.xsd
        /// <![CDATA[
        /// <?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
        ///   <VisualIdent xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"VisualId.xsd\">\n" +
        ///        <IdZapros VisualId=\"98781525\"/>\n" +
        ///        <IdZapros VisualId=\"98781577\"/>\n" +
        ///   </VisualIdent>]]>
        /// </summary>
        /// <param name="masivInnStrings">Параметр список</param>
        /// <param name="path">Параметр пути сохранения</param>
        private void SerializIdVisual(List<string> masivInnStrings, string path)
        {
            int i = 0;
            VisualIdent ident = new VisualIdent() {IdZapros = new IdZapros[masivInnStrings.Count]};
            foreach (var fid in masivInnStrings)
            {
                var f = new IdZapros() { VisualId = fid };
                ident.IdZapros[i] = f;
                i++;
            }
            SerializerClassToXml(path, ident, typeof(VisualIdent));
        }

        /// <summary>
        /// Метод конвертации xlsx по xml sheme FpdReg.xsd
        /// </summary>
        /// <param name="pathFilexlsx">Путь к файлу xlsx</param>
        /// <param name="listfile">Выбранный лист</param>
        /// <param name="letter">Буква в xlsx</param>
        /// <param name="numrow">Строка с которой конвертируем значения</param>
        /// <param name="path">Параметр пути сохранения</param>
        public void ConvertListFpdReg(string pathFilexlsx, string listfile, string letter, int numrow, string path)
        {
            var ws = ListXlsx(pathFilexlsx, listfile);
            var countcell = CountUseRow(ws, letter);
            List<string> listinn = new List<string>();
            for (int i = numrow; i <= countcell; i++)
            {
                listinn.Add(ws.Cell(letter + i).Value.ToString());
            }
            SerializFpdReg(listinn, path);
        }

        /// <summary>
        /// Метод конвертации в xml файл по схеме FpdReg.xsd
        /// <![CDATA[
        /// <?xml version="1.0"?>
        ///<TreatmentFPD xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        ///    <Fpd FpdId="212206294"/>
        ///    <Fpd FpdId="82990935"/>
        /// </TreatmentFPD> ]]>
        /// </summary>
        /// <param name="masivFpdStrings">Параметр список ФПД </param>
        /// <param name="path">Параметр пути сохранения</param>
        private void SerializFpdReg(List<string> masivFpdStrings, string path)
        {
            int i = 0;
            TreatmentFPD znfpd = new TreatmentFPD() { Fpd  = new Fpd[masivFpdStrings.Count] };
            foreach (var fpd in masivFpdStrings)
            {
                Fpd k = new Fpd() { FpdId = fpd };
                znfpd.Fpd[i] = k;
                i++;
            }
            SerializerClassToXml(path, znfpd, typeof(TreatmentFPD));
        }


        /// <summary>
        /// Метод отрабатывает если Журнал с ошибками не создан дольше будеь добавлять элементы
        /// </summary>
        public void CreateJurnalError(string pathjurnal, string znacenie, string branch, string errors)
        {
            JurnalError error = new JurnalError() {Error = new Error[1]};
            Error er = new Error() { Inn = znacenie, Error1 = errors, System = branch, DateTimeUse = DateTime.Now, DateTimeUseSpecified = true};
            error.Error[0] = er;
            SerializerClassToXml(pathjurnal, error, typeof(JurnalError));
        }

        /// <summary>
        /// Метод отрабатывает если Журнал с ок не создан дольше будеь добавлять элементы
        /// </summary>
        public void CreateJurnalOk(string pathjurnal, string znacenie, string okeys)
        {
            OkJurnal okey = new OkJurnal() { Ok = new Ok[1] };
            Ok ok = new Ok() { Inn = znacenie, Message = okeys, DateTimeUse = DateTime.Now, DateTimeUseSpecified = true};
            okey.Ok[0] = ok;
            SerializerClassToXml(pathjurnal, okey, typeof(OkJurnal));
        }
        /// <summary>
        /// Функция Сериализации объекта по классу в XML
        /// </summary>
        /// <param name="path">Полный путь к файлу xml</param>
        /// <param name="objserialize">Объект для сериализациии как правило класс</param>
        /// <param name="objType">Тип объекта по которому будем сериализовывать</param>
        public void SerializerClassToXml(string path,object objserialize, Type objType)
        {
            XmlSerializer formatter = new XmlSerializer(objType);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,objserialize);
            }
        }
        /// <summary>
        /// Десериализация xml to object
        /// вернуть object
        /// </summary>
        /// <param name="path">Путь к xml файлу</param>
        /// <param name="objType">Тип объекта по которому будем сериализовывать</param>
        public object DeserializationXmlToClass(string path, Type objType)
        {
            object obj;
            XmlSerializer serializer = new XmlSerializer(objType);
            using (Stream reader = new FileStream(path, FileMode.Open))
            {

                obj = serializer.Deserialize(reader);
            }
            return obj;
        }
    }
}