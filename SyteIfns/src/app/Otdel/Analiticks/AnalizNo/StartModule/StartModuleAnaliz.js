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
import { No } from '../Model/ModelAnaliz';
import { ServiceModel, PostBdk } from '../../../../PostZaprosFull/PostFull';
import { deserialize } from 'class-transformer';
import { LogicaAnaliz } from '../Model/LogicaAnalis';
import { MatPaginator } from '@angular/material';
import { LogicaParamGenerateParam } from '../../../../ModelService/ModelSelect';
import { ViewModelSelect } from '../../../../ModelService/ViewModelSelect';
import { MatDialog } from '@angular/material';
var AnalizNo = /** @class */ (function () {
    function AnalizNo(service, datekrsb, dialog) {
        this.service = service;
        this.datekrsb = datekrsb;
        this.dialog = dialog;
        this.selectingviewmodel = new ViewModelSelect();
        this.selectingmodel = new LogicaParamGenerateParam();
        this.logica = new LogicaAnaliz(this.datekrsb, this.service, this.selectingmodel, this.dialog);
    }
    AnalizNo.prototype.ngOnInit = function () {
        this.logica.servermodel();
    };
    AnalizNo.prototype.update = function () {
        var _this = this;
        try {
            if (this.selectingmodel.errorModel(this.selectingviewmodel.parametrdelo)) {
                this.logica.paramlogica.logicaselect(); //Закрываем логику выбора
                this.logica.paramlogica.logicaprogress(); //Открываем логику загрузки
                this.service.datacommandserver(this.selectingmodel.generatecommand(this.logica.wcf, this.selectingviewmodel.parametrdelo)).subscribe(function (model) {
                    _this.logica.no = deserialize(No, model.toString());
                    _this.logica.paramlogica.logicaprogress(); //Закрываем логику загрузки
                    _this.logica.paramlogica.logicadatabase(); //Открываем логику Данных
                    if (_this.logica.no != null) {
                        _this.logica.addtable(_this.logica.no);
                        _this.logica.table.dataSourceDeloNo.paginator = _this.paginatordataSource;
                        _this.logica.paramlogica.errornull = true;
                    }
                    else {
                        _this.logica.paramlogica.errornull = false;
                    }
                });
            }
            else {
                alert('Существуют ошибки в выборке!!!');
            }
        }
        catch (e) {
            alert(e.toString());
        }
    };
    AnalizNo.prototype.back = function (num) {
        switch (num) {
            case 1:
                this.logica.paramlogica.logicadatabase(); //Закрываем логику Данных
                this.logica.paramlogica.logicaselect(); //Открываем логику загрузки
                this.logica.table.selectAnalizNo = true;
                break;
        }
    };
    __decorate([
        ViewChild(MatPaginator),
        __metadata("design:type", MatPaginator)
    ], AnalizNo.prototype, "paginatordataSource", void 0);
    AnalizNo = __decorate([
        Component(({
            selector: 'AnalizNo',
            templateUrl: '../Template/AnalizNo.html',
            styleUrls: ['../Template/StyleAnaliz.css'],
            providers: [ServiceModel, PostBdk, MatDialog]
        })),
        __metadata("design:paramtypes", [ServiceModel, PostBdk, MatDialog])
    ], AnalizNo);
    return AnalizNo;
}());
export { AnalizNo };
//# sourceMappingURL=StartModuleAnaliz.js.map