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
namespace EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelWebSyteInventory {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ModelWebSyte {
        
        private OrganizationOgrnInventory[] organizationOgrnInventoryField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationOgrnInventory")]
        public OrganizationOgrnInventory[] OrganizationOgrnInventory {
            get {
                return this.organizationOgrnInventoryField;
            }
            set {
                this.organizationOgrnInventoryField = value;
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
    public partial class OrganizationOgrnInventory {
        
        private GrnInventories[] grnInventoriesField;
        
        private int idOgrnField;
        
        private string userLoginField;
        
        private long numberOgrnField;
        
        private bool isHiddenWebField;
        
        private int idStatusField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GrnInventories")]
        public GrnInventories[] GrnInventories {
            get {
                return this.grnInventoriesField;
            }
            set {
                this.grnInventoriesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdOgrn {
            get {
                return this.idOgrnField;
            }
            set {
                this.idOgrnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UserLogin {
            get {
                return this.userLoginField;
            }
            set {
                this.userLoginField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long NumberOgrn {
            get {
                return this.numberOgrnField;
            }
            set {
                this.numberOgrnField = value;
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdStatus {
            get {
                return this.idStatusField;
            }
            set {
                this.idStatusField = value;
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
    public partial class GrnInventories {
        
        private DocumentInventories[] documentInventoriesField;
        
        private int idDocGrnField;
        
        private int idGrnAis3Field;
        
        private bool idGrnAis3FieldSpecified;
        
        private int idOgrnField;
        
        private long numberOgrnGrnField;
        
        private string nameDocumentField;
        
        private bool isStartProcessField;
        
        private bool isFindGrnDataBaseField;
        
        private bool statusFinishField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DocumentInventories")]
        public DocumentInventories[] DocumentInventories {
            get {
                return this.documentInventoriesField;
            }
            set {
                this.documentInventoriesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdDocGrn {
            get {
                return this.idDocGrnField;
            }
            set {
                this.idDocGrnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdGrnAis3 {
            get {
                return this.idGrnAis3Field;
            }
            set {
                this.idGrnAis3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdGrnAis3Specified {
            get {
                return this.idGrnAis3FieldSpecified;
            }
            set {
                this.idGrnAis3FieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdOgrn {
            get {
                return this.idOgrnField;
            }
            set {
                this.idOgrnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long NumberOgrnGrn {
            get {
                return this.numberOgrnGrnField;
            }
            set {
                this.numberOgrnGrnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameDocument {
            get {
                return this.nameDocumentField;
            }
            set {
                this.nameDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsStartProcess {
            get {
                return this.isStartProcessField;
            }
            set {
                this.isStartProcessField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsFindGrnDataBase {
            get {
                return this.isFindGrnDataBaseField;
            }
            set {
                this.isFindGrnDataBaseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool StatusFinish {
            get {
                return this.statusFinishField;
            }
            set {
                this.statusFinishField = value;
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
    public partial class DocumentInventories {
        
        private InfoDocument infoDocumentField;
        
        private DirectoryDocument directoryDocumentField;
        
        private StatusDocument statusDocumentField;
        
        private int idDocumentField;
        
        private int idDocGrnField;
        
        private int idDocumentDirectoryField;
        
        private int idInfoField;
        
        private int countPageField;
        
        private string guidDocumentField;
        
        private bool stateDocumentField;
        
        private int idStatusDocumentField;
        
        /// <remarks/>
        public InfoDocument InfoDocument {
            get {
                return this.infoDocumentField;
            }
            set {
                this.infoDocumentField = value;
            }
        }
        
        /// <remarks/>
        public DirectoryDocument DirectoryDocument {
            get {
                return this.directoryDocumentField;
            }
            set {
                this.directoryDocumentField = value;
            }
        }
        
        /// <remarks/>
        public StatusDocument StatusDocument {
            get {
                return this.statusDocumentField;
            }
            set {
                this.statusDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdDocument {
            get {
                return this.idDocumentField;
            }
            set {
                this.idDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdDocGrn {
            get {
                return this.idDocGrnField;
            }
            set {
                this.idDocGrnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdDocumentDirectory {
            get {
                return this.idDocumentDirectoryField;
            }
            set {
                this.idDocumentDirectoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdInfo {
            get {
                return this.idInfoField;
            }
            set {
                this.idInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int CountPage {
            get {
                return this.countPageField;
            }
            set {
                this.countPageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string GuidDocument {
            get {
                return this.guidDocumentField;
            }
            set {
                this.guidDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool StateDocument {
            get {
                return this.stateDocumentField;
            }
            set {
                this.stateDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdStatusDocument {
            get {
                return this.idStatusDocumentField;
            }
            set {
                this.idStatusDocumentField = value;
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
    public partial class InfoDocument {
        
        private int idInfoField;
        
        private string nameDocumentInfoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdInfo {
            get {
                return this.idInfoField;
            }
            set {
                this.idInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameDocumentInfo {
            get {
                return this.nameDocumentInfoField;
            }
            set {
                this.nameDocumentInfoField = value;
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
    public partial class DirectoryDocument {
        
        private int idDocumentDirectoryField;
        
        private string nameDocumentDataBaseField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdDocumentDirectory {
            get {
                return this.idDocumentDirectoryField;
            }
            set {
                this.idDocumentDirectoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameDocumentDataBase {
            get {
                return this.nameDocumentDataBaseField;
            }
            set {
                this.nameDocumentDataBaseField = value;
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
    public partial class StatusDocument {
        
        private int idStatusDocumentField;
        
        private string nameMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdStatusDocument {
            get {
                return this.idStatusDocumentField;
            }
            set {
                this.idStatusDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameMessage {
            get {
                return this.nameMessageField;
            }
            set {
                this.nameMessageField = value;
            }
        }
    }
}
