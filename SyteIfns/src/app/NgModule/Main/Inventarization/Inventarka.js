var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './Navigate';
import { MainInventar } from '../../../Inventarka/Main/Main/MainInventarization';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from '../MaterialLibary/MaterialLibary';
import { ReactiveFormsModule } from '@angular/forms';
import { Equipment } from '../../../Inventarka/Equipment/View/Equepment';
import { Invent } from '../../../Inventarka/Invent/View/Invent';
import { User } from '../../../Inventarka/User/View/User';
import { FormsModule } from '@angular/forms';
import { Table } from '../../../Inventarka/ModelTable/View/ViewModelTable';
var InventarModule = /** @class */ (function () {
    function InventarModule() {
    }
    InventarModule = __decorate([
        NgModule(({
            imports: [
                FormsModule,
                CommonModule,
                AngularMaterialModule,
                ReactiveFormsModule,
                AppRoutingModule
            ],
            declarations: [
                MainInventar, Equipment, Invent, User, Table
            ]
        }))
    ], InventarModule);
    return InventarModule;
}());
export { InventarModule };
//# sourceMappingURL=Inventarka.js.map