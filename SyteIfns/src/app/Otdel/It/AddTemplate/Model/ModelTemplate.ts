 export class Document {
        public Templates: Templates;
        public IdNamedocument: number;
        public NameDocument: string;
        public ManualDoc: string;
        public IdTemplate: string;
        public DateCreate: Date;

    }
    export class Templates {
        public Headers: Headers;
        public Body: Body;
        public Stone: Stone;
        public IdTemplate: number;
        public IdHeaders: number;
        public IdBody: number;
        public IdStone: number;
        public DateCreateTemplate: Date;
    }
    export class Headers {
        public IdHeaders: number;
        public TextHeade1: string;
        public TextHeade2: string;
        public TextHeade3: string;
        public TextHeade4: string;
        public TextHeade5: string;
        public TextHeade6: string;
        public TextHeade7: string;
        public TextHeade8: string;
        public TextHeade9: string;
        public TextHeade10: string;
        public DateCreate: Date;
    }
    export class Body {
        public IdBody: number;
        public BodyGl1: string;
        public BodyGl2: string;
        public BodyGl3: string;
        public BodyGl4: string;
        public BodyGl5: string;
        public DateCreate: Date;
    }
    export class Stone {
        public IdStone: number;
        public Stone1: string;
        public Stone2: string;
        public Stone3: string;
        public Stone4: string;
        public Stone5: string;
        public Stone6: string;
        public Stone7: string;
        public DateCreate: Date;
    }
  
    export class ModelFull {
        public NameDocument: NameDocument[];
        public Template: Template[];
        public Headers: Headers[];
        public Body: Body[];
        public Stone: Stone[];
        public Document: Document[];
}

export class AngularTemplate {
    constructor(private  template: Template = null,
        private nameDocument: NameDocument =null,
        private head: Headers = null,
        private body: Body = null,
        private stone: Stone = null) {
        this.Template = template;
        this.Headers = head;
        this.Body = body;
        this.Stone = stone;
        this.NameDocument = nameDocument;
    }
    public NameDocument: NameDocument;
    public Template: Template;
    public Headers: Headers;
    public Body: Body;
    public Stone: Stone;
}

    export class NameDocument {
        public IdNamedocument: number;
        public NameDocument1: string;
        public ManualDoc: string;
        public IdTemplate: number;
        public DateCreate: Date;
    }

export class Template {
        public IdTemplate: number;
        public IdHeaders: number;
        public IdBody: number;
        public IdStone: number;
        public DateCreateTemplate: Date;
    }