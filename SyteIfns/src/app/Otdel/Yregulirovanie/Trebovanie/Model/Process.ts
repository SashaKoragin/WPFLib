export class BlocsInfoButton {

    blocks:boolean = false;
    messagestatus:string;

    blockbuttonreshen(message:string = null) {
        if (!this.blocks) {
            this.blocks = true;
            this.messagestatus = 'Запущен процесс по выставлению Решений!!!';
        } else {
            this.blocks = false;
            this.messagestatus = message;
        }
    }

    blockbuttonincass(message: string = null) {
        if (!this.blocks) {
            this.blocks = true;
            this.messagestatus = 'Запущен процесс по выставлению Инкассовых поручений!!!';
        } else {
            this.blocks = false;
            this.messagestatus = message;
        }
    }
}