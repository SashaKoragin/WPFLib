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
namespace EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelFilter {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute("ModelVirtualFilter", Namespace="", IsNullable=false)]
    public partial class ModelVirtualFilter1 : ModelVirtualFilter {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ModelVirtualFilter {
        
        private VirtualFilter[] virtualFilterField;
        
        private VirtualFilterToServer virtualFilterToServerField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("VirtualFilter")]
        public VirtualFilter[] VirtualFilter {
            get {
                return this.virtualFilterField;
            }
            set {
                this.virtualFilterField = value;
            }
        }
        
        /// <remarks/>
        public VirtualFilterToServer VirtualFilterToServer {
            get {
                return this.virtualFilterToServerField;
            }
            set {
                this.virtualFilterToServerField = value;
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
    public partial class VirtualFilter {
        
        private int idFilterField;
        
        private string nameFilterField;
        
        private string loginUserField;
        
        private bool isHiddenWebField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdFilter {
            get {
                return this.idFilterField;
            }
            set {
                this.idFilterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameFilter {
            get {
                return this.nameFilterField;
            }
            set {
                this.nameFilterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LoginUser {
            get {
                return this.loginUserField;
            }
            set {
                this.loginUserField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsHiddenWeb {
            get {
                return this.isHiddenWebField;
            }
            set {
                this.isHiddenWebField = value;
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
    public partial class VirtualFilterToServer {
        
        private int idFilterField;
        
        private string nameFilterField;
        
        private string loginUserField;
        
        private bool isHiddenWebField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdFilter {
            get {
                return this.idFilterField;
            }
            set {
                this.idFilterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameFilter {
            get {
                return this.nameFilterField;
            }
            set {
                this.nameFilterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LoginUser {
            get {
                return this.loginUserField;
            }
            set {
                this.loginUserField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsHiddenWeb {
            get {
                return this.isHiddenWebField;
            }
            set {
                this.isHiddenWebField = value;
            }
        }
    }
}