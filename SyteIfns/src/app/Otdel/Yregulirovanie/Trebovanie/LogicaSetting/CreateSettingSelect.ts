import { SysNum } from '../Model/ModelSelect'
import { PostTrebovanie} from '../../../../PostZaprosFull/PostFull'
import { Setting } from '../Model/ModelReshenie'

export enum Db {
   Тест,Рабочая
}

export class CreateSettingSelect {

    workandtest(num:number,setting:Setting):Setting {
        switch (num) {
            case 1:
                return this.testsetting(setting);
            case 2:
                return this.worksetting(setting);
            default: return null;
        }
    }

    testsetting(setting:Setting):Setting {
        setting.Db = 'Test';
        return setting;
    }

    worksetting(setting:Setting):Setting {
        setting.Db = 'Work';
        return setting;
    }

    createaddresh(resh:number,setting: Setting): Setting {
        setting.Id = 1;
        setting.ParametrSelect.D270 = resh;
        return setting;
    }

    createstartresh(resh: number, setting: Setting): Setting {
        setting.Id = 2;
        return setting;
    }

    createstartincass(resh: number, setting: Setting): Setting {
        setting.Id = 3;
        return setting;
    }
}