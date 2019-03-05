import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './RoutingMain';
import { Root } from '../../Main/ModelMain/Main'
import { AuthRoutingModule } from '../Auth/RoutingAuth';
import { LoginComponent } from '../../Autification/Securiti/Security';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { AngularMaterialModule} from './MaterialLibary/MaterialLibary';

import { ConnectionResolver } from '../../SignalRSignal/ConnectSignalR';
import { SignalRConfiguration, SignalRModule } from 'ng2-signalr';

export function createConfig(): SignalRConfiguration {
    const c = new SignalRConfiguration();
    c.logging = true;
    c.url = 'http://localhost:8059/signalr';
    return c;
}

@NgModule({
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
        Root, LoginComponent
    ],
    bootstrap: [Root],
    providers: [ConnectionResolver]
})
export class Maining {
    constructor(router: Router) {
        //Для Debuger
    }

}