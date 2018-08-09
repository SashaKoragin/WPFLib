import { Component, OnInit } from '@angular/core';
import { LetterForm } from '../../../../PostZaprosFull/PostFull';
import { FullSetting } from '../../../../FullSetting/FullSetting'
import { BlocsInfoButton } from '../../../../FullSetting/ProcessFull'
import { DateModel } from '../../../../FullSetting/DateModelFull'

@Component(({
    selector: 'my-letter',
    templateUrl: '../Template/FormLetter.html',
    styleUrls: ['../Template/FormLetter.css'],
    providers: [LetterForm]
}) as any)

export class BdkLetter implements OnInit {
    bloks: BlocsInfoButton = new BlocsInfoButton();
    setting: FullSetting = new FullSetting();
    date:DateModel = new DateModel();
    constructor(private dateservice: LetterForm) { }

    ngOnInit(): void {
       
    }

    startreport(dateStart:number, dateFinis:number) {
        this.bloks.serverrestmessage(null);
        this.setting.UseTemplate.IdTemplate = 1;
        if (this.date.valid()) {
            this.date.convertdate(this.setting, dateStart,dateFinis);
            this.dateservice.modelbdk(this.setting).subscribe(
                (model) => {
                    this.bloks.serverrestmessage(JSON.stringify(model));
                });
        } 
    }

}