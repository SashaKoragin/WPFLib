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
namespace LibaryXMLAutoReports.AnalizNo {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("AnalizNo", Namespace="", IsNullable=false)]
    public partial class No {
        
        private Delo[] deloField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Delo")]
        public Delo[] Delo {
            get {
                return this.deloField;
            }
            set {
                this.deloField = value;
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
    public partial class Delo {
        
        private StatusPriem statusPriemField;
        
        private StatusAnaliz statusAnalizField;
        
        private AnalizNO[] analizNOField;
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int d3979Field;
        
        private bool d3979FieldSpecified;
        
        private int status1PriemField;
        
        private bool status1PriemFieldSpecified;
        
        private int status1AnalizField;
        
        private bool status1AnalizFieldSpecified;
        
        private System.DateTime d85Field;
        
        private bool d85FieldSpecified;
        
        /// <remarks/>
        public StatusPriem StatusPriem {
            get {
                return this.statusPriemField;
            }
            set {
                this.statusPriemField = value;
            }
        }
        
        /// <remarks/>
        public StatusAnaliz StatusAnaliz {
            get {
                return this.statusAnalizField;
            }
            set {
                this.statusAnalizField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnalizNO")]
        public AnalizNO[] AnalizNO {
            get {
                return this.analizNOField;
            }
            set {
                this.analizNOField = value;
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
        public int D3979 {
            get {
                return this.d3979Field;
            }
            set {
                this.d3979Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool D3979Specified {
            get {
                return this.d3979FieldSpecified;
            }
            set {
                this.d3979FieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Status1Priem {
            get {
                return this.status1PriemField;
            }
            set {
                this.status1PriemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Status1PriemSpecified {
            get {
                return this.status1PriemFieldSpecified;
            }
            set {
                this.status1PriemFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Status1Analiz {
            get {
                return this.status1AnalizField;
            }
            set {
                this.status1AnalizField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Status1AnalizSpecified {
            get {
                return this.status1AnalizFieldSpecified;
            }
            set {
                this.status1AnalizFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime D85 {
            get {
                return this.d85Field;
            }
            set {
                this.d85Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool D85Specified {
            get {
                return this.d85FieldSpecified;
            }
            set {
                this.d85FieldSpecified = value;
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
    public partial class StatusPriem {
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int priznakField;
        
        private bool priznakFieldSpecified;
        
        private string messagePriemField;
        
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
        public int Priznak {
            get {
                return this.priznakField;
            }
            set {
                this.priznakField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PriznakSpecified {
            get {
                return this.priznakFieldSpecified;
            }
            set {
                this.priznakFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MessagePriem {
            get {
                return this.messagePriemField;
            }
            set {
                this.messagePriemField = value;
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
    public partial class StatusAnaliz {
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int priznakField;
        
        private bool priznakFieldSpecified;
        
        private string messageAnalizField;
        
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
        public int Priznak {
            get {
                return this.priznakField;
            }
            set {
                this.priznakField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PriznakSpecified {
            get {
                return this.priznakFieldSpecified;
            }
            set {
                this.priznakFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MessageAnaliz {
            get {
                return this.messageAnalizField;
            }
            set {
                this.messageAnalizField = value;
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
    public partial class AnalizNO {
        
        private MessageDate messageDateField;
        
        private MessageStrahovieAndOtkaz messageStrahovieAndOtkazField;
        
        private MessageStatusUh messageStatusUhField;
        
        private MessageVivod messageVivodField;
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int d3979Field;
        
        private bool d3979FieldSpecified;
        
        private int d3972Field;
        
        private bool d3972FieldSpecified;
        
        private int colorField;
        
        private bool colorFieldSpecified;
        
        private int dateAnalizField;
        
        private bool dateAnalizFieldSpecified;
        
        private int strahovieAndOtkazAnalizField;
        
        private bool strahovieAndOtkazAnalizFieldSpecified;
        
        private int statusUhAnalizField;
        
        private bool statusUhAnalizFieldSpecified;
        
        private int vivodField;
        
        private bool vivodFieldSpecified;
        
        private int d6Field;
        
        private bool d6FieldSpecified;
        
        private int d1560_2Field;
        
        private bool d1560_2FieldSpecified;
        
        private int d1560_1Field;
        
        private bool d1560_1FieldSpecified;
        
        private System.DateTime datePeredachiField;
        
        private bool datePeredachiFieldSpecified;
        
        private System.DateTime dateZakritiaField;
        
        private bool dateZakritiaFieldSpecified;
        
        private string n134Field;
        
        private string d3Field;
        
        private string kbkField;
        
        private string oKTMO_oldField;
        
        private string d09_3Field;
        
        private int n1_1Field;
        
        private bool n1_1FieldSpecified;
        
        private string n279Field;
        
        private string oKTMO_newField;
        
        private System.DateTime dateCreateField;
        
        private bool dateCreateFieldSpecified;
        
        private string errorField;
        
        private System.DateTime dateErrorField;
        
        private bool dateErrorFieldSpecified;
        
        /// <remarks/>
        public MessageDate MessageDate {
            get {
                return this.messageDateField;
            }
            set {
                this.messageDateField = value;
            }
        }
        
        /// <remarks/>
        public MessageStrahovieAndOtkaz MessageStrahovieAndOtkaz {
            get {
                return this.messageStrahovieAndOtkazField;
            }
            set {
                this.messageStrahovieAndOtkazField = value;
            }
        }
        
        /// <remarks/>
        public MessageStatusUh MessageStatusUh {
            get {
                return this.messageStatusUhField;
            }
            set {
                this.messageStatusUhField = value;
            }
        }
        
        /// <remarks/>
        public MessageVivod MessageVivod {
            get {
                return this.messageVivodField;
            }
            set {
                this.messageVivodField = value;
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
        public int D3979 {
            get {
                return this.d3979Field;
            }
            set {
                this.d3979Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool D3979Specified {
            get {
                return this.d3979FieldSpecified;
            }
            set {
                this.d3979FieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int D3972 {
            get {
                return this.d3972Field;
            }
            set {
                this.d3972Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool D3972Specified {
            get {
                return this.d3972FieldSpecified;
            }
            set {
                this.d3972FieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Color {
            get {
                return this.colorField;
            }
            set {
                this.colorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ColorSpecified {
            get {
                return this.colorFieldSpecified;
            }
            set {
                this.colorFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int DateAnaliz {
            get {
                return this.dateAnalizField;
            }
            set {
                this.dateAnalizField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateAnalizSpecified {
            get {
                return this.dateAnalizFieldSpecified;
            }
            set {
                this.dateAnalizFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int StrahovieAndOtkazAnaliz {
            get {
                return this.strahovieAndOtkazAnalizField;
            }
            set {
                this.strahovieAndOtkazAnalizField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StrahovieAndOtkazAnalizSpecified {
            get {
                return this.strahovieAndOtkazAnalizFieldSpecified;
            }
            set {
                this.strahovieAndOtkazAnalizFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int StatusUhAnaliz {
            get {
                return this.statusUhAnalizField;
            }
            set {
                this.statusUhAnalizField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusUhAnalizSpecified {
            get {
                return this.statusUhAnalizFieldSpecified;
            }
            set {
                this.statusUhAnalizFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Vivod {
            get {
                return this.vivodField;
            }
            set {
                this.vivodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VivodSpecified {
            get {
                return this.vivodFieldSpecified;
            }
            set {
                this.vivodFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int D6 {
            get {
                return this.d6Field;
            }
            set {
                this.d6Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool D6Specified {
            get {
                return this.d6FieldSpecified;
            }
            set {
                this.d6FieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int D1560_2 {
            get {
                return this.d1560_2Field;
            }
            set {
                this.d1560_2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool D1560_2Specified {
            get {
                return this.d1560_2FieldSpecified;
            }
            set {
                this.d1560_2FieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int D1560_1 {
            get {
                return this.d1560_1Field;
            }
            set {
                this.d1560_1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool D1560_1Specified {
            get {
                return this.d1560_1FieldSpecified;
            }
            set {
                this.d1560_1FieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime DatePeredachi {
            get {
                return this.datePeredachiField;
            }
            set {
                this.datePeredachiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DatePeredachiSpecified {
            get {
                return this.datePeredachiFieldSpecified;
            }
            set {
                this.datePeredachiFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime DateZakritia {
            get {
                return this.dateZakritiaField;
            }
            set {
                this.dateZakritiaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateZakritiaSpecified {
            get {
                return this.dateZakritiaFieldSpecified;
            }
            set {
                this.dateZakritiaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string N134 {
            get {
                return this.n134Field;
            }
            set {
                this.n134Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string D3 {
            get {
                return this.d3Field;
            }
            set {
                this.d3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Kbk {
            get {
                return this.kbkField;
            }
            set {
                this.kbkField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKTMO_old {
            get {
                return this.oKTMO_oldField;
            }
            set {
                this.oKTMO_oldField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string D09_3 {
            get {
                return this.d09_3Field;
            }
            set {
                this.d09_3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int N1_1 {
            get {
                return this.n1_1Field;
            }
            set {
                this.n1_1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool N1_1Specified {
            get {
                return this.n1_1FieldSpecified;
            }
            set {
                this.n1_1FieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string N279 {
            get {
                return this.n279Field;
            }
            set {
                this.n279Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKTMO_new {
            get {
                return this.oKTMO_newField;
            }
            set {
                this.oKTMO_newField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime DateCreate {
            get {
                return this.dateCreateField;
            }
            set {
                this.dateCreateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateCreateSpecified {
            get {
                return this.dateCreateFieldSpecified;
            }
            set {
                this.dateCreateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Error {
            get {
                return this.errorField;
            }
            set {
                this.errorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime DateError {
            get {
                return this.dateErrorField;
            }
            set {
                this.dateErrorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateErrorSpecified {
            get {
                return this.dateErrorFieldSpecified;
            }
            set {
                this.dateErrorFieldSpecified = value;
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
    public partial class MessageDate {
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int priznakField;
        
        private bool priznakFieldSpecified;
        
        private string messageDate1Field;
        
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
        public int Priznak {
            get {
                return this.priznakField;
            }
            set {
                this.priznakField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PriznakSpecified {
            get {
                return this.priznakFieldSpecified;
            }
            set {
                this.priznakFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("MessageDate")]
        public string MessageDate1 {
            get {
                return this.messageDate1Field;
            }
            set {
                this.messageDate1Field = value;
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
    public partial class MessageStrahovieAndOtkaz {
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int priznakField;
        
        private bool priznakFieldSpecified;
        
        private string messageStrahovieAndOtkaz1Field;
        
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
        public int Priznak {
            get {
                return this.priznakField;
            }
            set {
                this.priznakField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PriznakSpecified {
            get {
                return this.priznakFieldSpecified;
            }
            set {
                this.priznakFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("MessageStrahovieAndOtkaz")]
        public string MessageStrahovieAndOtkaz1 {
            get {
                return this.messageStrahovieAndOtkaz1Field;
            }
            set {
                this.messageStrahovieAndOtkaz1Field = value;
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
    public partial class MessageStatusUh {
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int priznakField;
        
        private bool priznakFieldSpecified;
        
        private string messageStatusUh1Field;
        
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
        public int Priznak {
            get {
                return this.priznakField;
            }
            set {
                this.priznakField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PriznakSpecified {
            get {
                return this.priznakFieldSpecified;
            }
            set {
                this.priznakFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("MessageStatusUh")]
        public string MessageStatusUh1 {
            get {
                return this.messageStatusUh1Field;
            }
            set {
                this.messageStatusUh1Field = value;
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
    public partial class MessageVivod {
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int priznakField;
        
        private bool priznakFieldSpecified;
        
        private string messageVivod1Field;
        
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
        public int Priznak {
            get {
                return this.priznakField;
            }
            set {
                this.priznakField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PriznakSpecified {
            get {
                return this.priznakFieldSpecified;
            }
            set {
                this.priznakFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("MessageVivod")]
        public string MessageVivod1 {
            get {
                return this.messageVivod1Field;
            }
            set {
                this.messageVivod1Field = value;
            }
        }
    }
}
