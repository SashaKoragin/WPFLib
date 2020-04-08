using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.PreCheck.ReportingMemo;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.PreCheck.ReportingMemo.DataContext
{
   public class ReportingMemoContext
    {
        public StatusButtonMethod Start { get; }
        public ReportingMemoContext()
        {
            var  reportMemoStart = new ReportingMemoStart();
            Start = new StatusButtonMethod
            {
                Button = {Command = new DelegateCommand(() => { reportMemoStart.ReportingMemoStartPreCheck(Start,ConfigFile.ServiceGetOrPost); })}
            };
        }
    }
}
