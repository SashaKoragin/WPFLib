using System;
using System.Runtime.Serialization;

namespace LibaryXMLAuto.Reports.FullTemplateSheme
{
        public class Headers
        {
        [DataMember(Name = "IdHeaders")]
        public int IdHeaders { get; set; }
        [DataMember(Name = "TextHeade1")]
        public string TextHeade1 { get; set; }
        [DataMember(Name = "TextHeade2")]
        public string TextHeade2 { get; set; }
        [DataMember(Name = "TextHeade3")]
        public string TextHeade3 { get; set; }
        [DataMember(Name = "TextHeade4")]
        public string TextHeade4 { get; set; }
        [DataMember(Name = "TextHeade5")]
        public string TextHeade5 { get; set; }
        [DataMember(Name = "TextHeade6")]
        public string TextHeade6 { get; set; }
        [DataMember(Name = "TextHeade7")]
        public string TextHeade7 { get; set; }
        [DataMember(Name = "TextHeade8")]
        public string TextHeade8 { get; set; }
        [DataMember(Name = "TextHeade9")]
        public string TextHeade9 { get; set; }
        [DataMember(Name = "TextHeade10")]
        public string TextHeade10 { get; set; }
        [DataMember(Name = "DateCreate")]
        public DateTime DateCreate { get; set; }
        }

        public class Body
        {
        [DataMember(Name = "IdBody")]
        public int IdBody { get; set; }
        [DataMember(Name = "BodyGl1")]
        public string BodyGl1 { get; set; }
        [DataMember(Name = "BodyGl2")]
        public string BodyGl2 { get; set; }
        [DataMember(Name = "BodyGl3")]
        public string BodyGl3 { get; set; }
        [DataMember(Name = "BodyGl4")]
        public string BodyGl4 { get; set; }
        [DataMember(Name = "BodyGl5")]
        public string BodyGl5 { get; set; }
        [DataMember(Name = "DateCreate")]
        public DateTime DateCreate { get; set; }
        }

        public class Stone
        {
        [DataMember(Name = "IdStone")]
        public int IdStone { get; set; }
        [DataMember(Name = "Stone1")]
        public string Stone1 { get; set; }
        [DataMember(Name = "Stone2")]
        public string Stone2 { get; set; }
        [DataMember(Name = "Stone3")]
        public string Stone3 { get; set; }
        [DataMember(Name = "Stone4")]
        public string Stone4 { get; set; }
        [DataMember(Name = "Stone5")]
        public string Stone5 { get; set; }
        [DataMember(Name = "Stone6")]
        public string Stone6 { get; set; }
        [DataMember(Name = "Stone7")]
        public string Stone7 { get; set; }
        [DataMember(Name = "DateCreate")]
        public DateTime DateCreate { get; set; }

        }

        public class NameDocument
        {
        [DataMember(Name = "IdNamedocument")]
        public int IdNamedocument { get; set; }
        [DataMember(Name = "NameDocument1")]
        public string NameDocument1 { get; set; }
        [DataMember(Name = "ManualDoc")]
        public string ManualDoc { get; set; }
        [DataMember(Name = "IdTemplate")]
        public int IdTemplate { get; set; }
        [DataMember(Name = "DateCreate")]
        public DateTime DateCreate { get; set; }
        }

        public class Template
        {
        [DataMember(Name = "IdTemplate")]
        public int IdTemplate { get; set; }
        [DataMember(Name = "IdHeaders")]
        public int IdHeaders { get; set; }
        [DataMember(Name = "IdBody")]
        public int IdBody { get; set; }
        [DataMember(Name = "IdStone")]
        public int IdStone { get; set; }
        [DataMember(Name = "DateCreateTemplate")]
        public DateTime DateCreateTemplate { get; set; }
        }

        public class AngularTemplate
            {
        [DataMember(Name = "NameDocument")]
        public NameDocument NameDocument { get; set; }
        [DataMember(Name = "Template")]
        public Template Template { get; set; }
        [DataMember(Name = "Headers")]
        public Headers Headers { get; set; }
        [DataMember(Name = "Body")]
        public Body Body { get; set; }
        [DataMember(Name = "Stone")]
        public Stone Stone { get; set; }
            }
        }
