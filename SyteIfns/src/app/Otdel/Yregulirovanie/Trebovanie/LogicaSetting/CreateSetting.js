var CreateSetting = /** @class */ (function () {
    function CreateSetting() {
    }
    CreateSetting.prototype.workandtest = function (num, setting) {
        switch (num) {
            case 1:
                return this.testsetting(setting);
            case 2:
                return this.worksetting(setting);
            default: return null;
        }
    };
    CreateSetting.prototype.testsetting = function (setting) {
        setting.Db = 'Test';
        return setting;
    };
    CreateSetting.prototype.worksetting = function (setting) {
        setting.Db = 'Work';
        return setting;
    };
    return CreateSetting;
}());
export { CreateSetting };
//# sourceMappingURL=CreateSetting.js.map