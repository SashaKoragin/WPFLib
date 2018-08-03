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
}
