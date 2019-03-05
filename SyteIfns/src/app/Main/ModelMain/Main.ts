import { Component } from '@angular/core';
import { ConnectionResolver } from '../../SignalRSignal/ConnectSignalR'
@Component({
    selector: 'app-root',
    templateUrl: '../Html/Main.html',
    styleUrls: ['../Html/Main.css']
})
export class Root {
    constructor(private signalR: ConnectionResolver) {}
}