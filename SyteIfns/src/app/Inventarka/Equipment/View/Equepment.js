var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
var Equipment = /** @class */ (function () {
    function Equipment() {
        this.tabs = ['Принтеры', 'Сканеры', 'МФУ', 'Системные блоки', 'Мониторы'];
        //  name: ModelColumns = new ModelColumns();
    }
    Equipment = __decorate([
        Component(({
            selector: 'equepment',
            templateUrl: '../Html/Equipment.html',
            styleUrls: ['../Html/Equipment.css'],
        }))
    ], Equipment);
    return Equipment;
}());
export { Equipment };
//# sourceMappingURL=Equepment.js.map