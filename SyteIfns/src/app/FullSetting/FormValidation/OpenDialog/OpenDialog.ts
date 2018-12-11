import { DialogDela } from '../Dialog/CreateDela/Class/DialogDela';
import { DialogOkato } from '../Dialog/AddOkato/Class/DialogOkato';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { FullSetting } from '../../FullSetting';
import { PostBdk } from '../../../PostZaprosFull/PostFull';
import { LogicaAnaliz } from '../../../Otdel/Analiticks/AnalizNo/Model/LogicaAnalis';
export class DialogOpenCreateDela {

    constructor(public dialog: MatDialog, public setting: FullSetting, private dataservice: PostBdk) { }
    //Открытие диалогового окна на добавления Dela
    public openDialogCreateDela(): void {
        this.dialog.open(DialogDela, {
            width: '1300px',
            height: '800px',
            data: { sett: this.setting, dataser: this.dataservice }
        });
    }

}

export class DialogOpenAddOkato {

    constructor(public dialog: MatDialog, public datekrsb: PostBdk) { }
    //Открытие диалогового окна для проставления ОКАТО
    public openDialogAddOkato(numDelo: number, num: number): void {
        this.dialog.open(DialogOkato, {
            width: '750px',
            height: '400px',
            data: { logica: this.datekrsb, delo: numDelo,numberproc: num}
        });
    }
}