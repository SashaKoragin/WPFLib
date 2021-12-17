using System.Collections.ObjectModel;
using AutomatAis3Full.Form.Automat.Analitic.Zadanie.ZacetVozvrat.Signature;
using AutomatAis3Full.Form.Automat.It.Rule.UserControl;
using AutomatAis3Full.Form.Automat.It.RuleInfoFull.UserControl;
using AutomatAis3Full.Form.Automat.It.UserTemplateAndRule.UserControl;
using AutomatAis3Full.Form.Automat.Okp2.RegisterDeclarations.RegisterDeclarations;
using AutomatAis3Full.Form.Automat.Okp2.TaxJournal.TaxJournal;
using AutomatAis3Full.Form.Automat.Okp3.UsnSend.UsnSend;
using AutomatAis3Full.Form.Automat.Okp4.FormSnuAuto.SnuFormAuto;
using AutomatAis3Full.Form.Automat.Okp4.MassSnuForm.MassSnuForm;
using AutomatAis3Full.Form.Automat.Okp4.PravoEdit.PravoEdit;
using AutomatAis3Full.Form.Automat.Okp4.PrintSnu.Print;
using AutomatAis3Full.Form.Automat.Okp5.ActIzvesheniaReshenia121.ActIzvesheniaReshenia;
using AutomatAis3Full.Form.Automat.Okp5.Identification.FaceIdentification;
using AutomatAis3Full.Form.Automat.Orn.ConfirmationNbo.ConfirmationNbo;
using AutomatAis3Full.Form.Automat.PreCheck.Journal129.Journal129;
using AutomatAis3Full.Form.Automat.PreCheck.ReportingMemo.ReportingMemo;
using AutomatAis3Full.Form.Automat.RaschetBudg.Migration.Migration;
using AutomatAis3Full.Form.Automat.RaschetBudg.VedRazd1.VedRaz1;
using AutomatAis3Full.Form.Automat.Registration.ActualStatus.UserControlStatus;
using AutomatAis3Full.Form.Automat.Registration.Journal.ReceivedDocument.ReceivedDocuments;
using AutomatAis3Full.Form.Automat.Registration.Rosreestr.UserControl;
using AutomatAis3Full.Form.Automat.Registration.TehnicalUpdate.UserControlTechnical;
using AutomatAis3Full.Form.Automat.Registration.TreatmentFPD.Zemly.UserControl;
using AutomatAis3Full.Form.Automat.Registration.VisualBank.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.FormTrebUplNaloga.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.MessageLk.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.RenouncementLk.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.Ticket05080902.Ticket0508090203.Ticket050809020306.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.RequirementsLog.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.SenderReshenia.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.SenderSpravk.UserControl;
using AutomatAis3Full.Form.FormirovanieSpiskov.Spiski.FormFormirovanie;
using AutomatAis3Full.Form.Report.ReportXml.ReportForm;
using LibraryCommandPublic.TestAutoit.Reg.YtochnenieSved.AutoCommand;
using ViewModelLib.ModelTestAutoit.FullWindowAutoIt;
using AutomatAis3Full.Form.Automat.Uregulirovanie.Ticket05080902.Ticket0508090202.Ticket050809020204.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.Ticket05080902.Ticket0508090202.Ticket050809020206.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.SigningDecisionApplication.UserControl;
using AutomatAis3Full.Form.Automat.Okp1.Declaration121.Declaration121;
using AutomatAis3Full.Form.Automat.Okp1.Declaration121ActIsh.Declaration121ActIsh;
using AutomatAis3Full.Form.Automat.Okp2.UserTask.TaxApprove.TaxApprove;
using AutomatAis3Full.Form.Automat.Okp3.JournalPatent.Patent;
using AutomatAis3Full.Form.Automat.Okp6.JournalDoc.ViewJournalDoc;
using AutomatAis3Full.Form.Automat.Okp6.RegistryDeclaration.ViewRegistryDeclaration;
using AutomatAis3Full.Form.Automat.Uregulirovanie.StartProcessFace.StartCash.ViewStartCash;
using AutomatAis3Full.Form.FormirovanieSpiskov.AutoGenerateListAutomation.ViewGenerator;
using AutomatAis3Full.Form.Automat.Okp1.Declaration121Error.Declaration121Error;
using AutomatAis3Full.Form.Automat.RaschetBudg.Krsb.Krsb;
using AutomatAis3Full.Form.Automat.Registration.AcceptanceDocuments.UserControl;
using AutomatAis3Full.Form.Automat.Uregulirovanie.StatementNp.ViewStatementNp;

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
              var ytochnenieSved = new YtochnenieSved();
            ObservableCollection<FullWindowAutoIt> window = new ObservableCollection<FullWindowAutoIt>
              {
                  new FullWindowAutoIt()
                  {
                      NameControl = "Отдел информатизации",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "ЦСУД",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "Управление ролевой принадлежностью",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Журнал заявок",
                                              UserControl = new RuleParse()
                                          },
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Мои роли (Сбор всех веток!)",
                                              UserControl = new FormRuleInfoFull()
                                          },
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Просмотр ролей (Сбор пользователей, ролей, шаблонов)",
                                              UserControl = new FormUserTemplateAndRule()
                                          }
                                      }
                                  }
                              }
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "Отдел перепроверенного анализа",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "Докладная записка",
                              UserControl = new ReportingMemo()
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "129. Налоговые правонарушения",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "2. Журнал налоговых правонарушений",
                                      UserControl = new Journal129()
                                  }
                              }
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "Урегулирование задолженности",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "Проведение зачетов/возвратов",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "Заявления НП о зачете/возврате (реестр)",
                                      UserControl = new ViewStatementNp()
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Взыскание задолженности за счет ден. средств",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "Запуск БП",
                                      UserControl = new ViewStartCash()
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Требования об уплате",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "Журнал требований об уплате",
                                      UserControl = new RequirementsLog()
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Общие задания",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                               new FullWindowAutoIt()
                               {
                                   NameControl = "05.08.10.01 Списание задолженности",
                                   CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                   {
                                     new FullWindowAutoIt()
                                     {
                                         NameControl  = "05.08.10.01.0X.01.02. Подписание Справки о суммах недоимки и задолженности",
                                         UserControl = new SenderSpravk()
                                     },
                                     new FullWindowAutoIt()
                                     {
                                         NameControl = "05.08.10.01.0X.02. Подписание решения. Создание операций в КРСБ",
                                         UserControl = new SenderReshenia()
                                     }
                                   }
                               },
                               new FullWindowAutoIt()
                               {
                                   NameControl = "05.08.09.02. Взыскание задолженности за счет имущества",
                                   CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                   {
                                      new FullWindowAutoIt()
                                      {
                                          NameControl = "05.08.09.02.02. Утверждение и подписание Служебных записок",
                                          CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                          {
                                              new FullWindowAutoIt()
                                              {
                                                  NameControl = "05.08.09.02.02.04. Утверждение Служебной записки",
                                                  UserControl = new StatementOfficeNote()
                                              },
                                              new FullWindowAutoIt()
                                              {
                                                  NameControl = "05.08.09.02.02.06. Подписание Служебной записки",
                                                  UserControl = new SignatureOfficeNote()
                                              },
                                          }
                                      },
                                      new FullWindowAutoIt()
                                      {
                                          NameControl = "Утверждение и подписание Заявлений о взыскании за счет имущества ФЛ",
                                          CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                          {
                                              new FullWindowAutoIt()
                                              {
                                                  NameControl = "05.08.09.02.03.06. Подпись руководителем взысканий за счет имущества",
                                                  UserControl = new SignatureHeadProperty()
                                              }
                                          }
                                      }
                                   }
                               },
                               new FullWindowAutoIt()
                               {
                                   NameControl = "05.08.03.0X.03. Утверждение требований об уплате",
                                   UserControl = new FormTrebUplNaloga()
                               },
                               new FullWindowAutoIt()
                               {
                                   NameControl = "05.09 Сообщения о принятом решении о зачете (возврате) подлежащие выгрузке в ЛК",
                                   UserControl = new MessageLk()
                               },
                               new FullWindowAutoIt()
                               {
                                   NameControl = "05.09 Сообщения о принятом решении об отказе  подлежащие выгрузке в ЛК",
                                   UserControl = new RecouncementLk()
                               },
                               new FullWindowAutoIt()
                               {
                                   NameControl = "05.09 Формирование решения об отказе по заявлению (Подписание руководителем НО)",
                                   UserControl = new SigningDecisionApplication()
                               }
                              }
                          }

                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "ОКП1",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "121. Камеральная налоговая проверка",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)",
                                      UserControl = new  FormDeclaration121()
                                  },                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "03. Реестр налоговых деклараций (расчетов), сведения о КНП (все) (Нарушения)",
                                      UserControl = new FormDeclaration121Error()
                                  },
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "03. Реестр налоговых деклараций (расчетов), сведения о КНП (все) (Акты Извещения Решения)",
                                      UserControl = new FormDeclaration121ActIsh()
                                  }
                              }
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "ОКП2",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "121. Камеральная налоговая проверка",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)",
                                      UserControl = new FormRegisterDeclarations()
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "129. Налоговые правонарушения",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "2. Журнал налоговых правонарушений",
                                      UserControl = new FormTaxJournal()
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Контрольная работа (налоговые проверки)",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "111. Формирование налоговых обязанностей",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Утверждение налоговых обязанностей",
                                              UserControl = new ViewTaxApprove()
                                          }
                                      }
                                  }
                              }
                          }
                      }
                  },
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
                                              NameControl = "Применение упрощенной системы налогообложения",
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
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Контрольная работа (налоговые проверки)",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "03. Реестр налоговых деклараций (расчетов), сведения о КНП (все) (Акты Извещения Решения)",
                                      UserControl = new FormDeclaration121ActIsh()
                                  },
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "203. Применение патентной системы налогообложения",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "03. Журнал учета и формирования документов, связанных с применением ПСН",
                                              UserControl = new FormPatent()
                                          }
                                      }
                                  }
                              }
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "ОКП5",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "106. Реестр расчетов по страховым взносам",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "Реестр расчетов по страховым взносам, сведения о КНП (все)",
                                      UserControl = new ActIzvesheniaResheniaView()
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Физические лица",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "2.01. Сведения о доходах ФЛ",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "5.01. Неидентифицированные получатели дохода",
                                              UserControl = new FaceIdentificationView(),
                                          }
                                      }
                                  }
                              }
                          }
                      }
                  },
                  new FullWindowAutoIt()
                  {
                      NameControl = "ОКП6",
                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                      {
                          new FullWindowAutoIt()
                          {
                              NameControl = "121. Камеральная налоговая проверка",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "04. Журнал документов, выписанных в ходе налоговой проверки",
                                      UserControl = new JourrnalDocView()
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "122. Камеральная налоговая проверка НДФЛ",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)  (Акты Извещения Решения)",
                                      UserControl = new RegistryDeclarationView()
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
                                      NameControl = "Ведение КРСБ",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Просмотр списка КРСБ налогоплательщика",
                                              UserControl = new Krsb()
                                          }
                                      }
                                  },
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
                                      NameControl = "14.КС–Корректировка сведений о правах не зарегистрированных  в органах Росреестра и правах наследования на ОН и ЗУ",
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
                              NameControl = "Учет документов",
                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "Прием документов учета НП",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "Прием документов учета НП (ФЛ)",
                                              UserControl = new UserControlAcceptanceDocuments()
                                          }
                                      }
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Банковские и лицевые счета",                              CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                              {
                                  new FullWindowAutoIt()
                                  {
                                      NameControl = "06. Журналы принятых файлов БС",
                                      CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                      {
                                          new FullWindowAutoIt()
                                          {
                                              NameControl = "01. Визуальный анализ сообщений банка",
                                              UserControl = new VisualBank()
                                          }
                                      }
                                  }
                              }
                          },
                          new FullWindowAutoIt()
                          {
                              NameControl = "Общие задания",
                              CollectionUserControl =
                                  new ObservableCollection<FullWindowAutoIt>()
                                  {
                                      new FullWindowAutoIt()
                                      {
                                          NameControl = "Уточнение сведений о ФЛ",
                                          UserControl = new Form.Automat.Registration.UtochneneeSved.UserControl.YtochnenieSved(ytochnenieSved)
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
                                                      NameControl = "15.02.02.01. Служебные. Технические исправления. Физические лица",
                                                      UserControl = new TehnicalUpdate()
                                                  },
                                              }
                                          }
                                      }
                                  },
                                  new FullWindowAutoIt()
                                  {
                                   NameControl = "07. Учет физических лиц",
                                   CollectionUserControl = new ObservableCollection<FullWindowAutoIt>()
                                    {
                                      new FullWindowAutoIt()
                                        {
                                         NameControl = "1.01. Журнал поступивших документов",
                                         UserControl = new ReceivedDocuments(ytochnenieSved)
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
                              NameControl = "Автоматическое формирование списка по XML схеме!",
                              UserControl = new ViewGenerator()

                          },
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
