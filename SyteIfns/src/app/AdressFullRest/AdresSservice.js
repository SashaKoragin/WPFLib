var AdressMerge = /** @class */ (function () {
    function AdressMerge() {
        //public host = 'i7751-w00000745';
        this.host = 'localhost';
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
    }
    return AdressMerge;
}());
export { AdressMerge };
//# sourceMappingURL=AdresSservice.js.map