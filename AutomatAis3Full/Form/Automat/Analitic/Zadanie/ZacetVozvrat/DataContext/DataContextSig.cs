using System.Windows.Input;
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using LibaryCommandPublic.TestAutoit.Analitic.TheUserTask;

namespace AutomatAis3Full.Form.Automat.Analitic.Zadanie.ZacetVozvrat.DataContext
{
    /// <summary>
    /// Класс преднозначен для Подписывание руководителем Зачеты возвраты
    /// </summary>
    class DataContextSig
    {
        public StatusButtonMethod StartButton { get; }
        public ICommand Green { get; }
        public ICommand Yellow { get; }
        public DataContextSig()
        {
            AutoClikcsTask task = new AutoClikcsTask();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => {task.SigZacetVozvrat(StartButton);});
            Yellow = new DelegateCommand(() => { Yellows(StartButton); });
            Green = new DelegateCommand(() => { Greens(StartButton); });
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
