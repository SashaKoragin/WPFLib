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
// Этот исходный код был создан с помощью xsd, версия=4.7.2046.0.
// 
namespace EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.Okp2.ShemeTaxJournal {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class AutoWebPage {
        
        private TaxJournalAutoWebPage[] taxJournalAutoWebPageField;
        
        private TaxJournal121AutoWebPage[] taxJournal121AutoWebPageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaxJournalAutoWebPage")]
        public TaxJournalAutoWebPage[] TaxJournalAutoWebPage {
            get {
                return this.taxJournalAutoWebPageField;
            }
            set {
                this.taxJournalAutoWebPageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaxJournal121AutoWebPage")]
        public TaxJournal121AutoWebPage[] TaxJournal121AutoWebPage {
            get {
                return this.taxJournal121AutoWebPageField;
            }
            set {
                this.taxJournal121AutoWebPageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class TaxJournalAutoWebPage {
        
        private System.Nullable<System.DateTime> dateIzveshenieField;
        
        private System.Nullable<bool> isLk3Field;
        
        private System.Nullable<bool> isMailField;
        
        private System.Nullable<bool> isPrintField;
        
        private System.Nullable<bool> isTksField;
        
        private System.Nullable<System.DateTime> dataCreateField;
        
        private System.Nullable<int> idDeloField;
        
        private System.Nullable<int> idField;
        
        private string logicsButtonField;
        
        private string loginUserField;
        
        private string innField;
        
        private string kppField;
        
        private string nameFaceField;
        
        private string fidField;
        
        private string typeDocumentField;
        
        private string messageInfoField;
        
        private string extensionsField;
        
        public TaxJournalAutoWebPage() {
            this.logicsButtonField = "Button";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> DateIzveshenie {
            get {
                return this.dateIzveshenieField;
            }
            set {
                this.dateIzveshenieField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> IsLk3 {
            get {
                return this.isLk3Field;
            }
            set {
                this.isLk3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> IsMail {
            get {
                return this.isMailField;
            }
            set {
                this.isMailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> IsPrint {
            get {
                return this.isPrintField;
            }
            set {
                this.isPrintField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> IsTks {
            get {
                return this.isTksField;
            }
            set {
                this.isTksField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> DataCreate {
            get {
                return this.dataCreateField;
            }
            set {
                this.dataCreateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> IdDelo {
            get {
                return this.idDeloField;
            }
            set {
                this.idDeloField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string LogicsButton {
            get {
                return this.logicsButtonField;
            }
            set {
                this.logicsButtonField = value;
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
        public string Inn {
            get {
                return this.innField;
            }
            set {
                this.innField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Kpp {
            get {
                return this.kppField;
            }
            set {
                this.kppField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameFace {
            get {
                return this.nameFaceField;
            }
            set {
                this.nameFaceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Fid {
            get {
                return this.fidField;
            }
            set {
                this.fidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TypeDocument {
            get {
                return this.typeDocumentField;
            }
            set {
                this.typeDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MessageInfo {
            get {
                return this.messageInfoField;
            }
            set {
                this.messageInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Extensions {
            get {
                return this.extensionsField;
            }
            set {
                this.extensionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class TaxJournal121AutoWebPage {
        
        private System.Nullable<int> idField;
        
        private System.Nullable<bool> isLk3Field;
        
        private System.Nullable<bool> isMailField;
        
        private System.Nullable<bool> isPrintField;
        
        private System.Nullable<bool> isTksField;
        
        private string logicsButtonField;
        
        private System.Nullable<System.DateTime> dateIzveshenieField;
        
        private System.Nullable<System.DateTime> dataCreateField;
        
        private System.Nullable<System.DateTime> dateFinishDeclarationField;
        
        private System.Nullable<System.DateTime> dateStartDeclarationField;
        
        private System.Nullable<System.DateTime> dateFinishCheckField;
        
        private System.Nullable<System.DateTime> dateStartCheckField;
        
        private System.Nullable<int> regNumDeclarationField;
        
        private System.Nullable<int> godField;
        
        private System.Nullable<int> counDayField;
        
        private string loginUserField;
        
        private string fidField;
        
        private string innField;
        
        private string nameFaceField;
        
        private string periodField;
        
        private string typeDocumentField;
        
        private string extensionsField;
        
        public TaxJournal121AutoWebPage() {
            this.logicsButtonField = "Button";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> IsLk3 {
            get {
                return this.isLk3Field;
            }
            set {
                this.isLk3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> IsMail {
            get {
                return this.isMailField;
            }
            set {
                this.isMailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> IsPrint {
            get {
                return this.isPrintField;
            }
            set {
                this.isPrintField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> IsTks {
            get {
                return this.isTksField;
            }
            set {
                this.isTksField = value;
            }
        }
        
        /// <remarks/>
        public string LogicsButton {
            get {
                return this.logicsButtonField;
            }
            set {
                this.logicsButtonField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> DateIzveshenie {
            get {
                return this.dateIzveshenieField;
            }
            set {
                this.dateIzveshenieField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> DataCreate {
            get {
                return this.dataCreateField;
            }
            set {
                this.dataCreateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> DateFinishDeclaration {
            get {
                return this.dateFinishDeclarationField;
            }
            set {
                this.dateFinishDeclarationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> DateStartDeclaration {
            get {
                return this.dateStartDeclarationField;
            }
            set {
                this.dateStartDeclarationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> DateFinishCheck {
            get {
                return this.dateFinishCheckField;
            }
            set {
                this.dateFinishCheckField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> DateStartCheck {
            get {
                return this.dateStartCheckField;
            }
            set {
                this.dateStartCheckField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> RegNumDeclaration {
            get {
                return this.regNumDeclarationField;
            }
            set {
                this.regNumDeclarationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> God {
            get {
                return this.godField;
            }
            set {
                this.godField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> CounDay {
            get {
                return this.counDayField;
            }
            set {
                this.counDayField = value;
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
        public string Fid {
            get {
                return this.fidField;
            }
            set {
                this.fidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Inn {
            get {
                return this.innField;
            }
            set {
                this.innField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameFace {
            get {
                return this.nameFaceField;
            }
            set {
                this.nameFaceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Period {
            get {
                return this.periodField;
            }
            set {
                this.periodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TypeDocument {
            get {
                return this.typeDocumentField;
            }
            set {
                this.typeDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Extensions {
            get {
                return this.extensionsField;
            }
            set {
                this.extensionsField = value;
            }
        }
    }
}
