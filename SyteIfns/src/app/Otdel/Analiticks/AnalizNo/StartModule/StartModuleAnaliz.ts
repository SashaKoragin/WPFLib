import { Component, OnInit, ViewChild } from '@angular/core';
import { No } from '../Model/ModelAnaliz';
import { AngularModel } from '../../../../ModelService/ModelService';
import { ServiceModel, PostBdk } from '../../../../PostZaprosFull/PostFull';
import { GenerateParamService } from '../../../../FullSetting/CreateSetting';
import { plainToClass, deserialize } from 'class-transformer';
import { ParametrSelectMail } from '../../../../ModelService/SelectCommand';
import { LogicaAnaliz } from '../Model/LogicaAnalis';
import { MatPaginator } from '@angular/material';
import { LogicaParamGenerateParam } from '../../../../ModelService/ModelSelect';
import { ViewModelSelect } from '../../../../ModelService/ViewModelSelect';
import { MatDialog } from '@angular/material';
@Component(({
    selector: 'AnalizNo',
    templateUrl: '../Template/AnalizNo.html',
    styleUrls: ['../Template/StyleAnaliz.css'],
    providers: [ServiceModel, PostBdk, MatDialog]
}) as any)
export class AnalizNo implements OnInit {
    constructor(public service: ServiceModel, public datekrsb: PostBdk, public dialog: MatDialog) { }
    @ViewChild(MatPaginator) paginatordataSource: MatPaginator;
    selectingviewmodel: ViewModelSelect = new ViewModelSelect();
    selectingmodel: LogicaParamGenerateParam = new LogicaParamGenerateParam();
    logica: LogicaAnaliz = new LogicaAnaliz(this.datekrsb,
                                            this.service,
        this.selectingmodel,
                                            this.dialog
    );
    ngOnInit(): void {
      this.logica.servermodel();
    }


    update() {
        try {
            if (this.selectingmodel.errorModel(this.selectingviewmodel.parametrdelo)) {
                this.logica.paramlogica.logicaselect(); //Закрываем логику выбора
                this.logica.paramlogica.logicaprogress();  //Открываем логику загрузки
                this.service.datacommandserver(
                    this.selectingmodel.generatecommand(
                        this.logica.wcf,
                        this.selectingviewmodel.parametrdelo)).subscribe((model) => {
                    this.logica.no = deserialize(No, model.toString());
                    this.logica.paramlogica.logicaprogress(); //Закрываем логику загрузки
                    this.logica.paramlogica.logicadatabase(); //Открываем логику Данных
                    if (this.logica.no != null) {
                        this.logica.addtable(this.logica.no);
                        this.logica.table.dataSourceDeloNo.paginator = this.paginatordataSource;
                        this.logica.paramlogica.errornull = true;
                    } else {
                        this.logica.paramlogica.errornull = false;
                    }
                });
            } else {
                alert('Существуют ошибки в выборке!!!');
            }
        } catch (e) {
            alert(e.toString());
        }
    }

    back(num: number) {
        switch (num) {
            case 1:
                this.logica.paramlogica.logicadatabase(); //Закрываем логику Данных
                this.logica.paramlogica.logicaselect(); //Открываем логику загрузки
                this.logica.table.selectAnalizNo = true;
                break;
        }
    }
}