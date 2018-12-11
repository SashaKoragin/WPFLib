import { FormGroup, FormControl, Validators } from '@angular/forms';
import { GenerateParamService, CreateSettingSelect } from '../../../../FullSetting/CreateSetting';
import { ServiceWcf } from '../../../../ModelService/ModelService';
import { NoAnalizTable } from '../../../../FullSetting/SelectTable/TableGenerator';
import { No } from './ModelAnaliz';
import { deserialize } from 'class-transformer';
import { ParamLogica } from '../../../../FullSetting/SelectTable/LogicaSelect';
import { LogicaSelecting } from './AnalizZapros';
import { validatorDate, forbiddenNameValidator } from '../../../../FullSetting/FunctionValidation';
import { DialogOpenAddOkato } from '../../../../FullSetting/FormValidation/OpenDialog/OpenDialog';
var LogicaAnaliz = /** @class */ (function () {
    function LogicaAnaliz(datekrsb, service, select, dialog) {
        this.datekrsb = datekrsb;
        this.service = service;
        this.select = select;
        this.dialog = dialog;
        this.no = null;
        this.wcf = null;
        this.table = new NoAnalizTable();
        this.paramlogica = new ParamLogica();
        this.messageserver = null;
        this.logicaSelecting = new LogicaSelecting();
        this.opendialog = new DialogOpenAddOkato(this.dialog, this.datekrsb);
        this.dateCreate = new FormGroup({
            'dateCreate': new FormControl('', [Validators.required, validatorDate()])
        });
        this.idCreate = new FormGroup({
            'id': new FormControl('', [Validators.required, forbiddenNameValidator(/^((\d{4,6}\/{1})+(\d{4,6})|(\d{4,6}))$/)])
        });
    }
    Object.defineProperty(LogicaAnaliz.prototype, "createDate", {
        get: function () { return this.dateCreate.get('dateCreate'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(LogicaAnaliz.prototype, "id", {
        get: function () { return this.idCreate.get('id'); },
        enumerable: true,
        configurable: true
    });
    LogicaAnaliz.prototype.servermodel = function () {
        var _this = this;
        try {
            var generate = new GenerateParamService(21);
            this.service.modelservice(generate.setting).subscribe(function (model) {
                _this.wcf = deserialize(ServiceWcf, model.toString());
            });
        }
        catch (e) {
            alert(e.toString());
        }
    };
    LogicaAnaliz.prototype.addtable = function (no) {
        this.table.addTableDelo(no.Delo);
    };
    ///Главная функция анализа по значениям и по дате
    LogicaAnaliz.prototype.analiz = function (num) {
        var _this = this;
        try {
            this.messageserver = null;
            var setting = new GenerateParamService(num); //Номер это какая процедура выполняется
            var createdb = new CreateSettingSelect().worksetting(setting.setting); //Установка рабочей БД
            // alert(this.createDate.value + 'Дата приема');
            // alert(this.id.value + 'Дела приема');
            if (this.createDate.value === '') {
                createdb.DeloPriem.addarraystring(this.id.value.split(/\//));
            }
            else {
                createdb.DeloCreate.datezaprosa(this.createDate.value);
            }
            // alert(JSON.stringify(createdb));
            this.datekrsb.analizkrsb(createdb).subscribe(function (model) {
                _this.messageserver = JSON.stringify(model);
            });
        }
        catch (e) {
            alert(e.toString());
        }
    };
    LogicaAnaliz.prototype.updatemodel = function () {
        var _this = this;
        this.service.datacommandserver(this.select.modelCommandServer).subscribe(function (model) {
            _this.no = deserialize(No, model.toString());
            if (_this.no != null) {
                _this.addtable(_this.no);
                _this.table.addTableAnaliz(null);
                _this.paramlogica.errornull = true;
            }
            else {
                _this.table.addTableAnaliz(null);
                _this.paramlogica.errornull = false;
            }
        });
    };
    LogicaAnaliz.prototype.startprocedure = function (numDelo, num) {
        var _this = this;
        this.messageserver = null;
        var setting = new GenerateParamService(num);
        var createdb = new CreateSettingSelect().worksetting(setting.setting);
        createdb.DeloCreate.D3979 = numDelo;
        this.datekrsb.analizkrsb(createdb).subscribe(function (model) {
            _this.messageserver = JSON.stringify(model);
            _this.updatemodel();
        });
    };
    return LogicaAnaliz;
}());
export { LogicaAnaliz };
//# sourceMappingURL=LogicaAnalis.js.map