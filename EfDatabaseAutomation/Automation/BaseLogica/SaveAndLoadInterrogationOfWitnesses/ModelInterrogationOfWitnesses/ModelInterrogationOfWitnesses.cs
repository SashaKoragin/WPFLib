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
// Этот исходный код был создан с помощью xsd, версия=4.7.2053.0.
// 
using AttributeHelperModelXml;

namespace EfDatabaseAutomation.Automation.BaseLogica.SaveAndLoadInterrogationOfWitnesses.ModelInterrogationOfWitnesses {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ModelInterrogationOfWitnesses {
        
        private Organization[] organizationField;
        
        private Counterpart[] counterpartField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Organization")]
        public Organization[] Organization {
            get {
                return this.organizationField;
            }
            set {
                this.organizationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Counterpart")]
        public Counterpart[] Counterpart {
            get {
                return this.counterpartField;
            }
            set {
                this.counterpartField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Organization {
        
        private string innOrgField;
        
        private string innUserField;
        
        private string typeOrgField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataNames(@"ИНН ОРГАНИЗАЦИИ", @"ИНН ОРГАНИЗАЦИИ")]
        public string InnOrg {
            get {
                return this.innOrgField;
            }
            set {
                this.innOrgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataNames(@"ИНН СОТРУДНИКА", @"ИНН СОТРУДНИКА")]
        public string InnUser {
            get {
                return this.innUserField;
            }
            set {
                this.innUserField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataNames(@"СФЕРА ДЕЯТЕЛЬНСТИ", @"СФЕРА ДЕЯТЕЛЬНСТИ")]
        public string TypeOrg {
            get {
                return this.typeOrgField;
            }
            set {
                this.typeOrgField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Counterpart {
        
        private string innOrgField;
        
        private string nameCeoField;
        
        private string innCounterpartyField;
        
        private string nameCounterpartyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataNames(@"ИНН ОРГАНИЗАЦИИ", @"ИНН ОРГАНИЗАЦИИ")]
        public string InnOrg {
            get {
                return this.innOrgField;
            }
            set {
                this.innOrgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataNames(@"ФИО ДИРЕКТОРА", @"ФИО ДИРЕКТОРА")]
        public string NameCeo {
            get {
                return this.nameCeoField;
            }
            set {
                this.nameCeoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataNames(@"ИНН КОНТРАГЕНТА", @"ИНН КОНТРАГЕНТА")]
        public string InnCounterparty {
            get {
                return this.innCounterpartyField;
            }
            set {
                this.innCounterpartyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataNames(@"НАИМЕНОВАНИЕ", @"НАИМЕНОВАНИЕ")]
        public string NameCounterparty {
            get {
                return this.nameCounterpartyField;
            }
            set {
                this.nameCounterpartyField = value;
            }
        }
    }
}
