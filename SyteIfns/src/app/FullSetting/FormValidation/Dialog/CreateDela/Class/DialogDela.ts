import {FullSetting} from '../../../../FullSetting';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Component, OnInit, ViewEncapsulation, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';
import { PostBdk } from '../../../../../PostZaprosFull/PostFull';
import { DeloPriem } from '../../../../SelectTable/TableGenerator';
import { CreateDela } from './ModelDelaPriem';
import { plainToClass, deserialize } from 'class-transformer';
import { forbiddenNameValidator } from '../../../../FunctionValidation';
//Интерфейс передачи в диалоговое окно
export interface IDialodDela {
    sett: FullSetting;
    dataser: PostBdk;
}

//Проверка  Validation Dela
export const validatorDela: ValidatorFn = (control: FormGroup): ValidationErrors => {
    const delaPriem = control.get('delaPriem');
    return delaPriem.value === null ? { 'validatorDela': true } : null;
};

@Component({
    selector: 'dialog-dela',
    templateUrl: '../HTML/Dela.html',
    styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
    encapsulation: ViewEncapsulation.None,
    providers: [DeloPriem]
})
export class DialogDela {
    constructor(private MatDialogRef: MatDialogRef<DialogDela>,
        @Inject(MAT_DIALOG_DATA) public data: IDialodDela,
        public delop: DeloPriem) {
    }

    delo: CreateDela =null;
    delatext: string = null;
    delaCreate = new FormGroup({
            'delaPriem': new FormControl('',
                [Validators.required, forbiddenNameValidator(/^((\d{4,6}\/{1})+(\d{4,6})|(\d{4,6}))$/)])
        },
        { validators: validatorDela });

    get delaPriem() { return this.delaCreate.get('delaPriem') }

    //Создание дел приема КРСБ
    addDeloCrete() {
        this.data.sett.DeloPriem.addarraystring(this.delatext.split(/\//));
        this.data.dataser.createkrsb(this.data.sett).subscribe(model => {
            this.delo = deserialize(CreateDela, model.toString());
            if (this.delo != null) {
                this.delop.addTable(this.delo.TableInfoDelo);
                this.delop.yesdate = true;
            } else {
                this.delop.yesdate = false;
            }
        });
    }
}