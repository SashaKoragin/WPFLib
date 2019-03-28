using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.FullWindowAutoIt
{
    public class FullWindowAutoIt : BindableBase
    {
        /// <summary>
        /// Выбор контента Для Автомата
        /// </summary>
        public FullWindowAutoIt UseContent
        {
            get { return _useContent; }
            set
            {
                _useContent = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Имена колекций ОКП4,Регистрация, Формирование списков, Отчеты
        /// </summary>
        private string _nameControl;

        private FullWindowAutoIt _useContent;

        /// <summary>
        /// Коллекция UserControl Элементов
        /// </summary>
        private ObservableCollection<FullWindowAutoIt> _collectionUserControl;

        /// <summary>
        /// Элемены UserControl
        /// </summary>
        private UserControl _userControl;






























        public UserControl users = new UserControl() { Content = new Grid() { },
          };
























        public string NameControl
        {
            get { return _nameControl; }
            set
            {
                _nameControl = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<FullWindowAutoIt> CollectionUserControl
        {
            get { return _collectionUserControl; }
            set
            {
                _collectionUserControl = value;
                RaisePropertyChanged();
            }
        }

        public UserControl UserControl
        {
            get { return _userControl; }
            set
            {
                _userControl = value;
                RaisePropertyChanged();
            }
        }
    }
    public class FullWindowAutoItMethod : FullWindowAutoIt
    {
        private bool _isCheck;

        public bool IsCheck
        {
            get { return _isCheck; }
            set
            { _isCheck = value;
              RaisePropertyChanged();     
            }
        }

        public void IsCheked(object parametr)
        {
            var o = (FullWindowAutoIt) parametr;
            if (o.UserControl != null)
            {
                IsCheck = false;
            }
        }
    }

}