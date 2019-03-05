import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors} from '@angular/forms'
import { BroadcastEventListener } from 'ng2-signalr';
import { Kam5Report } from '../../../../PostZaprosFull/PostFull';
import { Parametr } from '../Model/ModelParametr';
import { ConvertDate } from '../../../../FullSetting/FormatDate';
import { ConnectionResolver } from '../../../../SignalRSignal/ConnectSignalR';

const validreport: ValidatorFn = (control: FormGroup):
    ValidationErrors => {
    const qvartal = control.get('qvartal');
    const god = control.get('god');
    const reportvid = control.get('reportvid');
    const p1 = control.get('p1');
    const date = control.get('date');
    const errdetal = control.get('errdetal');
    return qvartal.value === null
        && god.value === null
        && reportvid.value === null
        && p1.value === null
        && date.value === null
        && errdetal.value === null ? { 'validator': true } : null;
    };


@Component(({
    selector: 'reportkam5',
    templateUrl: '../Template/ReportKam5.html',
    styleUrls: ['../Template/ReportKam5.css'],
    providers: [Kam5Report]
}))
export class ReportKam5 implements OnInit, OnDestroy {

    constructor(public httpclient: Kam5Report, public signalR: ConnectionResolver ) { }

    convertDate: ConvertDate = new ConvertDate();
    public onMessageSent = null;
    parametr: Parametr = new Parametr();
    public serverMessages: string[] = [];

    formtemplateReport = new FormGroup({
            'qvartal': new FormControl('', Validators.required),
            'god': new FormControl('', Validators.required),
            'reportvid': new FormControl('', Validators.required),
            'p1': new FormControl('', Validators.required),
            'date': new FormControl(new Date(), Validators.required),
            'errdetal': new FormControl('', Validators.required)
        },
        { validators: validreport });

    get qvartal() { return this.formtemplateReport.get('qvartal') }

    get god() { return this.formtemplateReport.get('god') }

    get reportvid() { return this.formtemplateReport.get('reportvid') }

    get p1() { return this.formtemplateReport.get('p1') }

    get date() { return this.formtemplateReport.get('date') }

    get errdetal() { return this.formtemplateReport.get('errdetal') }

    ngOnInit(): void {
        console.log('Запустили подпись на событие процедуры сервера!');
        this.onMessageSent = new BroadcastEventListener<string>('SqlServer');
        this.signalR.conect.listen(this.onMessageSent);
        this.onMessageSent.subscribe((sendChatMessage: string) => {
           this.serverMessages.push(sendChatMessage);
        });
    }

    reportstart(date: any) {
        this.serverMessages = [];
        this.signalR.user.Db = 'Work';
        this.signalR.user.ParamService.IdCommand = 28;
        this.parametr.createModelPost(this.signalR.user, this.convertDate.convertDateToServer(date));
        this.httpclient.reportFile(this.signalR.user).subscribe(data => {
            var blob = new Blob([data], { type: 'application/octet-stream' });
            var url = window.URL.createObjectURL(blob);
            var a = document.createElement('a');
            a.href = url;
            a.download = 'Отчет.xlsx';
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
        });
        this.qvartal.reset();
    }

    ngOnDestroy(): void {
        
        this.onMessageSent = null;
    }
}