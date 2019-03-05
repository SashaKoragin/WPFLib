import { FullSetting } from '../../../../FullSetting/FullSetting';

export class Parametr {



    public qvartal: Qvartal[] = [{ qvartal: 1, qvartaltext: '1 квартал' },
        { qvartal: 2, qvartaltext: '2 квартал' },
        { qvartal: 3, qvartaltext: '3 квартал' },
        { qvartal: 4, qvartaltext: '4 квартал' }];

    public reportVid: ReportVid[] = [{ reportvid: 0, reportvidtext: 'Статистика приема по НО' },
                                     {reportvid: 1, reportvidtext: 'Статистика в разрезе НП'},
                                     {reportvid: 2, reportvidtext: 'Ошибки приема в разрезе НП'},
                                     {reportvid: 3, reportvidtext: 'Сводный отчет о результатах приема'}];
    public opredelenie: Opredelenie[] = [{ opredelenie: 0, opredelenietext: 'Только расчет, представленный с номером корректировки' },
                                         { opredelenie: 1, opredelenietext: 'Любой успешно представленный расчет за аналогичный период' }];
    public error: ErrDetal[] = [{ error: 0, errortext: 'Не учитывать ошибки с кодами 2' },
                                { error: 1, errortext: 'Учитывать ошибки с кодами 2' } ];

    public qvartalone: Qvartal = null;
    public reportVidone: ReportVid = this.reportVid[3];
    public opredelenieone: Opredelenie = this.opredelenie[1];
    public errorone: ErrDetal = this.error[1];
    ///Подстановка параметров выбранных пользователем
    public createModelPost(setting: FullSetting,dateServer:string): FullSetting {
        setting.ReportRvs.Qvartal = this.qvartalone.qvartal;
        setting.ReportRvs.ReportVid = this.reportVidone.reportvid;
        setting.ReportRvs.P1 = this.opredelenieone.opredelenie;
        setting.ReportRvs.Data = dateServer;
        setting.ReportRvs.ErrDetal = this.errorone.error;
        return setting;
    }
}

class Qvartal {
    qvartal: number;
    qvartaltext:string;
}

class ReportVid {
    reportvid: number;
    reportvidtext: string;
}

class Opredelenie {
    opredelenie: number;
    opredelenietext: string;
}

class ErrDetal {
    error:number;
    errortext: string;
}