import { Component, OnInit } from '@angular/core';
import { ServersSqlAll } from '../../../../PostZaprosFull/PostFull';
import { ServersTable } from '../../../../FullSetting/SelectTable/TableGenerator';
import { CreateSettingSelect } from '../../../../FullSetting/CreateSetting';
import { ServerAndComputer, ServerIfns, ServerModel } from '../Model/ServersModel';
import * as svgsheme from '../../../../Images/Svg/SvgFileConst';

const svg = svgsheme;  //Для WebPack
import { deserialize } from 'class-transformer';
@Component(({
    selector: 'my-letter',
    templateUrl: '../Html/Servers.html',
    styleUrls: ['../Html/Servers.css'],
    providers:[ServersSqlAll]
}) as any)

export class Server implements OnInit {

    servermodel = new ServerModel();
    server: ServersTable = new ServersTable();
    setting: CreateSettingSelect = new CreateSettingSelect();
    constructor(private serverFull: ServersSqlAll) {

    }

    ngOnInit(): void {
        var settings = this.setting.generateSql(29);
        console.log(JSON.stringify(settings));
        this.serverFull.sqlServer(settings).subscribe(model => {
            var server = deserialize(ServerAndComputer, model.toString());
            this.server.addServers(server.ServerIfns);
            this.servermodel.select(server.ServerIfns);
        });
    }

    stylecolor(element: ServerIfns) {
        switch (element.Status) {
            case 'Success':
                return 'green';
            case 'TimedOut':
                return 'red';
            case 'DestinationHostUnreachable':
                return '#6d3106';
        }
    }
}