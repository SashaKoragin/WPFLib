var Parametr = /** @class */ (function () {
    function Parametr() {
        this.qvartal = [{ qvartal: 1, qvartaltext: '1 квартал' },
            { qvartal: 2, qvartaltext: '2 квартал' },
            { qvartal: 3, qvartaltext: '3 квартал' },
            { qvartal: 4, qvartaltext: '4 квартал' }];
        this.reportVid = [{ reportvid: 0, reportvidtext: 'Статистика приема по НО' },
            { reportvid: 1, reportvidtext: 'Статистика в разрезе НП' },
            { reportvid: 2, reportvidtext: 'Ошибки приема в разрезе НП' },
            { reportvid: 3, reportvidtext: 'Сводный отчет о результатах приема' }];
        this.opredelenie = [{ opredelenie: 0, opredelenietext: 'Только расчет, представленный с номером корректировки' },
            { opredelenie: 1, opredelenietext: 'Любой успешно представленный расчет за аналогичный период' }];
        this.error = [{ error: 0, errortext: 'Не учитывать ошибки с кодами 2' },
            { error: 1, errortext: 'Учитывать ошибки с кодами 2' }];
        this.qvartalone = null;
        this.reportVidone = this.reportVid[3];
        this.opredelenieone = this.opredelenie[1];
        this.errorone = this.error[1];
    }
    ///Подстановка параметров выбранных пользователем
    Parametr.prototype.createModelPost = function (setting, dateServer) {
        setting.ReportRvs.Qvartal = this.qvartalone.qvartal;
        setting.ReportRvs.ReportVid = this.reportVidone.reportvid;
        setting.ReportRvs.P1 = this.opredelenieone.opredelenie;
        setting.ReportRvs.Data = dateServer;
        setting.ReportRvs.ErrDetal = this.errorone.error;
        return setting;
    };
    return Parametr;
}());
export { Parametr };
var Qvartal = /** @class */ (function () {
    function Qvartal() {
    }
    return Qvartal;
}());
var ReportVid = /** @class */ (function () {
    function ReportVid() {
    }
    return ReportVid;
}());
var Opredelenie = /** @class */ (function () {
    function Opredelenie() {
    }
    return Opredelenie;
}());
var ErrDetal = /** @class */ (function () {
    function ErrDetal() {
    }
    return ErrDetal;
}());
//# sourceMappingURL=ModelParametr.js.map