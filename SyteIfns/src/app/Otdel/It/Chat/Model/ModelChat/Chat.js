var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Output, Input, EventEmitter } from '@angular/core';
var Chat = /** @class */ (function () {
    function Chat() {
        this.message = '';
        this.onMessage = new EventEmitter();
        this.onTextChanged = new EventEmitter();
        this.messages = [];
    }
    Chat.prototype.send = function () {
        console.log('send');
        this.onMessage.emit(this.message);
        this.message = '';
    };
    Chat.prototype.onMessageChanged = function () {
        this.onTextChanged.emit(this.message);
    };
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], Chat.prototype, "onMessage", void 0);
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], Chat.prototype, "onTextChanged", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Array)
    ], Chat.prototype, "messages", void 0);
    Chat = __decorate([
        Component({
            selector: 'chat-cmp',
            templateUrl: 'Chat.html',
            styleUrls: ['Chat.css']
        })
    ], Chat);
    return Chat;
}());
export { Chat };
//# sourceMappingURL=Chat.js.map