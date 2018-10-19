export class LogicaTemplate {

    //Навигация кнопок
    navigation:boolean = true;

    //Select выборка добавления шаблона
    addtemp: boolean = false;
    logicaaddtemp() {
            this.addtemp = true;
            this.navigation = false;
    }
    //Select выборка просмотра шаблона
    viewtemp: boolean = false;
    logicaviewtemp() {
            this.viewtemp = true;
            this.navigation = false;
    }
    //Назад
    back() {
        this.viewtemp = false;
        this.addtemp = false;
        this.navigation = true;
    }
}