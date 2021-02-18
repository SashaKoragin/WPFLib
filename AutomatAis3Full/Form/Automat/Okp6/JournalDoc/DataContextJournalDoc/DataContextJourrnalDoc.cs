using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using LibraryCommandPublic.TestAutoit.Okp6.JournalDoc;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp6.JournalDoc.DataContextJournalDoc
{
   public class DataContextJourrnalDoc
    {
        /// <summary>
        /// Кнопка старт
        /// </summary>
        public StatusButtonMethod StartButton { get; }

        /// <summary>
        /// Дата контекст
        /// </summary>
        public DataContextJourrnalDoc()
        {
            var docStart = new AutoJournalDoc();
            StartButton = new StatusButtonMethod
            {
                Button = { Command = new DelegateCommand(() => { docStart.StartDateJournalDoc(StartButton); }) }
            };
        }
    }
}
