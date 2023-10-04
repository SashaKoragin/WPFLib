var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Component, ViewEncapsulation, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
//Проверка  Validation Head
export var validatorHead = function (control) {
    var textHeade1 = control.get('textHeade1');
    var textHeade2 = control.get('textHeade2');
    var textHeade3 = control.get('textHeade3');
    var textHeade4 = control.get('textHeade4');
    var textHeade5 = control.get('textHeade5');
    var textHeade6 = control.get('textHeade6');
    var textHeade7 = control.get('textHeade7');
    var textHeade8 = control.get('textHeade8');
    var textHeade9 = control.get('textHeade9');
    var textHeade10 = control.get('textHeade10');
    return textHeade1.value === null
        && textHeade2.value === null
        && textHeade3.value === null
        && textHeade4.value === null
        && textHeade5.value === null
        && textHeade6.value === null
        && textHeade7.value === null
        && textHeade8.value === null
        && textHeade9.value === null
        && textHeade10.value === null ? { 'validatorHead': true } : null;
};
//Проверка  Validation Body
export var validatorBody = function (control) {
    var textBodyGl1 = control.get('textBodyGl1');
    var textBodyGl2 = control.get('textBodyGl2');
    var textBodyGl3 = control.get('textBodyGl3');
    var textBodyGl4 = control.get('textBodyGl4');
    var textBodyGl5 = control.get('textBodyGl5');
    return textBodyGl1.value === null
        && textBodyGl2.value === null
        && textBodyGl3.value === null
        && textBodyGl4.value === null
        && textBodyGl5.value === null ? { 'validatorBody': true } : null;
};
//Проверка  Validation Stone
export var validatorStone = function (control) {
    var textStone1 = control.get('textStone1');
    var textStone2 = control.get('textStone2');
    var textStone3 = control.get('textStone3');
    var textStone4 = control.get('textStone4');
    var textStone5 = control.get('textStone5');
    var textStone6 = control.get('textStone6');
    var textStone7 = control.get('textStone7');
    return textStone1.value === null
        && textStone2.value === null
        && textStone3.value === null
        && textStone4.value === null
        && textStone5.value === null
        && textStone6.value === null
        && textStone7.value === null ? { 'validatorStone': true } : null;
};
var HeadersAdd = /** @class */ (function () {
    function HeadersAdd(MatDialogRef, data) {
        this.MatDialogRef = MatDialogRef;
        this.data = data;
        //Реактивная форма Head
        this.formTemplateHeaders = new FormGroup({
            'textHeade1': new FormControl('', Validators.required),
            'textHeade2': new FormControl('', Validators.required),
            'textHeade3': new FormControl({ value: '' }, [Validators.required]),
            'textHeade4': new FormControl({ value: '' }, Validators.required),
            'textHeade5': new FormControl({ value: '' }, [Validators.required]),
            'textHeade6': new FormControl({ value: '' }, [Validators.required]),
            'textHeade7': new FormControl({ value: '' }, [Validators.required]),
            'textHeade8': new FormControl({ value: '' }, [Validators.required]),
            'textHeade9': new FormControl({ value: '' }, [Validators.required]),
            'textHeade10': new FormControl({ value: '' }, [Validators.required])
        }, { validators: validatorHead });
    }
    Object.defineProperty(HeadersAdd.prototype, "textHeade1", {
        get: function () { return this.formTemplateHeaders.get('textHeade1'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade2", {
        get: function () { return this.formTemplateHeaders.get('textHeade2'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade3", {
        get: function () { return this.formTemplateHeaders.get('textHeade3'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade4", {
        get: function () { return this.formTemplateHeaders.get('textHeade4'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade5", {
        get: function () { return this.formTemplateHeaders.get('textHeade5'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade6", {
        get: function () { return this.formTemplateHeaders.get('textHeade6'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade7", {
        get: function () { return this.formTemplateHeaders.get('textHeade7'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade8", {
        get: function () { return this.formTemplateHeaders.get('textHeade8'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade9", {
        get: function () { return this.formTemplateHeaders.get('textHeade9'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade10", {
        get: function () { return this.formTemplateHeaders.get('textHeade10'); },
        enumerable: false,
        configurable: true
    });
    //Команда отправки и добавления на сервер БД Heade
    HeadersAdd.prototype.addTempateHeade = function () {
        this.data.adress.addtemplate(this.data.angulardate).subscribe(function (model) {
            alert(JSON.stringify(model));
        });
        this.data.addTemp.fullTemplate();
    };
    HeadersAdd = __decorate([
        Component({
            selector: 'dialog-template',
            templateUrl: '../HTML/Headers.html',
            styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
            encapsulation: ViewEncapsulation.None
        })
        //Класс добавления Heade
        ,
        __param(1, Inject(MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [MatDialogRef, Object])
    ], HeadersAdd);
    return HeadersAdd;
}());
export { HeadersAdd };
var BodyAdd = /** @class */ (function () {
    function BodyAdd(MatDialogRef, data) {
        this.MatDialogRef = MatDialogRef;
        this.data = data;
        //Реактивная форма Body
        this.formTemplateBody = new FormGroup({
            'textBodyGl1': new FormControl('', Validators.required),
            'textBodyGl2': new FormControl('', Validators.required),
            'textBodyGl3': new FormControl({ value: '' }, [Validators.required]),
            'textBodyGl4': new FormControl({ value: '' }, Validators.required),
            'textBodyGl5': new FormControl({ value: '' }, [Validators.required])
        }, { validators: validatorBody });
    }
    Object.defineProperty(BodyAdd.prototype, "textBodyGl1", {
        get: function () { return this.formTemplateBody.get('textBodyGl1'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(BodyAdd.prototype, "textBodyGl2", {
        get: function () { return this.formTemplateBody.get('textBodyGl2'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(BodyAdd.prototype, "textBodyGl3", {
        get: function () { return this.formTemplateBody.get('textBodyGl3'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(BodyAdd.prototype, "textBodyGl4", {
        get: function () { return this.formTemplateBody.get('textBodyGl4'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(BodyAdd.prototype, "textBodyGl5", {
        get: function () { return this.formTemplateBody.get('textBodyGl5'); },
        enumerable: false,
        configurable: true
    });
    //Команда отправки и добавления на сервер БД Body
    BodyAdd.prototype.addTempateBody = function () {
        this.data.adress.addtemplate(this.data.angulardate).subscribe(function (model) {
            alert(JSON.stringify(model));
        });
        this.data.addTemp.fullTemplate();
    };
    BodyAdd = __decorate([
        Component({
            selector: 'dialog-template',
            templateUrl: '../HTML/Body.html',
            styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
            encapsulation: ViewEncapsulation.None
        })
        //Класс добавления Body
        ,
        __param(1, Inject(MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [MatDialogRef, Object])
    ], BodyAdd);
    return BodyAdd;
}());
export { BodyAdd };
var StoneAdd = /** @class */ (function () {
    function StoneAdd(MatDialogRef, data) {
        this.MatDialogRef = MatDialogRef;
        this.data = data;
        //Реактивная форма Stone
        this.formTemplateStone = new FormGroup({
            'textStone1': new FormControl('', Validators.required),
            'textStone2': new FormControl('', Validators.required),
            'textStone3': new FormControl({ value: '' }, [Validators.required]),
            'textStone4': new FormControl({ value: '' }, Validators.required),
            'textStone5': new FormControl({ value: '' }, [Validators.required]),
            'textStone6': new FormControl({ value: '' }, [Validators.required]),
            'textStone7': new FormControl({ value: '' }, [Validators.required])
        }, { validators: validatorStone });
    }
    Object.defineProperty(StoneAdd.prototype, "textStone1", {
        get: function () { return this.formTemplateStone.get('textStone1'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(StoneAdd.prototype, "textStone2", {
        get: function () { return this.formTemplateStone.get('textStone2'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(StoneAdd.prototype, "textStone3", {
        get: function () { return this.formTemplateStone.get('textStone3'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(StoneAdd.prototype, "textStone4", {
        get: function () { return this.formTemplateStone.get('textStone4'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(StoneAdd.prototype, "textStone5", {
        get: function () { return this.formTemplateStone.get('textStone5'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(StoneAdd.prototype, "textStone6", {
        get: function () { return this.formTemplateStone.get('textStone6'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(StoneAdd.prototype, "textStone7", {
        get: function () { return this.formTemplateStone.get('textStone7'); },
        enumerable: false,
        configurable: true
    });
    //Команда отправки и добавления на сервер БД Stone
    StoneAdd.prototype.addTempateStone = function () {
        this.data.adress.addtemplate(this.data.angulardate).subscribe(function (model) {
            alert(JSON.stringify(model));
        });
        this.data.addTemp.fullTemplate();
    };
    StoneAdd = __decorate([
        Component({
            selector: 'dialog-template',
            templateUrl: '../HTML/Stone.html',
            styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
            encapsulation: ViewEncapsulation.None
        }),
        __param(1, Inject(MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [MatDialogRef, Object])
    ], StoneAdd);
    return StoneAdd;
}());
export { StoneAdd };
//# sourceMappingURL=Dialogs.js.map