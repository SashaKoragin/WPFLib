import { MatTableDataSource } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
//Класс таблиц Создания писем
var TableLetter = /** @class */ (function () {
    function TableLetter() {
        this.displaydataSource = ['id', 'iddoc', 'name', 'date', 'detal', 'vig'];
        this.displaydataSourceDetal = ['iddoc', 'imns', 'nameimns', 'namebdk', 'datebdk'];
    }
    return TableLetter;
}());
export { TableLetter };
//Класс таблиц Решения
var TableReshenia = /** @class */ (function () {
    function TableReshenia() {
        this.displaydataSource = ['d270', 'idstatus', 'error', 'dateBlokReshenie', 'idstat2', 'errorIncass', 'dateBlokIncass', 'detal'];
        this.displaydataSourceDetalSysNum = ['D865Res', 'D270', 'N1', 'Summ', 'N120', 'D850Res', 'D851Res', 'D270IshRes', 'DateCreate'];
        this.displaydataSourceDetalIncass = ['D851Res_1', 'D850Incass', 'D851Incass', 'Summ', 'D270IshIncass', 'DateCreate'];
    }
    return TableReshenia;
}());
export { TableReshenia };
//Класс таблиц для создания Шаблона
var TableTemplate = /** @class */ (function () {
    function TableTemplate() {
        this.displaydataSource = ['Id', 'IdNamedocument', 'NameDocument', 'ManualDoc', 'IdTemplate', 'DateCreate', 'Detal'];
        this.displaydataSourceBody = ['Select', 'IdBody', 'BodyGl1', 'BodyGl2', 'BodyGl3', 'BodyGl4', 'BodyGl4', 'DateCreate'];
        this.selectionBody = new SelectionModel(false, []);
        this.displaydataSourceHeaders = ['Select', 'IdHeaders', 'TextHeade1', 'TextHeade2',
            'TextHeade3', 'TextHeade4', 'TextHeade5', 'TextHeade6', 'TextHeade7', 'TextHeade8', 'TextHeade9', 'TextHeade10', 'DateCreate'];
        this.selectionHeaders = new SelectionModel(false, []);
        this.displaydataSourceStone = ['Select', 'IdStone', 'Stone1', 'Stone2',
            'Stone3', 'Stone4', 'Stone5', 'Stone6', 'Stone7', 'DateCreate'];
        this.selectionStone = new SelectionModel(false, []);
    }
    return TableTemplate;
}());
export { TableTemplate };
//Класс таблиц предпроверки
var PredproverkaTable = /** @class */ (function () {
    function PredproverkaTable() {
        this.displaydataSourceDocumentReglament = ['Id', 'N441__1', 'Status1', 'MesErSt1', 'Status2', 'MesErSt2', 'DSt2', 'D85', 'Detal'];
        this.displaydataSourceDocumentDetalization = ['Id', 'N441__1', 'IdProcedure', 'N333__1',
            'IdUser', 'IdGroup', 'IdDocument', 'N77', 'N441__4'];
    }
    return PredproverkaTable;
}());
export { PredproverkaTable };
var DeloPriem = /** @class */ (function () {
    function DeloPriem() {
        this.displaydataDeloCreate = ['IdDelo', 'Id', 'Id2', 'Command'];
        //Есть ли данные или нет данных
        this.yesdate = true;
    }
    //Добавление в таблицу
    DeloPriem.prototype.addTable = function (tableinfo) {
        this.dataSourceDeloCreate = new MatTableDataSource(tableinfo);
    };
    return DeloPriem;
}());
export { DeloPriem };
var NoAnalizTable = /** @class */ (function () {
    function NoAnalizTable() {
        this.displaydataDeloNo = ['Select', 'D3979', 'Status1Priem', 'MessagePriem', 'Status1Analiz',
            'MessageAnaliz', 'DateCreate', 'Button'];
        this.selectionDelo = new SelectionModel(false, []);
        this.displaydataAnalizNo = ['D3979', 'D3972', 'Color', 'DateAnaliz', 'MessageDate1', 'StrahovieAndOtkazAnaliz',
            'MessageStrahovieAndOtkaz1', 'StatusUhAnaliz', 'MessageStatusUh1', 'Vivod', 'MessageVivod1',
            'D6', 'D1560_2', 'D1560_1', 'DatePeredachi', 'DateZakritia', 'N134', 'D3', 'Kbk', 'OKTMO_old',
            'D09_3', 'N1_1', 'N279', 'OKTMO_new', 'DateCreate', 'Error', 'DateError'];
        this.selectAnalizNo = true;
    }
    NoAnalizTable.prototype.addTableDelo = function (no) {
        this.dataSourceDeloNo = new MatTableDataSource(no);
    };
    NoAnalizTable.prototype.addTableAnaliz = function (analiz) {
        this.dataSourceAnalizNo = new MatTableDataSource(analiz);
    };
    NoAnalizTable.prototype.selectiondelo = function () {
        var _this = this;
        if (this.selectionDelo.selected.length > 0) {
            this.selectionDelo.selected.map(function (delo) {
                _this.addTableAnaliz(delo.AnalizNO);
                _this.selectAnalizNo = false;
            });
        }
        else {
            this.addTableAnaliz(null);
            this.selectAnalizNo = true;
        }
    };
    return NoAnalizTable;
}());
export { NoAnalizTable };
//# sourceMappingURL=TableGenerator.js.map