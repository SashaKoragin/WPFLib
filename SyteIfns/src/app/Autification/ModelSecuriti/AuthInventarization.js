var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthIdentification } from '../../PostZaprosFull/PostInventarization';
var AuthInventar = /** @class */ (function () {
    function AuthInventar(authService, router) {
        this.authService = authService;
        this.router = router;
    }
    AuthInventar.prototype.canActivate = function (route, state) {
        var url = state.url;
        return this.checkLogin(url);
    };
    AuthInventar.prototype.canActivateChild = function (route, state) {
        return this.canActivate(route, state);
    };
    AuthInventar.prototype.canLoad = function (route) {
        var url = "/" + route.path;
        return this.checkLogin(url);
    };
    AuthInventar.prototype.checkLogin = function (url) {
        if (this.authService.isLoggedIn) {
            return true;
        }
        this.authService.redirectUrl = url;
        this.router.navigate(['/inventarlogin']);
        return false;
    };
    AuthInventar = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [AuthIdentification, Router])
    ], AuthInventar);
    return AuthInventar;
}());
export { AuthInventar };
//# sourceMappingURL=AuthInventarization.js.map