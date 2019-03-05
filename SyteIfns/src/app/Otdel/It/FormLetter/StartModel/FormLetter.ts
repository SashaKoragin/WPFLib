import { Component, OnInit, ViewChild } from '@angular/core';
import { LetterForm, ServiceModel } from '../../../../PostZaprosFull/PostFull';
import { FullSetting } from '../../../../FullSetting/FullSetting';
import { GenerateParamService } from '../../../../FullSetting/CreateSetting';
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull';
import { DateModel } from '../../../../FullSetting/DateModelFull';
import { ParametrSelectMail } from '../../../../ModelService/SelectCommand';
import { Mail, WordDocument, UseTableTemplateBdk } from '../Model/ModelDataBase/ModelMail';
import { ServiceWcf, AngularModelFileDonload } from '../../../../ModelService/ModelService';
import { deserialize } from 'class-transformer';
import { TableLetter } from '../../../../FullSetting/SelectTable/TableGenerator'
import { ParamLogica } from '../../../../FullSetting/SelectTable/LogicaSelect'
import { MatTableDataSource, MatPaginator } from '@angular/material';


@Component(({
    selector: 'my-letter',
    templateUrl: '../Template/FormLetter.html',
    styleUrls: ['../Template/FormLetter.css'],
    providers: [LetterForm, ServiceModel]
}) as any)

export class BdkLetter implements OnInit {
    mail:Mail = null;
    wcf: ServiceWcf = null;
    bloks: BlocsInfoButton = new BlocsInfoButton();
    setting: FullSetting = new FullSetting();
    date: DateModel = new DateModel();
    paramlogica: ParamLogica = new ParamLogica();
    @ViewChild(MatPaginator) paginatordataSource: MatPaginator;
    //Для подстановки
    select: ParametrSelectMail = new ParametrSelectMail();
    table: TableLetter = new TableLetter();
    constructor(private dateservice: LetterForm, private service: ServiceModel) { }

    ngOnInit(): void {
        try {
            var generate = new GenerateParamService(12);
            this.service.modelservice(generate.setting).subscribe((model) => {
                this.wcf = deserialize(ServiceWcf, model.toString());
            });
        } catch (e) {
            alert(e.toString());
        }
    }

    startreport(dateStart: any, dateFinis: any) {
        this.bloks.serverrestmessage(null);
        this.setting.UseTemplate.IdTemplate = 1;
        if (this.date.valid()) {
            this.date.convertdate(this.setting, dateStart, dateFinis);
            this.dateservice.modelbdk(this.setting).subscribe(
                (model) => {
                    this.bloks.serverrestmessage(JSON.stringify(model));
                });
        }
    }

    update() {
        this.paramlogica.logicaselect(); //Закрываем логику выбора
        this.paramlogica.logicaprogress();  //Открываем логику загрузки
        this.service.datacommandserver(this.select.generatecommand(this.wcf, this.select.parametrmail)).subscribe((model) => {
            this.mail = deserialize(Mail, model.toString());
            this.paramlogica.logicaprogress(); //Закрываем логику загрузки
            this.paramlogica.logicadatabase(); //Открываем логику Данных
            if (this.mail != null) {
                this.table.dataSource = new MatTableDataSource<WordDocument>(this.mail.WordDocument);
                this.table.dataSource.paginator = this.paginatordataSource;
                this.paramlogica.errornull = true;
            } else {
                this.paramlogica.errornull = false;
            }
        });
    }

    back(num: number) {
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
    }

    detal(detal: UseTableTemplateBdk[]) {
        this.paramlogica.logicadatabase(); //Закрываем логику Данных
        this.paramlogica.detalization();   //Открываем детализацию
        this.table.dataSourceDetal = new MatTableDataSource<UseTableTemplateBdk>(detal);
    }

    donload(file: WordDocument) {
       var files = new AngularModelFileDonload();
        files.Guid = file.Numerdocument;
        files.Id = 1;
        files.Name = file.Namefile;
        try {
        this.service.downloadFile(files).subscribe(data => {
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
        } catch (e) {
            alert(e.toString());
        }
    }
}
