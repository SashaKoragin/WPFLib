import { FullSetting } from './FullSetting'
import { FormControl } from '@angular/forms';
import { moment } from './FormatDate'
//Общепринятая молдель отправки даты на сервер
export class DateModel {
    public validation: boolean = true;

    public messageerror: string;
    //С какой даты
    public D85DateStart: FormControl = new FormControl(new Date());
    //По какую дату
    public D85DateFinish: FormControl = new FormControl(new Date());

    valid(): boolean {
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
    }
    ///Конвертация даты в модели BDkOut
    convertdate(setting: FullSetting, dateStart: any, dateFinis: any) {
        setting.ParametrBdkOut.D85DateStart = `/Date(${dateStart.getTime()})/`;
        setting.ParametrBdkOut.D85DateFinish = `/Date(${dateFinis.getTime()})/`;
    }

    ///Конвертация даты в модели Решения
    convertdateresh(setting: FullSetting, dateStart: any, dateFinis: any) {
        setting.ParametrReshen.D85DateStart = `/Date(${dateStart.getTime()})/`;
        setting.ParametrReshen.D85DateFinish = `/Date(${dateFinis.getTime()})/`;
    }
}