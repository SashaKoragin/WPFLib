using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using AisPoco.Ifns51.ToAis;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.PreCheckLog;
using GalaSoft.MvvmLight.Threading;
using Ifns51.ToAis;
using LibraryAIS3Windows.ButtonsClikcs;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryCommandPublic.TestAutoit.PreCheck.ReportingMemo
{
   public class ReportingMemoStart
    {
        /// <summary>
        /// Парсим данные для Докладной записки
        /// </summary>
        /// <param name="statusButton">Кнопка</param>
        /// <param name="serviceGetOrPost">Адрес get bkb Post</param>
        /// <param name="pathTemp">Путь сохранения Temp</param>
        /// <param name="pathSaveBank">Путь сохранения выписок из банка</param>
        ///<param name="idTemplate">УН Шаблонов для веток</param>
        public void ReportingMemoStartPreCheck(StatusButtonMethod statusButton, string serviceGetOrPost, string pathTemp, string pathSaveBank, int[] idTemplate)
        {
            DispatcherHelper.Initialize();
                Task.Run(delegate
                {
                    try
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                        KclicerButton clickerButton = new KclicerButton();
                        LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                        var result = ResultGet(serviceGetOrPost, idTemplate);
                        if (result != null)
                        {
                            if (ais3.WinexistsAis3() == 1)
                            {
                                clickerButton.Click29(statusButton, result, serviceGetOrPost, pathTemp, pathSaveBank);
                                DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                            }
                            else
                            {
                                MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                            }
                        }
                        else
                        {
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                });
        }
        /// <summary>
        /// Проставить статус о подтверждении статуса правонарушения
        /// </summary>
        /// <param name="statusButton">Кнопка</param>
        public void StatusJournal129(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click30(statusButton);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
            });
        }

        /// <summary>
        /// Прием запроса сервера
        /// </summary>
        /// <param name="serviceGetOrPost">Сервисный адресс</param>
        /// <param name="idTemplate">Id Шаблонов</param>
        /// <returns></returns>
        public List<SrvToLoad> ResultGet(string serviceGetOrPost,int[] idTemplate)
        {
            var json = new SerializeJson();
            var request = (HttpWebRequest) WebRequest.Create($"{serviceGetOrPost}?{string.Join("idTemplate=",idTemplate)}");
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.Gone)
            {
                var log = new SqlPreCheckLog();
                log.AddTaxJournal(Environment.UserName,"GET", HttpStatusCode.Gone.ToString(), "Возникла фатальная ошибка 410!");
                //Фатальная ошибка выход
                MessageBox.Show("Возникла фатальная ошибка 410!");
            }
            if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                //Повторить через 10 минут сервер выключен
                var log = new SqlPreCheckLog();
                log.AddTaxJournal(Environment.UserName, "GET", HttpStatusCode.ServiceUnavailable.ToString(), "Сервис выключен повторите через 10 минут 503!");
                MessageBox.Show("Сервис выключен повторите через 10 минут 503!");
            }
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                //Все обработано не чего отдавать
                var log = new SqlPreCheckLog();
                log.AddTaxJournal(Environment.UserName, "GET", HttpStatusCode.NoContent.ToString(), "Все данные отработаны новых поступлений нет!");
                MessageBox.Show("Все данные отработаны новых поступлений нет!");
            }
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //Все хорошо
                var log = new SqlPreCheckLog();
                log.AddTaxJournal(Environment.UserName, "GET", HttpStatusCode.OK.ToString(), "Все хорошо!");
                string resultServer;
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    resultServer = rdr.ReadToEnd();
                }
                return (List<SrvToLoad>)json.JsonDeserializeObjectListClass<SrvToLoad>(resultServer) ;
            }
            return null;
        }
        /// <summary>
        /// Все шаблоны для Выбора
        /// </summary>
        /// <param name="serviceGetTemplate">Маршрут для шаблонов</param>
        /// <returns></returns>
        public List<TemplateModel> ResultGetTemplate(string serviceGetTemplate)
        {
            var json = new SerializeJson();
            var request = (HttpWebRequest)WebRequest.Create(serviceGetTemplate);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string resultServer;
            using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
            {
                resultServer = rdr.ReadToEnd();
            }
            return (List<TemplateModel>)json.JsonDeserializeObjectListClass<TemplateModel>(resultServer);
        }
    }
}
