import { Component, Output, Input, EventEmitter } from '@angular/core';
import { ChatMessage } from './MessageMethod';

@Component({
    selector: 'chat-cmp',
    templateUrl: 'Chat.html',
    styleUrls: ['Chat.css']
})

export class Chat {

    message: string = '';
    @Output() onMessage = new EventEmitter();
    @Output() onTextChanged = new EventEmitter();
    @Input() messages: ChatMessage[] = [];

    send() {
        console.log('send');
        this.onMessage.emit(this.message);
        this.message = '';
        
    }

    onMessageChanged() {
        this.onTextChanged.emit(this.message);
    }
}

