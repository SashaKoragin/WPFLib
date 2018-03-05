using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;

namespace ViewModelLib.ViewModelPage.ViewModel
{
    [DataContract]
    public class DemoItemIntereface : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string _name;
        private object _content;
        private ScrollBarVisibility _horizontalScrollBarVisibilityRequirement;
        private ScrollBarVisibility _verticalScrollBarVisibilityRequirement;
        private Thickness _marginRequirement = new Thickness(16);
        public DemoItemIntereface(string name, object content, IEnumerable<Link> documentation)
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
                OnPropertyChanged();
            }
        }
        [DataMember]
        public object Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        public ScrollBarVisibility HorizontalScrollBarVisibilityRequirement
        {
            get { return _horizontalScrollBarVisibilityRequirement; }
            set
            {
                _horizontalScrollBarVisibilityRequirement = value;
                OnPropertyChanged();
            }
        }

        public ScrollBarVisibility VerticalScrollBarVisibilityRequirement
        {
            get { return _verticalScrollBarVisibilityRequirement; }
            set
            {
                _verticalScrollBarVisibilityRequirement = value;
                OnPropertyChanged();
            }
        }

        public Thickness MarginRequirement
        {
            get { return _marginRequirement; }
            set
            {
                _marginRequirement = value;
                OnPropertyChanged();
            }
        }
    }
}
