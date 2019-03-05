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
import { ReportKam5 } from '../../../Otdel/Kam5/ReportKam5/StartModule/Report'


@NgModule(({
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
    entryComponents: [DialogOkato, HeadersAdd, BodyAdd, StoneAdd, DialogDela],
}) as any)

export class AppModule {}