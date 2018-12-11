export class No {
        Delo?: Delo[];
    }
export class Delo {
        StatusPriem?: StatusPriem;
        StatusAnaliz?: StatusAnaliz;
        AnalizNO?: AnalizNO[];
        Id?: number;
        D3979?: number;
        Status1Priem?: number;
        Status1Analiz?: number;
        D85?: Date;
    }
export class StatusPriem {
        Id?: number;
        Priznak?: number;
        MessagePriem?: string;
    }
export class StatusAnaliz {
        Id?: number;
        Priznak?: number;
        MessageAnaliz?: string;
    }
export class AnalizNO {
        MessageDate?: MessageDate;
        MessageStrahovieAndOtkaz?: MessageStrahovieAndOtkaz;
        MessageStatusUh?: MessageStatusUh;
        MessageVivod?: MessageVivod;
        Id?: number;
        D3979?: number;
        D3972?: number;
        Color?: number;
        DateAnaliz?: number;
        StrahovieAndOtkazAnaliz?: number;
        StatusUhAnaliz?: number;
        Vivod?: number;
        D6?: number;
        D1560_2?: number;
        D1560_1?: number;
        DatePeredachi?: Date;
        DateZakritia?: Date;
        N134?: string;
        D3?: string;
        Kbk?: string;
        OKTMO_old?: string;
        D09_3?: string;
        N1_1?: number;
        N279?: string;
        OKTMO_new?: string;
        DateCreate?: Date;
        Error?: string;
        DateError?: Date;
    }
export class MessageDate {
        Id?: number;
        Priznak?: number;
        MessageDate1?: string;
    }
export class MessageStrahovieAndOtkaz {
        Id?: number;
        Priznak?: number;
        MessageStrahovieAndOtkaz1?: string;
    }
export class MessageStatusUh {
        Id?: number;
        Priznak?: number;
        MessageStatusUh1?: string;
    }
export class MessageVivod {
        Id?: number;
        Priznak?: number;
        MessageVivod1?: string;
    }