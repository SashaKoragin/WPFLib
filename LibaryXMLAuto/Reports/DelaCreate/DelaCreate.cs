﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Этот исходный код был создан с помощью xsd, версия=4.6.81.0.
// 
namespace LibaryXMLAutoReports.DelaCreate {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("Dela", Namespace="", IsNullable=false)]
    public partial class CreateDela {
        
        private TableInfoDelo[] tableInfoDeloField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TableInfoDelo")]
        public TableInfoDelo[] TableInfoDelo {
            get {
                return this.tableInfoDeloField;
            }
            set {
                this.tableInfoDeloField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class TableInfoDelo {
        
        private int idDeloField;
        
        private bool idDeloFieldSpecified;
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private string id2Field;
        
        private string cmdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdDelo {
            get {
                return this.idDeloField;
            }
            set {
                this.idDeloField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdDeloSpecified {
            get {
                return this.idDeloFieldSpecified;
            }
            set {
                this.idDeloFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id2 {
            get {
                return this.id2Field;
            }
            set {
                this.id2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Cmd {
            get {
                return this.cmdField;
            }
            set {
                this.cmdField = value;
            }
        }
    }
}