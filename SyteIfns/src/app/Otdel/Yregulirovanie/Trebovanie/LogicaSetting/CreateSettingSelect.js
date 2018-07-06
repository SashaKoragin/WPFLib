export var Db;
(function (Db) {
    Db[Db["\u0422\u0435\u0441\u0442"] = 0] = "\u0422\u0435\u0441\u0442";
    Db[Db["\u0420\u0430\u0431\u043E\u0447\u0430\u044F"] = 1] = "\u0420\u0430\u0431\u043E\u0447\u0430\u044F";
})(Db || (Db = {}));
var CreateSettingSelect = /** @class */ (function () {
    function CreateSettingSelect() {
    }
    CreateSettingSelect.prototype.workandtest = function (num, setting) {
        switch (num) {
            case 1:
                return this.testsetting(setting);
            case 2:
                return this.worksetting(setting);
            default: return null;
        }
    };
    CreateSettingSelect.prototype.testsetting = function (setting) {
        setting.Db = 'Test';
        return setting;
    };
    CreateSettingSelect.prototype.worksetting = function (setting) {
        setting.Db = 'Work';
        return setting;
    };
    CreateSettingSelect.prototype.createaddresh = function (resh, setting) {
        setting.Id = 1;
        setting.ParametrSelect.D270 = resh;
        return setting;
    };
    CreateSettingSelect.prototype.createstartresh = function (resh, setting) {
        setting.Id = 2;
        return setting;
    };
    CreateSettingSelect.prototype.createstartincass = function (resh, setting) {
        setting.Id = 3;
        return setting;
    };
    return CreateSettingSelect;
}());
export { CreateSettingSelect };
//# sourceMappingURL=CreateSettingSelect.js.map