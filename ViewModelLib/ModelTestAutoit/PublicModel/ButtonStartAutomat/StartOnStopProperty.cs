using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Commands;
using Prism.Interactivity;
using Prism.Mvvm;
using Button = System.Windows.Controls.Button;

namespace ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat
{
   public class StartOnStopProperty : BindableBase
   {

        private bool _isChecs;
        private bool _islk2;
        private int _count;
        private bool _iswork;
        private Button _button = new Button();
      
        /// <summary>
        /// Логика галочки 
        /// </summary>
        public bool IsChekcs
       {
           get
           {
               return _isChecs;
           }
           set
           {
               _isChecs = value;
               RaisePropertyChanged();
           }
       }
        /// <summary>
        /// Свойство для задачи печати ЛК2 проверять или нет 
        /// </summary>
       public bool IsLk2
       {
            get
            {
                return _islk2;
            }
            set
            {
                _islk2 = value;
                RaisePropertyChanged();
            }
        }

       public Button Button
        {
            get { return _button; }
            set
            {
                _button = value;
                RaisePropertyChanged();
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                RaisePropertyChanged();
            }
        }

        public bool Iswork
        {
            get
            {
                return _iswork;
            }
            set
            {
                _iswork = value;
                RaisePropertyChanged();
            }
        }
    }
    public class StatusButtonMethod : StartOnStopProperty
    {
        public StatusButtonMethod()
        {
            StatusGrin();
            HotKeyStart.HotKeyPressed += (start) => StatusGrin();
            HotKeyStop.HotKeyPressed += (stop) => StatusYellow();

        }

        

        public static HotKey  HotKeyStop = new HotKey(ModifierKeys.Shift, Keys.S, IntPtr.Zero);
        public static HotKey HotKeyStart = new HotKey(ModifierKeys.Shift, Keys.A, IntPtr.Zero);
        public void StatusGrin()
        {
            //FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
            //button.SetValue(Button.ContentProperty, "Старт автомат!!!");
            //button.SetValue(Button.ForegroundProperty, Brushes.Black);
            //button.SetValue(Button.BackgroundProperty, Brushes.Green);
            //button.SetValue(Button.IsEnabledProperty, true);
            //Start.Button.Style = new Style() { Setters = { new Setter() { Property = Control.TemplateProperty, Value = new ControlTemplate() { VisualTree = button } } } };
            Button.Content = "Старт автомат!!!";
            Button.Foreground = Brushes.Black;
            Button.Background = Brushes.Green;
            Button.IsEnabled = true;
            Iswork = true;
            
            Count = 0;
        }

        public void StatusRed()
        {
            //FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
            //button.SetValue(Button.ContentProperty, "Работаем!!!");
            //button.SetValue(Button.ForegroundProperty, Brushes.Black);
            //button.SetValue(Button.BackgroundProperty, Brushes.Red);
            //button.SetValue(Button.IsEnabledProperty, false);
            //Start.Button.Style = new Style() { Setters = { new Setter() { Property = Control.TemplateProperty, Value = new ControlTemplate() { VisualTree = button } } } };
            Button.Content = "Работаем!!!";
            Button.Foreground = Brushes.Black;
            Button.Background = Brushes.Red;
            Button.IsEnabled = false;
            Count = 0;
            Iswork = true;
        }

        public void StatusYellow()
        {
            //FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
            //button.SetValue(Button.ContentProperty, "Приостановленно!!!");
            //button.SetValue(Button.ForegroundProperty, Brushes.Black);
            //button.SetValue(Button.BackgroundProperty, Brushes.Yellow);
            //button.SetValue(Button.IsEnabledProperty, false);
            //Start.Button.Style = new Style() { Setters = { new Setter() { Property = Control.TemplateProperty, Value = new ControlTemplate() { VisualTree = button } } } };
            Button.Content = "Приостановленно!!!";
            Button.Foreground = Brushes.Black;
            Button.Background = Brushes.Yellow;
            Button.IsEnabled = false;
            Count = 0;
            Iswork = false;
        }

        public void StatusGrinandYellow(string status)
        {
            if (status != "stop")
                StatusGrin();
            else
                StatusYellow();
        }
        /// <summary>
        /// Логика галочки
        /// </summary>
        public void IsCheker()
        {
            if (IsChekcs)
            {
                IsChekcs = false;
            }
        }
    }
}
