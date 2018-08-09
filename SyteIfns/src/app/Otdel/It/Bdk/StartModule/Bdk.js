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
import { ModelBdk } from '../Model/BdkModel';
import { FullSetting } from '../../../../FullSetting/FullSetting';
import { PostBdk } from '../../../../PostZaprosFull/PostFull';
import { CreateSettingSelect } from '../../../../FullSetting/CreateSetting';
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull';
import { deserialize } from "class-transformer";
var BdkIt = /** @class */ (function () {
    function BdkIt(dataservice) {
        this.dataservice = dataservice;
        this.bloks = new BlocsInfoButton();
        this.bdk = null;
        this.setting = new FullSetting();
        this.select = new CreateSettingSelect();
    }
    //Старт блока
    BdkIt.prototype.ngOnInit = function () {
        this.loadbdkstatistic();
    };
    //Подгрузка данных для БДК
    BdkIt.prototype.loadbdkstatistic = function () {
        var _this = this;
        try {
            this.dataservice.modelbdk(this.select.worksetting(this.setting)).subscribe(function (model) {
                _this.bdk = deserialize(ModelBdk, model.toString());
            });
        }
        catch (e) {
            console.log(e.toString());
        }
    };
    //Выполнение процедур для БДК
    BdkIt.prototype.storeprocedure = function (numprocedure, iduser, message) {
        var _this = this;
        if (this.setting.ParametrBdk.valid()) {
            switch (numprocedure) {
                case 1:
                    this.bloks.blockprocedure('анализу данных BDK');
                    break;
                case 2:
                    this.bloks.blockprocedure('созданию данных BDK');
                    break;
            }
            this.dataservice.startprocedurebdk(this.select.procedurebdk(numprocedure, iduser, message, this.select.worksetting(this.setting))).subscribe(function (model) {
                _this.bloks.blockprocedure(JSON.stringify(model));
                _this.loadbdkstatistic();
            });
        }
    };
    BdkIt = __decorate([
        Component(({
            selector: 'my-bdk',
            templateUrl: '../Template/Bdk.html',
            styleUrls: ['../Template/BdkStyle.css'],
            providers: [PostBdk]
        })),
        __metadata("design:paramtypes", [PostBdk])
    ], BdkIt);
    return BdkIt;
}());
export { BdkIt };
//# sourceMappingURL=Bdk.js.map