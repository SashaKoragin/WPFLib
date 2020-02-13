using System;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Lotuslib.LotusModel;
using LotusNotes.Dialogs.Local.Expedition.DataContext;
using LotusNotes.Dialogs.Local.Expedition.View;

namespace LotusNotes.Command
{
    class CommandsUse
    { 

    public ICommand RunDialog => new CommandsClass(ExecuteDialog);
        /// <summary>
        /// Команда выбора диалогового окна
        /// </summary>
        /// <param name="selectitem"></param>
        private  void ExecuteDialog(object selectitem)
        {
            try
            {
            var item = (ModelComutator)Convert.ChangeType(selectitem, typeof(ModelComutator));
            if (item != null)
                switch (item.Title)
                {
                    case "Канцелярия ЗГ 2012":
                        var view = new Dialogs.Local.Zg.Global.Zg
                        {
                            DataContext = new ModelDialogs.ZgDialogModel(item.Path)
                        };
                         DialogHost.Show(view);
                        break;
                        case "Экспедиция 2012":
                            var viewExpedition = new ExpeditionView()
                            {
                                DataContext = new ExpeditionDataContext(item.Path)
                            };
                            DialogHost.Show(viewExpedition);
                            break;
                        default:
                        MessageBox.Show("На это еще не создано");
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
