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
    return BlocsInfoButton;
}());
export { BlocsInfoButton };
//# sourceMappingURL=Process.js.map