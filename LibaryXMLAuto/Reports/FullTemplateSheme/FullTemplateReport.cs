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
namespace LibaryXMLAutoReports.FullTemplateSheme {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Document {
        
        private Templates templatesField;
        
        private int idNamedocumentField;
        
        private bool idNamedocumentFieldSpecified;
        
        private string nameDocumentField;
        
        private string manualDocField;
        
        private string idTemplateField;
        
        private System.DateTime dateCreateField;
        
        private bool dateCreateFieldSpecified;
        
        /// <remarks/>
        public Templates Templates {
            get {
                return this.templatesField;
            }
            set {
                this.templatesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdNamedocument {
            get {
                return this.idNamedocumentField;
            }
            set {
                this.idNamedocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdNamedocumentSpecified {
            get {
                return this.idNamedocumentFieldSpecified;
            }
            set {
                this.idNamedocumentFieldSpecified = value;
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
        public string ManualDoc {
            get {
                return this.manualDocField;
            }
            set {
                this.manualDocField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IdTemplate {
            get {
                return this.idTemplateField;
            }
            set {
                this.idTemplateField = value;
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Templates {
        
        private Headers headersField;
        
        private Body bodyField;
        
        private Stone stoneField;
        
        private int idTemplateField;
        
        private bool idTemplateFieldSpecified;
        
        private int idHeadersField;
        
        private bool idHeadersFieldSpecified;
        
        private int idBodyField;
        
        private bool idBodyFieldSpecified;
        
        private int idStoneField;
        
        private bool idStoneFieldSpecified;
        
        private System.DateTime dateCreateTemplateField;
        
        private bool dateCreateTemplateFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Headers Headers {
            get {
                return this.headersField;
            }
            set {
                this.headersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Body Body {
            get {
                return this.bodyField;
            }
            set {
                this.bodyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Stone Stone {
            get {
                return this.stoneField;
            }
            set {
                this.stoneField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdTemplate {
            get {
                return this.idTemplateField;
            }
            set {
                this.idTemplateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdTemplateSpecified {
            get {
                return this.idTemplateFieldSpecified;
            }
            set {
                this.idTemplateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdHeaders {
            get {
                return this.idHeadersField;
            }
            set {
                this.idHeadersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdHeadersSpecified {
            get {
                return this.idHeadersFieldSpecified;
            }
            set {
                this.idHeadersFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdBody {
            get {
                return this.idBodyField;
            }
            set {
                this.idBodyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdBodySpecified {
            get {
                return this.idBodyFieldSpecified;
            }
            set {
                this.idBodyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdStone {
            get {
                return this.idStoneField;
            }
            set {
                this.idStoneField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdStoneSpecified {
            get {
                return this.idStoneFieldSpecified;
            }
            set {
                this.idStoneFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime DateCreateTemplate {
            get {
                return this.dateCreateTemplateField;
            }
            set {
                this.dateCreateTemplateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateCreateTemplateSpecified {
            get {
                return this.dateCreateTemplateFieldSpecified;
            }
            set {
                this.dateCreateTemplateFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class Headers {
        
        private int idHeadersField;
        
        private bool idHeadersFieldSpecified;
        
        private byte[] imageFormField;
        
        private string textHeade1Field;
        
        private string textHeade2Field;
        
        private string textHeade3Field;
        
        private string textHeade4Field;
        
        private string textHeade5Field;
        
        private string textHeade6Field;
        
        private string textHeade7Field;
        
        private string textHeade8Field;
        
        private string textHeade9Field;
        
        private string textHeade10Field;
        
        private string textHeade11Field;
        
        private string textHeade12Field;
        
        private System.DateTime dateCreateField;
        
        private bool dateCreateFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdHeaders {
            get {
                return this.idHeadersField;
            }
            set {
                this.idHeadersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdHeadersSpecified {
            get {
                return this.idHeadersFieldSpecified;
            }
            set {
                this.idHeadersFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="base64Binary")]
        public byte[] ImageForm {
            get {
                return this.imageFormField;
            }
            set {
                this.imageFormField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade1 {
            get {
                return this.textHeade1Field;
            }
            set {
                this.textHeade1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade2 {
            get {
                return this.textHeade2Field;
            }
            set {
                this.textHeade2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade3 {
            get {
                return this.textHeade3Field;
            }
            set {
                this.textHeade3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade4 {
            get {
                return this.textHeade4Field;
            }
            set {
                this.textHeade4Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade5 {
            get {
                return this.textHeade5Field;
            }
            set {
                this.textHeade5Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade6 {
            get {
                return this.textHeade6Field;
            }
            set {
                this.textHeade6Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade7 {
            get {
                return this.textHeade7Field;
            }
            set {
                this.textHeade7Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade8 {
            get {
                return this.textHeade8Field;
            }
            set {
                this.textHeade8Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade9 {
            get {
                return this.textHeade9Field;
            }
            set {
                this.textHeade9Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade10 {
            get {
                return this.textHeade10Field;
            }
            set {
                this.textHeade10Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade11 {
            get {
                return this.textHeade11Field;
            }
            set {
                this.textHeade11Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextHeade12 {
            get {
                return this.textHeade12Field;
            }
            set {
                this.textHeade12Field = value;
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class Body {
        
        private int idBodyField;
        
        private bool idBodyFieldSpecified;
        
        private string bodyGl1Field;
        
        private string bodyGl2Field;
        
        private string bodyGl3Field;
        
        private string bodyGl4Field;
        
        private string bodyGl5Field;
        
        private System.DateTime dateCreateField;
        
        private bool dateCreateFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdBody {
            get {
                return this.idBodyField;
            }
            set {
                this.idBodyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdBodySpecified {
            get {
                return this.idBodyFieldSpecified;
            }
            set {
                this.idBodyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BodyGl1 {
            get {
                return this.bodyGl1Field;
            }
            set {
                this.bodyGl1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BodyGl2 {
            get {
                return this.bodyGl2Field;
            }
            set {
                this.bodyGl2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BodyGl3 {
            get {
                return this.bodyGl3Field;
            }
            set {
                this.bodyGl3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BodyGl4 {
            get {
                return this.bodyGl4Field;
            }
            set {
                this.bodyGl4Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BodyGl5 {
            get {
                return this.bodyGl5Field;
            }
            set {
                this.bodyGl5Field = value;
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class Stone {
        
        private int idStoneField;
        
        private bool idStoneFieldSpecified;
        
        private string stone1Field;
        
        private string stone2Field;
        
        private string stone3Field;
        
        private string stone4Field;
        
        private string stone5Field;
        
        private string stone6Field;
        
        private string stone7Field;
        
        private System.DateTime dateCreateField;
        
        private bool dateCreateFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdStone {
            get {
                return this.idStoneField;
            }
            set {
                this.idStoneField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdStoneSpecified {
            get {
                return this.idStoneFieldSpecified;
            }
            set {
                this.idStoneFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Stone1 {
            get {
                return this.stone1Field;
            }
            set {
                this.stone1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Stone2 {
            get {
                return this.stone2Field;
            }
            set {
                this.stone2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Stone3 {
            get {
                return this.stone3Field;
            }
            set {
                this.stone3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Stone4 {
            get {
                return this.stone4Field;
            }
            set {
                this.stone4Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Stone5 {
            get {
                return this.stone5Field;
            }
            set {
                this.stone5Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Stone6 {
            get {
                return this.stone6Field;
            }
            set {
                this.stone6Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Stone7 {
            get {
                return this.stone7Field;
            }
            set {
                this.stone7Field = value;
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("TableModelTemplate", Namespace="", IsNullable=false)]
    public partial class ModelFull {
        
        private NameDocument[] nameDocumentField;
        
        private Template[] templateField;
        
        private Headers[] headersField;
        
        private Body[] bodyField;
        
        private Stone[] stoneField;
        
        private Document[] documentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NameDocument", IsNullable=true)]
        public NameDocument[] NameDocument {
            get {
                return this.nameDocumentField;
            }
            set {
                this.nameDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Template", IsNullable=true)]
        public Template[] Template {
            get {
                return this.templateField;
            }
            set {
                this.templateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Headers", IsNullable=true)]
        public Headers[] Headers {
            get {
                return this.headersField;
            }
            set {
                this.headersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Body", IsNullable=true)]
        public Body[] Body {
            get {
                return this.bodyField;
            }
            set {
                this.bodyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Stone", IsNullable=true)]
        public Stone[] Stone {
            get {
                return this.stoneField;
            }
            set {
                this.stoneField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Document")]
        public Document[] Document {
            get {
                return this.documentField;
            }
            set {
                this.documentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class NameDocument {
        
        private int idNamedocumentField;
        
        private bool idNamedocumentFieldSpecified;
        
        private string nameDocument1Field;
        
        private string manualDocField;
        
        private int idTemplateField;
        
        private bool idTemplateFieldSpecified;
        
        private System.DateTime dateCreateField;
        
        private bool dateCreateFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdNamedocument {
            get {
                return this.idNamedocumentField;
            }
            set {
                this.idNamedocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdNamedocumentSpecified {
            get {
                return this.idNamedocumentFieldSpecified;
            }
            set {
                this.idNamedocumentFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("NameDocument")]
        public string NameDocument1 {
            get {
                return this.nameDocument1Field;
            }
            set {
                this.nameDocument1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ManualDoc {
            get {
                return this.manualDocField;
            }
            set {
                this.manualDocField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdTemplate {
            get {
                return this.idTemplateField;
            }
            set {
                this.idTemplateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdTemplateSpecified {
            get {
                return this.idTemplateFieldSpecified;
            }
            set {
                this.idTemplateFieldSpecified = value;
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2053.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class Template {
        
        private int idTemplateField;
        
        private bool idTemplateFieldSpecified;
        
        private int idHeadersField;
        
        private bool idHeadersFieldSpecified;
        
        private int idBodyField;
        
        private bool idBodyFieldSpecified;
        
        private int idStoneField;
        
        private bool idStoneFieldSpecified;
        
        private System.DateTime dateCreateTemplateField;
        
        private bool dateCreateTemplateFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdTemplate {
            get {
                return this.idTemplateField;
            }
            set {
                this.idTemplateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdTemplateSpecified {
            get {
                return this.idTemplateFieldSpecified;
            }
            set {
                this.idTemplateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdHeaders {
            get {
                return this.idHeadersField;
            }
            set {
                this.idHeadersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdHeadersSpecified {
            get {
                return this.idHeadersFieldSpecified;
            }
            set {
                this.idHeadersFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdBody {
            get {
                return this.idBodyField;
            }
            set {
                this.idBodyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdBodySpecified {
            get {
                return this.idBodyFieldSpecified;
            }
            set {
                this.idBodyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IdStone {
            get {
                return this.idStoneField;
            }
            set {
                this.idStoneField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdStoneSpecified {
            get {
                return this.idStoneFieldSpecified;
            }
            set {
                this.idStoneFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime DateCreateTemplate {
            get {
                return this.dateCreateTemplateField;
            }
            set {
                this.dateCreateTemplateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateCreateTemplateSpecified {
            get {
                return this.dateCreateTemplateFieldSpecified;
            }
            set {
                this.dateCreateTemplateFieldSpecified = value;
            }
        }
    }
}
