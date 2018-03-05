using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ViewModelPage.LoadingString
{
   public class Loading : BindableBase
    {
        public Loading(string text, int load)
        {
            _text = text;
            _load = load;
        }

        private string _text;
        private int _load;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged();
            }
        }

        public int Load
        {
            get { return _load; }
            set
            {
                _load = value;
                RaisePropertyChanged();
            }
        }
    }
}
