//Работа с интерфейсом блокировка сообщения и ТД MVVM
var BlocsInfoButton = /** @class */ (function () {
    function BlocsInfoButton() {
        this.blocks = false;
    }
    BlocsInfoButton.prototype.blockbuttonreshen = function (message) {
        if (message === void 0) { message = null; }
        if (!this.blocks) {
            this.blocks = true;
            this.messagestatus = 'Запущен процесс по выставлению Решений!!!';
        }
        else {
            this.blocks = false;
            this.messagestatus = message;
        }
    };
    BlocsInfoButton.prototype.blockbuttonincass = function (message) {
        if (message === void 0) { message = null; }
        if (!this.blocks) {
            this.blocks = true;
            this.messagestatus = 'Запущен процесс по выставлению Инкассовых поручений!!!';
        }
        else {
            this.blocks = false;
            this.messagestatus = message;
        }
    };
    BlocsInfoButton.prototype.blockprocedure = function (message) {
        if (!this.blocks) {
            this.blocks = true;
            this.messagestatus = 'Запущен процесс по ' + message + '!!!';
        }
        else {
            this.blocks = false;
            this.messagestatus = message;
        }
    };
    BlocsInfoButton.prototype.serverrestmessage = function (message) {
        this.messagestatus = message;
    };
    return BlocsInfoButton;
}());
export { BlocsInfoButton };
//# sourceMappingURL=ProcessFull.js.map