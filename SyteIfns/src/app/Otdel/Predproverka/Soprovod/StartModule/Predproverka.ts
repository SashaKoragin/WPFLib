import { Component, OnInit, ViewChild } from '@angular/core';
import { ServiceModel, PostSoprovod, DonloadFileReport } from '../../../../PostZaprosFull/PostFull';
import { GenerateParamService } from '../../../../FullSetting/CreateSetting';
import { AdressMerge } from '../../../../AdressFullRest/AdresSservice';
import { DonloadFile } from '../../../../FullSetting/DonloadFileServer/DonloadFile';
import { ServiceWcf }  from '../../../../ModelService/ModelService';
import { deserialize } from 'class-transformer';
import { FullSetting } from '../../../../FullSetting/FullSetting';
import { CreateSettingSelect } from '../../../../FullSetting/CreateSetting';
import { Soprovod,DocumentDetalization,DocumentReglament } from '../Model/Model'
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull';
import { ParametrSelectMail } from '../../../../ModelService/SelectCommand';
import { ParamLogica } from '../../../../FullSetting/SelectTable/LogicaSelect';
import { PredproverkaTable } from '../../../../FullSetting/SelectTable/TableGenerator';
import { MatTableDataSource, MatPaginator } from '@angular/material';

@Component(({
    selector: 'soprovod',
    templateUrl: '../Template/Predproverka.html',
    styleUrls: ['../Template/Style.css'],
    providers: [PostSoprovod, ServiceModel, DonloadFileReport]
}) as any)

export class Predproverka implements OnInit {
    constructor(private dataservice: PostSoprovod, private service: ServiceModel, public donloadreport: DonloadFileReport) { }
    status: BlocsInfoButton = new BlocsInfoButton();
    select = new CreateSettingSelect();
    predproverkatable: PredproverkaTable = new PredproverkaTable();
    wcf: ServiceWcf = null;
    adress: AdressMerge = new AdressMerge();
    soprovod: Soprovod = null;
    @ViewChild(MatPaginator) paginatordataSource: MatPaginator;
    setting: FullSetting = new FullSetting();
    paramlogica: ParamLogica = new ParamLogica();
    selecting: ParametrSelectMail = new ParametrSelectMail();
    donloadfile: DonloadFile = new DonloadFile(this.donloadreport);
    ngOnInit(): void {
        try {
            var generate = new GenerateParamService(14);
            this.service.modelservice(generate.setting).subscribe((model) => {
                this.wcf = deserialize(ServiceWcf, model.toString());
            });
        } catch (e) {
            alert(e.toString());
        }
    }

    startprocedurepred(index: number) {
        var setting1 = this.select.workandtest(2, this.setting);
        setting1.ParamPredproverka.N441 = this.setting.ParamPredproverka.N441;
        setting1.Id = index;
        switch (index) {
            case 1:
                 this.dataservice.procedurestart(setting1).subscribe((model) => {
                 this.status.messagestatus = JSON.stringify(model);
                }
            );
                break;
            case 2:
                setting1.ParamPredproverka.N441 = 0;
                this.status.blockprocedure('выстановлению статусов');
                this.dataservice.procedurestart(setting1).subscribe((model) => {
                this.status.blockprocedure(JSON.stringify(model));
                }
            );
                break;
            case 3:
                setting1.ParamPredproverka.N441 = 0;
                this.status.blockprocedure('созданию документа');
                this.dataservice.procedurestart(setting1).subscribe((model) => {
                this.status.blockprocedure(JSON.stringify(model));
                }
            );
                break;
        }
    }


    update() {
        try {
                this.paramlogica.logicaselect(); //Закрываем логику выбора
                this.paramlogica.logicaprogress(); //Открываем логику загрузки
                this.service.datacommandserver(
                    this.selecting.generatecommand(
                        this.wcf,
                        this.selecting.paramepredproverka)).subscribe((model) => {
                    this.soprovod = deserialize(Soprovod, model.toString());
                    this.paramlogica.logicaprogress(); //Закрываем логику загрузки
                    this.paramlogica.logicadatabase(); //Открываем логику Данных
                   if (this.soprovod != null) {
                       this.predproverkatable.dataSourceDocumentReglament =
                           new MatTableDataSource<DocumentReglament>(this.soprovod.DocumentReglament);
                       this.predproverkatable.dataSourceDocumentReglament.paginator = this.paginatordataSource;
                        this.paramlogica.errornull = true;
                    } else {
                        this.paramlogica.errornull = false;
                    }
                });
            } catch (e) {
                alert(e.toString());
            }
        }

    detaliz(detalization: DocumentDetalization) {
        var detal: DocumentDetalization[];
          detal = [detalization];
            this.paramlogica.logicadatabase(); //Закрываем логику Данных
            this.paramlogica.detalization();   //Открываем детализацию
        this.predproverkatable.dataSourceDocumentDetalization = new MatTableDataSource<DocumentDetalization>(detal);
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
}