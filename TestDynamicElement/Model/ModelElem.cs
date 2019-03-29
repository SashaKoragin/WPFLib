using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using Prism.Commands;
using Prism.Mvvm;
using TestDynamicElement.Bonus;
using TestDynamicElement.Bonus.ViewModel;

namespace TestDynamicElement.Model
{

    public class ModelElem : BindableBase
    {

        /// <summary>
        /// Добавление View
        /// </summary>
        public void AddColection()
        {
            ModelXaml.Add(new ModelElem() { Xaml = new Xaml1(ViewModel) });
            ModelXaml.Add(new ModelElem() { Xaml = new Xaml2(ViewModel) });
            ModelXaml.Add(new ModelElem() { Xaml = new MoveXaml.View.MoveXaml(View) });
            ModelXaml.Add(new ModelElem() { Xaml = new MoveXaml.View.MoveXaml1(View) });
            ModelXaml.Add(new ModelElem() { Xaml = null });
            ModelXaml.Add(new ModelElem() { Xaml = new MoveXaml.View.TestMoveXaml() });
        }
        /// <summary>
        /// ViewModel для дочерних xaml
        /// </summary>
        internal ElemViewModel ViewModel = new ElemViewModel();
        /// <summary>
        /// ViewModel для дочерних xaml
        /// </summary>
        internal MoveXaml.ViewModel.ViewModel View = new MoveXaml.ViewModel.ViewModel();


        private List<ModelElem> modelXaml = new List<ModelElem>();

        private UserControl xaml;

        public UserControl Xaml
        {
            get { return xaml; }
            set
            {
                xaml = value;
                RaisePropertyChanged();
            }
        }


        public List<ModelElem> ModelXaml
        {
            get { return modelXaml; }
            set
            {
                modelXaml = value;
                RaisePropertyChanged();
            }
        }

        private bool IsMoveXaml = true;

        /// <summary>
        /// Перенос всего xaml
        /// Есть ограничения на сериализацию коллекций они не сереализуются в XamlWriter.Save(o)!!!
        /// </summary>
        public void MoveFullXaml()
        {
            if (IsMoveXaml)
            {
                //ModelXaml[4].Xaml = ModelXaml[5].Xaml; Такая реализация тоже возможна
                ModelXaml[4].Xaml = (UserControl)CloneXaml(ModelXaml[5].Xaml);
                ModelXaml[5].Xaml = null;
                IsMoveXaml = false;
            }
            else
            {
                //ModelXaml[5].Xaml = ModelXaml[4].Xaml; Такая реализация тоже возможна
                ModelXaml[5].Xaml = (UserControl)CloneXaml(ModelXaml[4].Xaml);
                ModelXaml[4].Xaml = null;
                IsMoveXaml = true;

            }
        }
        /// <summary>
        /// Сереализация
        /// </summary>
        /// <param name="o">Объект предположительно xaml</param>
        /// <returns></returns>
        private Object CloneXaml(Object o)
        {
            string xaml = XamlWriter.Save(o);
            return XamlReader.Load(new XmlTextReader(new StringReader(xaml)));
        }
    }
}
