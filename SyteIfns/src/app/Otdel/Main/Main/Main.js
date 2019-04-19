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
import { Otdel } from '../ModelOtdel/ModelOtdel';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import * as images from '../../../Images/ImageConst';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';
import 'signalr/jquery.signalR.js';
var img = images; //Для WebPack
var Main = /** @class */ (function () {
    function Main(database, matIconRegistry, sanitizer) {
        var _this = this;
        this.matIconRegistry = matIconRegistry;
        this.fullpath = null;
        this.model = null;
        this.hasNestedChild = function (_, nodeData) { return !nodeData.types; };
        this._getChildren = function (node) { return node.children; };
        this.nestedTreeControl = new NestedTreeControl(this._getChildren);
        this.nestedDataSource = new MatTreeNestedDataSource();
        database.dataChange.subscribe(function (data) { return _this.nestedDataSource.data = data; });
        matIconRegistry.addSvgIcon('Acvarius Server', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/Acvarius Server.svg'));
        matIconRegistry.addSvgIcon('DepoStorm 3606', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/DepoStorm 3606.svg'));
        matIconRegistry.addSvgIcon('DL360', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/DL360.svg'));
        matIconRegistry.addSvgIcon('DL580', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/DL580.svg'));
        matIconRegistry.addSvgIcon('IBM 3000', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/IBM 3000.svg'));
        matIconRegistry.addSvgIcon('SHD Acvariuse', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/SHD Acvariuse.svg'));
        matIconRegistry.addSvgIcon('SHD P2000', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/SHD P2000.svg'));
    }
    Main.prototype.selectmodel = function (node) {
        this.fullpath = 'Ветка: ' + node.fullpath;
        this.model = 'Предназначение: ' + node.model;
    };
    Main = __decorate([
        Component(({
            selector: 'app-root',
            templateUrl: '../Html/Main.html',
            styleUrls: ['../Html/MainStyle.css'],
            providers: [Otdel]
        })),
        __metadata("design:paramtypes", [Otdel, MatIconRegistry, DomSanitizer])
    ], Main);
    return Main;
}());
export { Main };
//# sourceMappingURL=Main.js.map