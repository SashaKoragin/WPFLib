var LogicaTemplate = /** @class */ (function () {
    function LogicaTemplate() {
        //Навигация кнопок
        this.navigation = true;
        //Select выборка добавления шаблона
        this.addtemp = false;
        //Select выборка просмотра шаблона
        this.viewtemp = false;
    }
    LogicaTemplate.prototype.logicaaddtemp = function () {
        this.addtemp = true;
        this.navigation = false;
    };
    LogicaTemplate.prototype.logicaviewtemp = function () {
        this.viewtemp = true;
        this.navigation = false;
    };
    //Назад
    LogicaTemplate.prototype.back = function () {
        this.viewtemp = false;
        this.addtemp = false;
        this.navigation = true;
    };
    return LogicaTemplate;
}());
export { LogicaTemplate };
//# sourceMappingURL=Tables.js.map