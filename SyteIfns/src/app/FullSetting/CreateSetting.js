//Переключатель для решений
var DataBase = /** @class */ (function () {
    function DataBase() {
        this.databases = new Array();
        this.db = new DataBases(1, "Тест");
        this.pusharray();
    }
    DataBase.prototype.pusharray = function () {
        this.databases.push(new DataBases(1, "Тест"));
        this.databases.push(new DataBases(2, "Рабочая"));
    };
    return DataBase;
}());
export { DataBase };
var DataBases = /** @class */ (function () {
    function DataBases(num, db) {
        this.num = num;
        this.db = db;
    }
    return DataBases;
}());
//Класс для генерации настроек для процедур
var CreateSettingSelect = /** @class */ (function () {
    function CreateSettingSelect() {
    }
    //Выбор БД
    CreateSettingSelect.prototype.workandtest = function (num, setting) {
        switch (num) {
            case 1:
                return this.testsetting(setting);
            case 2:
                return this.worksetting(setting);
            default: return null;
        }
    };
    //Тестовая БД
    CreateSettingSelect.prototype.testsetting = function (setting) {
        setting.Db = 'Test';
        return setting;
    };
    //Рабочая БД
    CreateSettingSelect.prototype.worksetting = function (setting) {
        setting.Db = 'Work';
        return setting;
    };
    //Добавления системного номеры на обработку
    CreateSettingSelect.prototype.createaddresh = function (resh, setting) {
        setting.Id = 1;
        setting.ParametrReshen.D270 = resh;
        return setting;
    };
    //Запуск Автомата по решениям
    CreateSettingSelect.prototype.createstartresh = function (resh, setting) {
        setting.Id = 2;
        return setting;
    };
    //Запуск автомата по инкассовым поручениям
    CreateSettingSelect.prototype.createstartincass = function (resh, setting) {
        setting.Id = 3;
        return setting;
    };
    CreateSettingSelect.prototype.procedurebdk = function (numprocedure, iduser, message, setting) {
        setting.Id = numprocedure;
        setting.ParametrBdk.N269 = iduser;
        setting.ParametrBdk.D05 = message;
        return setting;
    };
    return CreateSettingSelect;
}());
export { CreateSettingSelect };
//# sourceMappingURL=CreateSetting.js.map