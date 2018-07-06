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
import { Setting } from '../Model/ModelReshenie';
import { SysNum, TableSysNumReshenField } from '../Model/ModelSelect';
import { CreateSettingSelect } from '../LogicaSetting/CreateSettingSelect';
import { deserialize } from "class-transformer";
import { BlocsInfoButton } from '../Model/Process';
var ReshenieStart = /** @class */ (function () {
    function ReshenieStart(dataservice) {
        this.dataservice = dataservice;
        this.status = new BlocsInfoButton();
        this.db = 'Тест';
        this.setting = new Setting();
        this.select = new CreateSettingSelect();
        this.reshenie = null;
        this.mode = true;
        this.num = 1;
        this.resheniedetal = null;
        this.incass = null;
        this.limit = 100;
        this.page = 1;
        this.filters = new TableSysNumReshenField();
    }
    ReshenieStart.prototype.ngOnInit = function () {
        this.loadswith(this.num);
    };
    //Основная функция загрузки данных
    ReshenieStart.prototype.loadswith = function (num) {
        var _this = this;
        try {
            this.dataservice.modelreshenie(this.select.workandtest(num, this.setting)).subscribe(function (model) {
                _this.reshenie = deserialize(SysNum, model.toString());
            });
        }
        catch (e) {
            console.log(e.toString());
        }
    };
    //Переключатель загрузки Test Work
    ReshenieStart.prototype.swithdb = function () {
        if (this.num === 1) {
            this.num = 2;
            this.db = 'Рабочая';
        }
        else {
            this.num = 1;
            this.db = 'Тест';
        }
        switch (this.num) {
            case 1:
                this.loadswith(this.num);
            case 2:
                this.loadswith(this.num);
        }
    };
    //Выполнение процедуры
    ReshenieStart.prototype.storeprocedurestart = function (index, resh) {
        var _this = this;
        if (resh === void 0) { resh = 0; }
        switch (index) {
            case 1:
                var setting1 = this.select.createaddresh(resh, this.select.workandtest(this.num, this.setting));
                this.dataservice.procedurestart(setting1).subscribe(function (model) {
                    _this.status.messagestatus = JSON.stringify(model);
                    _this.loadswith(_this.num);
                    _this.setting.ParametrSelect.D270 = 0;
                });
                break;
            case 2:
                this.status.blockbuttonreshen();
                var setting2 = this.select.createstartresh(resh, this.select.workandtest(this.num, this.setting));
                this.dataservice.procedurestart(setting2).subscribe(function (model) {
                    _this.status.blockbuttonreshen(JSON.stringify(model));
                });
                break;
            case 3:
                this.status.blockbuttonincass();
                var setting3 = this.select.createstartincass(resh, this.select.workandtest(this.num, this.setting));
                this.dataservice.procedurestart(setting3).subscribe(function (model) {
                    _this.status.blockbuttonincass(JSON.stringify(model));
                });
                break;
        }
    };
    ReshenieStart.prototype.detal = function (reshenie) {
        this.mode = false;
        this.resheniedetal = reshenie.reshenieField;
        this.incass = reshenie.reshenieField.incassField;
    };
    ReshenieStart.prototype.returns = function () {
        this.mode = true;
    };
    ReshenieStart = __decorate([
        Component({
            selector: 'my-treb',
            templateUrl: '../Template/Reshenie.html',
            styleUrls: ['../Template/Style.css'],
            providers: [PostTrebovanie]
        }),
        __metadata("design:paramtypes", [PostTrebovanie])
    ], ReshenieStart);
    return ReshenieStart;
}());
export { ReshenieStart };
//# sourceMappingURL=Reshenie.js.map