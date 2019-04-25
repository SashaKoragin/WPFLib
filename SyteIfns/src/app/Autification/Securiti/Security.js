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
import { ConnectionResolver } from '../../SignalRSignal/ConnectSignalR';
import { AuthServiceDomen } from '../../PostZaprosFull/PostFull';
import { ModelUser } from '../../FullSetting/FullSetting';
import { plainToClass } from 'class-transformer';
var LoginComponent = /** @class */ (function () {
    function LoginComponent(authService, router, signalR) {
        this.authService = authService;
        this.router = router;
        this.signalR = signalR;
    }
    LoginComponent.prototype.login = function () {
        var _this = this;
        console.log("Прошли 1");
        this.authService.login(this.signalR.user).subscribe(function (model) {
            console.log("Прошли 3");
            _this.signalR.user.ModelUser = plainToClass(ModelUser, model);
            _this.authService.result(_this.signalR.user);
            if (_this.authService.isLoggedIn) {
                _this.signalR.createconection();
                _this.signalR.start();
                _this.signalR.welcomestart();
                var redirect = _this.authService.redirectUrl ? _this.authService.redirectUrl : '/admin';
                var navigationExtras = {
                    queryParamsHandling: 'preserve',
                    preserveFragment: true
                };
                _this.router.navigate([redirect], navigationExtras);
            }
        });
    };
    LoginComponent.prototype.logout = function () {
        this.authService.logout();
        this.signalR.stop();
        ;
    };
    LoginComponent = __decorate([
        Component({
            selector: 'login',
            templateUrl: '../Html/MySecurity.html',
            styleUrls: ['../Html/MySecurity.css']
        }),
        __metadata("design:paramtypes", [AuthServiceDomen, Router, ConnectionResolver])
    ], LoginComponent);
    return LoginComponent;
}());
export { LoginComponent };
//# sourceMappingURL=Security.js.map