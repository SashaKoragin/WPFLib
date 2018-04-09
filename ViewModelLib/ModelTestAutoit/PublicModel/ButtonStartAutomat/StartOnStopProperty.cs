using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Commands;
using Prism.Interactivity;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat
{
   public class StartOnStopProperty : BindableBase
   {


        private int _count;
        private bool _iswork;
        private Button _button = new Button();

        public bool IsChekcs { get; set; }

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
        }

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

        public void IsCheker()
        {
            if (IsChekcs)
            {
                IsChekcs = false;
            }
        }
    }
}
