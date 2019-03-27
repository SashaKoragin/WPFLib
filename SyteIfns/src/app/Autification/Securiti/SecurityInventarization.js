var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthIdentification } from '../../PostZaprosFull/PostInventarization';
import { FullSelected } from '../../Inventarka/ModelInventarization/Inventarization';
import { deserialize } from 'class-transformer';
var LoginInventarization = /** @class */ (function () {
    function LoginInventarization(authService, router) {
        this.authService = authService;
        this.router = router;
    }
    LoginInventarization.prototype.login = function () {
        var _this = this;
        try {
            if ((this.authService.password !== null) &&
                (this.authService.logins !== null)) {
                this.authService.login().subscribe(function (model) {
                    if (model) {
                        _this.authService.fullSelect = deserialize(FullSelected, model.toString());
                        var redirect = _this.authService.redirectUrl ? _this.authService.redirectUrl : '/inventarization';
                        _this.authService.isLoggedIn = true;
                        var navigationExtras = {
                            queryParamsHandling: 'preserve',
                            preserveFragment: true
                        };
                        _this.router.navigate([redirect], navigationExtras);
                        return;
                    }
                    _this.authService.error = 'Не правильный Логин/Пароль';
                    return;
                });
            }
            else {
                this.authService.error = 'Не введен Логин/Пароль';
            }
        }
        catch (e) {
            alert(e);
        }
        ;
    };
    LoginInventarization.prototype.logout = function () {
        this.authService.logout();
    };
    LoginInventarization = __decorate([
        Component({
            selector: 'inventarlogin',
            templateUrl: '../Html/Inventarization.html',
            styleUrls: ['../Html/Inventarization.css']
        }),
        __metadata("design:paramtypes", [AuthIdentification, Router])
    ], LoginInventarization);
    return LoginInventarization;
}());
export { LoginInventarization };
//# sourceMappingURL=SecurityInventarization.js.map