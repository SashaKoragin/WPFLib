using AisPoco.Ifns51.ToAis;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.PreCheck.ReportingMemo;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace AutomatAis3Full.Form.Automat.PreCheck.ReportingMemo.DataContext
{
   public class ReportingMemoContext
    {
        public StatusButtonMethod Start { get; }

        public PublicModelCollectionSelect<TemplateModel> ModelTemplate { get; }

        public DelegateCommand<object> SelectModelTemplate { get; }
        public DelegateCommand<object> DeleteModelTemplate { get; }

        public ReportingMemoContext()
        {
            var  reportMemoStart = new ReportingMemoStart();
            var model = reportMemoStart.ResultGetTemplate(ConfigFile.AllTemplate);
            ModelTemplate = new PublicModelCollectionSelect<TemplateModel>(model);
            Start = new StatusButtonMethod
            {
                Button = {Command = new DelegateCommand(() => { reportMemoStart.ReportingMemoStartPreCheck(Start, 
                    ConfigFile.ServiceGetOrPost, 
                    ConfigFile.PathPdfTemp, 
                    ConfigFile.BankSvedSave, ModelTemplate
                    ); })}
            };
            SelectModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.SelectModelTemplate(param); });
            DeleteModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.DeleteModelTemplate(param); });
        }
    }
}
