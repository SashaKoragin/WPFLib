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
import { ModelColumns, ModelsTable, Table } from '../../ModelTable/Model/ModelTable';
import { AllSelected } from '../../ModelInventarization/Inventarization';
import { deserialize } from 'class-transformer';
var User = /** @class */ (function () {
    function User(httpclient) {
        this.httpclient = httpclient;
        this.name = null;
        this.model = new ModelsTable();
        this.table = null;
        this.select = null;
    }
    User.prototype.ngOnInit = function () {
        var _this = this;
        this.httpclient.alluser(1).subscribe(function (model) {
            if (model) {
                _this.select = deserialize(AllSelected, model.toString());
                _this.table = new Table(_this.select.Users, _this.model.modelusers);
                _this.name = new ModelColumns(_this.table.models);
            }
        });
    };
    User = __decorate([
        Component(({
            selector: 'equepment',
            templateUrl: '../Html/User.html',
            styleUrls: ['../Html/User.css'],
            providers: [PostInventar]
        })),
        __metadata("design:paramtypes", [PostInventar])
    ], User);
    return User;
}());
export { User };
//# sourceMappingURL=User.js.map