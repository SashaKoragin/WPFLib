import { Component, OnInit, ViewChild } from '@angular/core';
import { GenerateParamService } from '../../../../FullSetting/CreateSetting';
import { PostTrebovanie, ServiceModel } from '../../../../PostZaprosFull/PostFull';
import { CreateSettingSelect, DataBase } from '../../../../FullSetting/CreateSetting';
import { FullSetting} from '../../../../FullSetting/FullSetting';
import { SysNum, Reshenie, TableSysNumReshen, Incass} from '../Model/ModelSelect';
import { plainToClass, deserialize } from 'class-transformer';
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull';
import { DateModel } from '../../../../FullSetting/DateModelFull';
import { TableReshenia } from '../../../../FullSetting/SelectTable/TableGenerator';
import { ParamLogica } from '../../../../FullSetting/SelectTable/LogicaSelect';
import { ServiceWcf, AngularModel, AngularModelFileDonload } from '../../../../ModelService/ModelService';
import { ParametrSelectMail, SelectParamMail } from '../../../../ModelService/SelectCommand';
import { MatTableDataSource, MatPaginator } from '@angular/material';
@Component(({
    selector: 'my-treb',
    templateUrl: '../Template/Reshenie.html',
    styleUrls: ['../Template/Style.css'],
    providers: [PostTrebovanie, ServiceModel]
}) as any)
export class ReshenieStart implements OnInit {

    wcf: ServiceWcf = null;
    table: TableReshenia = new TableReshenia();
    paramlogica: ParamLogica = new ParamLogica();
    selecting: ParametrSelectMail = new ParametrSelectMail();
    @ViewChild(MatPaginator) paginatordataSource: MatPaginator;
    date: DateModel = new DateModel();
    status: BlocsInfoButton = new BlocsInfoButton();
    database: DataBase = new DataBase();
    setting: FullSetting = new FullSetting();
    select = new CreateSettingSelect();
    reshenie: SysNum = null;
    mode: boolean = true;
    resheniedetal: Reshenie = null;
    incass: Incass[] = null;
    errornull: boolean = true;
    filters: TableSysNumReshen = new TableSysNumReshen();

    constructor(private dataservice: PostTrebovanie, private service: ServiceModel) {}

    ngOnInit(): void {
        try {
            var generate = new GenerateParamService(1);
            this.service.modelservice(generate.setting).subscribe((model) => {
                this.wcf = deserialize(ServiceWcf, model.toString());
            });
        } catch (e) {
            alert(e.toString());
        }
    }

    //Выполнение процедуры
    storeprocedurestart(index: number, resh: number = 0) {
        switch (index) {
            case 1:
                var setting1 = this.select.createaddresh(resh, this.select.workandtest(this.database.db.num, this.setting));
                this.dataservice.procedurestart(setting1).subscribe((model) => {
                    this.status.messagestatus = JSON.stringify(model);
                    this.setting.ParametrReshen.D270 = 0;
                    }
                );
                break;
            case 2:
                this.status.blockbuttonreshen();
                this.setting.ParametrReshen.D270 = 0;
                var setting2 = this.select.createstartresh(resh, this.select.workandtest(this.database.db.num, this.setting));
                this.dataservice.procedurestart(setting2).subscribe((model) => {
                    this.status.blockbuttonreshen(JSON.stringify(model));
                    }
                );
                break;
            case 3:
                this.status.blockbuttonincass();
                this.setting.ParametrReshen.D270 = 0;
                var setting3 = this.select.createstartincass(resh, this.select.workandtest(this.database.db.num, this.setting));
                this.dataservice.procedurestart(setting3).subscribe((model) => {
                this.status.blockbuttonincass(JSON.stringify(model));
                    }
                );
                break;
        }
    }


    returns() {
        this.mode = true;
    }

    update() {
        try {
        this.paramlogica.logicaselect(); //Закрываем логику выбора
        this.paramlogica.logicaprogress();  //Открываем логику загрузки
            this.service.datacommandserver(
                this.selecting.generatecommand(
                    this.wcf,
                    this.selecting.parametrreshen,
                    this.database.db.num)).subscribe((model) => {
                this.reshenie = deserialize(SysNum, model.toString());
            this.paramlogica.logicaprogress(); //Закрываем логику загрузки
            this.paramlogica.logicadatabase(); //Открываем логику Данных
            if (this.reshenie != null) {
                this.table.dataSource = new MatTableDataSource<TableSysNumReshen>(this.reshenie.TableSysNumReshen);
                this.table.dataSource.paginator = this.paginatordataSource;
                this.paramlogica.errornull = true;
            } else {
                this.paramlogica.errornull = false;
            }
            });
        } catch (e) {
            alert(e.toString());
        }
    }


    detaliz(reshen: Reshenie) {
        var res: Reshenie[];
        res = [reshen];
        this.paramlogica.logicadatabase(); //Закрываем логику Данных
        this.paramlogica.detalization();   //Открываем детализацию
        this.table.dataSourceDetalSysNum = new MatTableDataSource<Reshenie>(res);
        this.table.dataSourceDetalIncass = new MatTableDataSource<Incass>(res[0].Incass);
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