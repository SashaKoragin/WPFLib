var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './Navigate';
import { Main } from '../../../Otdel/Main/Main/Main';
import { HeadersAdd, BodyAdd, StoneAdd } from '../../../FullSetting/FormValidation/Dialog/ItTemplate/Class/Dialogs';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from '../MaterialLibary/MaterialLibary';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from '../../../Otdel/Analiticks/FaceMerge/StartModule/StartComponent';
import { ReshenieStart } from '../../../Otdel/Yregulirovanie/Trebovanie/StartModule/Reshenie';
import { DialogDela } from '../../../FullSetting/FormValidation/Dialog/CreateDela/Class/DialogDela';
import { DialogOkato } from '../../../FullSetting/FormValidation/Dialog/AddOkato/Class/DialogOkato';
import { ChatComponent } from '../../../Otdel/It/Chat/StartModule/Chat';
import { Chat } from '../../../Otdel/It/Chat/Model/ModelChat/Chat';
import { BdkIt } from '../../../Otdel/It/Bdk/StartModule/Bdk';
import { BdkLetter } from '../../../Otdel/It/FormLetter/StartModel/FormLetter';
import { AddTemplate } from '../../../Otdel/It/AddTemplate/StartModel/AddTemplate';
import { Predproverka } from '../../../Otdel/Predproverka/Soprovod/StartModule/Predproverka';
import { AnalizNo } from '../../../Otdel/Analiticks/AnalizNo/StartModule/StartModuleAnaliz';
import { FormsModule } from '@angular/forms';
import { ReportKam5 } from '../../../Otdel/Kam5/ReportKam5/StartModule/Report';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule(({
            imports: [
                FormsModule,
                CommonModule,
                AngularMaterialModule,
                ReactiveFormsModule,
                AppRoutingModule
            ],
            declarations: [
                Main,
                DialogOkato, HeadersAdd, BodyAdd, StoneAdd, DialogDela,
                Predproverka, BdkIt, AnalizNo, BdkLetter, AddTemplate, ReshenieStart, AppComponent, AnalizNo, ReportKam5,
                ChatComponent, Chat
            ],
            entryComponents: [DialogOkato, HeadersAdd, BodyAdd, StoneAdd, DialogDela]
        }))
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=OtdelFull.js.map