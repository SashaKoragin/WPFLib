import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { LoginComponent } from '../../Autification/Securiti/Security';
import { AuthRoutingModule } from './RoutingAuth';
import { AngularMaterialModule } from '../Main/MaterialLibary/MaterialLibary';
import { LoginInventarization } from '../../Autification/Securiti/SecurityInventarization';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        AuthRoutingModule,
        AngularMaterialModule
    ],
    declarations: [
        LoginComponent, LoginInventarization
    ]
})
export class AuthModule { }