export class ChatMessage {
    public Who: string
    public Message: string
    constructor(public who: string, public message: string) {
        this.Who = who;
        this.Message = message;
    }
}