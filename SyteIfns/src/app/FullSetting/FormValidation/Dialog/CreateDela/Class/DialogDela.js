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
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Component, ViewEncapsulation, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DeloPriem } from '../../../../SelectTable/TableGenerator';
import { CreateDela } from './ModelDelaPriem';
import { deserialize } from 'class-transformer';
import { forbiddenNameValidator } from '../../../../FunctionValidation';
//Проверка  Validation Dela
export var validatorDela = function (control) {
    var delaPriem = control.get('delaPriem');
    return delaPriem.value === null ? { 'validatorDela': true } : null;
};
var DialogDela = /** @class */ (function () {
    function DialogDela(MatDialogRef, data, delop) {
        this.MatDialogRef = MatDialogRef;
        this.data = data;
        this.delop = delop;
        this.delo = null;
        this.delatext = null;
        this.delaCreate = new FormGroup({
            'delaPriem': new FormControl('', [Validators.required, forbiddenNameValidator(/^((\d{4,6}\/{1})+(\d{4,6})|(\d{4,6}))$/)])
        }, { validators: validatorDela });
    }
    Object.defineProperty(DialogDela.prototype, "delaPriem", {
        get: function () { return this.delaCreate.get('delaPriem'); },
        enumerable: false,
        configurable: true
    });
    //Создание дел приема КРСБ
    DialogDela.prototype.addDeloCrete = function () {
        var _this = this;
        this.data.sett.DeloPriem.addarraystring(this.delatext.split(/\//));
        this.data.dataser.createkrsb(this.data.sett).subscribe(function (model) {
            _this.delo = deserialize(CreateDela, model.toString());
            if (_this.delo != null) {
                _this.delop.addTable(_this.delo.TableInfoDelo);
                _this.delop.yesdate = true;
            }
            else {
                _this.delop.yesdate = false;
            }
        });
    };
    DialogDela = __decorate([
        Component({
            selector: 'dialog-dela',
            templateUrl: '../HTML/Dela.html',
            styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
            encapsulation: ViewEncapsulation.None,
            providers: [DeloPriem]
        }),
        __param(1, Inject(MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [MatDialogRef, Object, DeloPriem])
    ], DialogDela);
    return DialogDela;
}());
export { DialogDela };
//# sourceMappingURL=DialogDela.js.map