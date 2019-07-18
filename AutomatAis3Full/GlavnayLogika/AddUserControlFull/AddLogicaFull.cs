using System.Collections.ObjectModel;
using AutomatAis3Full.Form.Automat.Analitic.Zadanie.ZacetVozvrat.Signature;
using AutomatAis3Full.Form.Automat.Okp3.UsnSend.UsnSend;
using AutomatAis3Full.Form.Automat.Okp4.FormSnuAuto.SnuFormAuto;
using AutomatAis3Full.Form.Automat.Okp4.MassSnuForm.MassSnuForm;
using AutomatAis3Full.Form.Automat.Okp4.PravoEdit.PravoEdit;
using AutomatAis3Full.Form.Automat.Okp4.PrintSnu.Print;
using AutomatAis3Full.Form.Automat.Orn.ConfirmationNbo.ConfirmationNbo;
using AutomatAis3Full.Form.Automat.RaschetBudg.Migration.Migration;
using AutomatAis3Full.Form.Automat.RaschetBudg.VedRazd1.VedRaz1;
using AutomatAis3Full.Form.Automat.Registration.ActualStatus.UserControlStatus;
using AutomatAis3Full.Form.Automat.Registration.Rosreestr.UserControl;
using AutomatAis3Full.Form.Automat.Registration.TehnicalUpdate.UserControlTechnical;
using AutomatAis3Full.Form.Automat.Registration.TreatmentFPD.Zemly.UserControl;
using AutomatAis3Full.Form.FormirovanieSpiskov.Spiski.FormFormirovanie;
using AutomatAis3Full.Form.Report.ReportXml.ReportForm;
using ViewModelLib.ModelTestAutoit.FullWindowAutoIt;

namespace AutomatAis3Full.GlavnayLogika.AddUserControlFull
{

    public class AddLogicaFull
      {
          /// <summary>
          /// Рефлизация древовидной структуры
          /// </summary>
          /// <returns></returns>
          public FullWindowAutoItMethod FullWindowAdd()
          {
              FullWindowAutoItMethod autoit = new FullWindowAutoItMethod();
              ObservableCollection<FullWindowAutoIt> window = new ObservableCollection<FullWindowAutoIt>
              {
                  new FullWindowAutoIt()
                  {
                      NameControl = "ОКП3",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "Общие задания",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "Контрольная работа налоговые проверки",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Применение упрощенной системы налогооблажения",
                                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                              {
                                                  new FullWindowAutoIt()
                                                  {
                                                      NameControl = "Применение УСН",
                                                      UserControl = new FormUsnSend()
                                                  }
                                              }
                                              
                                          }
                                      }

                                  }
                              }
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "Расчеты с бюджетом",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "Расчеты с бюджетом",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "Ведомость невыясненных поступлений",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Ведомость невыясненных поступлений. Раздел 1",
                                              UserControl = new VedRaz1()
                                          }
                                      }
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "ПОН Координация",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "Миграция НП",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Журнал миграции НП",
                                              UserControl = new Migration()
                                          }
                                      }
                                      
                                  }
                              }
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "Аналитический",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "Урегулирование задолженности",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "05.09 Подпись проектов решений на зачет/возврат",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Подпись начальником аналитического отдела",
                                              UserControl = new SigZacetVozvrat()
                                          }
                                      }
                                  }
                              }
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "ОРН",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "Контрольная работа (налоговые проверки)",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                               new FullWindowAutoIt()
                               {
                                   NameControl = "Обработка документов НБО",
                                   CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                   {
                                       new FullWindowAutoIt()
                                       {
                                           NameControl = "Подтверждение ввода документов",
                                           UserControl = new ConfirmationNbo()
                                       }
                                   }
                               }   
                              }
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "ОКП4",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "1.06 Формирование и печать СНУ",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "1 Создание заявки на формирование СНУ",
                                      UserControl = new FormSnuAuto()
                                  },
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "1 Создание заявки на формирование СНУ массово!!!",
                                      UserControl = new MassSnuForm()
                                  },
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "2. Просмотр СНУ",
                                      UserControl = new UserPrintSnu()
                                  },
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "02. Доопределение данных об объектах собственности",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl =
                                          "14.КС–Корректировка сведений о правах не зарегистрированных  в органах Росреестра и правах наследования на ОН и ЗУ",
                                      UserControl = new PravoEditForm()
                                  }
                              }
                          }
                      }

                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "Регистрация",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "Общие задания",
                              CollectionUserControl =
                                  new ObservableCollection<FullWindowAutoIt>()
                                  {
                                      new FullWindowAutoIt()
                                      {
                                          NameControl = "Уточнение сведений о ФЛ",
                                          UserControl =
                                              new Form.Automat.Registration.UtochneneeSved.UserControl.
                                                  YtochnenieSved()
                                      }
                                  }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Собственность",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "05-06-07. Росреестр – Земельные участки/Имущество/Транспорт",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "05.03,06-03,07-02 Обработка данных веток",
                                              UserControl = new FpdZemly()
                                          }
                                      }
                                  },
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "14. Работа с лицами – правообладателями объектов, по которым требуется визуальная обработка",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "01. Росреестр - ФЛ, 11. Росреестр - Запросы на обработку",
                                              UserControl = new UserControlRosreestr()
                                          }
                                      }
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "ПОН ИЛ",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl =
                                          "1. ПОН ИЛ (ПЭ). Организации и физические лица, внесенные в ПОН ИЛ",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "2.01. ФЛ. Актуальное состояние",
                                              UserControl = new ActualStatus()
                                          }
                                      }
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Централизованный учет налогоплательщиков",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "15.02.02. Служебные. Технические исправления",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Физические лица",
                                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                              {
                                                  new FullWindowAutoIt()
                                                  {
                                                      NameControl =
                                                          "15.02.02.01. Служебные. Технические исправления. Физические лица",
                                                      UserControl = new TehnicalUpdate()
                                                  }
                                              }
                                          }
                                      }
                                  }
                              }
                          }

                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "Формирование Списков",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "Формирование По XML Схеме!!!",
                              UserControl = new FormSpisok()
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "Отчеты",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "Отчеты по Автоматам!!!",
                              UserControl = new Report()
                          }
                      }
                  }

              };
              autoit.CollectionUserControl = window;
              return autoit;
        }
      }
    }
