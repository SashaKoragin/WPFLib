﻿using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRLibraryAutomations.UserConnections;

namespace SignalRLibraryAutomations.ConnectAutomations
{
    [HubName("HubAutomation")]
    public class HubAutomations : Hub // this "Hub" is hooked by SignalR and is important. 
    {
        private static readonly BasicChatConnect<UserModel> Connections = new BasicChatConnect<UserModel>();

        /// <summary>
        /// Переназначеный класс подключение пользователя
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {

            var user = new UserModel()
            {
                Name = Context.QueryString["userName"],
                TabelNumbers = Context.QueryString["tabelNumbers"]
            };
            try
            {
                Connections.Add(user, Context.ConnectionId);
                HelloUser("Добро пожаловать пользователь: " + user.Name, Context.ConnectionId);
                Loggers.Log4NetLogger.Info(new Exception("Подключился пользователь: Имя - " + user.Name + " Номер - " + user.TabelNumbers + " Контекст - " + Context.ConnectionId));
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return base.OnConnected();
        }
        /// <summary>
        /// Метод отключение пользователя!!!
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            var user = new UserModel()
            {
                Name = Context.QueryString["user"],
                TabelNumbers = Context.QueryString["tabelnumbers"]
            };
            Loggers.Log4NetLogger.Info(new Exception("Отключился пользователь: Имя - " + user.Name + " Номер - " + user.TabelNumbers + " Контекст - " + Context.ConnectionId));
            Connections.Remove(user, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// Переподключение
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            var user = new UserModel()
            {
                Name = Context.QueryString["user"],
                TabelNumbers = Context.QueryString["tabelnumbers"]
            };
            if (!Connections.GetConnections(user).Contains(Context.ConnectionId))
            {
                Connections.Add(user, Context.ConnectionId);
            }
            Loggers.Log4NetLogger.Info(new Exception("Переподключился пользователь: Имя - " + user.Name + " Номер - " + user.TabelNumbers + " Контекст - " + Context.ConnectionId));
            return base.OnReconnected();
        }
        //Тестовый метод для проверки что все сделанно правильно
        public void HelloUser(string hellouser, string conectionId)
        {
            Clients.Client(conectionId).HelloUser(hellouser);
        }
        /// <summary>
        /// Сообщение с сервера
        /// </summary>
        /// <param name="usernameGuid">GUID Пользователя </param>
        /// <param name="message">Сообщение!</param>
        /// <returns></returns>
        public static async Task SqlServer(string usernameGuid, string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<HubAutomations>();
            await context.Clients.Client(usernameGuid).SqlServer(message);
        }

        /// <summary>
        /// Отдел и подписанты подписка
        /// </summary>
        /// <param name="department">JSON Отдел и подписанты</param>
        public static void SubscribeDepartmentSender(string department)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<HubAutomations>();
            Loggers.Log4NetLogger.Info(new Exception("Модель Отдел и подписанты рассылка пошла!!!"));
            context.Clients.All.SubscribeDepartmentSender(department);
        }

        /// <summary>
        /// Отдел и подписанты подписка на удаление записи
        /// </summary>
        /// <param name="department">JSON Отдел и подписанты удаление</param>
        public static void SubscribeDepartmentSenderDelete(string department)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<HubAutomations>();
            Loggers.Log4NetLogger.Info(new Exception("Модель Отдел и подписанты рассылка пошла!!!"));
            context.Clients.All.SubscribeDepartmentSenderDelete(department);
        }
        /// <summary>
        /// Подписка на редактирования дела
        /// </summary>
        /// <param name="organizationOgrnInventory">Дело ОГРН</param>
        public static void SubscribeOrganizationOgrnInventory(string organizationOgrnInventory)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<HubAutomations>();
            Loggers.Log4NetLogger.Info(new Exception("Модель дело ОГРН рассылка пошла!!!"));
            context.Clients.All.SubscribeOrganizationOgrnInventory(organizationOgrnInventory);
        }
        /// <summary>
        /// Подписка на изменение ГРН
        /// </summary>
        /// <param name="grnInventory"></param>
        public static void SubscribeGrnInventory(string grnInventory)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<HubAutomations>();
            Loggers.Log4NetLogger.Info(new Exception("Модель дело ГРН рассылка пошла!!!"));
            context.Clients.All.SubscribeGrnInventory(grnInventory);
        }
        /// <summary>
        /// Подписка на документ организации
        /// </summary>
        /// <param name="documentInventory"></param>
        public static void SubscribeDocumentInventory(string documentInventory)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<HubAutomations>();
            Loggers.Log4NetLogger.Info(new Exception("Модель документы рассылка пошла!!!"));
            context.Clients.All.SubscribeDocumentInventory(documentInventory);
        }
        /// <summary>
        /// Подписка на обновление или редактирование данных
        /// </summary>
        /// <param name="infoDocument">Информация о документе</param>
        public static void SubscribeInfoDocument(string infoDocument)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<HubAutomations>();
            Loggers.Log4NetLogger.Info(new Exception("Модель документы рассылка пошла!!!"));
            context.Clients.All.SubscribeInfoDocument(infoDocument);
        }
        /// <summary>
        /// Подписка на добавление Контейнера
        /// </summary>
        /// <param name="documentContainer">Документ контейнер</param>
        public static void SubscribeDocumentContainer(string documentContainer)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<HubAutomations>();
            Loggers.Log4NetLogger.Info(new Exception("Модель документы рассылка пошла!!!"));
            context.Clients.All.SubscribeDocumentContainer(documentContainer);
        }
    }
}
