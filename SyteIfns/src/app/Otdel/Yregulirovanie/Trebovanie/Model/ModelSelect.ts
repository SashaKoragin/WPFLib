export class SysNum {
    tableSysNumReshenField: TableSysNumReshenField[];
}
export class TableSysNumReshenField {

    d270Field: number;
    d270FieldSpecified: boolean;
    dateBlokIncassField: string;
    dateBlokIncassFieldSpecified: boolean;
    dateBlokReshenieField: string;
    dateBlokReshenieFieldSpecified: boolean;
    errorIncassField?: string;
    errorReshenieField?: any;
    idStatus_1Field: number;
    idStatus_1FieldSpecified: boolean;
    idStatus_2Field: number;
    idStatus_2FieldSpecified: boolean;
    reshenieField: ReshenieField;
}

export class ReshenieField {
    d270Field: number;
    d270FieldSpecified: boolean;
    d270IshResField: number;
    d270IshResFieldSpecified: boolean;
    d850ResField: number;
    d850ResFieldSpecified: boolean;
    d851ResField: number;
    d851ResFieldSpecified: boolean;
    d865Field: number;
    d865FieldSpecified: boolean;
    d865ResField: number;
    d865ResFieldSpecified: boolean;
    dateCreateField: string;
    dateCreateFieldSpecified: boolean;
    incassField: IncassField[];
    n120Field: number;
    n120FieldSpecified: boolean;
    n1Field: number;
    n1FieldSpecified: boolean;
    summField: number;
    summFieldSpecified: boolean;
}

export class IncassField {
    d270IshIncassField: number;
    d270IshIncassFieldSpecified: boolean;
    d850IncassField: number;
    d850IncassFieldSpecified: boolean;
    d851IncassField: number;
    d851IncassFieldSpecified: boolean;
    d851Res_1Field: number;
    d851Res_1FieldSpecified: boolean;
    summField: number;
    summFieldSpecified: boolean;
    dateCreateField: string;
    dateCreateFieldSpecified: boolean;
}