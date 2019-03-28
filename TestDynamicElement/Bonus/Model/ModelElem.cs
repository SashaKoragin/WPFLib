using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;

namespace TestDynamicElement.Bonus.Model
{
   public class ModelElem : BindableBase
    {
        private string textElem1 = null;

        private string textElem2 = null;

        private bool blok1 = false;

        private bool blok2 = true;

        public string TextElem1
        {
            get { return textElem1; }
            set
            {
                textElem1 = value;
                RaisePropertyChanged();
            }
        }

        public bool Blok1
        {
            get { return blok1; }
            set
            {
                blok1 = value;
                RaisePropertyChanged();
            }
        }

        public string TextElem2
        {
            get { return textElem2; }
            set
            {
                textElem2 = value;
                RaisePropertyChanged();
            }
        }
        public bool Blok2
        {
            get { return blok2; }
            set
            {
                blok2 = value;
                RaisePropertyChanged();
            }
        }

        public void MoveText()
        {
            if (String.IsNullOrWhiteSpace(TextElem1) && String.IsNullOrWhiteSpace(TextElem2))
            {
                MessageBox.Show("Не чего переносить ввидите текст");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(TextElem1))
                {
                    TextElem1 = TextElem2;
                    TextElem2 = null;
                    Blok1 = true;
                    Blok2 = false;
                }
                else
                {
                    TextElem2 = TextElem1;
                    TextElem1 = null;
                    Blok2 = true;
                    Blok1 = false;
                }

            }
        }

    }
}
