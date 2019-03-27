var AdressInventarka = /** @class */ (function () {
    function AdressInventarka() {
        //public host = 'i7751-w00000745';
        this.host = 'localhost';
        this.autificationInventar = "http://" + this.host + ":8182/Inventarka/Authorization";
        this.alluser = "http://" + this.host + ":8182/Inventarka/AllUsers";
    }
    return AdressInventarka;
}());
export { AdressInventarka };
//# sourceMappingURL=AdressInventarka.js.map