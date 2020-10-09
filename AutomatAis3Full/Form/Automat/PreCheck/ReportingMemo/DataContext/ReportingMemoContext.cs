using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.PreCheck.ReportingMemo;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.TemplateModel;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.PreCheck.ReportingMemo.DataContext
{
   public class ReportingMemoContext
    {
        public StatusButtonMethod Start { get; }
        public ReportingMemoContext()
        {
            var  reportMemoStart = new ReportingMemoStart();
            var model = reportMemoStart.ResultGetTemplate(ConfigFile.AllTemplate);
            Start = new StatusButtonMethod
            {
                Button = {Command = new DelegateCommand(() => { reportMemoStart.ReportingMemoStartPreCheck(Start, 
                    ConfigFile.ServiceGetOrPost, 
                    ConfigFile.PathPdfTemp, 
                    ConfigFile.BankSvedSave, new []{1,2}
                    ); })}
            };
        }
    }
}
