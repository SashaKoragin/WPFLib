import { Component, OnInit } from '@angular/core';
import { PostTrebovanie } from '../../../../PostZaprosFull/PostFull';
import { Setting } from '../Model/ModelReshenie'
import { SysNum, ReshenieField, TableSysNumReshenField, IncassField} from '../Model/ModelSelect'
import { CreateSettingSelect,Db } from '../LogicaSetting/CreateSettingSelect'
import { plainToClass, deserialize } from "class-transformer";
import { BlocsInfoButton } from '../Model/Process'
@Component(
{
        selector: 'my-treb',
        templateUrl: '../Template/Reshenie.html',
        styleUrls: ['../Template/Style.css'],
        providers: [PostTrebovanie]
})

export class ReshenieStart implements OnInit{

    status:BlocsInfoButton = new BlocsInfoButton();

    db: string = 'Тест';
    setting: Setting = new Setting();
    select = new CreateSettingSelect();
    reshenie: SysNum = null;
    mode:boolean = true;
    num: number = 1;
    resheniedetal: ReshenieField = null;
    incass: IncassField[] = null;

    numberResh:number;
    limit: number =100;
    page: number = 1;
    filters: TableSysNumReshenField = new TableSysNumReshenField();
    
    constructor(private dataservice: PostTrebovanie ) { }

    ngOnInit(): void {
        this.loadswith(this.num);
    }

    //Основная функция загрузки данных
    loadswith(num: number) {
        try {
           this.dataservice.modelreshenie(this.select.workandtest(num, this.setting)).subscribe((model) => {
               this.reshenie = deserialize(SysNum, model.toString());
            });
        } catch (e) {
            console.log(e.toString());
        }
    }

    //Переключатель загрузки Test Work
    swithdb() {
        if (this.num ===1) {
            this.num = 2;
            this.db = 'Рабочая';
        } else {
            this.num = 1;
            this.db = 'Тест';
        }
        switch (this.num) {
            case 1:
                this.loadswith(this.num);
            case 2:
                this.loadswith(this.num);
        }
    }
    //Выполнение процедуры
    storeprocedurestart(index: number,resh:number = 0) {
        switch (index) {
            case 1:
                var setting1 = this.select.createaddresh(resh, this.select.workandtest(this.num, this.setting));
                this.dataservice.procedurestart(setting1).subscribe((model) => {
                    this.status.messagestatus = JSON.stringify(model);
                    this.loadswith(this.num);
                    this.setting.ParametrSelect.D270 = 0;
                    }
                );
                break;
            case 2:
                this.status.blockbuttonreshen();
                var setting2 = this.select.createstartresh(resh, this.select.workandtest(this.num, this.setting));
                this.dataservice.procedurestart(setting2).subscribe((model) => {
                    this.status.blockbuttonreshen(JSON.stringify(model));
                    }
                );
                break;
            case 3: 
                this.status.blockbuttonincass();
               var setting3 = this.select.createstartincass(resh, this.select.workandtest(this.num, this.setting));
                this.dataservice.procedurestart(setting3).subscribe((model) => {
                    this.status.blockbuttonincass(JSON.stringify(model));
                    }
                );
                break;
        }
    }

    detal(reshenie: TableSysNumReshenField) {
        this.mode = false;
        this.resheniedetal = reshenie.reshenieField;
        this.incass = reshenie.reshenieField.incassField;
    }

    returns() {
        this.mode = true;
    }
}