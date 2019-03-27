import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainInventar } from '../../../Inventarka/Main/Main/MainInventarization';
import { AuthInventar  } from '../../../Autification/ModelSecuriti/AuthInventarization';
import { Equipment } from '../../../Inventarka/Equipment/View/Equepment';
import { Invent } from '../../../Inventarka/Invent/View/Invent';
import { User } from '../../../Inventarka/User/View/User';
const appRoutes: Routes = [
{
    path: '',
    component: MainInventar,
    canActivate: [AuthInventar],
    children: [
        {
            path: 'techical',
            component: Equipment
        },
        {
            path: 'inventar',
            component: Invent
        },
        {
            path: 'users',
            component: User
        }]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(appRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }


