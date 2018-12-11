import { ServiceWcf, AngularModel } from './ModelService';
import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';
import { forbiddenNameValidator } from '../FullSetting/FunctionValidation';
import { moment } from '../FullSetting/FormatDate';

//Класс выборки
class SelectCompanent {
    //Значение
    value: string;
    //View графика
    viewValue: string;
    //Номер для подстановки знака
    num: number;
}

//Клас полей значений для проверки Validation
export class FormSelect {
   public  numberPole = new FormControl('', [forbiddenNameValidator(/^((\d{1,10}\/{1})+(\d{1,10})|(\d{0,10})|(^$))$/)]);
   public  stringPole = new FormControl();
   public  datePole = new FormControl('', [forbiddenNameValidator(/^((((3[01]|[12][0-9]|0[1-9])\.(1[012]|0[1 9])\.((?:19|20)\d{2}))\/{1})+((3[01]|[12][0-9]|0[1-9])\.(1[012]|0[1 9])\.((?:19|20)\d{2}))|((3[01]|[12][0-9]|0[1-9])\.(1[012]|0[1 9])\.((?:19|20)\d{2}))|(^$))$/)]);
}

//Параметры создания на вместе с подстановкой
export class SelectParam {
    //Наименование параметра
    name: string;
    //Сам параметр в выборке
    nameparametr: string;
    //Сам текст параметра
    paramvalue: string;
    //Выборка для генерации
    select: SelectCompanent;
    //Ун шаблона для создания типов в ковычках или без true с кавычками false без кавычек
    numеrtemplate: boolean;
    //Шаблон 1-Дата, 2-Текст, 3-Числа :Числа и дата это 1 шаблон только даты генерятся по другому и с кавычками методу
    template: number;
    //Форма шаблона
    formTemplate: FormControl;

}

export class LogicaParamGenerateParam {

    //Модель команды отправляемой на сервер работает после Генерации для повторного использования
    public modelCommandServer: AngularModel;

    //Проверка Валидации всего блока при нажатии Обновить
    public errorModel(select: SelectParam[]):boolean {
        for (var sel of select) {
            if (sel.select !== null && sel.select.num !== 0) {
                if (sel.formTemplate.invalid) {
                    return false;
                }
            }
        }
       return true;
   }

    //Параметр не подставляется тогда и только тогда когда все
    // параметры SelectCompanent.num равны 0!!! Вожно!!!
    where: string = 'Where ';

    //Выборка по числам и датам
    selectparamNumber: SelectCompanent[] = [
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
    selectparamString: SelectCompanent[] = [
        { value: '', viewValue: 'Без условия', num: 0 },
        { value: ' IS NULL ', viewValue: 'Пусто', num: 1 },
        { value: ' IS NOT NULL ', viewValue: 'Не пусто', num: 2 },
        { value: ' = ', viewValue: 'Совпадает текст', num: 3 }, //'текст'
        { value: ' <> ', viewValue: 'Не совпадает', num: 4 }, //'текст'
        { value: ' Like ', viewValue: 'Начинается', num: 5 }, //'текст%'
        { value: ' NOT LIKE ', viewValue: 'Не начинается', num: 6 }, //'текст%'
        { value: ' LIKE ', viewValue: 'Содержит', num: 7 }, // '%текст%'
        { value: ' NOT LIKE ', viewValue: 'Не содержит', num: 8 }, // '%текст%'
        { value: ' LIKE ', viewValue: 'Оканчивается', num: 9 }, // '%текст'
        { value: ' NOT LIKE ', viewValue: 'Не оканчивается', num: 10 }, // '%текст'
        { value: ' IN ', viewValue: 'Из перечня', num: 11 } // in ('1','2','3','4')
    ];

    ///Генерит команду и БД на которой выполнить команду
    generatecommand(service: ServiceWcf, select: SelectParam[], numDb: number = 2): AngularModel {
        var generate = new GenerateFullCommand();
        this.modelCommandServer = generate.generateCommand(service, select, this.where, generate.generateDb(numDb));
        return this.modelCommandServer;
    }
}

class GenerateFullCommand {

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



    generateCommand(service: ServiceWcf, select: SelectParam[], where: string, angular: AngularModel): AngularModel {
        var command: string;
        var arraycommand: string = '';
        for (var sel of select) {
            if(sel.select != null && sel.select.num !== 0 && sel.paramvalue.trim() !== '') {
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
          //  alert(arraycommand);
        }
        if (arraycommand !== '') {
            command = service.ServiceWcfCommand.Command.replace('/*{@}*/', where.concat(arraycommand));
        } else {
            command = service.ServiceWcfCommand.Command;
        }
        //alert(command);
        angular.Command = command;
        angular.Id = service.ServiceWcfCommand.Id;
        angular.Discription = service.ServiceWcfCommand.DescriptionFull;
        return angular;
    }

    //Генерация Даты c кавычками по другой логике нужно писать логику на дату т ам по другому
    generateDate(select: SelectParam, isparam: string): string {
        if (new Array(2, 3, 4, 5, 6).some(x => x === select.select.num)) {
            return this.generateStringAndNumber(select, isparam, `'${select.paramvalue.trim()}'`);
        } else {
            if (select.select.num === 1) {
                return this.generateDateEqually(select, isparam, `'${select.paramvalue.trim()}' and ${select.nameparametr} < '${moment(select.paramvalue.trim(), 'DD.MM.YYYY').add(1, 'days').format('DD.MM.YYYY')}'`);
            }
            return this.generateStringAndNumber(select, isparam, `('${select.paramvalue.trim().replace(new RegExp(/[\/]/g), '\',\'')}')`);
        }
    }
    //Генерация строк с кавычками
    generateString(select: SelectParam, isparam: string): string {
        switch (select.select.num) {
            case 2:
                return this.generateStringAndNumber(select, isparam, '');
            case 3:
                return this.generateStringAndNumber(select, isparam, '');
            case 4:
                return this.generateStringAndNumber(select, isparam, `'${select.paramvalue.trim()}'`);
            case 5:
                return this.generateStringAndNumber(select, isparam, `'${select.paramvalue.trim()}'`);
            case 6:
                return this.generateStringAndNumber(select, isparam, `'${select.paramvalue.trim()}%'`);
            case 7:
                return this.generateStringAndNumber(select, isparam, `'%${select.paramvalue.trim()}%'`);
            case 8:
                return this.generateStringAndNumber(select, isparam, `'%${select.paramvalue.trim()}%'`);
            case 9:
                return this.generateStringAndNumber(select, isparam, `'%${select.paramvalue.trim()}'`);
            case 10:
                return this.generateStringAndNumber(select, isparam, `'%${select.paramvalue.trim()}'`);
            case 11:
                return this.generateStringAndNumber(select, isparam, `('${select.paramvalue.trim().replace(new RegExp(/[\/]/g), '\',\'')}')`);
            default:
                return null;
        }
    }

    //Генерация чисел без ковычек
    generateNumber(select: SelectParam, isparam: string): string {
        if (new Array(1,2,3,4,5,6).some(x => x === select.select.num)) {
            return this.generateStringAndNumber(select, isparam, `${select.paramvalue.trim()}`);
        } else {
            return this.generateStringAndNumber(select, isparam, `(${select.paramvalue.trim().replace(new RegExp(/[\/]/g), ',')})`);
        }
    }
    ///Все таки Case на каждое число или из перечня параметра
    generateStringAndNumber(select: SelectParam, isparam: string, strparam: string): string {
        var str: string = '';
        if (isparam !== '') {
            return str.concat(' and ', select.nameparametr, select.select.value, strparam);
        } else {
            return str.concat(select.nameparametr, select.select.value, strparam);
        }
    }
    ///Генерация параметра дата равно
    generateDateEqually(select: SelectParam, isparam: string, strparam: string): string {
        var str: string = '';
        if (isparam !== '') {
            return str.concat(' and ', select.nameparametr, `>${select.select.value}`, strparam);
        } else {
            return str.concat(select.nameparametr, `>${select.select.value}`,strparam);
        }
    }
}