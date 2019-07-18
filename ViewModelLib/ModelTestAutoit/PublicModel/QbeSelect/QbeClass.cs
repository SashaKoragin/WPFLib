using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;

namespace ViewModelLib.ModelTestAutoit.PublicModel.QbeSelect
{
    /// <summary>
    /// Поля C b F в имуществе
    /// </summary>
    public class QbeClass
    {
        private ObservableCollection<ParamQbe> _statusC  = new ObservableCollection<ParamQbe>();
        private ObservableCollection<ParamQbe> _statusF  = new ObservableCollection<ParamQbe>();

        public ObservableCollection<ParamQbe> StatusC { get; set; } = new ObservableCollection<ParamQbe>();
        public ObservableCollection<ParamQbe> StatusF { get; set; } = new ObservableCollection<ParamQbe>();

        public ObservableCollection<ParamQbe> F
        {
            get { return _statusF; }
            set
            {
                _statusF = value;
            }
        }

        public ObservableCollection<ParamQbe> C
        {
            get { return _statusC; }
            set
            {
                _statusC = value;
            }
        }
    }


    public class QbeClassMethod : QbeClass
    {
        /// <summary>
        /// Объявление класса
        /// </summary>
        public QbeClassMethod()
        {
            AddColectionQbe();
        }
        /// <summary>
        /// Добавление QBE полей
        /// </summary>
        private void AddColectionQbe()
        {
            StatusC.Add(new ParamQbe() { ColorNum = Brushes.Yellow, Num = 14 });
            StatusC.Add(new ParamQbe() {ColorNum = Brushes.Aqua, Num = 11});
            StatusC.Add(new ParamQbe() {ColorNum = Brushes.Brown, Num = 4});
            StatusF.Add(new ParamQbe() { ColorNum = Brushes.Yellow, Num = 14 });
            StatusF.Add(new ParamQbe() { ColorNum = Brushes.Orange, Num = 6 });
        }
        /// <summary>
        /// Выбираем Статус C
        /// </summary>
        /// <param name="param">Объект выбора</param>
        public void SelectStatusAddC(object param)
        {
            System.Windows.Controls.CheckBox parame = (System.Windows.Controls.CheckBox)param;
            C.Add(new ParamQbe() {Num =Convert.ToInt32(parame.Content), ColorNum = parame.Background});
        }
        /// <summary>
        /// Удаляем сататус C
        /// </summary>
        /// <param name="param">Объект выбора</param>
        public void DeleteStatusAddC(object param)
        {
            System.Windows.Controls.CheckBox parame = (System.Windows.Controls.CheckBox)param;
            C.Remove(C.Single(parameter => parameter.Num == Convert.ToInt32(parame.Content)));
        }
        /// <summary>
        /// Добавляем статус F 
        /// </summary>
        /// <param name="param">Объект выбора</param>
        public void SelectStatusAddF(object param)
        {
            System.Windows.Controls.CheckBox parame = (System.Windows.Controls.CheckBox)param;
            F.Add(new ParamQbe() { Num = Convert.ToInt32(parame.Content), ColorNum = parame.Background });
        }
        /// <summary>
        /// Удаляем статус F
        /// </summary>
        /// <param name="param">Объект выбора</param>
        public void DeleteStatusAddF(object param)
        {
            System.Windows.Controls.CheckBox parame = (System.Windows.Controls.CheckBox) param;
            F.Remove(F.Single(parameter => parameter.Num == Convert.ToInt32(parame.Content)));
        }
    }

    /// <summary>
    /// Значение и цвет полей
    /// </summary>
    public class ParamQbe
    {
        public int Num { get; set; }
        public Brush ColorNum { get; set; }
    }
}
