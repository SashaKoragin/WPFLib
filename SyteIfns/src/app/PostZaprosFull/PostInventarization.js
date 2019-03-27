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
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Users } from '../Inventarka/ModelInventarization/Inventarization';
import { AdressInventarka } from '../AdressFullRest/AdressInventarka';
import { ModelParametr } from '../Inventarka/ModelInventarization/Parametr';
var url = new AdressInventarka();
var httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
var AuthIdentification = /** @class */ (function () {
    function AuthIdentification(http) {
        this.http = http;
        this.user = new Users();
        this.logins = null;
        this.password = null;
        this.isLoggedIn = false;
    }
    AuthIdentification.prototype.login = function () {
        this.error = null;
        this.user.Passwords = this.password;
        this.user.NameUser = this.logins;
        return this.http.post(url.autificationInventar, this.user, httpOptionsJson);
    };
    AuthIdentification.prototype.logout = function () {
        this.isLoggedIn = false;
        this.user = new Users();
        this.error = null;
    };
    AuthIdentification = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [HttpClient])
    ], AuthIdentification);
    return AuthIdentification;
}());
export { AuthIdentification };
var PostInventar = /** @class */ (function () {
    function PostInventar(http) {
        this.http = http;
    }
    ///Выборка всего из БД в зависимостb от num пользователи
    PostInventar.prototype.alluser = function (num) {
        return this.http.post(url.alluser, new ModelParametr(num), httpOptionsJson);
    };
    PostInventar = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], PostInventar);
    return PostInventar;
}());
export { PostInventar };
//# sourceMappingURL=PostInventarization.js.map