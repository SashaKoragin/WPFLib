var AdressMerge = /** @class */ (function () {
    function AdressMerge() {
        this.host = 'i7751-w00000745';
        //  public host = 'localhost';
        //Авторизация на сервере
        this.authservicedomain = "http://" + this.host + ":8181/ServiceRest/AuthServiceDomain";
        this.addresError = "http://" + this.host + ":8181/ServiceRest/SqlFaceError";
        this.addresFaceAdd = "http://" + this.host + ":8181/ServiceRest/SqlFaceAdd";
        this.addresDelFace = "http://" + this.host + ":8181/ServiceRest/SqlFaceDel";
        this.useprocedure = "http://" + this.host + ":8181/ServiceRest/StoreProcedureReshenie";
        this.loadbdk = "http://" + this.host + ":8181/ServiceRest/LoadBdk";
        this.procedurebdk = "http://" + this.host + ":8181/ServiceRest/ProcedureBdk";
        this.startoutbdkletter = "http://" + this.host + ":8181/ServiceRest/StartOpenXmlTest";
        this.startproceduresoprovod = "http://" + this.host + ":8181/ServiceRest/ProcedureSoprovod";
        this.servicecommand = "http://" + this.host + ":8181/ServiceRest/ServiceCommand";
        this.sqlcommand = "http://" + this.host + ":8181/ServiceRest/ModelSqlSelect";
        this.donloadfileangular = "http://" + this.host + ":8181/ServiceRest/AngularFileDonload";
        this.addtemplate = "http://" + this.host + ":8181/ServiceRest/AddTemplate";
        this.createkrsb = "http://" + this.host + ":8181/ServiceRest/CreteKrsb";
        this.analizkrsb = "http://" + this.host + ":8181/ServiceRest/ProcedureAnalizKrsb";
        this.reportKam5 = "http://" + this.host + ":8181/ServiceRest/StoreProcedureKam5";
        this.serversFullSql = "http://" + this.host + ":8181/ServiceRest/ServerList";
        this.adressTrebovanie = "http://" + this.host + ":8181/ServiceRest/ReportFile/\u0422\u0440\u0435\u0431\u043E\u0432\u0430\u043D\u0438\u044F.xlsx";
        this.adressBdk = "http://" + this.host + ":8181/ServiceRest/ReportFile/\u0411\u0434\u043A.xlsx";
        this.adressIstrebovanie = "http://" + this.host + ":8181/ServiceRest/ReportFile/\u0418\u0441\u0442\u0440\u0435\u0431\u043E\u0432\u0430\u043D\u0438\u0435.xlsx";
    }
    return AdressMerge;
}());
export { AdressMerge };
//# sourceMappingURL=AdresSservice.js.map