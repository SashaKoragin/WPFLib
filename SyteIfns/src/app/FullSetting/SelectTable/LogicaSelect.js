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
    //Переключение выборки select
    ParamLogica.prototype.logicaselect = function () {
        if (this.select) {
            this.select = false;
        }
        else {
            this.select = true;
        }
    };
    //Переключение выборки progress
    ParamLogica.prototype.logicaprogress = function () {
        if (this.progress) {
            this.progress = false;
        }
        else {
            this.progress = true;
        }
    };
    //Переключение выборки database
    ParamLogica.prototype.logicadatabase = function () {
        if (this.database) {
            this.database = false;
        }
        else {
            this.database = true;
        }
    };
    //Логика детализации
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