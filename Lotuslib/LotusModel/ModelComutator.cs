using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Runtime.Serialization;

namespace Lotuslib.LotusModel
{
    [DataContract]
    public class ModelComutator : BindableBase
    {
         public ObservableCollection<ModelComutator> _shemedbcom = new ObservableCollection<ModelComutator>();
        [DataMember]
        public ObservableCollection<ModelComutator> ShemeDbCom
        { get { return _shemedbcom; } }

        public string Path;
        public string Title;
        [DataMember]
        public string PathDb
        {
            get { return Path; }
            set { Path = value; }
        }
        [DataMember]
        public string TitleDb
        {
            get { return Title; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Title = value;
            }
        }
    }
}