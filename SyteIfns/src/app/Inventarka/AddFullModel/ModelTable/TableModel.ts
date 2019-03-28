import { Users } from '../../ModelInventarization/Inventarization';
import { MatTableDataSource } from '@angular/material';

export class UserTableModel {
    dataSource: MatTableDataSource<Users>;
    displayedColumns = ['IdUser', 'Name', 'TabelNumber', 'Telephon', 'TelephonUndeground', 'IpTelephon', 'NameRules', 'NameOtdel', 'ActionsColumn'];

    public addtableModel(user: Users[]) {
        this.dataSource = new MatTableDataSource<Users>(user);

    }
}