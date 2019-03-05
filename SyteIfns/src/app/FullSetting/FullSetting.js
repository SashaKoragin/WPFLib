var FullSetting = /** @class */ (function () {
    function FullSetting() {
        this.ParametrReshen = new ParametrReshen();
        this.ParametrBdk = new ParametrBdk();
        this.UseTemplate = new UseTemplate();
        this.ParamService = new ParamService();
        this.ParametrBdkOut = new ParametrBdkOut();
        this.ParamPredproverka = new ParamPredproverka();
        this.DeloPriem = new DeloPriem();
        this.DeloCreate = new DeloCreate();
        this.DeloCreate = new DeloCreate();
        this.ReportRvs = new ReportRvs();
        this.ModelUser = new ModelUser();
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
// Подстановка параметра для выборки с сервиса данных выборки
var ParamService = /** @class */ (function () {
    function ParamService() {
    }
    return ParamService;
}());
//Дела приема КРСБ
var DeloPriem = /** @class */ (function () {
    function DeloPriem() {
    }
    DeloPriem.prototype.addarraystring = function (mass) {
        this.DelaPriem = mass;
    };
    return DeloPriem;
}());
//Создание карточек КРСБ
var DeloCreate = /** @class */ (function () {
    function DeloCreate() {
    }
    DeloCreate.prototype.datezaprosa = function (datedelo) {
        this.DateDelo = "/Date(" + datedelo.getTime() + ")/";
    };
    return DeloCreate;
}());
//Настройки для камерального 5 Страховые взносы
var ReportRvs = /** @class */ (function () {
    function ReportRvs() {
    }
    //Метод конвертации даты в string
    ReportRvs.prototype.datezaprosa = function (data) {
        this.Data = "/Date(" + data.getTime() + ")/";
    };
    return ReportRvs;
}());
//Модель пользователя
var ModelUser = /** @class */ (function () {
    function ModelUser() {
        this.Login = null;
        this.Password = null;
        this.UserName = null;
        this.Guid = this.newGuid();
        this.UserNameGuide = this.UserName + this.Guid;
        ///Ошибка с сервера
        this.Error = null;
    }
    ModelUser.prototype.newGuid = function () {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    };
    return ModelUser;
}());
export { ModelUser };
//# sourceMappingURL=FullSetting.js.map