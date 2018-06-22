var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from "@angular/core";
import { Face, FaceAdd } from "../Model/FaceError";
import { DataService } from '../../../../PostZaprosFull/PostFull';
import { plainToClass } from "class-transformer";
//По сути патерн MVVM только в рамках асинхронности
var AppComponent = /** @class */ (function () {
    function AppComponent(dataservice) {
        this.dataservice = dataservice;
        this.facemodel = null;
        this.faces = new FaceAdd();
        this.server = null;
        this.tableMode = false;
    }
    AppComponent.prototype.ngOnInit = function () {
        this.load();
    };
    AppComponent.prototype.load = function () {
        var _this = this;
        this.dataservice.getfacepost().subscribe(function (model) {
            _this.facemodel = plainToClass(Face, model);
            if (_this.facemodel.SqlFaceErrorResult != null) {
                _this.tableMode = true;
            }
        });
    };
    AppComponent.prototype.del = function (face) {
        var _this = this;
        this.dataservice.deleteface(face).subscribe(function (model) {
            _this.server = JSON.stringify(model);
            _this.load();
        });
    };
    AppComponent.prototype.addface = function (faces) {
        var _this = this;
        try {
            this.dataservice.addfacemerge(faces).subscribe(function (model) {
                _this.server = JSON.stringify(model);
                _this.load();
            });
        }
        catch (e) {
            alert(e.toString());
        }
    };
    AppComponent = __decorate([
        Component({
            selector: 'my-app',
            templateUrl: '../Template/MergeFace.html',
            providers: [DataService]
        }),
        __metadata("design:paramtypes", [DataService])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
