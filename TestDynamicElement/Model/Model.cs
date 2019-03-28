using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TestDynamicElement.Model
{
    public class Model
    {

        private ObservableCollection<Model> user = new ObservableCollection<Model>();


        public ObservableCollection<Model> User
        {
            get { return user; }
            set { user = value; }
        }

        public UserControl Control { get; set; }


        public void AddModel()
        {
            user.Add(new Model() { Control = new UserControl() { Content = new StackPanel() { Children = { new Button() { Background = Brushes.Red, Content = "2" }, new Border() {Width = 40} }} } });
            user.Add(new Model() { Control = new UserControl() { Content = new Canvas() { Width = 30, Height = 30, Background = Brushes.Green} } });
            user.Add(new Model() { Control = new UserControl() { Content = new Button() { Background = Brushes.Red, Content = "2"} } });
        }
        /// <summary>
        /// Добавление элемента в модель
        /// </summary>
        public void AddElement()
        {
            user.Add(new Model() { Control = new UserControl() { Content = new Button() { Background = Brushes.Aqua, Content = "3" } } });
            user.Add(new Model() { Control = new UserControl() { Content = new Button() { Background = Brushes.Azure, Content = "4" } } });
            user.Add(new Model() { Control = new UserControl() { Content = new Canvas() { Width = 30, Height = 30, Background = Brushes.Black} } });
        }
    }
}
