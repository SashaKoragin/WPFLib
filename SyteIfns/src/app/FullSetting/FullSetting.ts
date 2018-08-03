//Настройки общие если что сюда добавлять
export class FullSetting {
    //Параметры для решения
    public ParametrReshen: ParametrReshen = new ParametrReshen();
    //Параметры для БДК
    public ParametrBdk: ParametrBdk = new ParametrBdk();
    //Принадлежность БД Тест или рабочая
    public Db: string;
    //Номер процедуры
    public Id:number;
}

class ParametrReshen {
    //Системный номер решения
    public D270: number;

    constructor() {
        this.D270 = 0;
    }
}

class ParametrBdk {
    //Уникальный номер пользователя из Fn74
    public validation: boolean = true;
    public validationmessage: string = null;
    public N269: number = 1008;
    public D05: string = null;

    valid():boolean {
        if (this.N269 !== 0) {
            this.validation = true;
            this.validationmessage = null;
        } else {
            this.validation = false;
            this.validationmessage = 'Атрибут N269 не может быть равен 0!!! Поставте к примеру 1008 Администратор FN74';
        }
        return this.validation;
    }

}
