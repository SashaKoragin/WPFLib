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
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BroadcastEventListener } from 'ng2-signalr';
import { Kam5Report } from '../../../../PostZaprosFull/PostFull';
import { Parametr } from '../Model/ModelParametr';
import { ConvertDate } from '../../../../FullSetting/FormatDate';
import { ConnectionResolver } from '../../../../SignalRSignal/ConnectSignalR';
var validreport = function (control) {
    var qvartal = control.get('qvartal');
    var god = control.get('god');
    var reportvid = control.get('reportvid');
    var p1 = control.get('p1');
    var date = control.get('date');
    var errdetal = control.get('errdetal');
    return qvartal.value === null
        && god.value === null
        && reportvid.value === null
        && p1.value === null
        && date.value === null
        && errdetal.value === null ? { 'validator': true } : null;
};
var ReportKam5 = /** @class */ (function () {
    function ReportKam5(httpclient, signalR) {
        this.httpclient = httpclient;
        this.signalR = signalR;
        this.convertDate = new ConvertDate();
        this.onMessageSent = null;
        this.parametr = new Parametr();
        this.serverMessages = [];
        this.formtemplateReport = new FormGroup({
            'qvartal': new FormControl('', Validators.required),
            'god': new FormControl('', Validators.required),
            'reportvid': new FormControl('', Validators.required),
            'p1': new FormControl('', Validators.required),
            'date': new FormControl(new Date(), Validators.required),
            'errdetal': new FormControl('', Validators.required)
        }, { validators: validreport });
    }
    Object.defineProperty(ReportKam5.prototype, "qvartal", {
        get: function () { return this.formtemplateReport.get('qvartal'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ReportKam5.prototype, "god", {
        get: function () { return this.formtemplateReport.get('god'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ReportKam5.prototype, "reportvid", {
        get: function () { return this.formtemplateReport.get('reportvid'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ReportKam5.prototype, "p1", {
        get: function () { return this.formtemplateReport.get('p1'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ReportKam5.prototype, "date", {
        get: function () { return this.formtemplateReport.get('date'); },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ReportKam5.prototype, "errdetal", {
        get: function () { return this.formtemplateReport.get('errdetal'); },
        enumerable: false,
        configurable: true
    });
    ReportKam5.prototype.ngOnInit = function () {
        var _this = this;
        console.log('Запустили подпись на событие процедуры сервера!');
        this.onMessageSent = new BroadcastEventListener('SqlServer');
        this.signalR.conect.listen(this.onMessageSent);
        this.onMessageSent.subscribe(function (sendChatMessage) {
            _this.serverMessages.push(sendChatMessage);
        });
    };
    ReportKam5.prototype.reportstart = function (date) {
        this.serverMessages = [];
        this.signalR.user.Db = 'Work';
        this.signalR.user.ParamService.IdCommand = 28;
        this.parametr.createModelPost(this.signalR.user, this.convertDate.convertDateToServer(date));
        this.httpclient.reportFile(this.signalR.user);
        this.qvartal.reset();
        this.formtemplateReport.reset();
    };
    ReportKam5.prototype.ngOnDestroy = function () {
        this.onMessageSent = null;
    };
    ReportKam5 = __decorate([
        Component(({
            selector: 'reportkam5',
            templateUrl: '../Template/ReportKam5.html',
            styleUrls: ['../Template/ReportKam5.css'],
            providers: [Kam5Report]
        })),
        __metadata("design:paramtypes", [Kam5Report, ConnectionResolver])
    ], ReportKam5);
    return ReportKam5;
}());
export { ReportKam5 };
//# sourceMappingURL=Report.js.map