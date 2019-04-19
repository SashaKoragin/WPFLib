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
import { ServersSqlAll } from '../../../../PostZaprosFull/PostFull';
import { ServersTable } from '../../../../FullSetting/SelectTable/TableGenerator';
import { CreateSettingSelect } from '../../../../FullSetting/CreateSetting';
import { ServerAndComputer, ServerModel } from '../Model/ServersModel';
import * as svgsheme from '../../../../Images/Svg/SvgFileConst';
var svg = svgsheme; //Для WebPack
import { deserialize } from 'class-transformer';
var Server = /** @class */ (function () {
    function Server(serverFull) {
        this.serverFull = serverFull;
        this.servermodel = new ServerModel();
        this.server = new ServersTable();
        this.setting = new CreateSettingSelect();
    }
    Server.prototype.ngOnInit = function () {
        var _this = this;
        var settings = this.setting.generateSql(29);
        console.log(JSON.stringify(settings));
        this.serverFull.sqlServer(settings).subscribe(function (model) {
            var server = deserialize(ServerAndComputer, model.toString());
            _this.server.addServers(server.ServerIfns);
            _this.servermodel.select(server.ServerIfns);
        });
    };
    Server.prototype.stylecolor = function (element) {
        switch (element.Status) {
            case 'Success':
                return 'green';
            case 'TimedOut':
                return 'red';
            case 'DestinationHostUnreachable':
                return '#6d3106';
        }
    };
    Server = __decorate([
        Component(({
            selector: 'my-letter',
            templateUrl: '../Html/Servers.html',
            styleUrls: ['../Html/Servers.css'],
            providers: [ServersSqlAll]
        })),
        __metadata("design:paramtypes", [ServersSqlAll])
    ], Server);
    return Server;
}());
export { Server };
//# sourceMappingURL=Servers.js.map