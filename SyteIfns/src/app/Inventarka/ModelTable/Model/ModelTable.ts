import { MatTableDataSource} from '@angular/material';
import { Users } from '../../ModelInventarization/Inventarization';


export class ModelColumns {

    constructor(models:any) {
        this.model = models;
    }



    public model = null;

}


export class ModelsTable {
    public modelusers = [
    { key: 'id', header: 'Учетный номер', cell: (row: Users) => `${row.IdUser}` },
    { key: 'name', header: 'Имя пользователя', cell: (row: Users) => `${row.Name}` },
    { key: 'tabelNumber', header: 'Табельный номер', cell: (row: Users) => `${row.TabelNumber}` },
    { key: 'telephon', header: 'Телефон внутренний', cell: (row: Users) => `${row.Telephon}` },
    { key: 'telephonUndeground', header: 'Телефон городской', cell: (row: Users) => `${row.TelephonUndeground}` },
    { key: 'ipTelephon', header: 'IP Телефона', cell: (row: Users) => `${row.IpTelephon}` },
    { key: 'macTelephon', header: 'Мак адрес', cell: (row: Users) => `${row.MacTelephon}` },
    { key: 'nameRules', header: 'Наименование роли', cell: (row: Users) => `${typeof row.Rules === 'undefined' ? null : row.Rules.NameRules}` },
    { key: 'nameOtdel', header: 'Наименование отдела', cell: (row: Users) => `${typeof row.Otdel === 'undefined' ? null : row.Otdel.NameOtdel}` },
        { key: 'button', header: 'Наименование отдела', cell: (row: string) =>'<button></button>' }
    ];
}

export class Table<T> {

    constructor(public  model: T[],public  table: any) {
    }


    public models = { columns: this.table, datasource: new MatTableDataSource<T>(this.model), displayedColumns: this.table.map(x => x.key) };
}
