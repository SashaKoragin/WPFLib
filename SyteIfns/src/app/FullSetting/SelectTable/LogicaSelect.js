var ParamLogica = /** @class */ (function () {
    function ParamLogica() {
        //Ошибка если нет данных
        this.errornull = true;
        //Шкала загрузки
        this.progress = true;
        //Select выборка
        this.select = true;
        //Данные
        this.database = true;
        //Детализация
        this.detal = true;
    }
    ParamLogica.prototype.logicaselect = function () {
        if (this.select) {
            this.select = false;
        }
        else {
            this.select = true;
        }
    };
    ParamLogica.prototype.logicaprogress = function () {
        if (this.progress) {
            this.progress = false;
        }
        else {
            this.progress = true;
        }
    };
    ParamLogica.prototype.logicadatabase = function () {
        if (this.database) {
            this.database = false;
        }
        else {
            this.database = true;
        }
    };
    ParamLogica.prototype.detalization = function () {
        if (this.detal) {
            this.detal = false;
        }
        else {
            this.detal = true;
        }
    };
    return ParamLogica;
}());
export { ParamLogica };
//# sourceMappingURL=LogicaSelect.js.map