var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MainInventar } from '../../../Inventarka/Main/Main/MainInventarization';
import { AuthInventar } from '../../../Autification/ModelSecuriti/AuthInventarization';
import { Equipment } from '../../../Inventarka/Equipment/View/Equepment';
import { Invent } from '../../../Inventarka/Invent/View/Invent';
import { User } from '../../../Inventarka/User/View/User';
var appRoutes = [
    {
        path: '',
        component: MainInventar,
        canActivate: [AuthInventar],
        children: [
            {
                path: 'techical',
                component: Equipment
            },
            {
                path: 'inventar',
                component: Invent
            },
            {
                path: 'users',
                component: User
            }
        ]
    }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        NgModule({
            imports: [
                RouterModule.forChild(appRoutes)
            ],
            exports: [RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
export { AppRoutingModule };
//# sourceMappingURL=Navigate.js.map