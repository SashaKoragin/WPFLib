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
import { AdressMerge } from './adress/app.adressservice';
var httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
var DataService = /** @class */ (function () {
    function DataService(http) {
        this.http = http;
        this.url = new AdressMerge();
    }
    DataService.prototype.getfacepost = function () {
        return this.http.post(this.url.addresError, null);
    };
    DataService.prototype.deleteface = function (face) {
        return this.http.post(this.url.addresDelFace, face.idField, httpOptions);
    };
    DataService.prototype.addfacemerge = function (face) {
        try {
            return this.http.post(this.url.addresFaceAdd, face, httpOptions);
        }
        catch (e) {
            alert(e.toString());
        }
    };
    DataService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], DataService);
    return DataService;
}());
export { DataService };
//# sourceMappingURL=app.post.js.map