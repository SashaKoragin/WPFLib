import { MatTableDataSource } from '@angular/material';
var UserTableModel = /** @class */ (function () {
    function UserTableModel() {
        this.displayedColumns = ['IdUser', 'Name', 'TabelNumber', 'Telephon', 'TelephonUndeground', 'IpTelephon', 'NameRules', 'NameOtdel', 'ActionsColumn'];
    }
    UserTableModel.prototype.add = function (user) {
        alert(user.Otdel.NameOtdel);
    };
    UserTableModel.prototype.addtableModel = function (user) {
        this.dataSource = new MatTableDataSource(user);
    };
    return UserTableModel;
}());
export { UserTableModel };
//# sourceMappingURL=TableModel.js.map