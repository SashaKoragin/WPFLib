import { MatTableDataSource } from '@angular/material';
var ModelColumns = /** @class */ (function () {
    function ModelColumns(models) {
        this.model = null;
        this.model = models;
    }
    return ModelColumns;
}());
export { ModelColumns };
var ModelsTable = /** @class */ (function () {
    function ModelsTable() {
        this.modelusers = [
            { key: 'id', header: 'Учетный номер', cell: function (row) { return "" + row.IdUser; } },
            { key: 'name', header: 'Имя пользователя', cell: function (row) { return "" + row.Name; } },
            { key: 'tabelNumber', header: 'Табельный номер', cell: function (row) { return "" + row.TabelNumber; } },
            { key: 'telephon', header: 'Телефон внутренний', cell: function (row) { return "" + row.Telephon; } },
            { key: 'telephonUndeground', header: 'Телефон городской', cell: function (row) { return "" + row.TelephonUndeground; } },
            { key: 'ipTelephon', header: 'IP Телефона', cell: function (row) { return "" + row.IpTelephon; } },
            { key: 'macTelephon', header: 'Мак адрес', cell: function (row) { return "" + row.MacTelephon; } },
            { key: 'nameRules', header: 'Наименование роли', cell: function (row) { return "" + (typeof row.Rules === 'undefined' ? null : row.Rules.NameRules); } },
            { key: 'nameOtdel', header: 'Наименование отдела', cell: function (row) { return "" + (typeof row.Otdel === 'undefined' ? null : row.Otdel.NameOtdel); } },
            { key: 'button', header: 'Наименование отдела', cell: function (row) { return '<button></button>'; } }
        ];
    }
    return ModelsTable;
}());
export { ModelsTable };
var Table = /** @class */ (function () {
    function Table(model, table) {
        this.model = model;
        this.table = table;
        this.models = { columns: this.table, datasource: new MatTableDataSource(this.model), displayedColumns: this.table.map(function (x) { return x.key; }) };
    }
    return Table;
}());
export { Table };
//# sourceMappingURL=ModelTable.js.map