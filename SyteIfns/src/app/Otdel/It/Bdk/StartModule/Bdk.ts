import { Component, OnInit } from '@angular/core';
import { ModelBdk } from '../Model/BdkModel'
import { FullSetting } from '../../../../FullSetting/FullSetting'
import { PostBdk } from '../../../../PostZaprosFull/PostFull';
import { CreateSettingSelect, DataBase } from '../../../../FullSetting/CreateSetting'
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull'
import { plainToClass, deserialize } from "class-transformer";

@Component(({
    selector: 'my-bdk',
    templateUrl: '../Template/Bdk.html',
    styleUrls: ['../Template/BdkStyle.css'],
    providers: [PostBdk]
}) as any)

export class BdkIt implements OnInit{

    bloks: BlocsInfoButton = new BlocsInfoButton();
    bdk: ModelBdk = null;
    setting: FullSetting = new FullSetting();
    select = new CreateSettingSelect();



    constructor(private dataservice: PostBdk) { }
    //Старт блока
    ngOnInit(): void {
        this.loadbdkstatistic();
    }
    //Подгрузка данных для БДК
    loadbdkstatistic() {
        try {
            this.dataservice.modelbdk(this.select.worksetting(this.setting)).subscribe((model) => {
                this.bdk = deserialize(ModelBdk, model.toString());
            });
        } catch (e) {
            console.log(e.toString());
        }
    }
    //Выполнение процедур для БДК
    storeprocedure(numprocedure: number, iduser: number, message: string) {
        if (this.setting.ParametrBdk.valid()) {
        switch (numprocedure) {
            case 1:
                this.bloks.blockprocedure('анализу данных BDK'); 
                break;
            case 2:
                this.bloks.blockprocedure('созданию данных BDK');
                break;
        }
        this.dataservice.startprocedurebdk(
            this.select.procedurebdk(
                numprocedure,
                iduser,
                message,
                this.select.worksetting(this.setting))).subscribe(
            (model) => {
                this.bloks.blockprocedure(JSON.stringify(model));
                this.loadbdkstatistic();
            }
            );
        }
    }
    }