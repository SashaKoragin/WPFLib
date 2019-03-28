import { Component, ViewChild } from '@angular/core';
import { ModelFull, NameDocument, Headers, Stone, Body } from '../Model/ModelTemplate'
import { LogicaTemplate} from '../Model/Tables'
import { ServiceWcf } from '../../../../ModelService/ModelService';
import { GenerateParamService } from '../../../../FullSetting/CreateSetting';
import { TemplateAdd, ServiceModel } from '../../../../PostZaprosFull/PostFull';
import { deserialize } from 'class-transformer';
import { ParametrSelectMail } from '../../../../ModelService/SelectCommand';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { TableTemplate } from '../../../../FullSetting/SelectTable/TableGenerator';
import { ControlTemplate } from '../../../../FullSetting/FormValidation/FormValidation'
import { MatDialog } from '@angular/material';
@Component(({
    selector: 'add-template',
    templateUrl: '../Template/AddTemplate.html',
    styleUrls: ['../Template/AddTemplate.css'],
    providers: [ServiceModel, TemplateAdd, MatDialog]
}) as any)

    //Класс добавления шаблона
export class AddTemplate {

    constructor(private service: ServiceModel, public dialog: MatDialog, public addtemp: TemplateAdd) { }
    @ViewChild(MatPaginator) paginatordataSource: MatPaginator;
    logica: LogicaTemplate = new LogicaTemplate();
    modelfull: ModelFull = null;
    wcf: ServiceWcf = null;

    select: ParametrSelectMail = new ParametrSelectMail();
    template: TableTemplate = new TableTemplate();
    form: ControlTemplate = new ControlTemplate(this as AddTemplate,this.dialog,this.addtemp);


    ngOnInit(): void {
        try {
            var generate = new GenerateParamService(13);
            this.service.modelservice(generate.setting).subscribe((model) => {
                this.wcf = deserialize(ServiceWcf, model.toString());
                this.fullTemplate();
            });
        } catch (e) {
            alert(e.toString());
        }
    }
    //Подгрузка всех шаблонов в БД
    fullTemplate() {
        this.service.datacommandserver(this.select.generatecommandnotparam(this.wcf)).subscribe((model) => {
            this.modelfull = deserialize(ModelFull, model.toString());
            this.template.dataSource = new MatTableDataSource<NameDocument>(this.modelfull.NameDocument);
            this.template.dataSource.paginator = this.paginatordataSource;
            this.template.dataSourceBody = new MatTableDataSource<Body>(this.modelfull.Body);
            this.template.dataSourceHeaders = new MatTableDataSource<Headers>(this.modelfull.Headers);
            this.template.dataSourceStone = new MatTableDataSource<Stone>(this.modelfull.Stone);
        });
    }
    //Добавления документа в БД
    addtemplate() {
        alert(JSON.stringify(this.form.document));
        this.addtemp.addtemplate(this.form.document).subscribe(model => {
            alert(JSON.stringify(model));
        });
        this.fullTemplate();
    }
}
