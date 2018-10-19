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
import { LetterForm, ServiceModel } from '../../../../PostZaprosFull/PostFull';
import { FullSetting } from '../../../../FullSetting/FullSetting';
import { GenerateParamService } from '../../../../FullSetting/CreateSetting';
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull';
import { DateModel } from '../../../../FullSetting/DateModelFull';
import { ParametrSelectMail } from '../../../../ModelService/SelectCommand';
import { Mail } from '../Model/ModelDataBase/ModelMail';
import { ServiceWcf, AngularModelFileDonload } from '../../../../ModelService/ModelService';
import { deserialize } from 'class-transformer';
import { TableLetter } from '../../../../FullSetting/SelectTable/TableGenerator';
import { ParamLogica } from '../../../../FullSetting/SelectTable/LogicaSelect';
import { MatTableDataSource, MatPaginator } from '@angular/material';
var BdkLetter = /** @class */ (function () {
    function BdkLetter(dateservice, service) {
        this.dateservice = dateservice;
        this.service = service;
        this.mail = null;
        this.wcf = null;
        this.bloks = new BlocsInfoButton();
        this.setting = new FullSetting();
        this.date = new DateModel();
        this.paramlogica = new ParamLogica();
        //Для подстановки
        this.select = new ParametrSelectMail();
        this.table = new TableLetter();
    }
    BdkLetter.prototype.ngOnInit = function () {
        var _this = this;
        try {
            var generate = new GenerateParamService(12);
            this.service.modelservice(generate.setting).subscribe(function (model) {
                _this.wcf = deserialize(ServiceWcf, model.toString());
            });
        }
        catch (e) {
            alert(e.toString());
        }
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
    BdkLetter.prototype.update = function () {
        var _this = this;
        this.paramlogica.logicaselect(); //Закрываем логику выбора
        this.paramlogica.logicaprogress(); //Открываем логику загрузки
        this.service.datacommandserver(this.select.generatecommand(this.wcf, this.select.parametrmail)).subscribe(function (model) {
            _this.mail = deserialize(Mail, model.toString());
            _this.paramlogica.logicaprogress(); //Закрываем логику загрузки
            _this.paramlogica.logicadatabase(); //Открываем логику Данных
            if (_this.mail != null) {
                _this.table.dataSource = new MatTableDataSource(_this.mail.WordDocument);
                _this.table.dataSource.paginator = _this.paginatordataSource;
                _this.paramlogica.errornull = true;
            }
            else {
                _this.paramlogica.errornull = false;
            }
        });
    };
    BdkLetter.prototype.back = function (num) {
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
    BdkLetter.prototype.detal = function (detal) {
        this.paramlogica.logicadatabase(); //Закрываем логику Данных
        this.paramlogica.detalization(); //Открываем детализацию
        this.table.dataSourceDetal = new MatTableDataSource(detal);
    };
    BdkLetter.prototype.donload = function (file) {
        var files = new AngularModelFileDonload();
        files.Guid = file.Numerdocument;
        files.Id = 1;
        files.Name = file.Namefile;
        try {
            this.service.downloadFile(files).subscribe(function (data) {
                var blob = new Blob([data], { type: 'application/octet-stream' });
                var url = window.URL.createObjectURL(blob);
                var a = document.createElement('a');
                a.href = url;
                a.download = file.Namefile;
                document.body.appendChild(a);
                a.click();
                document.body.removeChild(a);
                window.URL.revokeObjectURL(url);
            });
        }
        catch (e) {
            alert(e.toString());
        }
    };
    __decorate([
        ViewChild(MatPaginator),
        __metadata("design:type", MatPaginator)
    ], BdkLetter.prototype, "paginatordataSource", void 0);
    BdkLetter = __decorate([
        Component(({
            selector: 'my-letter',
            templateUrl: '../Template/FormLetter.html',
            styleUrls: ['../Template/FormLetter.css'],
            providers: [LetterForm, ServiceModel]
        })),
        __metadata("design:paramtypes", [LetterForm, ServiceModel])
    ], BdkLetter);
    return BdkLetter;
}());
export { BdkLetter };
//# sourceMappingURL=FormLetter.js.map