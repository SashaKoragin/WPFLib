export class ServiceWcf {
    ServiceWcfCommand:ServiceWcfCommand;
}

class ServiceWcfCommand {
    GroupOtdel: GroupOtdel;
    ClassOtdel: ClassOtdel;
    SobytieOtdel: SobytieOtdel;
    Id: number;
    IdGroup: number;
    IdClass: number;
    IdSobytieSystem: number;
    DescriptionFull: string;
    DescriptionParam: string;
    Command: string;
    DateCreate: Date;
}

class GroupOtdel {
    IdGroup: number;
    GroupDescription:string;
    NameGroup: string;
    DateCreate: Date;
}

class ClassOtdel {
    IdClass: number;
    ClassLanguage: string;
    ClassDescription: string;
    DateCreate: Date;
}

class SobytieOtdel {
    IdSobytieSystem: number;
    DescriptionSobytie: string;
    DateCreate: Date;
}

export class AngularModel {
    Id: number;
    Discription: string;
    Db: string;
    Command: string;
}

export class AngularModelFileDonload {
    //Определение БД
    Id: number;
    //Guid
    Guid: string;
    //Имя файла
    Name: string;


}