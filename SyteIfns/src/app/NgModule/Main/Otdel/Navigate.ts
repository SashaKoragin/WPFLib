﻿import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Predproverka } from '../../../Otdel/Predproverka/Soprovod/StartModule/Predproverka';
import { AnalizNo } from '../../../Otdel/Analiticks/AnalizNo/StartModule/StartModuleAnaliz';
import { BdkIt } from '../../../Otdel/It/Bdk/StartModule/Bdk';
import { BdkLetter } from '../../../Otdel/It/FormLetter/StartModel/FormLetter';
import { AddTemplate } from '../../../Otdel/It/AddTemplate/StartModel/AddTemplate';
import { ReshenieStart } from '../../../Otdel/Yregulirovanie/Trebovanie/StartModule/Reshenie';
import { AppComponent } from '../../../Otdel/Analiticks/FaceMerge/StartModule/StartComponent';
import { ChatComponent } from '../../../Otdel/It/Chat/StartModule/Chat';
import { Main } from '../../../Otdel/Main/Main/Main';
import { AuthGuard} from '../../../Autification/ModelSecuriti/AuthGuard';
import { ReportKam5 } from '../../../Otdel/Kam5/ReportKam5/StartModule/Report';
import { Server} from '../../../Otdel/It/Server/View/Servers';
const appRoutes: Routes = [
    {
        path: '',
        component: Main,
        canActivate: [AuthGuard],
        children:[
          {
            path: 'page1',
            component: BdkIt
          },
            {
                path: 'page2',
                component: BdkLetter
            },
            {
                path: 'page3',
                component: AddTemplate
            },
            {
                path: 'page4',
                component: ReshenieStart
            },
            {
                path: 'page5',
                component: AppComponent
            },
            {
                path: 'page6',
                component: AnalizNo
            },
            {
                path: 'page7',
                component: Predproverka
            },
            {
                path: 'page8',
                component: ChatComponent
            },
            {
                path: 'page9',
                component: ReportKam5
            },
            {
                path: 'page10',
                component: Server
            }
            ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(appRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }


