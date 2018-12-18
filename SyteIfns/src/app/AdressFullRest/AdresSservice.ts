export class AdressMerge {
   // public host = 'i7751-w00000745';
    public host = 'localhost';
    public addresError = `http://${this.host}:8181/ServiceRest/SqlFaceError`;
    public addresFaceAdd = `http://${this.host}:8181/ServiceRest/SqlFaceAdd`;
    public addresDelFace = `http://${this.host}:8181/ServiceRest/SqlFaceDel`;
    public useprocedure = `http://${this.host}:8181/ServiceRest/StoreProcedureReshenie`;
    public loadbdk = `http://${this.host}:8181/ServiceRest/LoadBdk`;
    public procedurebdk = `http://${this.host}:8181/ServiceRest/ProcedureBdk`;
    public startoutbdkletter = `http://${this.host}:8181/ServiceRest/StartOpenXmlTest`;
    public startproceduresoprovod = `http://${this.host}:8181/ServiceRest/ProcedureSoprovod`;
    public servicecommand = `http://${this.host}:8181/ServiceRest/ServiceCommand`;
    public sqlcommand = `http://${this.host}:8181/ServiceRest/ModelSqlSelect`;
    public donloadfileangular = `http://${this.host}:8181/ServiceRest/AngularFileDonload`;
    public addtemplate = `http://${this.host}:8181/ServiceRest/AddTemplate`;
    public createkrsb = `http://${this.host}:8181/ServiceRest/CreteKrsb`;
    public analizkrsb = `http://${this.host}:8181/ServiceRest/ProcedureAnalizKrsb`;

    public adressTrebovanie = `http://${this.host}:8181/ServiceRest/ReportFile/Требования.xlsx`;
    public adressBdk = `http://${this.host}:8181/ServiceRest/ReportFile/Бдк.xlsx`;
    public adressIstrebovanie = `http://${this.host}:8181/ServiceRest/ReportFile/Истребование.xlsx`;
}