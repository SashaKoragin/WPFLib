using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm;

namespace ViewModelLib.ModelTestAutoit.ShemeXsd
{
   public class Sheme : BindableBase
    {
        /// <summary>
        /// Схема листов с колонками
        /// </summary>
        public ObservableCollection<Sheme> Shemefulllist = new ObservableCollection<Sheme>();

        private string _shemes;

        public string Shemes
        {
            get { return _shemes; }
            set
            {
                _shemes = value;
                RaisePropertyChanged();
            }
        }

    }
}
