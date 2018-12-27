import { Component, OnInit, OnDestroy } from '@angular/core';
import { ISignalRConnection, BroadcastEventListener } from 'ng2-signalr';
import { ActivatedRoute } from '@angular/router';
import { ChatMessage } from '../Model/ModelChat/MessageMethod';
import { Subscription } from 'rxjs/Subscription';


@Component(({
    selector: 'my-chat',
    templateUrl: '../Template/HtmlChat.html',
    styleUrls: ['../Template/CssChat.css']
}) as any)

export class ChatComponent implements OnInit, OnDestroy {
    constructor(private route: ActivatedRoute) {
        this.connection = this.route.snapshot.data['connection'];
    }
    public chatMessages: ChatMessage[]=[];
    public connection: ISignalRConnection;
    public subscription: Subscription;
    ngOnInit() {
        try {
            let onMessageSent$ = new BroadcastEventListener<ChatMessage>('OnMessageSent');
            this.connection.listen(onMessageSent$);
            this.subscription = onMessageSent$.subscribe((sendChatMessage: ChatMessage) => {
                this.chatMessages.push(sendChatMessage);
            });
        } catch (e) {
            alert(e.toString());
        }

    }

    onChatMessage(message: string) {
        try {
            console.log('onChatMessage');
            this.connection.invoke('Chat', new ChatMessage('Hannes', message));
        } catch (err) {
            console.log('Welcome Error: ' + err);
        }
    }






    //Выход
    ngOnDestroy(): void {
        console.log('ngOnDestroy');
        this.subscription.unsubscribe();
        this.connection.stop();
    }
}