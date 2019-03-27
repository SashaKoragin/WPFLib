import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../Autification/ModelSecuriti/AuthGuard';
import { AuthInventar } from '../../Autification/ModelSecuriti/AuthInventarization';
import { AppModule } from './Otdel/OtdelFull';
import { InventarModule } from './Inventarization/Inventarka';

const appRoutes: Routes = [
    {
        path: 'admin',
        loadChildren: ()=> AppModule,
        canLoad: [AuthGuard]
    },
    {
        path: 'inventarization',
        loadChildren: () => InventarModule,
        canLoad: [AuthInventar]
    }


];

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes,
            {
                enableTracing: false // <-- debugging purposes only
            }
        )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }
