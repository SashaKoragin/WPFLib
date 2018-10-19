export class Soprovod {
        DocumentReglament: DocumentReglament[];
    }
export class DocumentReglament {
    DocumentDetalization: DocumentDetalization;
    Id: number;
    N441__1: number;
    Status1: number;
    MesErSt1: string;
    DSt1: Date;
    Status2: number;
    MesErSt2: string;
    DSt2: Date;
    D85: Date;
    }
    export class  DocumentDetalization {
        Id: number;
        N441__1: number;
        IdProcedure: number;
        N333__1: number;
        IdUser: number;
        IdGroup: number;
        IdDocument: number;
        N77: string;
        Сoment: string;
        N441__4: Date;
    }