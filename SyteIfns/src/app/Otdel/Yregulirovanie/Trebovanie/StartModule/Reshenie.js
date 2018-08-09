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
import { CreateSettingSelect, DataBase } from '../../../../FullSetting/CreateSetting';
import { FullSetting } from '../../../../FullSetting/FullSetting';
import { SysNum, TableSysNumReshen } from '../Model/ModelSelect';
import { deserialize } from "class-transformer";
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull';
import { DateModel } from '../../../../FullSetting/DateModelFull';
var ReshenieStart = /** @class */ (function () {
    function ReshenieStart(dataservice) {
        this.dataservice = dataservice;
        this.date = new DateModel();
        this.status = new BlocsInfoButton();
        this.database = new DataBase();
        this.setting = new FullSetting();
        this.select = new CreateSettingSelect();
        this.reshenie = null;
        this.mode = true;
        this.resheniedetal = null;
        this.incass = null;
        this.errornull = true;
        this.limit = 100;
        this.page = 1;
        this.filters = new TableSysNumReshen();
    }
    ReshenieStart.prototype.ngOnInit = function () {
    };
    //Основная функция загрузки данных
    ReshenieStart.prototype.loadswith = function (num, dateStart, dateFinis) {
        var _this = this;
        try {
            if (this.date.valid()) {
                this.date.convertdateresh(this.setting, dateStart, dateFinis);
                this.dataservice.modelreshenie(this.select.workandtest(num, this.setting)).subscribe(function (model) {
                    _this.reshenie = deserialize(SysNum, model.toString());
                    if (_this.reshenie != null) {
                        _this.errornull = true;
                    }
                    else {
                        _this.errornull = false;
                    }
                });
            }
        }
        catch (e) {
            console.log(e.toString());
        }
    };
    //Переключатель загрузки Test Work
    ReshenieStart.prototype.swithdb = function (num, dateStart, dateFinis) {
        switch (num) {
            case 1:
                this.loadswith(num, dateStart, dateFinis);
            case 2:
                this.loadswith(num, dateStart, dateFinis);
        }
    };
    //Выполнение процедуры
    ReshenieStart.prototype.storeprocedurestart = function (index, resh) {
        var _this = this;
        if (resh === void 0) { resh = 0; }
        switch (index) {
            case 1:
                var setting1 = this.select.createaddresh(resh, this.select.workandtest(this.database.db.num, this.setting));
                this.dataservice.procedurestart(setting1).subscribe(function (model) {
                    _this.status.messagestatus = JSON.stringify(model);
                    _this.setting.ParametrReshen.D270 = 0;
                });
                break;
            case 2:
                this.status.blockbuttonreshen();
                this.setting.ParametrReshen.D270 = 0;
                var setting2 = this.select.createstartresh(resh, this.select.workandtest(this.database.db.num, this.setting));
                this.dataservice.procedurestart(setting2).subscribe(function (model) {
                    _this.status.blockbuttonreshen(JSON.stringify(model));
                });
                break;
            case 3:
                this.status.blockbuttonincass();
                this.setting.ParametrReshen.D270 = 0;
                var setting3 = this.select.createstartincass(resh, this.select.workandtest(this.database.db.num, this.setting));
                this.dataservice.procedurestart(setting3).subscribe(function (model) {
                    _this.status.blockbuttonincass(JSON.stringify(model));
                });
                break;
        }
    };
    ReshenieStart.prototype.detal = function (reshenie) {
        this.mode = false;
        this.resheniedetal = reshenie.Reshenie;
        this.incass = reshenie.Reshenie.Incass;
    };
    ReshenieStart.prototype.returns = function () {
        this.mode = true;
    };
    ReshenieStart = __decorate([
        Component(({
            selector: 'my-treb',
            templateUrl: '../Template/Reshenie.html',
            styleUrls: ['../Template/Style.css'],
            providers: [PostTrebovanie]
        })),
        __metadata("design:paramtypes", [PostTrebovanie])
    ], ReshenieStart);
    return ReshenieStart;
}());
export { ReshenieStart };
//# sourceMappingURL=Reshenie.js.map