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
import { ServiceModel, PostSoprovod, DonloadFileReport } from '../../../../PostZaprosFull/PostFull';
import { GenerateParamService } from '../../../../FullSetting/CreateSetting';
import { AdressMerge } from '../../../../AdressFullRest/AdresSservice';
import { DonloadFile } from '../../../../FullSetting/DonloadFileServer/DonloadFile';
import { ServiceWcf } from '../../../../ModelService/ModelService';
import { deserialize } from 'class-transformer';
import { FullSetting } from '../../../../FullSetting/FullSetting';
import { CreateSettingSelect } from '../../../../FullSetting/CreateSetting';
import { Soprovod } from '../Model/Model';
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull';
import { ParametrSelectMail } from '../../../../ModelService/SelectCommand';
import { ParamLogica } from '../../../../FullSetting/SelectTable/LogicaSelect';
import { PredproverkaTable } from '../../../../FullSetting/SelectTable/TableGenerator';
import { MatTableDataSource, MatPaginator } from '@angular/material';
var Predproverka = /** @class */ (function () {
    function Predproverka(dataservice, service, donloadreport) {
        this.dataservice = dataservice;
        this.service = service;
        this.donloadreport = donloadreport;
        this.status = new BlocsInfoButton();
        this.select = new CreateSettingSelect();
        this.predproverkatable = new PredproverkaTable();
        this.wcf = null;
        this.adress = new AdressMerge();
        this.soprovod = null;
        this.setting = new FullSetting();
        this.paramlogica = new ParamLogica();
        this.selecting = new ParametrSelectMail();
        this.donloadfile = new DonloadFile(this.donloadreport);
    }
    Predproverka.prototype.ngOnInit = function () {
        var _this = this;
        try {
            var generate = new GenerateParamService(14);
            this.service.modelservice(generate.setting).subscribe(function (model) {
                _this.wcf = deserialize(ServiceWcf, model.toString());
            });
        }
        catch (e) {
            alert(e.toString());
        }
    };
    Predproverka.prototype.startprocedurepred = function (index) {
        var _this = this;
        var setting1 = this.select.workandtest(2, this.setting);
        setting1.ParamPredproverka.N441 = this.setting.ParamPredproverka.N441;
        setting1.Id = index;
        switch (index) {
            case 1:
                this.dataservice.procedurestart(setting1).subscribe(function (model) {
                    _this.status.messagestatus = JSON.stringify(model);
                });
                break;
            case 2:
                setting1.ParamPredproverka.N441 = 0;
                this.status.blockprocedure('выстановлению статусов');
                this.dataservice.procedurestart(setting1).subscribe(function (model) {
                    _this.status.blockprocedure(JSON.stringify(model));
                });
                break;
            case 3:
                setting1.ParamPredproverka.N441 = 0;
                this.status.blockprocedure('созданию документа');
                this.dataservice.procedurestart(setting1).subscribe(function (model) {
                    _this.status.blockprocedure(JSON.stringify(model));
                });
                break;
        }
    };
    Predproverka.prototype.update = function () {
        var _this = this;
        try {
            this.paramlogica.logicaselect(); //Закрываем логику выбора
            this.paramlogica.logicaprogress(); //Открываем логику загрузки
            this.service.datacommandserver(this.selecting.generatecommand(this.wcf, this.selecting.paramepredproverka)).subscribe(function (model) {
                _this.soprovod = deserialize(Soprovod, model.toString());
                _this.paramlogica.logicaprogress(); //Закрываем логику загрузки
                _this.paramlogica.logicadatabase(); //Открываем логику Данных
                if (_this.soprovod != null) {
                    _this.predproverkatable.dataSourceDocumentReglament =
                        new MatTableDataSource(_this.soprovod.DocumentReglament);
                    _this.predproverkatable.dataSourceDocumentReglament.paginator = _this.paginatordataSource;
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
    Predproverka.prototype.detaliz = function (detalization) {
        var detal;
        detal = [detalization];
        this.paramlogica.logicadatabase(); //Закрываем логику Данных
        this.paramlogica.detalization(); //Открываем детализацию
        this.predproverkatable.dataSourceDocumentDetalization = new MatTableDataSource(detal);
    };
    Predproverka.prototype.back = function (num) {
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
    ], Predproverka.prototype, "paginatordataSource", void 0);
    Predproverka = __decorate([
        Component(({
            selector: 'soprovod',
            templateUrl: '../Template/Predproverka.html',
            styleUrls: ['../Template/Style.css'],
            providers: [PostSoprovod, ServiceModel, DonloadFileReport]
        })),
        __metadata("design:paramtypes", [PostSoprovod, ServiceModel, DonloadFileReport])
    ], Predproverka);
    return Predproverka;
}());
export { Predproverka };
//# sourceMappingURL=Predproverka.js.map