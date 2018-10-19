//Настройки общие если что сюда добавлять
export class FullSetting {
    //Параметры для решения
    public ParametrReshen: ParametrReshen = new ParametrReshen();
    //Параметры для БДК
    public ParametrBdk: ParametrBdk = new ParametrBdk();

    //Шаблон для печати
    public UseTemplate: UseTemplate = new UseTemplate();
    //Параметр для выбора данных с сервиса
    public ParamService: ParamService = new ParamService();
    //Параметры отправки БДК
    public ParametrBdkOut: ParametrBdkOut = new ParametrBdkOut();
    //Параметры предпроверки
    public ParamPredproverka: ParamPredproverka = new ParamPredproverka();
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
    //С какой даты передаю в конвертированном порядке в классе ParametrReshen
    public D85DateStart: string;
    //По какую дату передаю в конвертированном порядке в классе ParametrReshen
    public D85DateFinish: string;
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
//Настройки предпроверки
class ParamPredproverka {
    public N441:number = 0;
}
//Класс шаблона
class UseTemplate {
    //Номер шаблона
    public IdTemplate: number = 0;
}
//Параметры отправки Бдк даты сообщений
class ParametrBdkOut {
    //С какой даты передаю в конвертированном порядке в классе DateModelFull
    public D85DateStart: string;
    //По какую дату передаю в конвертированном порядке в классе DateModelFull
    public D85DateFinish: string;
}

class ParamService {
    IdCommand:number;
}