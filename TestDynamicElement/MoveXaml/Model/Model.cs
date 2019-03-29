using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml.Serialization;
using Prism.Mvvm;

namespace TestDynamicElement.MoveXaml.Model
{
    public class Model : BindableBase, ICloneable
    {
       
        public object Clone()
        {
            return MemberwiseClone();
        }

        private List<Model> user2 = new List<Model>();


        public List<Model> User2
        {
            get { return user2; }
            set
            {
                user2 = value;
                RaisePropertyChanged();
            }
        }

        private List<Model> user = new List<Model>();


        public List<Model> User
        {
            get { return user; }
            set
            {
                user = value;
                RaisePropertyChanged();
            }
        }

        public UserControl Control { get; set; }

        public void AddModel()
        {
            user.Add(new Model() { Control = new UserControl() { Content = new StackPanel() { Children = { new Button() { Background = Brushes.Red, Content = "2" }, new Border() { Width = 40 } } } } });
            user.Add(new Model() { Control = new UserControl() { Content = new Canvas() { Width = 30, Height = 30, Background = Brushes.Green } } });
            user.Add(new Model() { Control = new UserControl() { Content = new Button() { Background = Brushes.Red, Content = "2" } } });
        }
    }

    public class Logica : Model
    {
        public bool IsMove =true;

        public void Clones()
        {
            if (IsMove)
            {
                var cloneList = User.Select(obj => (Model)obj.Clone()).ToList();
                User2 = new List<Model>(cloneList);
                IsMove = false;
            }
            else
            {
                var cloneList = User2.Select(obj => (Model)obj.Clone()).ToList();
                User = new List<Model>(cloneList);
                IsMove = true;
            }

        }



    }
}
