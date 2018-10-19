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
import { ModelFull } from '../Model/ModelTemplate';
import { LogicaTemplate } from '../Model/Tables';
import { ServiceWcf } from '../../../../ModelService/ModelService';
import { GenerateParamService } from '../../../../FullSetting/CreateSetting';
import { TemplateAdd, ServiceModel } from '../../../../PostZaprosFull/PostFull';
import { deserialize } from 'class-transformer';
import { ParametrSelectMail } from '../../../../ModelService/SelectCommand';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { TableTemplate } from '../../../../FullSetting/SelectTable/TableGenerator';
import { ControlTemplate } from '../../../../FullSetting/FormValidation/FormValidation';
import { MatDialog } from '@angular/material';
var AddTemplate = /** @class */ (function () {
    function AddTemplate(service, dialog, addtemp) {
        this.service = service;
        this.dialog = dialog;
        this.addtemp = addtemp;
        this.logica = new LogicaTemplate();
        this.modelfull = null;
        this.wcf = null;
        this.select = new ParametrSelectMail();
        this.template = new TableTemplate();
        this.form = new ControlTemplate(this, this.dialog, this.addtemp);
    }
    AddTemplate.prototype.ngOnInit = function () {
        var _this = this;
        try {
            var generate = new GenerateParamService(13);
            this.service.modelservice(generate.setting).subscribe(function (model) {
                _this.wcf = deserialize(ServiceWcf, model.toString());
                _this.fullTemplate();
            });
        }
        catch (e) {
            alert(e.toString());
        }
    };
    AddTemplate.prototype.fullTemplate = function () {
        var _this = this;
        this.service.datacommandserver(this.select.generatecommandnotparam(this.wcf)).subscribe(function (model) {
            _this.modelfull = deserialize(ModelFull, model.toString());
            _this.template.dataSource = new MatTableDataSource(_this.modelfull.NameDocument);
            _this.template.dataSource.paginator = _this.paginatordataSource;
            _this.template.dataSourceBody = new MatTableDataSource(_this.modelfull.Body);
            _this.template.dataSourceHeaders = new MatTableDataSource(_this.modelfull.Headers);
            _this.template.dataSourceStone = new MatTableDataSource(_this.modelfull.Stone);
        });
    };
    AddTemplate.prototype.addtemplate = function () {
        alert(JSON.stringify(this.form.document));
        this.addtemp.addtemplate(this.form.document).subscribe(function (model) {
            alert(JSON.stringify(model));
        });
    };
    __decorate([
        ViewChild(MatPaginator),
        __metadata("design:type", MatPaginator)
    ], AddTemplate.prototype, "paginatordataSource", void 0);
    AddTemplate = __decorate([
        Component(({
            selector: 'add-template',
            templateUrl: '../Template/AddTemplate.html',
            styleUrls: ['../Template/AddTemplate.css'],
            providers: [ServiceModel, TemplateAdd, MatDialog]
        })),
        __metadata("design:paramtypes", [ServiceModel, MatDialog, TemplateAdd])
    ], AddTemplate);
    return AddTemplate;
}());
export { AddTemplate };
//# sourceMappingURL=AddTemplate.js.map