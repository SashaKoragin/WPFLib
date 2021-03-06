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
import { ChatMessage } from '../Model/ModelChat/MessageMethod';
import { ConnectionResolver } from '../../../../SignalRSignal/ConnectSignalR';
var ChatComponent = /** @class */ (function () {
    function ChatComponent(signalR) {
        this.signalR = signalR;
        this.chatMessages = [];
    }
    ChatComponent.prototype.onChatMessage = function (message) {
        this.signalR.conect.invoke('Chat', new ChatMessage(this.signalR.user.ModelUser.UserName, message));
    };
    ChatComponent = __decorate([
        Component(({
            selector: 'my-chat',
            templateUrl: '../Template/HtmlChat.html',
            styleUrls: ['../Template/CssChat.css']
        })),
        __metadata("design:paramtypes", [ConnectionResolver])
    ], ChatComponent);
    return ChatComponent;
}());
export { ChatComponent };
//# sourceMappingURL=Chat.js.map