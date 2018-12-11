export class ParamLogica {
    //Ошибка если нет данных
    errornull: boolean = true;

    //Шкала загрузки
    progress: boolean = true;
    //Select выборка
    select: boolean = true;

    //Данные
    database: boolean = true;
    //Детализация
    detal: boolean = true;
    //Переключение выборки select
    logicaselect() {
        if (this.select) {
            this.select = false;
        } else {
            this.select = true;
        }
    }
    //Переключение выборки progress
    logicaprogress() {
        if (this.progress) {
            this.progress = false;
        } else {
            this.progress = true;
        }
    }
    //Переключение выборки database
    logicadatabase() {
        if (this.database) {
            this.database = false;
        } else {
            this.database = true;
        }
    }
    //Логика детализации
    detalization() {
        if (this.detal) {
            this.detal = false;
        } else {
            this.detal = true;
        }
    }
}