//Общепринятая молдель отправки даты на сервер
var DateModel = /** @class */ (function () {
    function DateModel() {
        this.validation = true;
    }
    DateModel.prototype.valid = function () {
        if (this.D85DateStart == null || this.D85DateFinish == null) {
            this.messageerror = 'Не все даты введены для запроса!!!';
            return this.validation = false;
        }
        if (this.D85DateStart > this.D85DateFinish) {
            this.messageerror = 'Дата начала не может быть больше окончания!!!';
            return this.validation = false;
        }
        this.messageerror = null;
        return this.validation = true;
    };
    ///Конвертация даты в модели BDkOut
    DateModel.prototype.convertdate = function (setting, dateStart, dateFinis) {
        var ds = new Date(dateStart);
        var df = new Date(dateFinis);
        setting.ParametrBdkOut.D85DateStart = "/Date(" + ds.getTime() + ")/";
        setting.ParametrBdkOut.D85DateFinish = "/Date(" + df.getTime() + ")/";
    };
    ///Конвертация даты в модели Решения
    DateModel.prototype.convertdateresh = function (setting, dateStart, dateFinis) {
        var ds = new Date(dateStart);
        var df = new Date(dateFinis);
        setting.ParametrReshen.D85DateStart = "/Date(" + ds.getTime() + ")/";
        setting.ParametrReshen.D85DateFinish = "/Date(" + df.getTime() + ")/";
    };
    return DateModel;
}());
export { DateModel };
//# sourceMappingURL=DateModelFull.js.map