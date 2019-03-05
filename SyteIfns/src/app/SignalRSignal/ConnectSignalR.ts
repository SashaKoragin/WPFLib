import { SignalR, ISignalRConnection, IConnectionOptions, BroadcastEventListener, ConnectionStatus } from 'ng2-signalr';
import { Injectable } from '@angular/core';
import { FullSetting } from '../FullSetting/FullSetting';
import { ChatMessage } from  '../Otdel/It/Chat/Model/ModelChat/MessageMethod';

@Injectable()
export class ConnectionResolver {

    public user: FullSetting = new FullSetting();
    public welcome: string;
    ///Чат Messager
    public chatMessages: ChatMessage[] = [];
    conect: ISignalRConnection = null;
    status: ConnectionStatus = null;

    constructor(public signalR: SignalR) { }

    //Создается соединение
    createconection() {
        try {
            var options: IConnectionOptions = {
                hubName: 'ServiceMessage',
                qs: { user: this.user.ModelUser.UserName, guid: this.user.ModelUser.Guid},
                url: 'http://i7751-w00000745:8059/signalr',
                executeErrorsInZone: true,
                executeEventsInZone: true,
                executeStatusChangeInZone: true
                //Можно задать ping интервал
            }
            console.log('Создали соединение!!!');
            this.conect = this.signalR.createConnection(options);
        } catch (e) {
            alert(e.toString());
        }
    }

    ///Запуск подписи на событие
     start() {
        if (this.status === null) {
            this.conect.start();
            console.log('Запустили сервер!');
            this.statususe();
            this.chatMessanger();
        }

    }

    private statususe() {
        this.conect.status.subscribe((state: ConnectionStatus) => {
            this.status = state;
            console.log('Подписались на status');
        });
    }

    stop() {
        if (this.status.name === 'connected') {
            console.log('Остановили сервер!');
            this.conect.stop();
            this.status = null;
            this.welcome = null;
        }
    }

    welcomestart() {
        let welcome = new BroadcastEventListener<string>('Welcome');
        this.conect.listen(welcome);
        welcome.subscribe((welcome: string) => {
            this.welcome = welcome;
            console.log('Подписались на привествие!');
        });
    }

    chatMessanger() {
        let onMessageSent = new BroadcastEventListener<ChatMessage>('SendMessageAll');
        this.conect.listen(onMessageSent);
        onMessageSent.subscribe((sendChatMessage: ChatMessage) => {
            this.chatMessages.push(sendChatMessage);
            console.log('Подписались на чат!');
        });
    }
}