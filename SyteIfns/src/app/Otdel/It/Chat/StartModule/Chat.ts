import { Component, OnInit } from '@angular/core';
import { ISignalRConnection } from 'ng2-signalr';
import { ActivatedRoute } from '@angular/router';

@Component(({
    selector: 'my-chat',
    templateUrl: '../Template/HtmlChat.html',
    styleUrls: ['../Template/CssChat.css']
}) as any)

export class ChatComponent implements OnInit {
    constructor(private route: ActivatedRoute) { }
    public connection: ISignalRConnection;
    title:string;
    ngOnInit() {
        this.title = 'Привет мир!!!';
        this.connection = this.route.snapshot.data['connection'];
    }

}