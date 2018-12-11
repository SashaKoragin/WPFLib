import { AngularModel } from './ModelService';
import { FormControl } from '@angular/forms';
import { forbiddenNameValidator } from '../FullSetting/FunctionValidation';
import { moment } from '../FullSetting/FormatDate';
//Класс выборки
var SelectCompanent = /** @class */ (function () {
    function SelectCompanent() {
    }
    return SelectCompanent;
}());
//Клас полей значений для проверки Validation
var FormSelect = /** @class */ (function () {
    function FormSelect() {
        this.numberPole = new FormControl('', [forbiddenNameValidator(/^((\d{1,10}\/{1})+(\d{1,10})|(\d{0,10})|(^$))$/)]);
        this.stringPole = new FormControl();
        this.datePole = new FormControl('', [forbiddenNameValidator(/^((((3[01]|[12][0-9]|0[1-9])\.(1[012]|0[1 9])\.((?:19|20)\d{2}))\/{1})+((3[01]|[12][0-9]|0[1-9])\.(1[012]|0[1 9])\.((?:19|20)\d{2}))|((3[01]|[12][0-9]|0[1-9])\.(1[012]|0[1 9])\.((?:19|20)\d{2}))|(^$))$/)]);
    }
    return FormSelect;
}());
//Параметры создания на вместе с подстановкой
var SelectParam = /** @class */ (function () {
    function SelectParam() {
    }
    return SelectParam;
}());
var LogicaParamGenerateParam = /** @class */ (function () {
    function LogicaParamGenerateParam() {
        //Параметр не подставляется тогда и только тогда когда все
        // параметры SelectCompanent.num равны 0!!! Вожно!!!
        this.where = 'Where ';
        //Выборка по числам и датам
        this.selectparamNumber = [
            { value: '', viewValue: 'Без условия', num: 0 },
            { value: ' = ', viewValue: 'Равно', num: 1 },
            { value: ' <> ', viewValue: 'Не равно', num: 2 },
            { value: ' > ', viewValue: 'Больше', num: 3 },
            { value: ' < ', viewValue: 'Меньше', num: 4 },
            { value: ' <= ', viewValue: 'Не больше', num: 5 },
            { value: ' >= ', viewValue: 'Не меньше', num: 6 },
            { value: ' IN ', viewValue: 'Из перечня', num: 7 } //in (1,2,3,4)
        ];
        //По строкам
        this.selectparamString = [
            { value: '', viewValue: 'Без условия', num: 0 },
            { value: ' IS NULL ', viewValue: 'Пусто', num: 1 },
            { value: ' IS NOT NULL ', viewValue: 'Не пусто', num: 2 },
            { value: ' = ', viewValue: 'Совпадает текст', num: 3 },
            { value: ' <> ', viewValue: 'Не совпадает', num: 4 },
            { value: ' Like ', viewValue: 'Начинается', num: 5 },
            { value: ' NOT LIKE ', viewValue: 'Не начинается', num: 6 },
            { value: ' LIKE ', viewValue: 'Содержит', num: 7 },
            { value: ' NOT LIKE ', viewValue: 'Не содержит', num: 8 },
            { value: ' LIKE ', viewValue: 'Оканчивается', num: 9 },
            { value: ' NOT LIKE ', viewValue: 'Не оканчивается', num: 10 },
            { value: ' IN ', viewValue: 'Из перечня', num: 11 } // in ('1','2','3','4')
        ];
        this.parametrdelo = [
            { name: 'Ун дела приема', nameparametr: 'Delo.D3979', paramvalue: '', select: null, numеrtemplate: false, template: 3, formTemplate: new FormSelect().numberPole },
            { name: 'Ун статуса приема', nameparametr: 'Delo.Status1Priem', paramvalue: '', select: null, numеrtemplate: false, template: 3, formTemplate: new FormSelect().numberPole },
            { name: 'Описание приема', nameparametr: 'StatusPriem.MessagePriem', paramvalue: '', select: null, numеrtemplate: true, template: 2, formTemplate: new FormSelect().stringPole },
            { name: 'Ун статуса анализа', nameparametr: 'Delo.Status1Analiz', paramvalue: '', select: null, numеrtemplate: false, template: 3, formTemplate: new FormSelect().numberPole },
            { name: 'Дата записи', nameparametr: 'DocumentReglament.D85', paramvalue: '', select: null, numеrtemplate: true, template: 1, formTemplate: new FormSelect().datePole }
        ];
    }
    //Проверка Валидации всего блока при нажатии Обновить
    LogicaParamGenerateParam.prototype.errorModel = function (select) {
        for (var _i = 0, select_1 = select; _i < select_1.length; _i++) {
            var sel = select_1[_i];
            if (sel.select !== null && sel.select.num !== 0) {
                if (sel.formTemplate.invalid) {
                    return false;
                }
            }
        }
        return true;
    };
    ///Генерит команду и БД на которой выполнить команду
    LogicaParamGenerateParam.prototype.generatecommand = function (service, select, numDb) {
        if (numDb === void 0) { numDb = 2; }
        var generate = new GenerateFullCommand();
        this.modelCommandServer = generate.generateCommand(service, select, this.where, generate.generateDb(numDb));
        return this.modelCommandServer;
    };
    return LogicaParamGenerateParam;
}());
export { LogicaParamGenerateParam };
var GenerateFullCommand = /** @class */ (function () {
    function GenerateFullCommand() {
    }
    GenerateFullCommand.prototype.generateDb = function (num) {
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
    GenerateFullCommand.prototype.generateCommand = function (service, select, where, angular) {
        var command;
        var arraycommand = '';
        for (var _i = 0, select_2 = select; _i < select_2.length; _i++) {
            var sel = select_2[_i];
            if (sel.select != null && sel.select.num !== 0 && sel.paramvalue.trim() !== '') {
                switch (sel.template) {
                    case 1:
                        arraycommand += this.generateDate(sel, arraycommand);
                        break;
                    case 2:
                        arraycommand += this.generateString(sel, arraycommand);
                        break;
                    case 3:
                        arraycommand += this.generateNumber(sel, arraycommand);
                        break;
                }
            }
        }
        if (arraycommand !== '') {
            command = service.ServiceWcfCommand.Command.replace('/*{@}*/', where.concat(arraycommand));
        }
        else {
            command = service.ServiceWcfCommand.Command;
        }
        alert(command);
        angular.Command = command;
        angular.Id = service.ServiceWcfCommand.Id;
        angular.Discription = service.ServiceWcfCommand.DescriptionFull;
        return angular;
    };
    //Генерация Даты c кавычками по другой логике нужно писать логику на дату т ам по другому
    GenerateFullCommand.prototype.generateDate = function (select, isparam) {
        if (new Array(2, 3, 4, 5, 6).some(function (x) { return x === select.select.num; })) {
            return this.generateStringAndNumber(select, isparam, "'" + select.paramvalue.trim() + "'");
        }
        else {
            if (select.select.num === 1) {
                return this.generateDateEqually(select, isparam, "'" + select.paramvalue.trim() + " and " + select.nameparametr + " < '" + moment(select.paramvalue.trim()).add(1, 'days').format('MM.DD.YYYY') + "'");
            }
            return this.generateStringAndNumber(select, isparam, "('" + select.paramvalue.trim().replace(new RegExp(/[\/]/g), '\',\'') + "')");
        }
    };
    //Генерация строк с кавычками
    GenerateFullCommand.prototype.generateString = function (select, isparam) {
        switch (select.select.num) {
            case 2:
                return this.generateStringAndNumber(select, isparam, '');
            case 3:
                return this.generateStringAndNumber(select, isparam, '');
            case 4:
                return this.generateStringAndNumber(select, isparam, "'" + select.paramvalue.trim() + "'");
            case 5:
                return this.generateStringAndNumber(select, isparam, "'" + select.paramvalue.trim() + "'");
            case 6:
                return this.generateStringAndNumber(select, isparam, "'" + select.paramvalue.trim() + "%'");
            case 7:
                return this.generateStringAndNumber(select, isparam, "'%" + select.paramvalue.trim() + "%'");
            case 8:
                return this.generateStringAndNumber(select, isparam, "'%" + select.paramvalue.trim() + "%'");
            case 9:
                return this.generateStringAndNumber(select, isparam, "'%" + select.paramvalue.trim() + "'");
            case 10:
                return this.generateStringAndNumber(select, isparam, "'%" + select.paramvalue.trim() + "'");
            case 11:
                return this.generateStringAndNumber(select, isparam, "('" + select.paramvalue.trim().replace(new RegExp(/[\/]/g), '\',\'') + "')");
            default:
                return null;
        }
    };
    //Генерация чисел без ковычек
    GenerateFullCommand.prototype.generateNumber = function (select, isparam) {
        if (new Array(1, 2, 3, 4, 5, 6).some(function (x) { return x === select.select.num; })) {
            return this.generateStringAndNumber(select, isparam, "" + select.paramvalue.trim());
        }
        else {
            return this.generateStringAndNumber(select, isparam, "(" + select.paramvalue.trim().replace(new RegExp(/[\/]/g), ',') + ")");
        }
    };
    ///Все таки Case на каждое число или из перечня параметра
    GenerateFullCommand.prototype.generateStringAndNumber = function (select, isparam, strparam) {
        var str = '';
        if (isparam !== '') {
            return str.concat(' and ', select.nameparametr, select.select.value, strparam);
        }
        else {
            return str.concat(select.nameparametr, select.select.value, strparam);
        }
    };
    ///Генерация параметра дата равно
    GenerateFullCommand.prototype.generateDateEqually = function (select, isparam, strparam) {
        var str = '';
        if (isparam !== '') {
            return str.concat(' and ', select.nameparametr, select.select.value, ">" + strparam);
        }
        else {
            return str.concat(select.nameparametr, select.select.value, ">" + strparam);
        }
    };
    return GenerateFullCommand;
}());
//# sourceMappingURL=TestComSelect.js.map