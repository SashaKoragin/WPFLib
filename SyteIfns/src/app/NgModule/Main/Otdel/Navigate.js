var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Predproverka } from '../../../Otdel/Predproverka/Soprovod/StartModule/Predproverka';
import { AnalizNo } from '../../../Otdel/Analiticks/AnalizNo/StartModule/StartModuleAnaliz';
import { BdkIt } from '../../../Otdel/It/Bdk/StartModule/Bdk';
import { BdkLetter } from '../../../Otdel/It/FormLetter/StartModel/FormLetter';
import { AddTemplate } from '../../../Otdel/It/AddTemplate/StartModel/AddTemplate';
import { ReshenieStart } from '../../../Otdel/Yregulirovanie/Trebovanie/StartModule/Reshenie';
import { AppComponent } from '../../../Otdel/Analiticks/FaceMerge/StartModule/StartComponent';
import { ChatComponent } from '../../../Otdel/It/Chat/StartModule/Chat';
import { Main } from '../../../Otdel/Main/Main/Main';
import { AuthGuard } from '../../../Autification/ModelSecuriti/AuthGuard';
import { ReportKam5 } from '../../../Otdel/Kam5/ReportKam5/StartModule/Report';
var appRoutes = [
    {
        path: '',
        component: Main,
        canActivate: [AuthGuard],
        children: [
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
            }
        ]
    }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        NgModule({
            imports: [
                RouterModule.forChild(appRoutes)
            ],
            exports: [RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
export { AppRoutingModule };
//# sourceMappingURL=Navigate.js.map