﻿using AutomatAis3Full.Form.Automat.Okp1.Declaration121ActIsh.DataContext;
using System.Text.RegularExpressions;
using System.Windows.Controls;


namespace AutomatAis3Full.Form.Automat.Okp1.Declaration121ActIsh.Declaration121ActIsh
{
    /// <summary>
    /// Логика взаимодействия для FormDeclaration121ActIsh.xaml
    /// </summary>
    public partial class FormDeclaration121ActIsh : UserControl
    {
        public FormDeclaration121ActIsh()
        {
            InitializeComponent();
            DataContext = new DataContextDeclaration121ActIsh();
        }

        //private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}
    }
}
