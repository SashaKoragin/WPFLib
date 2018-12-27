var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './Navigate';
import { Main } from './Otdel/Main/Main/Main';
import { HeadersAdd, BodyAdd, StoneAdd } from './FullSetting/FormValidation/Dialog/ItTemplate/Class/Dialogs';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './Otdel/Analiticks/FaceMerge/StartModule/StartComponent';
import { ReshenieStart } from './Otdel/Yregulirovanie/Trebovanie/StartModule/Reshenie';
import { DialogDela } from './FullSetting/FormValidation/Dialog/CreateDela/Class/DialogDela';
import { DialogOkato } from './FullSetting/FormValidation/Dialog/AddOkato/Class/DialogOkato';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SignalRConfiguration, SignalRModule } from 'ng2-signalr';
import { ChatComponent } from './Otdel/It/Chat/StartModule/Chat';
import { Chat } from './Otdel/It/Chat/Model/ModelChat/Chat';
import { Sicurity } from './Otdel/Autification/Sicurity/Sicurity';
import { MatAutocompleteModule, MatBadgeModule, MatBottomSheetModule, MatButtonModule, MatButtonToggleModule, MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule, MatDialogModule, MatDividerModule, MatExpansionModule, MatGridListModule, MatIconModule, MatInputModule, MatListModule, MatMenuModule, MatNativeDateModule, MatPaginatorModule, MatProgressBarModule, MatProgressSpinnerModule, MatRadioModule, MatRippleModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSlideToggleModule, MatSnackBarModule, MatSortModule, MatStepperModule, MatTableModule, MatTabsModule, MatToolbarModule, MatTooltipModule, MatTreeModule } from '@angular/material';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { BdkIt } from './Otdel/It/Bdk/StartModule/Bdk';
import { BdkLetter } from './Otdel/It/FormLetter/StartModel/FormLetter';
import { AddTemplate } from './Otdel/It/AddTemplate/StartModel/AddTemplate';
import { Predproverka } from './Otdel/Predproverka/Soprovod/StartModule/Predproverka';
import { AnalizNo } from './Otdel/Analiticks/AnalizNo/StartModule/StartModuleAnaliz';
var AngularMaterialModule = /** @class */ (function () {
    function AngularMaterialModule() {
    }
    AngularMaterialModule = __decorate([
        NgModule(({
            exports: [
                CdkTableModule,
                CdkTreeModule,
                MatAutocompleteModule,
                MatBadgeModule,
                MatBottomSheetModule,
                MatButtonModule,
                MatButtonToggleModule,
                MatCardModule,
                MatCheckboxModule,
                MatChipsModule,
                MatStepperModule,
                MatDatepickerModule,
                MatDialogModule,
                MatDividerModule,
                MatExpansionModule,
                MatGridListModule,
                MatIconModule,
                MatInputModule,
                MatListModule,
                MatMenuModule,
                MatNativeDateModule,
                MatPaginatorModule,
                MatProgressBarModule,
                MatProgressSpinnerModule,
                MatRadioModule,
                MatRippleModule,
                MatSelectModule,
                MatSidenavModule,
                MatSliderModule,
                MatSlideToggleModule,
                MatSnackBarModule,
                MatSortModule,
                MatTableModule,
                MatTabsModule,
                MatToolbarModule,
                MatTooltipModule,
                MatTreeModule
            ]
        }))
    ], AngularMaterialModule);
    return AngularMaterialModule;
}());
export { AngularMaterialModule };
export function createConfig() {
    var c = new SignalRConfiguration();
    c.hubName = 'ServiceMessage';
    c.qs = { user: 'Donald' };
    c.url = 'http://localhost:8059/signalr';
    c.logging = true;
    c.executeEventsInZone = true; // optional, default is true
    c.executeErrorsInZone = true; // optional, default is false
    c.executeStatusChangeInZone = true; // optional, default is true
    return c;
}
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule(({
            imports: [
                BrowserModule,
                FormsModule,
                HttpClientModule,
                AngularMaterialModule,
                BrowserAnimationsModule,
                ReactiveFormsModule,
                AppRoutingModule,
                SignalRModule.forRoot(createConfig)
            ],
            declarations: [
                Main,
                DialogOkato, HeadersAdd, BodyAdd, StoneAdd, DialogDela,
                Predproverka, BdkIt, AnalizNo, BdkLetter, AddTemplate, ReshenieStart, AppComponent, AnalizNo,
                ChatComponent, Chat, Sicurity
            ],
            bootstrap: [Main],
            entryComponents: [DialogOkato, HeadersAdd, BodyAdd, StoneAdd, DialogDela]
        }))
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=LoadComponentFull.js.map