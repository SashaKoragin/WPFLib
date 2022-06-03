using System;
using System.Globalization;
using System.Linq;
using System.Windows.Automation;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.KrsbJournal;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.RaschBydjFunction
{
   public class KrsbFunction
   {

       public string TreeKrsb =  "Налоговое администрирование\\Расчеты с бюджетом\\Ведение КРСБ\\Просмотр списка КРСБ налогоплательщика ";

        /// <summary>
        /// Логика поиска суммы КРСБ и расчет
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="sumNp">Сумма плательщика для анализа</param>
        /// <param name="journal">Журнал БД</param>
        /// <param name="status">Статус карточки</param>
        /// <param name="kbk">Cписок КБК</param>
        /// <param name="oktmo">ОКТМО</param>
        public string FindSum(LibraryAutomations libraryAutomation, decimal sumNp, TaxJournal121 journal, string[] kbk, string status = "01", string oktmo = "")
        {
            decimal sumUpl = (decimal)0.00;
            int isClosed = 2;
            var sw = TreeKrsb.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeKrsb);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            while (true)
            {
                if (libraryAutomation.IsEnableElements(KrsbAis3.MemoInn, null, true) != null)
                {
                    libraryAutomation.SetValuePattern(journal.Inn);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.FindInn);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(KrsbAis3.Rrsb, null, true) != null)
                        {
                            //Если не находим продолжаем выставлять 1000
                            var allKrsb = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindFirstElement(KrsbAis3.ListKrsb)).Cast<AutomationElement>().Distinct()
                               .FirstOrDefault(elem => elem.Current.Name.Contains("List`1 row ") &&
                               kbk.Contains(
                               libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                               libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                               .First(doc => doc.Current.Name.Contains("КБК")))) &&
                               libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                               libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                               .First(doc => doc.Current.Name.Contains("Закрыта"))) == "False" &&
                               libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                               libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                               .First(doc => doc.Current.Name.Contains("Статус НП"))) == status &&
                               libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                               libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                               .First(doc => doc.Current.Name.Contains("ОКТМО"))) == oktmo.Trim());
                            if (allKrsb != null)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Rrsb);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.OpenYers);
                                libraryAutomation.InvokePattern(libraryAutomation.FindFirstElement(KrsbAis3.ListYers));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.UpdateInfo);
                                if (libraryAutomation.IsEnableElements(KrsbAis3.UpdateInfo, null, true) != null)
                                {
                                    var listCash = libraryAutomation
                                        .SelectAutomationColrction(
                                            libraryAutomation.FindFirstElement(KrsbAis3.ListCash))
                                        .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("List`1 row ") &&
                                                                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                                                libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                                                    .First(doc => doc.Current.Name.Contains("Отчётный период"))) == $"{journal.Period.Replace("за ", "")} {journal.God}"
                                                                                            &&
                                                                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                                                libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                                                    .First(doc => doc.Current.Name.Contains("Наименование операции"))) == $"начислено налога по расчету"
                                        ).ToList();
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Summ);

                                    foreach (var sum in listCash)
                                    {
                                        sum.SetFocus();
                                        var panel = libraryAutomation
                                            .SelectAutomationColrction(libraryAutomation.IsEnableElements(KrsbAis3.viewPl, null, false, 40, 0, false, ';'))
                                            .Cast<AutomationElement>().ToArray();
                                        if (libraryAutomation.IsEnableElements(KrsbAis3.FindPl, panel[1], false, 1) != null)
                                        {
                                            var listSum = libraryAutomation
                                                .SelectAutomationColrction(
                                                    libraryAutomation.FindElement)
                                                .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("List`1 row ")).ToList();
                                            foreach (var ss in listSum)
                                            {
                                                sumUpl += Convert.ToDecimal(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                    libraryAutomation
                                                        .SelectAutomationColrction(ss)
                                                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Сумма погашения"))));
                                            }
                                        }
                                    }
                                }
                                isClosed = 3;
                            }
                            break;
                        }
                    }
                    MouseCloseFormRsb(isClosed);
                    break;
                }
            }
            return Convert.ToString(sumNp - sumUpl, CultureInfo.CurrentCulture);
        }
        /// <summary>
        /// Закрытие КРСБ по списку плательщиков
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        public void ClosedKrsbPl(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var selectModel = new KrsbJournal();
            var isCklickExit = 1;
            var listModel = selectModel.SelectKrsbNps(statusButton.IsChekcs);
            var sw = TreeKrsb.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeKrsb);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            foreach (var krsbNp in listModel)
            {
                if (statusButton.Iswork)
                {
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(KrsbAis3.MemoInn, null, true) != null)
                            {
                                libraryAutomation.SetValuePattern(krsbNp.Inn);
                                if(libraryAutomation.ParseValuePattern(libraryAutomation.IsEnableElements(KrsbAis3.VielListKrsb))!="True")
                                {
                                    libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(KrsbAis3.VielListKrsb));
                                }
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.FindInn);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(KrsbAis3.UpdateButton, null, true) != null)
                                    {
                                         var id = krsbNp.Krsbs.Select(x => x.IdParameter).ToArray();
                                         var firstIsClosedKrsb = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindFirstElement(KrsbAis3.ListKrsb)).Cast<AutomationElement>()
                                                  .FirstOrDefault(elem => elem.Current.Name.Contains("List`1 row ") &&
                                                  libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                  libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                  .First(doc => doc.Current.Name.Contains("Закрыта"))) == "False"
                                                  && id.Any(idKrsb => idKrsb.Equals(Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                  libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                  .First(doc => doc.Current.Name.Contains("ИД КРСБ"))))))) ;
                                        if (firstIsClosedKrsb != null)
                                        {
                                             libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(KrsbAis3.ClosedKrsbMenu));
                                             while (true)
                                             {
                                                  if (libraryAutomation.IsEnableElements(KrsbAis3.ClosedUpdate, null, true) != null)
                                                  {
                                                      var allClosedKrsb = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindFirstElement(KrsbAis3.ListKrsbClosed)).Cast<AutomationElement>().Where(elem => elem.Current.Name != "Data Area").Distinct()
                                                                          .Where(elem => elem.Current.Name.Contains("List`1 row ") &&
                                                                          libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                          libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                          .First(doc => doc.Current.Name.Contains("Отметка"))) == "False"
                                                                          && id.Any(idKrsb => idKrsb.Equals(Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                             libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                             .First(doc => doc.Current.Name.Contains("ИД КРСБ"))))))).ToList();
                                                      foreach (AutomationElement closed in allClosedKrsb)
                                                      {
                                                          Krsb krsb;
                                                          var elem = libraryAutomation.FindFirstElement("Name:Отметка", closed);
                                                          elem.SetFocus();
                                                          libraryAutomation.ClickElement(elem);
                                                          AutoItX.Sleep(200);
                                                          if (libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(elem) == "False")
                                                          {
                                                               var idkrsb = libraryAutomation.FindFirstElement("Name:ИД КРСБ", closed);
                                                               idkrsb.SetFocus();
                                                               var idModel = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(idkrsb));
                                                               krsb = krsbNp.Krsbs.First(x => x.IdParameter == idModel);
                                                               krsb.IsPriznak = false;
                                                          }
                                                          else
                                                          {
                                                               var idkrsb = libraryAutomation.FindFirstElement("Name:ИД КРСБ", closed);
                                                               idkrsb.SetFocus();
                                                               var idModel = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(idkrsb));
                                                               krsb = krsbNp.Krsbs.First(x => x.IdParameter == idModel);
                                                               krsb.IsPriznak = true;
                                                          }
                                                          selectModel.SaveModelKrsb(krsb);
                                                      }
                                                     libraryAutomation.IsEnableElements(KrsbAis3.MemoClosed);
                                                     libraryAutomation.FindElement.SetFocus();
                                                     AutoItX.ClipPut("Ошибочное создание КРСБ");
                                                     AutoItX.Send(ButtonConstant.CtrlV);
                                                    if (libraryAutomation.IsEnableElements(KrsbAis3.WinError3, null, true, 5) != null) 
                                                    {
                                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError3);
                                                        //libraryAutomation.IsEnableElements(KrsbAis3.MemoClosed);
                                                        //libraryAutomation.FindElement.SetFocus();
                                                        //AutoItX.ClipPut("Ошибочное создание КРСБ");
                                                        //AutoItX.Send(ButtonConstant.CtrlV);
                                                        isCklickExit = 2;
                                                        krsbNp.IsPriznakFullClosed = false;
                                                        break;
                                                    }
                                                    libraryAutomation.FindFirstElement(KrsbAis3.ClosedKrsbButton);
                                                    if (libraryAutomation.FindElement.Current.IsEnabled)
                                                    {
                                                       PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.ClosedKrsbButton);
                                                       if (libraryAutomation.IsEnableElements(KrsbAis3.WinError4Cancel, null, true, 5) != null)
                                                       {
                                                           if (libraryAutomation.IsEnableElements(KrsbAis3.WinError2, null, true, 5) != null)
                                                           {
                                                               PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError2);
                                                           }
                                                           else
                                                           {
                                                               PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.ClosedKrsbButton);
                                                               if (libraryAutomation.IsEnableElements(KrsbAis3.WinError4Cancel, null, true, 5) != null)
                                                               {
                                                                   //Здесь надо делать
                                                                   PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError4Ok);
                                                                   if (libraryAutomation.IsEnableElements(KrsbAis3.Win2QwetionKill, null, true, 5) != null)
                                                                   {
                                                                       PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win1Ok);
                                                                       if (libraryAutomation.IsEnableElements(KrsbAis3.Win2Qwetion, null, true, 5) != null)
                                                                       {
                                                                           PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,KrsbAis3.Win2No);
                                                                       }
                                                                       PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win2Yes);
                                                                       PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win3Ok);
                                                                       if (libraryAutomation.IsEnableElements(KrsbAis3.WinError1, null, true, 5) != null)
                                                                       {
                                                                          PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError1);
                                                                       }
                                                                   }
                                                               }
                                                            krsbNp.IsPriznakFullClosed = true;
                                                           }
                                                       }
                                                       else
                                                       {
                                                           if (libraryAutomation.IsEnableElements(KrsbAis3.WinError2, null, true, 5) != null)
                                                           {
                                                               PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError2);
                                                           }
                                                           else
                                                           {
                                                               PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win1Ok);
                                                               if (libraryAutomation.IsEnableElements(KrsbAis3.Win2Qwetion, null, true, 5) != null)
                                                               {
                                                                   PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win2No);
                                                               }
                                                               PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win2Yes);
                                                               PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win3Ok);
                                                               if (libraryAutomation.IsEnableElements(KrsbAis3.WinError1, null, true, 5) != null)
                                                               {
                                                                   PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError1);
                                                               }
                                                           } 
                                                           krsbNp.IsPriznakFullClosed = true;
                                                       }
                                                       isCklickExit = libraryAutomation.IsEnableElements(KrsbAis3.UpdateButton, null, true) != null ? 1 : 2;
                                                    }
                                                    else
                                                    {
                                                        isCklickExit = 2;
                                                        krsbNp.IsPriznakFullClosed = true;
                                                    }
                                                    break;
                                                  }
                                             }
                                        }
                                    else
                                    {
                                        foreach(var krsb in krsbNp.Krsbs)
                                        {
                                            krsb.IsPriznak = true;
                                            selectModel.SaveModelKrsb(krsb);
                                        }
                                        krsbNp.IsPriznakFullClosed = true;
                                    }
                                    MouseCloseFormRsb(isCklickExit);
                                    isCklickExit = 1;
                                    break;
                                    }
                                }
                            break;
                            }
                        }
                        selectModel.SaveModelNp(krsbNp);
                }
                else
                {
                    MouseCloseFormRsb(isCklickExit);
                    break;
                }
            }
        }
        /// <summary>
        /// Закрыть подчиненные формы
        /// </summary>
        private void MouseCloseFormRsb(int countClose)
        {
            var win = new WindowsAis3();
            while (countClose > 0)
            {
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                countClose--;
            }
        }
   }
}
