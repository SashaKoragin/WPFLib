export class FullSetting {

    constructor() {
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
    //Параметры для решения
    public ParametrReshen: ParametrReshen;
    //Параметры для БДК
    public ParametrBdk: ParametrBdk;
    //Шаблон для печати
    public UseTemplate: UseTemplate;
    //Параметр для выбора данных с сервиса
    public ParamService: ParamService;
    //Параметры отправки БДК
    public ParametrBdkOut: ParametrBdkOut;
    //Параметры предпроверки
    public ParamPredproverka: ParamPredproverka;
    //Дела приема КРСБ
    public DeloPriem: DeloPriem;
    //Создание дел КРСБ
    public DeloCreate: DeloCreate;
    //Отчеты Камеральный 5
    public ReportRvs: ReportRvs;
    //Модель пользователя
    public ModelUser: ModelUser;
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

// Подстановка параметра для выборки с сервиса данных выборки
class ParamService {
    IdCommand:number;
}
//Дела приема КРСБ
class DeloPriem {
    DelaPriem: Array<string>;

   public addarraystring(mass: string[]) {
        this.DelaPriem = mass;
    }
}
//Создание карточек КРСБ
class DeloCreate {
    DateDelo: string;
    D3979: number;
    Okato:string;

  public datezaprosa( datedelo: any) {
      this.DateDelo = `/Date(${datedelo.getTime()})/`;
  }
}
//Настройки для камерального 5 Страховые взносы
class ReportRvs {
    Qvartal: number;
    God: number;
    ReportVid: number;
    P1: number;
    Data: string;
    ErrDetal: number;
    //Метод конвертации даты в string
    public datezaprosa(data: any) {
        this.Data = `/Date(${data.getTime()})/`;
    }
}
//Модель пользователя
export class ModelUser {

    Login: string = null;
    Password: string = null;
    UserName: string = null;
    Guid: string = this.newGuid();
    UserNameGuide: string = this.UserName + this.Guid;
    ///Ошибка с сервера
    Error: string = null;
     newGuid() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
}