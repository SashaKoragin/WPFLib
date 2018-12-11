import { PostBdk } from  '../../../../../PostZaprosFull/PostFull';
import { Component, OnInit, ViewEncapsulation, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { GenerateParamService, CreateSettingSelect } from '../../../../CreateSetting';
import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';
import { forbiddenNameValidator } from '../../../../FunctionValidation';

export interface IDialodOkato {
    logica: PostBdk;
    delo: number;
    numberproc: number;
}

@Component({
    selector: 'dialog-okato',
    templateUrl: '../HTML/Okato.html',
    styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
    encapsulation: ViewEncapsulation.None
})
export class DialogOkato {
    constructor(private MatDialogRef: MatDialogRef<DialogOkato>,
        @Inject(MAT_DIALOG_DATA) public data: IDialodOkato) {
    }

    delaOkato = new FormGroup({
        'okato': new FormControl('',
            [Validators.required, forbiddenNameValidator(/^(\d{11})$/)])
    });

    get okato() { return this.delaOkato.get('okato') }

    message:string = null;

    addokato() {
        this.message = null;
        var setting = new GenerateParamService(this.data.numberproc);
        var createdb = new CreateSettingSelect().worksetting(setting.setting);
        createdb.DeloCreate.D3979 = this.data.delo;
        createdb.DeloCreate.Okato = this.okato.value;
        this.data.logica.analizkrsb(createdb).subscribe((model) => {
            this.message = JSON.stringify(model);
        });
    }
}