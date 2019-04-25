var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { SignalR, BroadcastEventListener } from 'ng2-signalr';
import { Injectable } from '@angular/core';
import { FullSetting } from '../FullSetting/FullSetting';
var ConnectionResolver = /** @class */ (function () {
    function ConnectionResolver(signalR) {
        this.signalR = signalR;
        this.user = new FullSetting();
        ///Чат Messager
        this.chatMessages = [];
        this.conect = null;
        this.status = null;
    }
    //Создается соединение
    ConnectionResolver.prototype.createconection = function () {
        try {
            var options = {
                hubName: 'ServiceMessage',
                qs: { user: this.user.ModelUser.UserName, guid: this.user.ModelUser.Guid },
                url: 'http://localhost:8059/signalr',
                executeErrorsInZone: true,
                executeEventsInZone: true,
                executeStatusChangeInZone: true
                //Можно задать ping интервал
            };
            console.log('Создали соединение!!!');
            this.conect = this.signalR.createConnection(options);
        }
        catch (e) {
            alert(e.toString());
        }
    };
    ///Запуск подписи на событие
    ConnectionResolver.prototype.start = function () {
        if (this.status === null) {
            this.conect.start();
            console.log('Запустили сервер!');
            this.statususe();
            this.chatMessanger();
        }
    };
    ConnectionResolver.prototype.statususe = function () {
        var _this = this;
        this.conect.status.subscribe(function (state) {
            _this.status = state;
            console.log('Подписались на status');
        });
    };
    ConnectionResolver.prototype.stop = function () {
        if (this.status.name === 'connected') {
            console.log('Остановили сервер!');
            this.conect.stop();
            this.status = null;
            this.welcome = null;
        }
    };
    ConnectionResolver.prototype.welcomestart = function () {
        var _this = this;
        var welcome = new BroadcastEventListener('Welcome');
        this.conect.listen(welcome);
        welcome.subscribe(function (welcome) {
            _this.welcome = welcome;
            console.log('Подписались на привествие!');
        });
    };
    ConnectionResolver.prototype.chatMessanger = function () {
        var _this = this;
        var onMessageSent = new BroadcastEventListener('SendMessageAll');
        this.conect.listen(onMessageSent);
        onMessageSent.subscribe(function (sendChatMessage) {
            _this.chatMessages.push(sendChatMessage);
            console.log('Подписались на чат!');
        });
    };
    ConnectionResolver = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [SignalR])
    ], ConnectionResolver);
    return ConnectionResolver;
}());
export { ConnectionResolver };
//# sourceMappingURL=ConnectSignalR.js.map