var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { PostInventar } from '../../../PostZaprosFull/PostInventarization';
import { AllSelected } from '../../ModelInventarization/Inventarization';
import { UserValidation } from '../../AddFullModel/ValidationModel/ValidateTableForm';
import { UserTableModel } from '../../AddFullModel/ModelTable/TableModel';
//import { TableDataSource, ValidatorService } from 'angular4-material-table';
import { deserialize } from 'class-transformer';
var User = /** @class */ (function () {
    function User(httpclient, uservalid) {
        this.httpclient = httpclient;
        this.uservalid = uservalid;
        this.user = new UserTableModel();
        this.select = null;
    }
    User.prototype.ngOnInit = function () {
        var _this = this;
        this.httpclient.alluser(1).subscribe(function (model) {
            if (model) {
                _this.select = deserialize(AllSelected, model.toString());
                _this.user.addtableModel(_this.select.Users);
                // this.table = new Table<Users>(this.select.Users, this.model.modelusers);
                // this.name= new ModelColumns(this.table.models);
            }
        });
    };
    User = __decorate([
        Component(({
            selector: 'equepment',
            templateUrl: '../Html/User.html',
            styleUrls: ['../Html/User.css'],
            providers: [PostInventar, UserValidation]
        })),
        __metadata("design:paramtypes", [PostInventar, UserValidation])
    ], User);
    return User;
}());
export { User };
//# sourceMappingURL=User.js.map