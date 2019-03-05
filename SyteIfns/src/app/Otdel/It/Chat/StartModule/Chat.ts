import { Component } from '@angular/core';
import { ChatMessage } from '../Model/ModelChat/MessageMethod';
import { ConnectionResolver } from '../../../../SignalRSignal/ConnectSignalR';

@Component(({
    selector: 'my-chat',
    templateUrl: '../Template/HtmlChat.html',
    styleUrls: ['../Template/CssChat.css']
}) as any)

export class ChatComponent {
    constructor(public signalR: ConnectionResolver) { }

    public chatMessages: ChatMessage[] = [];

    onChatMessage(message: string) {
        this.signalR.conect.invoke('Chat', new ChatMessage(this.signalR.user.ModelUser.UserName, message));
    }


}