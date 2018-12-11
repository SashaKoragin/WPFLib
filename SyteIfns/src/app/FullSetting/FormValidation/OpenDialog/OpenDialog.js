import { DialogDela } from '../Dialog/CreateDela/Class/DialogDela';
import { DialogOkato } from '../Dialog/AddOkato/Class/DialogOkato';
var DialogOpenCreateDela = /** @class */ (function () {
    function DialogOpenCreateDela(dialog, setting, dataservice) {
        this.dialog = dialog;
        this.setting = setting;
        this.dataservice = dataservice;
    }
    //Открытие диалогового окна на добавления Dela
    DialogOpenCreateDela.prototype.openDialogCreateDela = function () {
        this.dialog.open(DialogDela, {
            width: '1300px',
            height: '800px',
            data: { sett: this.setting, dataser: this.dataservice }
        });
    };
    return DialogOpenCreateDela;
}());
export { DialogOpenCreateDela };
var DialogOpenAddOkato = /** @class */ (function () {
    function DialogOpenAddOkato(dialog, datekrsb) {
        this.dialog = dialog;
        this.datekrsb = datekrsb;
    }
    //Открытие диалогового окна для проставления ОКАТО
    DialogOpenAddOkato.prototype.openDialogAddOkato = function (numDelo, num) {
        this.dialog.open(DialogOkato, {
            width: '750px',
            height: '400px',
            data: { logica: this.datekrsb, delo: numDelo, numberproc: num }
        });
    };
    return DialogOpenAddOkato;
}());
export { DialogOpenAddOkato };
//# sourceMappingURL=OpenDialog.js.map