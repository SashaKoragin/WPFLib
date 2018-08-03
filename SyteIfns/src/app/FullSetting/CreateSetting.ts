import { FullSetting } from './FullSetting'
//Переключатель для решений
export class DataBase {
    public databases =new Array<DataBases>();
    public db: DataBases = new DataBases(1, "Тест");

    constructor() {
        this.pusharray();
    }

    pusharray() {
        this.databases.push(new DataBases(1, "Тест"));
        this.databases.push(new DataBases(2, "Рабочая"));
    }

}
class DataBases {
    constructor(num: number, db: string) {
        this.num = num;
        this.db = db;
    }
    num: number;
    db: string;
}

//Класс для генерации настроек для процедур
export class CreateSettingSelect {
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