using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibaryXMLAuto.ModelXmlSql.Model.Trebovanie
{
    [DataContract]
    public class Setting
    {
        [DataMember(Name = "ParametrSelect")]
        public ParametrSelect ParametrSelect { get; set; }
        [DataMember(Name = "Db")]
        public string Db { get; set; }
        [DataMember(Name = "Id")]
        public int Id { get; set; }
    }

    public class ParametrSelect
    {
        [DataMember(Name = "D270")]
        public int D270 { get; set; } = 0;
    }
}
