var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
var UserValidation = /** @class */ (function () {
    function UserValidation() {
    }
    UserValidation.prototype.getRowValidator = function () {
        return new FormGroup({
            'IdUser': new FormControl(null, Validators.required),
            'Name': new FormControl(null, Validators.required),
            'TabelNumber': new FormControl(null, Validators.required),
            'Telephon': new FormControl(null, Validators.required),
            'TelephonUndeground': new FormControl(null, Validators.required),
            'IpTelephon': new FormControl(null, Validators.required),
            'NameRules': new FormControl(null, Validators.required),
            'NameOtdel': new FormControl(null, Validators.required)
        });
    };
    UserValidation = __decorate([
        Injectable()
    ], UserValidation);
    return UserValidation;
}());
export { UserValidation };
//# sourceMappingURL=ValidateTableForm.js.map