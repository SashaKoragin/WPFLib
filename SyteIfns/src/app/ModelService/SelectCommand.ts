import { ServiceWcf, AngularModel } from './ModelService';


//Класс выборки
class SelectCompanent {
    //Значение
    value: string;
    //View графика
    viewValue: string;
    //Номер для подстановки
    num: number;
}
//Параметры создания на вместе с подстановкой
export class SelectParamMail {
    //Наименование параметра
    name: string;
    //Сам параметр в выборке
    nameparametr: string;
    paramvalue: string;
    //Выборка для генерации
    select: SelectCompanent;
    //Ун шаблона для создания типов в ковычках или без 1 с кавычками 2 без кавычек
    numеrtemplate: number;
}
//Фронт как я его представляю
export class ParametrSelectMail {
    //Параметр не подставляется тогда и только тогда когда все
    // параметры SelectCompanent.num равны 0!!! Вожно!!!
    where: string = 'Where ';
    //Параметры подстановки
    selectparam: SelectCompanent[] = [
        { value: '', viewValue: 'Без условия', num: 0 },
        { value: ' = ', viewValue: 'Равно', num: 1 },
        { value: ' Like ', viewValue: 'Содержит текст', num: 2 }];

    public parametrmail: SelectParamMail[] = [
        { name: 'Ун документа', nameparametr: 'WordDocument.Numerdocument', paramvalue: '', select: null, numеrtemplate: 1 },
        { name: 'Имя файла', nameparametr: 'WordDocument.Namefile', paramvalue: '', select: null, numеrtemplate: 1 },
        { name: 'Номер инспекции', nameparametr: 'UseTableTemplateBdk.N279', paramvalue: '', select: null, numеrtemplate: 2 },
        { name: 'Наименование инспекции', nameparametr: 'UseTableTemplateBdk.N280', paramvalue: '', select: null, numеrtemplate: 1 },
        { name: 'Наименование контейнера БДК', nameparametr: 'UseTableTemplateBdk.D981', paramvalue: '', select: null, numеrtemplate: 1 },
        { name: 'Дата приема', nameparametr: 'UseTableTemplateBdk.D85', paramvalue: '', select: null, numеrtemplate: 1 }
    ];

    public parametrreshen: SelectParamMail[] = [
        { name: 'Системный номер', nameparametr: 'TableSysNumReshen.D270', paramvalue: '', select: null, numеrtemplate: 2 },
        { name: 'Статус решения', nameparametr: 'TableSysNumReshen.IdStatus_1', paramvalue: '', select: null, numеrtemplate: 2 },
        { name: 'Ошибка решения', nameparametr: 'TableSysNumReshen.ErrorReshenie', paramvalue: '', select: null, numеrtemplate: 1 },
        { name: 'Статус поручения', nameparametr: 'TableSysNumReshen.IdStatus_2', paramvalue: '', select: null, numеrtemplate: 2 },
        { name: 'Ошибка поручения', nameparametr: 'TableSysNumReshen.ErrorIncass', paramvalue: '', select: null, numеrtemplate: 1 },
        { name: 'Ун плательщика', nameparametr: 'Reshenie.N1', paramvalue: '', select: null, numеrtemplate: 2 },
        { name: 'Дата создания', nameparametr: 'TableSysNumReshen.DataCreate', paramvalue: '', select: null, numеrtemplate: 2 }
    ];

    public paramepredproverka: SelectParamMail[] = [
        { name: 'Ун документа', nameparametr: 'DocumentReglament.N441__1', paramvalue: '', select: null, numеrtemplate: 2 },
        { name: 'Ун статуса', nameparametr: 'DocumentReglament.Status1', paramvalue: '', select: null, numеrtemplate: 2 },
        { name: 'Сообщение об ошибке', nameparametr: 'DocumentReglament.MesErSt1', paramvalue: '', select: null, numеrtemplate: 1 },
        { name: 'Дата записи', nameparametr: 'DocumentReglament.D85', paramvalue: '', select: null, numеrtemplate: 2 }
    ];

    generatecommand(service: ServiceWcf, select: SelectParamMail[], numDb:number = 2): AngularModel {
        var generate = new GenerateCommand();
        return generate.generatecommand(service, select, this.where, generate.generateDb(numDb));
    }

    generatecommandnotparam(service: ServiceWcf, numDb: number = 2): AngularModel {
        var generate = new GenerateCommand();
        return generate.generatecommandnotparam(service, generate.generateDb(numDb));
    }
}
//Класс для генерации команды
class GenerateCommand {

    generateDb(num: number): AngularModel {
        var angular = new AngularModel();
        switch (num) {
            case 1:
                angular.Db = 'Test';
                break;
            case 2:
                angular.Db = 'Work';
                break;
        }
        return angular;
    }


    generatecommand(service: ServiceWcf, select: SelectParamMail[], where: string, angular:AngularModel): AngularModel {
        var mass: string = '';
        var command: string = '';
        var i: number = 0;
        for (var sel of select) {
            if (sel.select != null && sel.select.num !== 0 && sel.paramvalue.trim() !== '') {
                if (sel.numеrtemplate === 1) {
                    if (i > 0) {
                        mass += command.concat(' and ', sel.nameparametr, sel.select.value, `'${sel.paramvalue.trim()}'`);
                    } else {
                        mass += command.concat(sel.nameparametr, sel.select.value, `'${sel.paramvalue.trim()}'`);
                    }
                } else {
                    if (i > 0) {
                        mass += command.concat(' and ', sel.nameparametr, sel.select.value, sel.paramvalue.trim());
                    } else {
                        mass += command.concat(sel.nameparametr, sel.select.value, sel.paramvalue.trim());
                    }
                }
                command = '';
                i++;
            }
        }
        if (mass !== '') {
            command = service.ServiceWcfCommand.Command.replace('/*{@}*/', where.concat(mass));
        } else {
            command = service.ServiceWcfCommand.Command;
        }
        angular.Command = command;
        angular.Id = service.ServiceWcfCommand.Id;
        angular.Discription = service.ServiceWcfCommand.DescriptionFull;
        return angular;
    }

    generatecommandnotparam(service: ServiceWcf, angular: AngularModel): AngularModel {
        angular.Command = service.ServiceWcfCommand.Command;
        angular.Id = service.ServiceWcfCommand.Id;
        angular.Discription = service.ServiceWcfCommand.DescriptionFull;
        return angular;

    }

}