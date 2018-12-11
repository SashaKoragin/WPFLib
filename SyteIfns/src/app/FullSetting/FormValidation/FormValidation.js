import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AngularTemplate, Headers, Stone, Body, Template, NameDocument } from '../../Otdel/It/AddTemplate/Model/ModelTemplate';
import { SelectionModel } from '@angular/cdk/collections';
import { HeadersAdd, BodyAdd, StoneAdd } from './Dialog/ItTemplate/Class/Dialogs';
//Проверка Validation для добавления документа в БД
export var identityRevealedValidator = function (control) {
    var nameDoc = control.get('nameDoc');
    var manualDoc = control.get('manualDoc');
    var headers = control.get('headers');
    var body = control.get('body');
    var stone = control.get('stone');
    return nameDoc.value === null
        && manualDoc.value === null
        && headers.value === null
        && body.value === null
        && stone.value === null ? { 'identityRevealed': true } : null;
};
//Класс контролов
var ControlTemplate = /** @class */ (function () {
    function ControlTemplate(addTemp, dialog, addtemp) {
        this.addTemp = addTemp;
        this.dialog = dialog;
        this.addtemp = addtemp;
        //Модель для документа
        this.document = new AngularTemplate(new Template, new NameDocument);
        //Модель для заголовка
        this.head = new AngularTemplate(null, null, new Headers);
        //Модель для тела
        this.bodys = new AngularTemplate(null, null, null, new Body);
        //Модель для основания
        this.stones = new AngularTemplate(null, null, null, null, new Stone);
        //selector Body
        this.selectionBody = new SelectionModel(false, []);
        //selector Header
        this.selectionHeaders = new SelectionModel(false, []);
        //selector Stone
        this.selectionStone = new SelectionModel(false, []);
        //Реактивная форма на документ
        this.formTemplate = new FormGroup({
            'nameDoc': new FormControl('', Validators.required),
            'manualDoc': new FormControl('', Validators.required),
            'headers': new FormControl({ value: '' }, [Validators.required]),
            'body': new FormControl({ value: '' }, Validators.required),
            'stone': new FormControl({ value: '' }, [Validators.required])
        }, { validators: identityRevealedValidator });
    }
    Object.defineProperty(ControlTemplate.prototype, "nameDoc", {
        get: function () { return this.formTemplate.get('nameDoc'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ControlTemplate.prototype, "manualDoc", {
        get: function () { return this.formTemplate.get('manualDoc'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ControlTemplate.prototype, "headers", {
        get: function () { return this.formTemplate.get('headers'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ControlTemplate.prototype, "body", {
        get: function () { return this.formTemplate.get('body'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ControlTemplate.prototype, "stone", {
        get: function () { return this.formTemplate.get('stone'); },
        enumerable: true,
        configurable: true
    });
    //Выбор из таблицы Header
    ControlTemplate.prototype.selectHeaders = function () {
        var _this = this;
        if (this.selectionHeaders.selected.length > 0) {
            this.selectionHeaders.selected.map(function (head) {
                _this.document.Template.IdHeaders = head.IdHeaders;
            });
        }
        else {
            this.document.Template.IdHeaders = null;
        }
    };
    //Выбор из таблицы Body
    ControlTemplate.prototype.selectBody = function () {
        var _this = this;
        if (this.selectionBody.selected.length > 0) {
            this.selectionBody.selected.map(function (body) {
                _this.document.Template.IdBody = body.IdBody;
            });
        }
        else {
            this.document.Template.IdBody = null;
        }
    };
    //Выбор из таблицы Stone
    ControlTemplate.prototype.selectStone = function () {
        var _this = this;
        if (this.selectionStone.selected.length > 0) {
            this.selectionStone.selected.map(function (stone) {
                _this.document.Template.IdStone = stone.IdStone;
            });
        }
        else {
            this.document.Template.IdStone = null;
        }
    };
    //Открытие диалогового окна на добавления Header
    ControlTemplate.prototype.openDialogHead = function () {
        this.dialog.open(HeadersAdd, {
            width: '600px',
            data: { angulardate: this.head, adress: this.addtemp, addTemp: this.addTemp }
        });
    };
    //Открытие диалогового окна на добавления Body
    ControlTemplate.prototype.openDialogBody = function () {
        this.dialog.open(BodyAdd, {
            width: '600px',
            data: { angulardate: this.bodys, adress: this.addtemp, addTemp: this.addTemp }
        });
    };
    //Открытие диалогового окна на добавления Stone
    ControlTemplate.prototype.openDialogStone = function () {
        this.dialog.open(StoneAdd, {
            width: '600px',
            data: { angulardate: this.stones, adress: this.addtemp, addTemp: this.addTemp }
        });
    };
    return ControlTemplate;
}());
export { ControlTemplate };
//# sourceMappingURL=FormValidation.js.map