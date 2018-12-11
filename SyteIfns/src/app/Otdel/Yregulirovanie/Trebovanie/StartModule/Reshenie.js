var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewChild } from '@angular/core';
import { GenerateParamService } from '../../../../FullSetting/CreateSetting';
import { PostTrebovanie, ServiceModel, DonloadFileReport } from '../../../../PostZaprosFull/PostFull';
import { CreateSettingSelect, DataBase } from '../../../../FullSetting/CreateSetting';
import { FullSetting } from '../../../../FullSetting/FullSetting';
import { SysNum, TableSysNumReshen } from '../Model/ModelSelect';
import { deserialize } from 'class-transformer';
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull';
import { DateModel } from '../../../../FullSetting/DateModelFull';
import { TableReshenia } from '../../../../FullSetting/SelectTable/TableGenerator';
import { ParamLogica } from '../../../../FullSetting/SelectTable/LogicaSelect';
import { ServiceWcf } from '../../../../ModelService/ModelService';
import { ParametrSelectMail } from '../../../../ModelService/SelectCommand';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { AdressMerge } from '../../../../AdressFullRest/AdresSservice';
import { DonloadFile } from '../../../../FullSetting/DonloadFileServer/DonloadFile';
var ReshenieStart = /** @class */ (function () {
    function ReshenieStart(dataservice, service, donloadreport) {
        this.dataservice = dataservice;
        this.service = service;
        this.donloadreport = donloadreport;
        this.wcf = null;
        this.table = new TableReshenia();
        this.paramlogica = new ParamLogica();
        this.selecting = new ParametrSelectMail();
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
        this.filters = new TableSysNumReshen();
        this.adress = new AdressMerge();
        this.donloadfile = new DonloadFile(this.donloadreport);
    }
    ReshenieStart.prototype.ngOnInit = function () {
        var _this = this;
        try {
            var generate = new GenerateParamService(1);
            this.service.modelservice(generate.setting).subscribe(function (model) {
                _this.wcf = deserialize(ServiceWcf, model.toString());
            });
        }
        catch (e) {
            alert(e.toString());
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
    ReshenieStart.prototype.returns = function () {
        this.mode = true;
    };
    ReshenieStart.prototype.update = function () {
        var _this = this;
        try {
            this.paramlogica.logicaselect(); //Закрываем логику выбора
            this.paramlogica.logicaprogress(); //Открываем логику загрузки
            this.service.datacommandserver(this.selecting.generatecommand(this.wcf, this.selecting.parametrreshen, this.database.db.num)).subscribe(function (model) {
                _this.reshenie = deserialize(SysNum, model.toString());
                _this.paramlogica.logicaprogress(); //Закрываем логику загрузки
                _this.paramlogica.logicadatabase(); //Открываем логику Данных
                if (_this.reshenie != null) {
                    _this.table.dataSource = new MatTableDataSource(_this.reshenie.TableSysNumReshen);
                    _this.table.dataSource.paginator = _this.paginatordataSource;
                    _this.paramlogica.errornull = true;
                }
                else {
                    _this.paramlogica.errornull = false;
                }
            });
        }
        catch (e) {
            alert(e.toString());
        }
    };
    ReshenieStart.prototype.detaliz = function (reshen) {
        var res;
        res = [reshen];
        this.paramlogica.logicadatabase(); //Закрываем логику Данных
        this.paramlogica.detalization(); //Открываем детализацию
        this.table.dataSourceDetalSysNum = new MatTableDataSource(res);
        this.table.dataSourceDetalIncass = new MatTableDataSource(res[0].Incass);
    };
    ReshenieStart.prototype.back = function (num) {
        switch (num) {
            case 1:
                this.paramlogica.logicadatabase(); //Закрываем логику Данных
                this.paramlogica.logicaselect(); //Открываем логику загрузки
                break;
            case 2:
                this.paramlogica.logicadatabase(); //Открываем логику Данных
                this.paramlogica.detalization(); //Закрываем детализацию
                break;
        }
    };
    __decorate([
        ViewChild(MatPaginator),
        __metadata("design:type", MatPaginator)
    ], ReshenieStart.prototype, "paginatordataSource", void 0);
    ReshenieStart = __decorate([
        Component(({
            selector: 'my-treb',
            templateUrl: '../Template/Reshenie.html',
            styleUrls: ['../Template/Style.css'],
            providers: [PostTrebovanie, ServiceModel, DonloadFileReport]
        })),
        __metadata("design:paramtypes", [PostTrebovanie, ServiceModel, DonloadFileReport])
    ], ReshenieStart);
    return ReshenieStart;
}());
export { ReshenieStart };
//# sourceMappingURL=Reshenie.js.map