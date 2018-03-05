using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using WordReportsFull.EventsFull;
using WordReportsFull.Trige.SelectVisibl;
using WordReportsFull.Trige.UregTrig;
using WordReportsFull.ValidationControl;

namespace WordReportsFull.WpfForm.Mains.FormYreg
{
    /// <summary>
    /// Логика взаимодействия для Uregulirovanie.xaml
    /// </summary>
    public partial class Uregulirovanie : Page
    {
        public Uregulirovanie()
        {
            InitializeComponent();
        }

        
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            PathForm.PathLoadForm.PathSeat(sender, ComboBox, e);
        }

        private void ReportGenerate(object sender, RoutedEventArgs e)
        {
            ReportsStart report = new ReportsStart(this);
            report.Report();
        }

        private void SelectPath(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox.SelectedValue != null)
            {
                var template = new SelectVisiblQbe { Path = new ObservableCollection<SelectVisiblQbe>() };
                var trig = (TrigVisibl)Resources["Trig"];
                var itemotcet = (ContentZn) ComboBox.SelectedValue;
                template.Path.Add(new SelectVisiblQbe { NameTemplate = itemotcet.NameTemplate});
                ListFile.ItemsSource = template.Path;
                SwithQbe.SwithQbe.SwithQ(trig, itemotcet.NameTemplate);
            }
        }



    }
}
