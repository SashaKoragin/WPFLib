import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../Autification/ModelSecuriti/AuthGuard';
import { AppModule } from './Otdel/OtdelFull';

const appRoutes: Routes = [
    {
        path: 'admin',
        loadChildren: ()=> AppModule,
        canLoad: [AuthGuard]
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
