//Настройки общие если что сюда добавлять
var FullSetting = /** @class */ (function () {
    function FullSetting() {
        //Параметры для решения
        this.ParametrReshen = new ParametrReshen();
        //Параметры для БДК
        this.ParametrBdk = new ParametrBdk();
        //Шаблон для печати
        this.UseTemplate = new UseTemplate();
        //Параметр для выбора данных с сервиса
        this.ParamService = new ParamService();
        //Параметры отправки БДК
        this.ParametrBdkOut = new ParametrBdkOut();
        //Параметры предпроверки
        this.ParamPredproverka = new ParamPredproverka();
    }
    return FullSetting;
}());
export { FullSetting };
var ParametrReshen = /** @class */ (function () {
    function ParametrReshen() {
        this.D270 = 0;
    }
    return ParametrReshen;
}());
var ParametrBdk = /** @class */ (function () {
    function ParametrBdk() {
        //Уникальный номер пользователя из Fn74
        this.validation = true;
        this.validationmessage = null;
        this.N269 = 1008;
        this.D05 = null;
    }
    ParametrBdk.prototype.valid = function () {
        if (this.N269 !== 0) {
            this.validation = true;
            this.validationmessage = null;
        }
        else {
            this.validation = false;
            this.validationmessage = 'Атрибут N269 не может быть равен 0!!! Поставте к примеру 1008 Администратор FN74';
        }
        return this.validation;
    };
    return ParametrBdk;
}());
//Настройки предпроверки
var ParamPredproverka = /** @class */ (function () {
    function ParamPredproverka() {
        this.N441 = 0;
    }
    return ParamPredproverka;
}());
//Класс шаблона
var UseTemplate = /** @class */ (function () {
    function UseTemplate() {
        //Номер шаблона
        this.IdTemplate = 0;
    }
    return UseTemplate;
}());
//Параметры отправки Бдк даты сообщений
var ParametrBdkOut = /** @class */ (function () {
    function ParametrBdkOut() {
    }
    return ParametrBdkOut;
}());
var ParamService = /** @class */ (function () {
    function ParamService() {
    }
    return ParamService;
}());
//# sourceMappingURL=FullSetting.js.map