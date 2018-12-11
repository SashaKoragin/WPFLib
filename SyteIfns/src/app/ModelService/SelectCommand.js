import { AngularModel } from './ModelService';
//Класс выборки
var SelectCompanent = /** @class */ (function () {
    function SelectCompanent() {
    }
    return SelectCompanent;
}());
//Параметры создания на вместе с подстановкой
var SelectParamMail = /** @class */ (function () {
    function SelectParamMail() {
    }
    return SelectParamMail;
}());
export { SelectParamMail };
//Фронт как я его представляю
var ParametrSelectMail = /** @class */ (function () {
    function ParametrSelectMail() {
        //Параметр не подставляется тогда и только тогда когда все
        // параметры SelectCompanent.num равны 0!!! Вожно!!!
        this.where = 'Where ';
        //Параметры подстановки
        this.selectparam = [
            { value: '', viewValue: 'Без условия', num: 0 },
            { value: ' = ', viewValue: 'Равно', num: 1 },
            { value: ' Like ', viewValue: 'Содержит текст', num: 2 }
        ];
        this.parametrmail = [
            { name: 'Ун документа', nameparametr: 'WordDocument.Numerdocument', paramvalue: '', select: null, numеrtemplate: 1 },
            { name: 'Имя файла', nameparametr: 'WordDocument.Namefile', paramvalue: '', select: null, numеrtemplate: 1 },
            { name: 'Номер инспекции', nameparametr: 'UseTableTemplateBdk.N279', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Наименование инспекции', nameparametr: 'UseTableTemplateBdk.N280', paramvalue: '', select: null, numеrtemplate: 1 },
            { name: 'Наименование контейнера БДК', nameparametr: 'UseTableTemplateBdk.D981', paramvalue: '', select: null, numеrtemplate: 1 },
            { name: 'Дата приема', nameparametr: 'UseTableTemplateBdk.D85', paramvalue: '', select: null, numеrtemplate: 1 }
        ];
        this.parametrreshen = [
            { name: 'Системный номер', nameparametr: 'TableSysNumReshen.D270', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Статус решения', nameparametr: 'TableSysNumReshen.IdStatus_1', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Ошибка решения', nameparametr: 'TableSysNumReshen.ErrorReshenie', paramvalue: '', select: null, numеrtemplate: 1 },
            { name: 'Статус поручения', nameparametr: 'TableSysNumReshen.IdStatus_2', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Ошибка поручения', nameparametr: 'TableSysNumReshen.ErrorIncass', paramvalue: '', select: null, numеrtemplate: 1 },
            { name: 'Ун плательщика', nameparametr: 'Reshenie.N1', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Дата создания', nameparametr: 'TableSysNumReshen.DataCreate', paramvalue: '', select: null, numеrtemplate: 1 }
        ];
        this.paramepredproverka = [
            { name: 'Ун документа', nameparametr: 'DocumentReglament.N441__1', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Ун статуса', nameparametr: 'DocumentReglament.Status1', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Сообщение об ошибке', nameparametr: 'DocumentReglament.MesErSt1', paramvalue: '', select: null, numеrtemplate: 1 },
            { name: 'Дата записи', nameparametr: 'DocumentReglament.D85', paramvalue: '', select: null, numеrtemplate: 1 }
        ];
        this.parametrdelo = [
            { name: 'Ун дела приема', nameparametr: 'Delo.D3979', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Ун статуса приема', nameparametr: 'Delo.Status1Priem', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Ун статуса анализа', nameparametr: 'Delo.Status1Analiz', paramvalue: '', select: null, numеrtemplate: 2 },
            { name: 'Дата записи', nameparametr: 'DocumentReglament.D85', paramvalue: '', select: null, numеrtemplate: 1 }
        ];
    }
    ParametrSelectMail.prototype.generatecommand = function (service, select, numDb) {
        if (numDb === void 0) { numDb = 2; }
        var generate = new GenerateCommand();
        return generate.generatecommand(service, select, this.where, generate.generateDb(numDb));
    };
    ParametrSelectMail.prototype.generatecommandnotparam = function (service, numDb) {
        if (numDb === void 0) { numDb = 2; }
        var generate = new GenerateCommand();
        return generate.generatecommandnotparam(service, generate.generateDb(numDb));
    };
    return ParametrSelectMail;
}());
export { ParametrSelectMail };
//Класс для генерации команды
var GenerateCommand = /** @class */ (function () {
    function GenerateCommand() {
    }
    GenerateCommand.prototype.generateDb = function (num) {
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
    };
    GenerateCommand.prototype.generatecommand = function (service, select, where, angular) {
        var mass = '';
        var command = '';
        var i = 0;
        for (var _i = 0, select_1 = select; _i < select_1.length; _i++) {
            var sel = select_1[_i];
            if (sel.select != null && sel.select.num !== 0 && sel.paramvalue.trim() !== '') {
                if (sel.numеrtemplate === 1) {
                    if (i > 0) {
                        mass += command.concat(' and ', sel.nameparametr, sel.select.value, "'" + sel.paramvalue.trim() + "'");
                    }
                    else {
                        mass += command.concat(sel.nameparametr, sel.select.value, "'" + sel.paramvalue.trim() + "'");
                    }
                }
                else {
                    if (i > 0) {
                        mass += command.concat(' and ', sel.nameparametr, sel.select.value, sel.paramvalue.trim());
                    }
                    else {
                        mass += command.concat(sel.nameparametr, sel.select.value, sel.paramvalue.trim());
                    }
                }
                command = '';
                i++;
            }
        }
        if (mass !== '') {
            command = service.ServiceWcfCommand.Command.replace('/*{@}*/', where.concat(mass));
        }
        else {
            command = service.ServiceWcfCommand.Command;
        }
        angular.Command = command;
        angular.Id = service.ServiceWcfCommand.Id;
        angular.Discription = service.ServiceWcfCommand.DescriptionFull;
        return angular;
    };
    GenerateCommand.prototype.generatecommandnotparam = function (service, angular) {
        angular.Command = service.ServiceWcfCommand.Command;
        angular.Id = service.ServiceWcfCommand.Id;
        angular.Discription = service.ServiceWcfCommand.DescriptionFull;
        return angular;
    };
    return GenerateCommand;
}());
//# sourceMappingURL=SelectCommand.js.map