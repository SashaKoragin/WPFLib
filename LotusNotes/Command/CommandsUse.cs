using System;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Lotuslib.LotusModel;

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
                            DataContext = new ModelDialogs.ZgDialogModel("IFNS\\2012\\Arhiv2016\\ZG_Arhiv_2017.nsf") //"IFNS\\2012\\Arhiv2016\\ZG_Arhiv_2017.nsf"
                        };
                         DialogHost.Show(view);
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
