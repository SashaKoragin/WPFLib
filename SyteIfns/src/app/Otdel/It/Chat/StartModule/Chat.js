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
import { BroadcastEventListener } from 'ng2-signalr';
import { ActivatedRoute } from '@angular/router';
import { ChatMessage } from '../Model/ModelChat/MessageMethod';
var ChatComponent = /** @class */ (function () {
    function ChatComponent(route) {
        this.route = route;
        this.chatMessages = [];
        this.connection = this.route.snapshot.data['connection'];
    }
    ChatComponent.prototype.ngOnInit = function () {
        var _this = this;
        try {
            var onMessageSent$ = new BroadcastEventListener('OnMessageSent');
            this.connection.listen(onMessageSent$);
            this.subscription = onMessageSent$.subscribe(function (sendChatMessage) {
                _this.chatMessages.push(sendChatMessage);
            });
        }
        catch (e) {
            alert(e.toString());
        }
    };
    ChatComponent.prototype.onChatMessage = function (message) {
        try {
            console.log('onChatMessage');
            this.connection.invoke('Chat', new ChatMessage('Hannes', message));
        }
        catch (err) {
            console.log('Welcome Error: ' + err);
        }
    };
    //Выход
    ChatComponent.prototype.ngOnDestroy = function () {
        console.log('ngOnDestroy');
        this.subscription.unsubscribe();
        this.connection.stop();
    };
    ChatComponent = __decorate([
        Component(({
            selector: 'my-chat',
            templateUrl: '../Template/HtmlChat.html',
            styleUrls: ['../Template/CssChat.css']
        })),
        __metadata("design:paramtypes", [ActivatedRoute])
    ], ChatComponent);
    return ChatComponent;
}());
export { ChatComponent };
//# sourceMappingURL=Chat.js.map