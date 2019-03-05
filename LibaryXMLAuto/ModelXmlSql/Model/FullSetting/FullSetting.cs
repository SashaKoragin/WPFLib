using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LibaryXMLAuto.ModelXmlSql.Model.FullSetting
{
   public class FullSetting
    {
        /// <summary>
        /// Параметры для решений
        /// </summary>
        [DataMember(Name = "ParametrReshen")]
        public ParametrReshen ParametrReshen { get; set; }
        /// <summary>
        /// Параметры для БДК
        /// </summary>
        [DataMember(Name = "ParametrBdk")]
        public ParametrBdk ParametrBdk { get; set; }
        /// <summary>
        /// Параметры шаблона
        /// </summary>
        public UseTemplate UseTemplate { get; set; }
        /// <summary>
        /// Параметры для отправки БДК даты
        /// </summary>
        public ParametrBdkOut ParametrBdkOut { get; set; }
        /// <summary>
        /// Параметры предпроверки
        /// </summary>
        public ParamPredproverka ParamPredproverka { get; set; }
        /// <summary>
        /// Параметры для выбора комманды с сервиса данных
        /// </summary>
        public ParamService ParamService { get; set; }
        /// <summary>
        /// Настройки для анализа карточек КРСБ
        /// </summary>
        public DeloCreate DeloCreate { get; set; }
        /// <summary>
        /// Дела приема КРСБ
        /// </summary>
        public DeloPriem DeloPriem { get; set; }
        /// <summary>
        /// Параметры для процедуры страховые взносы
        /// </summary>
        public ReportRvs ReportRvs { get; set; }
        /// <summary>
        /// Модель пользователя
        /// </summary>
        public ModelUser ModelUser { get; set; }
        /// <summary>
        /// БД Тест или рабочая
        /// </summary>
        [DataMember(Name = "Db")]
        public string Db { get; set; }
        /// <summary>
        /// Номер процедуры выполнения
        /// </summary>
        [DataMember(Name = "Id")]
        public int Id { get; set; }
    }

    public class ParametrReshen
    {
        /// <summary>
        /// Системный номер
        /// </summary>
        [DataMember(Name = "D270")]
        public int D270 { get; set; } = 0;
        /// <summary>
        /// Дата начала выборки
        /// </summary>
        [DataMember(Name = "D85_DateStart")]
        public DateTime D85DateStart { get; set; }
        /// <summary>
        /// Дата конца выборки
        /// </summary>
        [DataMember(Name = "D85_DateFinish")]
        public DateTime D85DateFinish { get; set; }
    }

    public class ParametrBdk
    {
        /// <summary>
        /// Ун пользователя
        /// </summary>
        [DataMember(Name = "N269")]
        public int N269 { get; set; } = 0;

        /// <summary>
        /// Сообщение
        /// </summary>
        [DataMember(Name = "D05")]
        public string D05 { get; set; }
    }

    /// <summary>
    /// Параметры шаблона для Sql выборки
    /// </summary>
    public class UseTemplate
    {
        /// <summary>
        /// Номер шаблона
        /// </summary>
        [DataMember(Name = "IdTemplate")]
        public int IdTemplate { get; set; }
    }


    /// <summary>
    /// Параметры для ReportBdk.ReportBdkFull
    /// </summary>
    public class ParametrBdkOut
    {
        /// <summary>
        /// Дата начала выборки
        /// </summary>
        [DataMember(Name = "D85_DateStart")]
        public DateTime D85DateStart { get; set; }
        /// <summary>
        /// Дата конца выборки
        /// </summary>
        [DataMember(Name = "D85_DateFinish")]
        public DateTime D85DateFinish { get; set; }
    }

    public class ParamPredproverka
    {
        public int N441 { get; set; }
    }

    public class ParamService
    {
        /// <summary>
        /// Подстановка параметра для выборки с сервиса данных выборки
        /// </summary>
        [DataMember(Name = "IdCommand")]
        public int IdCommand { get; set; }
    }
    /// <summary>
    /// Предворительно значения дел приема
    /// </summary>
    public class DeloPriem
    {
        /// <summary>
        /// Значения дел приема
        /// </summary>
        [DataMember(Name = "DelaPriem")]
        public List<string> DelaPriem { get; set; }
    }
    //Создание карточек КРСБ
    public class DeloCreate
    {
        /// <summary>
        /// Дата поступления дел приема
        /// </summary>
        [DataMember(Name = "DateDelo")]
        public DateTime DateDelo { get; set; }
        /// <summary>
        /// Уникальный номер дела
        /// </summary>
        [DataMember(Name = "D3979")]
        public int D3979 { get; set; }
        /// <summary>
        /// Уникальный номер дела
        /// </summary>
        [DataMember(Name = "Okato")]
        public string Okato { get; set; }
    }

    public class ReportRvs
    {
        /// <summary>
        /// отчетный квартал (1, 2, 3, 4)
        /// </summary>
        [DataMember(Name= "Qvartal")]
        public int Qvartal { get; set; }
        /// <summary>
        /// отчетный год
        /// </summary>
        [DataMember(Name = "God")]
        public int God { get; set; }
        /// <summary>
        /// -- вид отчета:
        ///	   -- 0 - статистика приема по НО,
        ///	   -- 1 - статистика в разрезе НП,
        ///	   -- 2 - ошибки приема в разрезе НП, 
        ///	   -- 3 - сводный отчет о результатах приема
        /// </summary>
        [DataMember(Name = "ReportVid")]
        public int ReportVid { get; set; }

        /// <summary>
        /// по умолчанию 1
        ///-- алгоритм определения успешно представленного расчета:
        ///-- 1 - любой успешно представленный расчет 
        ///       за аналогичный отчетный период
        ///-- 0 - только расчет, представленный с номером корректировки 
        ///       больше ошибочного или представленнный позже ошибочного
        /// </summary>
        [DataMember(Name = "P1")]
        public int P1 { get; set; }
        /// <summary>
        ///  отчетная дата (по-умолчанию = текущая дата)
        /// </summary>
        [DataMember(Name = "Data")]
        public DateTime Data { get; set; }
        /// <summary>
        /// --По умолчанию 1
        /// -- 1 - учитывать ошибки с кодами 2* 
        ///	-- 0 - не учитывать ошибки с кодами 2*
        /// </summary>
        [DataMember(Name = "ErrDetal")]
        public int ErrDetal { get; set; }
    }

    public class ModelUser
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [DataMember(Name = "Login")]
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [DataMember(Name = "Password")]
        public string Password { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DataMember(Name= "UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// Номер пользователя
        /// </summary>
        [DataMember(Name = "Guid")]
        public string Guid { get; set; }
        /// <summary>
        /// Совмещенный Имя пользователя и Номер пользователя
        /// </summary>
        [DataMember(Name = "UserNameGuide")]
        public string UserNameGuide { get; set; }
        /// <summary>
        /// Ошибка при авторизации
        /// </summary>
        [DataMember(Name = "Error")]
        public string Error { get; set; }
    }
}
