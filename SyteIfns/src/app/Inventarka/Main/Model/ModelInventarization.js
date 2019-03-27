var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';
var ModelInventar = /** @class */ (function () {
    function ModelInventar() {
    }
    return ModelInventar;
}());
export { ModelInventar };
var Inventar = /** @class */ (function () {
    function Inventar() {
        this.dataChange = new BehaviorSubject([{
                otdelfunc: 'Инвентаризация',
                children: [{
                        otdelfunc: 'Пользователи',
                        children: null, types: 'Все пользователи', pages: './users', fullpath: 'Пользователи\\Все пользователи', model: 'Все пользователи'
                    },
                    {
                        otdelfunc: 'Техника',
                        children: null, types: 'Вся техника', pages: './techical', fullpath: 'Техника\\Вся техника', model: 'Вся техника'
                    },
                    {
                        otdelfunc: 'Общая',
                        children: null, types: 'Общая инвентаризация', pages: './inventar', fullpath: 'Общая\\Общая инвентаризация', model: 'Инвентаризация'
                    }], types: null, pages: null, fullpath: null, model: null
            }]);
    }
    Inventar = __decorate([
        Injectable()
    ], Inventar);
    return Inventar;
}());
export { Inventar };
//# sourceMappingURL=ModelInventarization.js.map