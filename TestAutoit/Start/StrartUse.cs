using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoIt;
using TestAutoit.Form;

namespace TestAutoit.Start
{
    public class StrartUse
    {
        public AutoForm Formr;

        public StrartUse(AutoForm form)
        {
            Formr = form;

        }

        /// <summary>
        /// Состояние готово
        /// </summary>
        public bool Flag = false;

        public void Start()
        {
            var file = new ReadsFiles.Readersfile();
            var i = 0;
            if (Flag == false)
            {
                if (AutoItX.WinExists("АИС Налог-3 ПРОМ ") != 0)
                {
                    string[] inn = file.Filesreadinn();
                    Formr.Kol.Text = Formr.Text + inn.Length;
                    foreach (var innone in inn)
                    {
                        i++;
                        AutoItX.ControlClick("АИС Налог-3 ПРОМ ", "по выбраным налогоплательщикам", "[NAME:rB1]", "Left");
                        AutoItX.WinWait("", "Подготовка условий. Пожалуйста подождите...", 10000);
                        AutoItX.Sleep(4000);
                        AutoItX.WinActivate("", "Подготовка условий. Пожалуйста подождите...");
                        ButtonsClikcs.ButtonsCliks.ButtonFormZayv(innone);
                        AutoItX.Sleep(500);
                        AutoItX.WinActivate("АИС Налог-3 ПРОМ ");
                        AutoItX.ControlClick("АИС Налог-3 ПРОМ ", "Создать заявку", "[NAME:but_Create]", "Left");
                        AutoItX.WinWait("Создать заявку с параметрами", "СНУ", 10000);
                        if (AutoItX.WinExists("Создать заявку с параметрами", "СНУ") != 0)
                        {
                            AutoItX.Send("{Enter}");
                        }
                        Formr.Otch.Text = Formr.Otch.Text + i;
                        //file.Filewrite(innone);
                    }
                    MessageBox.Show(@"Обработка завершина");
                }



                else
                {
                    MessageBox.Show(@"Окно не найдено");
                }
            }



        }
        
        /// <summary>
        /// Пробуем печатать!!!
        /// </summary>
        public  void Ptrints()
        {
            Task.Run(delegate
            {
                string inns = "";
                string fio = "";
                string adres = "";
                var parse = new Parse.ParseFl();
                var button = new ButtonsClikcs.ButtonsCliks(Formr);
                var yeslk = new Lk.LkYesAndNo();
                var file = new ReadsFiles.Readersfile();
                var i = 0;
                var _date = "11.12.2017";
                var _datevrucenea = "22.12.2017";
                if (Flag == false)
                {
                    if (AutoItX.WinExists("АИС Налог-3 ПРОМ ") != 0)
                    {
                        string[] inn = file.Filesreadinnprint();
                        foreach (var innone in inn)
                        {
                            i++;
                            button.ButtonPrint(innone, _date);
                            while (true)
                            {
                                if (AutoItX.WinExists("АИС Налог-3 ПРОМ ","Данные, удовлетворяющие заданным условиям не найдены.") == 1)
                                {
                                    //AutoItX.ControlFocus("АИС Налог-3 ПРОМ ", "", "[NAME:gridData]");
                                    //AutoItX.MouseClick("left",
                                    //    SysForm.Status.WindowsAis.X + SysForm.Status.WinGrid.X + 95,
                                    //    SysForm.Status.WindowsAis.Y + SysForm.Status.WinGrid.Y + 15, 1);
                                    AutoItX.Send("{F3}");
                                    break;
                                }
                                if ( AutoItX.WinExists("АИС Налог-3 ПРОМ ", "УН исходящего документа") == 1)
                                {
                                    
                                    while (true)
                                    {
                                        parse.FuncParse();
                                        AutoItX.MouseClick("left", SysForm.Status.WindowsAis.X + 440, SysForm.Status.WindowsAis.Y + 90, 1);
                                        AutoItX.Send("{Tab 2}");
                                        AutoItX.Send("{Enter}");
                                        AutoItX.WinWait("Установить статус СНУ \"Отправлен адресату\"", "Дата вручения", 10000);
                                        AutoItX.ControlSend("Установить статус СНУ \"Отправлен адресату\"", "Дата вручения", "[NAME:ultraDateTimeEditor1]", _datevrucenea);
                                        AutoItX.ControlClick("Установить статус СНУ \"Отправлен адресату\"", "Дата вручения", "[NAME:ultraButton1]");
                                        AutoItX.WinWait("Установить состояние отправлен адресату", "Операция выполнена успешно!");
                                        AutoItX.Send("{Enter}");
                                        AutoItX.Sleep(500);
                                        AutoItX.Send("{Tab}");
                                        if (String.Equals(inns, parse._inn) || String.Equals(fio, parse._fio) || String.Equals(adres, parse._adress))
                                        {
                                            AutoItX.Send("{F5}");
                                             inns = "";
                                             fio = "";
                                             adres = "";
                                            AutoItX.WinWait("АИС Налог-3 ПРОМ ", "УН исходящего документа");
                                            break;
                                        }
                                        else
                                        {
                                            inns = parse._inn;
                                            fio = parse._fio;
                                            adres = parse._adress;

                                        }
                                    }


                                    while (true)
                                    {
                                        parse.FuncParse();      
                                        if (yeslk.SqlLk(parse._inn))
                                        {
                                            //Истина есть ЛК2
                                            if (String.Equals(inns, parse._inn) || String.Equals(fio, parse._fio) || String.Equals(adres, parse._adress))
                                            {
                                                AutoItX.Send("{F3}");
                                                break;
                                            }
                                            else
                                            {   
                                                AutoItX.Sleep(1000);
                                                AutoItX.WinActivate("АИС Налог-3 ПРОМ ");
                                                inns = parse._inn;
                                                fio = parse._fio;
                                                adres = parse._adress;
                                                parse.SaveLkYes(); //Не правильно нужно вниз
                                                AutoItX.Send("{Tab}");
                                            }
                                        }
                                        else
                                        {
                                            //Ложь нет ЛК2
                                            if (String.Equals(inns, parse._inn) || String.Equals(fio, parse._fio) || String.Equals(adres, parse._adress))
                                            {
                                                AutoItX.Send("{F3}");
                                                break;
                                            }
                                            else
                                            {
                                              
                                                AutoItX.MouseClick("left", SysForm.Status.WindowsAis.X + 180, SysForm.Status.WindowsAis.Y + 90, 1);
                                                AutoItX.ProcessWait("AcroRd32.exe",10000);
                                                AutoItX.Sleep(2000); //Можно контролить  процесс
                                                while (true)
                                                {
                                                    if (AutoItX.ProcessExists("AcroRd32.exe") > 0)
                                                    {
                                                        AutoItX.ProcessClose("AcroRd32.exe");
                                                    }
                                                    if (AutoItX.ProcessExists("AcroRd32.exe") == 0)
                                                    {
                                                        break;
                                                    }
                                                }
                                                AutoItX.WinActivate("АИС Налог-3 ПРОМ ");
                                                AutoItX.Send("{Tab}");
                                                inns = parse._inn;
                                                fio = parse._fio;
                                                adres = parse._adress;
                                                parse.SaveLkNo(); //не правильбно  нужно вниз

                                            }
                                        }
                                    }
                                    //while (true)
                                    //{
                                    //    if (AutoItX.ProcessExists("AcroRd32.exe") > 0)
                                    //    {
                                    //        AutoItX.ProcessClose("AcroRd32.exe");
                                    //    }
                                    //    if (AutoItX.ProcessExists("AcroRd32.exe") == 0)
                                    //    {
                                    //        break;
                                    //    }
                                    //}
                                    var inns1 = inns;
                                    Formr.BeginInvoke(new MethodInvoker(()=>Formr.Otch.Text = @"Текуший ИНН" + inns1 ));
                                    break;
                                }
                            }
                        }
                        MessageBox.Show(@"Обработка завершина");
                    }
                    else
                    {
                        MessageBox.Show(@"Окно не найдено");
                    }
                }
            });

        }
    }
}
