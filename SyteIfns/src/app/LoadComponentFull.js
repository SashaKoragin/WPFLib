var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from "./Otdel/Analiticks/FaceMerge/StartModule/StartComponent";
import { ReshenieStart } from "./Otdel/Yregulirovanie/Trebovanie/StartModule/Reshenie";
import { Filter } from './Otdel/Yregulirovanie/Trebovanie/Model/Filter';
var FaceError = /** @class */ (function () {
    function FaceError() {
    }
    FaceError = __decorate([
        NgModule({
            imports: [BrowserModule, FormsModule, HttpClientModule],
            declarations: [AppComponent],
            bootstrap: [AppComponent]
        })
    ], FaceError);
    return FaceError;
}());
export { FaceError };
var Reshenie = /** @class */ (function () {
    function Reshenie() {
    }
    Reshenie = __decorate([
        NgModule({
            imports: [BrowserModule, FormsModule, HttpClientModule],
            declarations: [ReshenieStart, Filter],
            bootstrap: [ReshenieStart]
        })
    ], Reshenie);
    return Reshenie;
}());
export { Reshenie };
//# sourceMappingURL=LoadComponentFull.js.map