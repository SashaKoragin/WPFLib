﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.PublicModel.LabelAndErrorModel
{
   public class LabelModel : BindableBase
   {
        private Brush _color;
        private string _url;
        private string _messageReport;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                RaisePropertyChanged();
            }
        }
        public string MessageReport
        {
            get { return _messageReport; }
            set
            {
                _messageReport = value;
                 RaisePropertyChanged();
            }
        }

        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                RaisePropertyChanged();
            }
        }
    }
}
