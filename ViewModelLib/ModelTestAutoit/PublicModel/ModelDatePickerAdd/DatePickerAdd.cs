using Prism.Mvvm;
using System;

namespace ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd
{
   public class DatePickerAdd : BindableBase
    {

        private int _countIzveshenie = 1;

        public int CountIzveshenie
        {
            get => _countIzveshenie;
            set
            {
                _countIzveshenie = value;
                RaisePropertyChanged();
            }
        }

        private int _countDay = 43;
      
        public int CountDay 
        { 
            get => _countDay;
            set 
            {
                _countDay = value;
                Date = ModelDateTime(CountDay);
                RaisePropertyChanged();
            } 
        }

        private readonly DateTime _date = DateTime.Now.Date;
        public DateTime Date
        {
            get => ModelDateTime(CountDay);
            set => RaisePropertyChanged();
        }

        private DateTime _dateResh = DateTime.Now.Date;

        public DateTime DateResh
        {
            get { return _dateResh; }
            set { _dateResh = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// Модель даты и время проставляем
        /// </summary>
        /// <param name="countDay">Количество дней</param>
        private DateTime ModelDateTime(int countDay)
        {
           var date = _date.AddDays(CountDay);
            if (date.DayOfWeek == DayOfWeek.Saturday)
                date = date.AddDays(2);
            if (date.DayOfWeek == DayOfWeek.Sunday)
                date = date.AddDays(1);
            return date;
        }
    }
}
