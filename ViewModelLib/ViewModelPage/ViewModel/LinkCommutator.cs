using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Prism.Mvvm;

namespace ViewModelLib.ViewModelPage.ViewModel
{
    [DataContract]
    public class LinkCommutator
    {

        private string _name;
        private object _content;
       
        public LinkCommutator(string name, object content, IEnumerable<Link> documentation)
        {
            _name = name;
            _content = content;
            Documentation = documentation;
        }
        [DataMember]
        public IEnumerable<Link> Documentation { get; }
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        [DataMember]
        public object Content
        {
            get { return _content; }
            set
            {
                _content = value;
            }
        }
    }
}
