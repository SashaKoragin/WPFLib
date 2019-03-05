import { Component, ViewEncapsulation, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors } from '@angular/forms';
import { AngularTemplate  } from '../../../../../Otdel/It/AddTemplate/Model/ModelTemplate';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { TemplateAdd } from '../../../../../PostZaprosFull/PostFull';
import { AddTemplate } from '../../../../../Otdel/It/AddTemplate/StartModel/AddTemplate';

//Интерфейс передачи в диалоговое окно
export interface IDialodData {
    angulardate: AngularTemplate;
    adress: TemplateAdd;
    addTemp: AddTemplate;
}
//Проверка  Validation Head
export const validatorHead: ValidatorFn = (control: FormGroup): ValidationErrors => {
    const textHeade1 = control.get('textHeade1');
    const textHeade2 = control.get('textHeade2');
    const textHeade3 = control.get('textHeade3');
    const textHeade4 = control.get('textHeade4');
    const textHeade5 = control.get('textHeade5');
    const textHeade6 = control.get('textHeade6');
    const textHeade7 = control.get('textHeade7');
    const textHeade8 = control.get('textHeade8');
    const textHeade9 = control.get('textHeade9');
    const textHeade10 = control.get('textHeade10');
    return textHeade1.value === null
        && textHeade2.value === null
        && textHeade3.value === null
        && textHeade4.value === null
        && textHeade5.value === null
        && textHeade6.value === null
        && textHeade7.value === null
        && textHeade8.value === null
        && textHeade9.value === null
        && textHeade10.value === null ? { 'validatorHead': true } : null;
};
//Проверка  Validation Body
export const validatorBody: ValidatorFn = (control: FormGroup): ValidationErrors => {
    const textBodyGl1 = control.get('textBodyGl1');
    const textBodyGl2 = control.get('textBodyGl2');
    const textBodyGl3 = control.get('textBodyGl3');
    const textBodyGl4 = control.get('textBodyGl4');
    const textBodyGl5 = control.get('textBodyGl5');
    return textBodyGl1.value === null
        && textBodyGl2.value === null
        && textBodyGl3.value === null
        && textBodyGl4.value === null
        && textBodyGl5.value === null ? { 'validatorBody': true } : null;
};
//Проверка  Validation Stone
export const validatorStone: ValidatorFn = (control: FormGroup): ValidationErrors => {
    const textStone1 = control.get('textStone1');
    const textStone2 = control.get('textStone2');
    const textStone3 = control.get('textStone3');
    const textStone4 = control.get('textStone4');
    const textStone5 = control.get('textStone5');
    const textStone6 = control.get('textStone6');
    const textStone7 = control.get('textStone7');
    return textStone1.value === null
        && textStone2.value === null
        && textStone3.value === null
        && textStone4.value === null
        && textStone5.value === null
        && textStone6.value === null
        && textStone7.value === null ? { 'validatorStone': true } : null;
};

@Component({
    selector: 'dialog-template',
    templateUrl: '../HTML/Headers.html',
    styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
    encapsulation: ViewEncapsulation.None
})
    //Класс добавления Heade
export class HeadersAdd {

    constructor(private MatDialogRef: MatDialogRef<HeadersAdd>,
        @Inject(MAT_DIALOG_DATA) public data: IDialodData) { }
    //Реактивная форма Head
    formTemplateHeaders = new FormGroup({
        'textHeade1': new FormControl('', Validators.required),
        'textHeade2': new FormControl('', Validators.required),
        'textHeade3': new FormControl({ value: '' }, [Validators.required]),
        'textHeade4': new FormControl({ value: '' }, Validators.required),
        'textHeade5': new FormControl({ value: '' }, [Validators.required]),
        'textHeade6': new FormControl({ value: '' }, [Validators.required]),
        'textHeade7': new FormControl({ value: '' }, [Validators.required]),
        'textHeade8': new FormControl({ value: '' }, [Validators.required]),
        'textHeade9': new FormControl({ value: '' }, [Validators.required]),
        'textHeade10': new FormControl({ value: '' }, [Validators.required])
    },
        { validators: validatorHead });

    get textHeade1() { return this.formTemplateHeaders.get('textHeade1') }
    get textHeade2() { return this.formTemplateHeaders.get('textHeade2') }
    get textHeade3() { return this.formTemplateHeaders.get('textHeade3') }
    get textHeade4() { return this.formTemplateHeaders.get('textHeade4') }
    get textHeade5() { return this.formTemplateHeaders.get('textHeade5') }
    get textHeade6() { return this.formTemplateHeaders.get('textHeade6') }
    get textHeade7() { return this.formTemplateHeaders.get('textHeade7') }
    get textHeade8() { return this.formTemplateHeaders.get('textHeade8') }
    get textHeade9() { return this.formTemplateHeaders.get('textHeade9') }
    get textHeade10() { return this.formTemplateHeaders.get('textHeade10') }
    //Команда отправки и добавления на сервер БД Heade
    addTempateHeade() {
        this.data.adress.addtemplate(this.data.angulardate).subscribe(model => {
            alert(JSON.stringify(model));
        });
        this.data.addTemp.fullTemplate();
    }
}

@Component({
    selector: 'dialog-template',
    templateUrl: '../HTML/Body.html',
    styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
    encapsulation: ViewEncapsulation.None
})
    //Класс добавления Body
export class BodyAdd {

    constructor(private MatDialogRef: MatDialogRef<BodyAdd>,
        @Inject(MAT_DIALOG_DATA) public data: IDialodData) { }
    //Реактивная форма Body
    formTemplateBody = new FormGroup({
        'textBodyGl1': new FormControl('', Validators.required),
        'textBodyGl2': new FormControl('', Validators.required),
        'textBodyGl3': new FormControl({ value: '' }, [Validators.required]),
        'textBodyGl4': new FormControl({ value: '' }, Validators.required),
        'textBodyGl5': new FormControl({ value: '' }, [Validators.required])
    },
        { validators: validatorBody });

    get textBodyGl1() { return this.formTemplateBody.get('textBodyGl1') }
    get textBodyGl2() { return this.formTemplateBody.get('textBodyGl2') }
    get textBodyGl3() { return this.formTemplateBody.get('textBodyGl3') }
    get textBodyGl4() { return this.formTemplateBody.get('textBodyGl4') }
    get textBodyGl5() { return this.formTemplateBody.get('textBodyGl5') }
    //Команда отправки и добавления на сервер БД Body
    public addTempateBody(): void {
        this.data.adress.addtemplate(this.data.angulardate).subscribe(model => {
            alert(JSON.stringify(model));
        });
        this.data.addTemp.fullTemplate();
    }
}

@Component({
    selector: 'dialog-template',
    templateUrl: '../HTML/Stone.html',
    styleUrls: ['../../StyleDialog/FullDialogStyle.css'],
    encapsulation: ViewEncapsulation.None
})
export class StoneAdd {

    constructor(private MatDialogRef: MatDialogRef<StoneAdd>,
        @Inject(MAT_DIALOG_DATA) public data: IDialodData ) { }
    //Реактивная форма Stone
    formTemplateStone = new FormGroup({
        'textStone1': new FormControl('', Validators.required),
        'textStone2': new FormControl('', Validators.required),
        'textStone3': new FormControl({ value: '' }, [Validators.required]),
        'textStone4': new FormControl({ value: '' }, Validators.required),
        'textStone5': new FormControl({ value: '' }, [Validators.required]),
        'textStone6': new FormControl({ value: '' }, [Validators.required]),
        'textStone7': new FormControl({ value: '' }, [Validators.required])
    },
        { validators: validatorStone });

    get textStone1() { return this.formTemplateStone.get('textStone1') }
    get textStone2() { return this.formTemplateStone.get('textStone2') }
    get textStone3() { return this.formTemplateStone.get('textStone3') }
    get textStone4() { return this.formTemplateStone.get('textStone4') }
    get textStone5() { return this.formTemplateStone.get('textStone5') }
    get textStone6() { return this.formTemplateStone.get('textStone6') }
    get textStone7() { return this.formTemplateStone.get('textStone7') }
    //Команда отправки и добавления на сервер БД Stone
    public addTempateStone(): void {
        this.data.adress.addtemplate(this.data.angulardate).subscribe(model => {
            alert(JSON.stringify(model));
        });
        this.data.addTemp.fullTemplate();
    }
}