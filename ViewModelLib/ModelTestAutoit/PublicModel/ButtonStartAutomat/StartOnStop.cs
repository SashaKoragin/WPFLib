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
    public class StatusButton : StartOnStop
    {
        public StartOnStop Start = new StartOnStop();
        
        public void StatusGrin()
        {
            //FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
            //button.SetValue(Button.ContentProperty, "Старт автомат!!!");
            //button.SetValue(Button.ForegroundProperty, Brushes.Black);
            //button.SetValue(Button.BackgroundProperty, Brushes.Green);
            //button.SetValue(Button.IsEnabledProperty, true);
            //Start.Button.Style = new Style() { Setters = { new Setter() { Property = Control.TemplateProperty, Value = new ControlTemplate() { VisualTree = button } } } };
            Start.Button.Content = "Старт автомат!!!";
            Start.Button.Foreground = Brushes.Black;
            Start.Button.Background = Brushes.Green;
            Start.Button.IsEnabled = true;
            Start.Iswork = true;
            Start.Count = 0;
        }

        public void StatusRed()
        {
            //FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
            //button.SetValue(Button.ContentProperty, "Работаем!!!");
            //button.SetValue(Button.ForegroundProperty, Brushes.Black);
            //button.SetValue(Button.BackgroundProperty, Brushes.Red);
            //button.SetValue(Button.IsEnabledProperty, false);
            //Start.Button.Style = new Style() { Setters = { new Setter() { Property = Control.TemplateProperty, Value = new ControlTemplate() { VisualTree = button } } } };
            Start.Button.Content = "Работаем!!!";
            Start.Button.Foreground = Brushes.Black;
            Start.Button.Background = Brushes.Red;
            Start.Button.IsEnabled = false;
            Start.Count = 0;
            Start.Iswork = true;
        }

        public void StatusYellow()
        {
            //FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
            //button.SetValue(Button.ContentProperty, "Приостановленно!!!");
            //button.SetValue(Button.ForegroundProperty, Brushes.Black);
            //button.SetValue(Button.BackgroundProperty, Brushes.Yellow);
            //button.SetValue(Button.IsEnabledProperty, false);
            //Start.Button.Style = new Style() { Setters = { new Setter() { Property = Control.TemplateProperty, Value = new ControlTemplate() { VisualTree = button } } } };
            Start.Button.Content = "Приостановленно!!!";
            Start.Button.Foreground = Brushes.Black;
            Start.Button.Background = Brushes.Yellow;
            Start.Button.IsEnabled = false;
            Start.Count = 0;
            Start.Iswork = false;
        }

        public void StatusGrinandYellow(string status)
        {
            if (status != "stop")
                StatusGrin();
            else
                StatusYellow();
        }
    }
    public class StartOnStop : BindableBase
    {
        private int _count;
        private bool _iswork;
       
        private Button _button = new Button();

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
}
