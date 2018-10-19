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
import { AngularTemplate } from '../../../../Otdel/It/AddTemplate/Model/ModelTemplate';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
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
var HeadersAdd = /** @class */ (function () {
    function HeadersAdd(MatDialogRef, data) {
        this.MatDialogRef = MatDialogRef;
        this.data = data;
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
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade2", {
        get: function () { return this.formTemplateHeaders.get('textHeade2'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade3", {
        get: function () { return this.formTemplateHeaders.get('textHeade3'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade4", {
        get: function () { return this.formTemplateHeaders.get('textHeade4'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade5", {
        get: function () { return this.formTemplateHeaders.get('textHeade5'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade6", {
        get: function () { return this.formTemplateHeaders.get('textHeade6'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade7", {
        get: function () { return this.formTemplateHeaders.get('textHeade7'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade8", {
        get: function () { return this.formTemplateHeaders.get('textHeade8'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade9", {
        get: function () { return this.formTemplateHeaders.get('textHeade9'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HeadersAdd.prototype, "textHeade10", {
        get: function () { return this.formTemplateHeaders.get('textHeade10'); },
        enumerable: true,
        configurable: true
    });
    HeadersAdd.prototype.addTempate = function () {
        alert(this.data.Headers.TextHeade1);
        alert(this.data.Headers.TextHeade2);
        alert(this.data.Headers.TextHeade3);
        alert(this.data.Headers.TextHeade4);
        alert(this.data.Headers.TextHeade5);
        alert(this.data.Headers.TextHeade6);
        alert(this.data.Headers.TextHeade7);
        alert(this.data.Headers.TextHeade8);
        alert(this.data.Headers.TextHeade9);
        alert(this.data.Headers.TextHeade10);
    };
    HeadersAdd = __decorate([
        Component({
            selector: 'dialog-content-example-dialog',
            templateUrl: '../HTML/Headers.html',
            styleUrls: ['../HTML/FullDialogStyle.css'],
            encapsulation: ViewEncapsulation.None
        }),
        __param(1, Inject(MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [MatDialogRef,
            AngularTemplate])
    ], HeadersAdd);
    return HeadersAdd;
}());
export { HeadersAdd };
//# sourceMappingURL=Headers.js.map