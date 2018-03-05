using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DBFtoSQL2008Enterprise.Aplication.Commands;
using DBFtoSQL2008Enterprise.Aplication.ViewModelElement.UpdateModel;
using DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ViewModel;
using MigSharp;

namespace DBFtoSQL2008Enterprise.Aplication.Page
{
    public partial class ConvertDbFtoSql : UserControl
    {
        public ConvertDbFtoSql()
        {
            InitializeComponent();
        }

        private void SelectOnClick(object sender, RoutedEventArgs e)
        {
            var t = Task.Run(delegate { Sobytie.EnumSob.EnumSobytie(sender,e,this); });
        }
    }
}
