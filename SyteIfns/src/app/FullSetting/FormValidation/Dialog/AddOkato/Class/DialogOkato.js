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
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { GenerateParamService, CreateSettingSelect } from '../../../../CreateSetting';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { forbiddenNameValidator } from '../../../../FunctionValidation';
var DialogOkato = /** @class */ (function () {
    function DialogOkato(MatDialogRef, data) {
        this.MatDialogRef = MatDialogRef;
        this.data = data;
        this.delaOkato = new FormGroup({
            'okato': new FormControl('', [Validators.required, forbiddenNameValidator(/^(\d{11})$/)])
        });
        this.message = null;
    }
    Object.defineProperty(DialogOkato.prototype, "okato", {
        get: function () { return this.delaOkato.get('okato'); },
        enumerable: true,
        configurable: true
    });
    DialogOkato.prototype.addokato = function () {
        var _this = this;
        this.message = null;
        var setting = new GenerateParamService(this.data.numberproc);
        var createdb = new CreateSettingSelect().worksetting(setting.setting);
        createdb.DeloCreate.D3979 = this.data.delo;
        createdb.DeloCreate.Okato = this.okato.value;
        this.data.logica.analizkrsb(createdb).subscribe(function (model) {
            _this.message = JSON.stringify(model);
        });
    };
    DialogOkato = __decorate([
        Component({
            selector: 'dialog-okato',
            templateUrl: '../HTML/Okato.html',
            styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
            encapsulation: ViewEncapsulation.None
        }),
        __param(1, Inject(MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [MatDialogRef, Object])
    ], DialogOkato);
    return DialogOkato;
}());
export { DialogOkato };
//# sourceMappingURL=DialogOkato.js.map