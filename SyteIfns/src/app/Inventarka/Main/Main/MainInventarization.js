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
import { Inventar } from '../Model/ModelInventarization';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { AuthIdentification } from '../../../PostZaprosFull/PostInventarization';
var MainInventar = /** @class */ (function () {
    function MainInventar(database, authService) {
        var _this = this;
        this.authService = authService;
        this.fullpath = null;
        this.model = null;
        this.welcome = null;
        this.hasNestedChild = function (_, nodeData) { return !nodeData.types; };
        this._getChildren = function (node) { return node.children; };
        this.welcome = 'Добро пожаловать: ' + authService.fullSelect.Users.Name;
        this.nestedTreeControl = new NestedTreeControl(this._getChildren);
        this.nestedDataSource = new MatTreeNestedDataSource();
        database.dataChange.subscribe(function (data) { return _this.nestedDataSource.data = data; });
    }
    MainInventar.prototype.selectmodel = function (node) {
        this.fullpath = 'Ветка: ' + node.fullpath;
        this.model = 'Предназначение: ' + node.model;
    };
    MainInventar = __decorate([
        Component(({
            selector: 'app-root',
            templateUrl: '../Html/Inventarization.html',
            styleUrls: ['../Html/Inventarization.css'],
            providers: [Inventar]
        })),
        __metadata("design:paramtypes", [Inventar, AuthIdentification])
    ], MainInventar);
    return MainInventar;
}());
export { MainInventar };
//# sourceMappingURL=MainInventarization.js.map