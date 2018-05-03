using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AutomatAis3Full.Form.Automat.Okp4.FormSnuAuto.SnuFormAuto;
using AutomatAis3Full.Form.Automat.Okp4.MassSnuForm.MassSnuForm;
using AutomatAis3Full.Form.Automat.Okp4.PravoEdit.PravoEdit;
using AutomatAis3Full.Form.Automat.Registration.TreatmentFPD.Zemly.UserControl;
using AutomatAis3Full.Form.FormirovanieSpiskov.Spiski.FormFormirovanie;
using AutomatAis3Full.Form.Report.ReportXml.ReportForm;
using ViewModelLib.ModelTestAutoit.FullWindowAutoIt;

namespace AutomatAis3Full.GlavnayLogika.AddUserControlFull
{

    public class AddLogicaFull
      {
        public FullWindowAutoItMethod FullWindowAdd()
        {
            FullWindowAutoItMethod autoit = new FullWindowAutoItMethod();
            ObservableCollection<FullWindowAutoIt> window = new ObservableCollection<FullWindowAutoIt>
            {
                new FullWindowAutoIt()
                {
                    NameControl = "ОКП4",
                    CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                        {new FullWindowAutoIt() {NameControl = "1.06 Формирование и печать СНУ", CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                           {
                           new FullWindowAutoIt() {NameControl = "1 Создание заявки на формирование СНУ", UserControl = new FormSnuAuto()},
                           new FullWindowAutoIt() {NameControl = "1 Создание заявки на формирование СНУ массово!!!", UserControl = new MassSnuForm()},
                           } },
                        new FullWindowAutoIt() {NameControl = "02. Доопределение данных об объектах собственности", CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                           {
                            new FullWindowAutoIt() {NameControl = "14.КС–Корректировка сведений о правах не зарегистрированных  в органах Росреестра и правах наследования на ОН и ЗУ", UserControl = new PravoEditForm()                           } }
                        } }
                    
                },
                new FullWindowAutoIt()
                {
                    NameControl = "Регистрация",
                    CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                    {
                        new FullWindowAutoIt() {NameControl = "Общие задания" , CollectionUserControl = new ObservableCollection<FullWindowAutoIt>() {new FullWindowAutoIt() {NameControl = "Уточнение сведений о ФЛ", UserControl = new Form.Automat.Registration.UtochneneeSved.UserControl.YtochnenieSved()} } },
                        new FullWindowAutoIt()
                        {
                            NameControl = "Собственность", CollectionUserControl =  new ObservableCollection<FullWindowAutoIt>() {
                              new FullWindowAutoIt()
                              {
                                  NameControl = "05-06-07. Росреестр – Земельные участки/Имущество/Транспорт", CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                  { 
                                    new FullWindowAutoIt() {NameControl = "05.03,06-03,07-02 Обработка данных веток", UserControl = new FpdZemly()}
                                  }
                               }
                        }
                     }
                   }
                },
                new FullWindowAutoIt()
                {
                    NameControl = "Формирование Списков", CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                    {
                        new FullWindowAutoIt() {NameControl = "Формирование По XML Схеме!!!", UserControl = new FormSpisok()}
                    }
                },
                new FullWindowAutoIt()
                {
                    NameControl = "Отчеты",
                    CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                    {
                        new FullWindowAutoIt() {NameControl = "Отчеты по Автоматам!!!",UserControl = new Report()}
                    }
                }

            };
            autoit.CollectionUserControl = window;
        return autoit;
      }
    }
}
