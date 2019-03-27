import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginInventarization } from '../../Autification/Securiti/SecurityInventarization';
import { LoginComponent } from '../../Autification/Securiti/Security';

const authRoutes: Routes = [
    {
        path: 'login',
        component: LoginComponent

    },
    {
        path: 'inventarlogin',
        component: LoginInventarization
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(authRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class AuthRoutingModule { }
