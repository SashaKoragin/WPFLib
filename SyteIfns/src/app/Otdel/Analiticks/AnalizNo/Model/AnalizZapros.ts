export class LogicaSelecting {

    public log: Logica[] = [
        { param: 'Запрос по дате!!!', bool1: true, bool2: false },
        { param: 'Запрос по УН Дела!!!', bool1: false, bool2: true }
    ];
    public logica:Logica = this.log[0];
}

class Logica {
    param: string;
    bool1: boolean;
    bool2: boolean;
}