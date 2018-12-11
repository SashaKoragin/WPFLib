import { Component, OnInit, ViewEncapsulation, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';
import { PostBdk, ServiceModel} from '../../../../PostZaprosFull/PostFull'
import { GenerateParamService, CreateSettingSelect } from '../../../../FullSetting/CreateSetting';
import { DateModel } from '../../../../FullSetting/DateModelFull';
import { ServiceWcf } from '../../../../ModelService/ModelService';
import { NoAnalizTable } from '../../../../FullSetting/SelectTable/TableGenerator';
import { No } from './ModelAnaliz';
import { ParametrSelectMail } from '../../../../ModelService/SelectCommand';
import { plainToClass, deserialize } from 'class-transformer';
import { ParamLogica } from '../../../../FullSetting/SelectTable/LogicaSelect';
import { LogicaSelecting } from './AnalizZapros';
import { validatorDate, forbiddenNameValidator } from '../../../../FullSetting/FunctionValidation';
import { LogicaParamGenerateParam } from '../../../../ModelService/ModelSelect';
import { DialogOpenAddOkato } from '../../../../FullSetting/FormValidation/OpenDialog/OpenDialog';
import { MatDialog } from '@angular/material';
export class LogicaAnaliz {
    no: No = null;
    wcf: ServiceWcf = null;
    table: NoAnalizTable = new NoAnalizTable();
    paramlogica: ParamLogica = new ParamLogica();
    constructor(public datekrsb: PostBdk, private service: ServiceModel, private select: LogicaParamGenerateParam, public dialog: MatDialog ) { }
    messageserver: string = null;
    logicaSelecting: LogicaSelecting = new LogicaSelecting();
    opendialog: DialogOpenAddOkato = new DialogOpenAddOkato(this.dialog, this.datekrsb);
    dateCreate = new FormGroup({
        'dateCreate': new FormControl('',
            [Validators.required, validatorDate()])
    });

    idCreate = new FormGroup({
        'id': new FormControl('',
            [Validators.required, forbiddenNameValidator(/^((\d{4,6}\/{1})+(\d{4,6})|(\d{4,6}))$/)])
    });

    get createDate() { return this.dateCreate.get('dateCreate'); }

    get id() { return this.idCreate.get('id'); }

    servermodel() {
        try {
            var generate = new GenerateParamService(21);
            this.service.modelservice(generate.setting).subscribe((model) => {
                this.wcf = deserialize(ServiceWcf, model.toString());
            });
        } catch (e) {
            alert(e.toString());
        }
    }

    addtable(no: No) {
        this.table.addTableDelo(no.Delo);
    }
    ///Главная функция анализа по значениям и по дате
    analiz(num: number) {
        try {
        this.messageserver = null;
        var setting = new GenerateParamService(num); //Номер это какая процедура выполняется
        var createdb = new CreateSettingSelect().worksetting(setting.setting); //Установка рабочей БД
       // alert(this.createDate.value + 'Дата приема');
       // alert(this.id.value + 'Дела приема');
        if (this.createDate.value === '') {
            createdb.DeloPriem.addarraystring(this.id.value.split(/\//));
        } else {
            createdb.DeloCreate.datezaprosa(this.createDate.value);
        }
       // alert(JSON.stringify(createdb));
        this.datekrsb.analizkrsb(createdb).subscribe((model) => {
            this.messageserver = JSON.stringify(model);
            });
        } catch (e) {
            alert(e.toString());
        }
    }

    updatemodel() {
        this.service.datacommandserver(this.select.modelCommandServer).subscribe((model) => {
                    this.no = deserialize(No, model.toString());
                    if (this.no != null) {
                        this.addtable(this.no);
                        this.table.addTableAnaliz(null);
                        this.paramlogica.errornull = true;
                    } else {
                        this.table.addTableAnaliz(null);
                        this.paramlogica.errornull = false;
                    }
        });
    }

    startprocedure(numDelo: number, num: number) {
        this.messageserver = null;
        var setting = new GenerateParamService(num);
        var createdb = new CreateSettingSelect().worksetting(setting.setting);
        createdb.DeloCreate.D3979 = numDelo;
        this.datekrsb.analizkrsb(createdb).subscribe((model) => {
            this.messageserver = JSON.stringify(model);
            this.updatemodel();
        });
    }
}