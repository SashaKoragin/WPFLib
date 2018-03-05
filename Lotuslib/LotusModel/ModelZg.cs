using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace Lotuslib.LotusModel
{
   public class ModelZg : BindableBase
    {
        public object _lock = new object();
        private ObservableCollection<ModelZg> _modelzg = new ObservableCollection<ModelZg>();

        public void UpdateOff()
        {
            BindingOperations.DisableCollectionSynchronization(ShemeDbZg);
        }

        public void UpdateOn()
        {
            BindingOperations.EnableCollectionSynchronization(ShemeDbZg, _lock);
        }

        public ObservableCollection<ModelZg> ShemeDbZg
        {
            get { return _modelzg; }
        }
        public ModelZg Selectzg = null;

        public ModelZg SelectZg
        {
            get { return Selectzg; }
            set { Selectzg = value; }
        }
        ICommand _onGroup;
        ICommand _groupstatus;
        //public void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
        //    GridViewColumnHeader column = (sender as GridViewColumnHeader);
        //    var st = ((Binding)column.Column.DisplayMemberBinding).Path.Path;
        //    MessageBox.Show(st);
        //}
        public CollectionView GroupColectionView { get; set; }
        public ICommand GroupStatus
        {
            get
            {
                if (_groupstatus == null)
                {
                    _groupstatus = new DelegateCommand<object>(a =>
                    {
                      GroupColectionView = (CollectionView)CollectionViewSource.GetDefaultView(ShemeDbZg);
                      PropertyGroupDescription groupDescription = new PropertyGroupDescription("NameFio");
                      GroupColectionView.GroupDescriptions.Add(groupDescription);
                });
                }
                return _groupstatus;
            }
        }
        public ICommand OnGroup
        {
            get
            {
                if (_onGroup == null)
                {
                    _onGroup = new DelegateCommand<object>(a =>
                        {
                            GroupColectionView.GroupDescriptions.Clear();
                        });
                }
                return _onGroup;
            }
        }

        /// <summary>
        /// Отдел на кого
        /// </summary>
        public string DepartamentZg;
        /// <summary>
        /// Статус ЗГ
        /// </summary>
        public string StatusZg;
        /// <summary>
        /// Дата регистрации ЗГ
        /// </summary>
        public object DataregZg;
        /// <summary>
        /// Номер ЗГ
        /// </summary>
        public string NumZg;
        /// <summary>
        /// Номер исходящего
        /// </summary>
        public string Incardrespoutnum;
        /// <summary>
        /// Дата исходящего
        /// </summary>
        public object Incardrespdi;
        /// <summary>
        /// Дата контроля
        /// </summary>
        public object Extofiledate;
        /// <summary>
        /// Имя того кто отправил письмо
        /// </summary>
        public string Namefio;

        public string NameFio
        {
            get { return Namefio; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Namefio = value;
            }
        }
        public string Departament
        {
            get { return DepartamentZg; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                DepartamentZg = value;
            }
        }

        public string Status
        {
            get { return StatusZg; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                StatusZg = value;
            }
        }

        public object Datareg
        {
            get { return DataregZg; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                DataregZg = value;
            }
        }
        public string Num
        {
            get { return NumZg; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                NumZg = value;
            }
        }

        public string InCardRespOutNum
        {
            get { return Incardrespoutnum; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Incardrespoutnum = value;
            }
        }
        public object InCardRespDi
        {
            get { return Incardrespdi; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Incardrespdi = value;
            }
        }
        public object ExToFileDate
        {
            get { return Extofiledate; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Extofiledate = value;
            }
        }
    }
}
