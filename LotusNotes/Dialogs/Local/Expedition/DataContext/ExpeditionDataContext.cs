using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace LotusNotes.Dialogs.Local.Expedition.DataContext
{
   public class ExpeditionDataContext : BindableBase
    {
        public string Db { get; set; }

        public ExpeditionDataContext(string dataBasePath)
        {
            Db = dataBasePath;
        }

    }
}
