var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './RoutingMain';
import { Root } from '../../Main/ModelMain/Main';
import { AuthRoutingModule } from '../Auth/RoutingAuth';
import { LoginComponent } from '../../Autification/Securiti/Security';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { AngularMaterialModule } from './MaterialLibary/MaterialLibary';
import { ConnectionResolver } from '../../SignalRSignal/ConnectSignalR';
import { SignalRConfiguration, SignalRModule } from 'ng2-signalr';
import { LoginInventarization } from '../../Autification/Securiti/SecurityInventarization';
export function createConfig() {
    var c = new SignalRConfiguration();
    c.logging = true;
    c.url = 'http://localhost:8059/signalr';
    return c;
}
var Maining = /** @class */ (function () {
    function Maining(router) {
        //Для Debuger
    }
    Maining = __decorate([
        NgModule({
            imports: [
                BrowserModule,
                BrowserAnimationsModule,
                CommonModule,
                FormsModule,
                AuthRoutingModule,
                AngularMaterialModule,
                HttpClientModule,
                AppRoutingModule,
                SignalRModule.forRoot(createConfig)
            ],
            declarations: [
                Root, LoginComponent, LoginInventarization
            ],
            bootstrap: [Root],
            providers: [ConnectionResolver]
        }),
        __metadata("design:paramtypes", [Router])
    ], Maining);
    return Maining;
}());
export { Maining };
//# sourceMappingURL=NgMain.js.map