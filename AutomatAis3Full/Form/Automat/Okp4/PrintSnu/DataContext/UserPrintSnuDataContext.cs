using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.Okp4.SnuOneAuto.AutoCommand;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.PdfModelPrint;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DatePicker;

namespace AutomatAis3Full.Form.Automat.Okp4.PrintSnu.DataContext
{
   public class UserPrintSnuDataContext
    {
        public PdfListFile PdfModel { get; }
        public XmlUseMethod Xml { get; }
        public StatusButtonMethod StartButton { get; }
        public DatePickerPub Date { get; }
        public ICommand Update { get; }
        public ICommand Green { get; }
        public ICommand Yellow { get; }
        public ICommand Validate { get; }
        public ICommand Validate2 { get; }
        public ICommand Moving { get; }
        public ICommand DeleteTemp { get; }
        public ICommand PrintPdf { get; }
        public UserPrintSnuDataContext()
        {
            PdfModel = new PdfListFile();
            var commandauto = new AutoCklicsAisCommand();
            StartButton = new StatusButtonMethod();
            Date = new DatePickerPub();
            Xml = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand((() => { commandauto.PrintSnu(Date, StartButton, ConfigFile.FileInnFull, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk, ConfigFile.Connection); }));
            Validate = new DelegateCommand(()=> {PdfModel.CountPdfTemp(ConfigFile.PathPdfTemp);});
            Validate2 = new DelegateCommand(()=> {PdfModel.CountPdfWork(ConfigFile.PathPdfWork);});
            Moving = new DelegateCommand((() => {PdfModel.MoveWork(ConfigFile.PathPdfWork);}));
            DeleteTemp = new DelegateCommand((() => {PdfModel.DeleteTemp();}));
            Yellow = new DelegateCommand(() => { Yellows(StartButton); });
            Green = new DelegateCommand(() => { Greens(StartButton); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.FileInnFull); });
            PrintPdf = new DelegateCommand(() => { PdfModel.PrintAllFile(ConfigFile.PathPdfWork); });
        }

        public void Yellows(StatusButtonMethod status)
        {
            status.StatusYellow();
        }
        public void Greens(StatusButtonMethod status)
        {
            status.StatusGrin();
        }
    }
}
