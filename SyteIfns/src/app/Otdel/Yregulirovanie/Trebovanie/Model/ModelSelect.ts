export class SysNum {
    TableSysNumReshen: TableSysNumReshen[];
}
export class TableSysNumReshen {

    D270: number;
    D270Specified: boolean;
    DateBlokIncass: string;
    DateBlokIncassSpecified: boolean;
    DateBlokReshenie: string;
    DateBlokReshenieSpecified: boolean;
    ErrorIncass?: string;
    ErrorReshenie?: any;
    IdStatus_1: number;
    IdStatus_1Specified: boolean;
    IdStatus_2: number;
    IdStatus_2Specified: boolean;
    Reshenie: Reshenie;
}

export class Reshenie {
    D270: number;
    D270Specified: boolean;
    D270IshRes: number;
    D270IshResSpecified: boolean;
    D850Res: number;
    D850ResSpecified: boolean;
    D851Res: number;
    D851ResSpecified: boolean;
    D865: number;
    D865Specified: boolean;
    D865Res: number;
    D865ResSpecified: boolean;
    DateCreate: string;
    DateCreateSpecified: boolean;
    Incass: Incass[];
    N120: number;
    N120Specified: boolean;
    N1: number;
    N1Specified: boolean;
    Summ: number;
    SummSpecified: boolean;
}

export class Incass {
    D270IshIncass: number;
    D270IshIncassSpecified: boolean;
    D850Incass: number;
    D850IncassSpecified: boolean;
    D851Incass: number;
    D851IncassSpecified: boolean;
    D851Res_1: number;
    D851Res_1Specified: boolean;
    Summ: number;
    SummSpecified: boolean;
    DateCreate: string;
    DateCreateSpecified: boolean;
}
