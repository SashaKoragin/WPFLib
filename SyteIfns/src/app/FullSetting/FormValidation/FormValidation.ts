import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';
import { AngularTemplate, Headers, Stone, Body,Template,NameDocument } from '../../Otdel/It/AddTemplate/Model/ModelTemplate';
import { SelectionModel } from '@angular/cdk/collections';
import { MatDialog, MatDialogConfig} from '@angular/material';
import { HeadersAdd, BodyAdd, StoneAdd } from './Dialog/ItTemplate/Class/Dialogs';
import { TemplateAdd } from '../../PostZaprosFull/PostFull';
import { AddTemplate } from '../../Otdel/It/AddTemplate/StartModel/AddTemplate';

//Проверка Validation для добавления документа в БД
export const identityRevealedValidator: ValidatorFn = (control: FormGroup): ValidationErrors  => {
    const nameDoc = control.get('nameDoc');
    const manualDoc = control.get('manualDoc');
    const headers = control.get('headers');
    const body = control.get('body');
    const stone = control.get('stone');
    return nameDoc.value === null
        && manualDoc.value === null
        && headers.value === null
        && body.value === null
        && stone.value === null ? { 'identityRevealed': true } : null;
};

//Класс контролов
export class ControlTemplate {

    constructor(public addTemp: AddTemplate, public dialog: MatDialog, public addtemp: TemplateAdd) {}
    //Модель для документа
    document: AngularTemplate = new AngularTemplate(new Template, new NameDocument);
    //Модель для заголовка
    head: AngularTemplate = new AngularTemplate(null, null, new Headers);
    //Модель для тела
    bodys: AngularTemplate = new AngularTemplate(null, null, null, new Body);
    //Модель для основания
    stones: AngularTemplate = new AngularTemplate(null, null, null, null, new Stone);
    //selector Body
    selectionBody = new SelectionModel<Body>(false, []);
    //selector Header
    selectionHeaders = new SelectionModel<Headers>(false, []);
    //selector Stone
    selectionStone = new SelectionModel<Stone>(false, []);
    //Реактивная форма на документ
    formTemplate = new FormGroup({
        'nameDoc': new FormControl('', Validators.required),
        'manualDoc': new FormControl('', Validators.required),
        'headers': new FormControl({ value: ''}, [ Validators.required]),
        'body': new FormControl({ value: ''}, Validators.required),
        'stone': new FormControl({ value: '' }, [Validators.required])
    },
        { validators: identityRevealedValidator });

    get nameDoc() { return this.formTemplate.get('nameDoc') }
    get manualDoc() { return this.formTemplate.get('manualDoc' ) }
    get headers() { return this.formTemplate.get('headers')}
    get body() { return this.formTemplate.get('body' ) }
    get stone() { return this.formTemplate.get('stone') }
    //Выбор из таблицы Header
    selectHeaders() {
        if (this.selectionHeaders.selected.length > 0) {
            this.selectionHeaders.selected.map(head => {
                this.document.Template.IdHeaders = head.IdHeaders;
            });
        } else {
            this.document.Template.IdHeaders = null;
        }
    }
    //Выбор из таблицы Body
    selectBody() {
        if (this.selectionBody.selected.length > 0) {
            this.selectionBody.selected.map(body => {
                this.document.Template.IdBody = body.IdBody;
            });
        } else {
            this.document.Template.IdBody = null;
        }
    }
    //Выбор из таблицы Stone
    selectStone() {
        if (this.selectionStone.selected.length > 0) {
            this.selectionStone.selected.map(stone => {
                this.document.Template.IdStone = stone.IdStone;
            });
        } else {
            this.document.Template.IdStone = null;
        }
    }
    //Открытие диалогового окна на добавления Header
   public openDialogHead(): void {
       this.dialog.open(HeadersAdd,{
           width: '600px',
           data: { angulardate: this.head, adress: this.addtemp, addTemp: this.addTemp }

       });
    }
    //Открытие диалогового окна на добавления Body
    public openDialogBody(): void {
        this.dialog.open(BodyAdd, {
            width: '600px',
            data: { angulardate: this.bodys, adress: this.addtemp, addTemp: this.addTemp }
        });
    }
    //Открытие диалогового окна на добавления Stone
    public openDialogStone(): void {
        this.dialog.open(StoneAdd, {
            width: '600px',
            data: { angulardate: this.stones, adress: this.addtemp, addTemp: this.addTemp }
        });
    }
}