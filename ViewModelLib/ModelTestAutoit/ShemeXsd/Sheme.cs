﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using Prism.Mvvm;
using ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm;

namespace ViewModelLib.ModelTestAutoit.ShemeXsd
{
    /// <summary>
    /// Класс модели образцов
    /// </summary>
   public class Sheme : BindableBase
    {
        /// <summary>
        /// Схема листов с колонками
        /// </summary>
        public ObservableCollection<Sheme> Shemefulllist = new ObservableCollection<Sheme>();
        /// <summary>
        /// Колекция образцов
        /// </summary>
        public ObservableCollection<Sheme> ShemeFullDocument
        { get { return Shemefulllist; } }

        private Sheme _sheme;
        public Sheme Shema
        {
            get { return _sheme; }
            set
            {
                _sheme = value;
                RaisePropertyChanged();
            }
        }

        private UserControl _control;
        private string _shemes;
        private FlowDocument _document;

        public UserControl UserContr
        {
            get { return _control; }
            set
            {
                _control = value;
                RaisePropertyChanged();
            }
            
        }
        /// <summary>
        /// Сама схема
        /// </summary>
        public string Shemes
        {
            get { return _shemes; }
            set
            {
                _shemes = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Документ образца
        /// </summary>
        public FlowDocument Document
        {
            get { return _document; }
            set
            {
                _document = value;
                RaisePropertyChanged();
            }
        }

    }
}
