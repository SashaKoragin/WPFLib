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
import { PostTrebovanie } from '../../../../PostZaprosFull/PostFull';
import { Setting } from '../Model/ModelTrebovanie';
var TrebovanieStart = /** @class */ (function () {
    function TrebovanieStart(dataservice) {
        this.dataservice = dataservice;
        this.setting = new Setting();
        this.component = 'Круто!!!';
    }
    TrebovanieStart.prototype.ngOnInit = function () {
        this.component = 'Крутто 2 компанент!!! Ура добились!!!';
    };
    TrebovanieStart.prototype.use = function () {
        this.setting.Db = 'work';
        this.setting.Id = 1;
        this.setting.ParametrSelect.D270 = 22222;
        alert(this.setting.ParametrSelect.D270);
        this.dataservice.modeltest(this.setting).subscribe(function (model) { JSON.stringify(model); });
    };
    TrebovanieStart = __decorate([
        Component({
            selector: 'my-treb',
            templateUrl: '../Template/Trebovanie.html',
            providers: [PostTrebovanie]
        }),
        __metadata("design:paramtypes", [PostTrebovanie])
    ], TrebovanieStart);
    return TrebovanieStart;
}());
export { TrebovanieStart };
