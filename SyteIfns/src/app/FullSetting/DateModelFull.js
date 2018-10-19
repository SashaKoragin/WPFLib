import { FormControl } from '@angular/forms';
import { moment } from './FormatDate';
//Общепринятая молдель отправки даты на сервер
var DateModel = /** @class */ (function () {
    function DateModel() {
        this.validation = true;
        //С какой даты
        this.D85DateStart = new FormControl(new Date());
        //По какую дату
        this.D85DateFinish = new FormControl(new Date());
    }
    DateModel.prototype.valid = function () {
        if (this.D85DateStart.value == null || this.D85DateFinish.value == null) {
            this.messageerror = 'Не все даты введены для запроса!!!';
            return this.validation = false;
        }
        if (moment(this.D85DateStart.value).format('MM.DD.YYYY') > moment(this.D85DateFinish.value).format('MM.DD.YYYY')) {
            this.messageerror = 'Дата начала не может быть больше окончания!!!';
            return this.validation = false;
        }
        this.messageerror = null;
        return this.validation = true;
    };
    ///Конвертация даты в модели BDkOut
    DateModel.prototype.convertdate = function (setting, dateStart, dateFinis) {
        setting.ParametrBdkOut.D85DateStart = "/Date(" + dateStart.getTime() + ")/";
        setting.ParametrBdkOut.D85DateFinish = "/Date(" + dateFinis.getTime() + ")/";
    };
    ///Конвертация даты в модели Решения
    DateModel.prototype.convertdateresh = function (setting, dateStart, dateFinis) {
        setting.ParametrReshen.D85DateStart = "/Date(" + dateStart.getTime() + ")/";
        setting.ParametrReshen.D85DateFinish = "/Date(" + dateFinis.getTime() + ")/";
    };
    return DateModel;
}());
export { DateModel };
//# sourceMappingURL=DateModelFull.js.map