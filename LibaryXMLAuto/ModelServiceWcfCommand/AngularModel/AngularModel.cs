using System;
using System.Runtime.Serialization;

namespace LibaryXMLAuto.ModelServiceWcfCommand.AngularModel
{
   public class AngularModel
    {
        /// <summary>
        /// Номер команды
        /// </summary>
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [DataMember(Name = "Discription")]
        public string Discription { get; set; }
        /// <summary>
        /// База данных Test или рабочая
        /// </summary>
        public string Db { get; set; }
        /// <summary>
        /// Команда Sql обработанная на фронтенде
        /// </summary>
        [DataMember(Name = "Command")]
        public string Command { get; set; }
    }

    public class AngularModelFileDonload
    {
        //Определение Таблицы БД
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        //Guid 
        [DataMember(Name = "Guid")]
        public Guid Guid { get; set; }
        //Имя файла
        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
}