var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginInventarization } from '../../Autification/Securiti/SecurityInventarization';
import { LoginComponent } from '../../Autification/Securiti/Security';
var authRoutes = [
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'inventarlogin',
        component: LoginInventarization
    }
];
var AuthRoutingModule = /** @class */ (function () {
    function AuthRoutingModule() {
    }
    AuthRoutingModule = __decorate([
        NgModule({
            imports: [
                RouterModule.forChild(authRoutes)
            ],
            exports: [
                RouterModule
            ]
        })
    ], AuthRoutingModule);
    return AuthRoutingModule;
}());
export { AuthRoutingModule };
//# sourceMappingURL=RoutingAuth.js.map