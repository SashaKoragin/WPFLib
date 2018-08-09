import { Component, OnInit } from '@angular/core';
import { PostTrebovanie } from '../../../../PostZaprosFull/PostFull';
import { CreateSettingSelect, DataBase } from '../../../../FullSetting/CreateSetting'
import { FullSetting} from '../../../../FullSetting/FullSetting'
import { SysNum, Reshenie, TableSysNumReshen, Incass} from '../Model/ModelSelect'
import { plainToClass, deserialize } from "class-transformer";
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull'
import { DateModel } from '../../../../FullSetting/DateModelFull'
@Component(({
    selector: 'my-treb',
    templateUrl: '../Template/Reshenie.html',
    styleUrls: ['../Template/Style.css'],
    providers: [PostTrebovanie]
}) as any)

export class ReshenieStart implements OnInit{
    date: DateModel = new DateModel();
    status:BlocsInfoButton = new BlocsInfoButton();
    database:DataBase = new DataBase();
    setting: FullSetting = new FullSetting();
    select = new CreateSettingSelect();
    reshenie: SysNum = null;
    mode:boolean = true;
    resheniedetal: Reshenie = null;
    incass: Incass[] = null;
    errornull: boolean = true;
    numberResh:number;
    limit: number =100;
    page: number = 1;
    filters: TableSysNumReshen = new TableSysNumReshen();
    
    constructor(private dataservice: PostTrebovanie ) { }

    ngOnInit(): void {
    }

    //Основная функция загрузки данных
    loadswith(num: number, dateStart: number, dateFinis: number) {
        try {
            if (this.date.valid()) {
                this.date.convertdateresh(this.setting, dateStart, dateFinis);
                this.dataservice.modelreshenie(this.select.workandtest(num, this.setting)).subscribe((model) => {
                    this.reshenie = deserialize(SysNum, model.toString());
                    if (this.reshenie != null) {
                        this.errornull = true;
                    } else {
                        this.errornull = false;
                    }
                });
            }
        } catch (e) {
            console.log(e.toString());
        }
    }

    //Переключатель загрузки Test Work
    swithdb(num: number, dateStart: number, dateFinis: number) {
        switch (num) {
            case 1:
                this.loadswith(num, dateStart, dateFinis);
            case 2:
                this.loadswith(num, dateStart, dateFinis);
        }
    }
    //Выполнение процедуры
    storeprocedurestart(index: number,resh:number = 0) {
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

    detal(reshenie: TableSysNumReshen) {
        this.mode = false;
        this.resheniedetal = reshenie.Reshenie;
        this.incass = reshenie.Reshenie.Incass;
    }

    returns() {
        this.mode = true;
    }
}