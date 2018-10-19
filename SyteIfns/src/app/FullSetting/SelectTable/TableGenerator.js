import { SelectionModel } from '@angular/cdk/collections';
var TableLetter = /** @class */ (function () {
    function TableLetter() {
        this.displaydataSource = ['id', 'iddoc', 'name', 'date', 'detal', 'vig'];
        this.displaydataSourceDetal = ['iddoc', 'imns', 'nameimns', 'namebdk', 'datebdk'];
    }
    return TableLetter;
}());
export { TableLetter };
var TableReshenia = /** @class */ (function () {
    function TableReshenia() {
        this.displaydataSource = ['d270', 'idstatus', 'error', 'dateBlokReshenie', 'idstat2', 'errorIncass', 'dateBlokIncass', 'detal'];
        this.displaydataSourceDetalSysNum = ['D865Res', 'D270', 'N1', 'Summ', 'N120', 'D850Res', 'D851Res', 'D270IshRes', 'DateCreate'];
        this.displaydataSourceDetalIncass = ['D851Res_1', 'D850Incass', 'D851Incass', 'Summ', 'D270IshIncass', 'DateCreate'];
    }
    return TableReshenia;
}());
export { TableReshenia };
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
var PredproverkaTable = /** @class */ (function () {
    function PredproverkaTable() {
        this.displaydataSourceDocumentReglament = ['Id', 'N441__1', 'Status1', 'MesErSt1', 'Status2', 'MesErSt2', 'DSt2', 'D85', 'Detal'];
        this.displaydataSourceDocumentDetalization = ['Id', 'N441__1', 'IdProcedure', 'N333__1',
            'IdUser', 'IdGroup', 'IdDocument', 'N77', 'N441__4'];
    }
    return PredproverkaTable;
}());
export { PredproverkaTable };
//# sourceMappingURL=TableGenerator.js.map