import { FullSetting } from './FullSetting';
//Переключатель для решений
export class DataBase {

    public databases: DataBases[] =[
        { num: 1, db: 'Тест' },
        { num: 2, db: 'Рабочая' }
    ];

    public db: DataBases = this.databases[0];
}
class DataBases {
    num: number;
    db: string;
}


//Класс для генерации настроек для процедур
export class CreateSettingSelect {

    generateSql(sqlcommand: number, db: string='Work'): FullSetting {
        var setting: FullSetting = new FullSetting();
        setting.Id = sqlcommand;
        setting.Db = db;
        return setting;
    }


    //Выбор БД
    workandtest(num: number, setting: FullSetting): FullSetting {
        switch (num) {
            case 1:
                return this.testsetting(setting);
            case 2:
                return this.worksetting(setting);
            default: return null;
        }
    }
    //Тестовая БД
    testsetting(setting: FullSetting): FullSetting {
        setting.Db = 'Test';
        return setting;
    }
    //Рабочая БД
    worksetting(setting: FullSetting): FullSetting {
        setting.Db = 'Work';
        return setting;
    }

    //Добавления системного номеры на обработку
    createaddresh(resh: number, setting: FullSetting): FullSetting {
        setting.Id = 1;
        setting.ParametrReshen.D270 = resh;
        return setting;
    }
    //Запуск Автомата по решениям
    createstartresh(resh: number, setting: FullSetting): FullSetting {
        setting.Id = 2;
        return setting;
    }
    //Запуск автомата по инкассовым поручениям
    createstartincass(resh: number, setting: FullSetting): FullSetting {
        setting.Id = 3;
        return setting;
    }
    procedurebdk(numprocedure: number, iduser: number, message: string, setting: FullSetting):FullSetting {
        setting.Id = numprocedure;
        setting.ParametrBdk.N269 = iduser;
        setting.ParametrBdk.D05 = message;
        return setting;
    }
}
//Генерация параметра для сервиса
export class GenerateParamService {

   public setting = new FullSetting();
    constructor(id: number) {
        this.setting.ParamService.IdCommand = id;
    }
}