var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { LetterForm } from '../../../../PostZaprosFull/PostFull';
import { FullSetting } from '../../../../FullSetting/FullSetting';
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull';
import { DateModel } from '../../../../FullSetting/DateModelFull';
var BdkLetter = /** @class */ (function () {
    function BdkLetter(dateservice) {
        this.dateservice = dateservice;
        this.bloks = new BlocsInfoButton();
        this.setting = new FullSetting();
        this.date = new DateModel();
    }
    BdkLetter.prototype.ngOnInit = function () {
    };
    BdkLetter.prototype.startreport = function (dateStart, dateFinis) {
        var _this = this;
        this.bloks.serverrestmessage(null);
        this.setting.UseTemplate.IdTemplate = 1;
        if (this.date.valid()) {
            this.date.convertdate(this.setting, dateStart, dateFinis);
            this.dateservice.modelbdk(this.setting).subscribe(function (model) {
                _this.bloks.serverrestmessage(JSON.stringify(model));
            });
        }
    };
    BdkLetter = __decorate([
        Component(({
            selector: 'my-letter',
            templateUrl: '../Template/FormLetter.html',
            styleUrls: ['../Template/FormLetter.css'],
            providers: [LetterForm]
        })),
        __metadata("design:paramtypes", [LetterForm])
    ], BdkLetter);
    return BdkLetter;
}());
export { BdkLetter };
//# sourceMappingURL=FormLetter.js.map