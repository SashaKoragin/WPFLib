import { NgModule } from '@angular/core';
import { HeadersAdd, BodyAdd, StoneAdd } from './FullSetting/FormValidation/Dialog/ItTemplate/Class/Dialogs'
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './Otdel/Analiticks/FaceMerge/StartModule/StartComponent';
import { ReshenieStart } from './Otdel/Yregulirovanie/Trebovanie/StartModule/Reshenie';
import { Filter } from './Otdel/Yregulirovanie/Trebovanie/Model/Filter';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
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
    MatStepperModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule
    } from '@angular/material';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { BdkIt } from './Otdel/It/Bdk/StartModule/Bdk';
import { BdkLetter } from './Otdel/It/FormLetter/StartModel/FormLetter';
import { AddTemplate } from './Otdel/It/AddTemplate/StartModel/AddTemplate';
import { Predproverka } from './Otdel/Predproverka/Soprovod/StartModule/Predproverka';

@NgModule(({
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
}) as any)
export class AngularMaterialModule { }

@NgModule({
    get imports(): any[] { return [BrowserModule, FormsModule, HttpClientModule]; },
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})

export class FaceError {}

@NgModule(({
    imports: [BrowserModule, FormsModule, HttpClientModule, AngularMaterialModule, BrowserAnimationsModule, ReactiveFormsModule],
    declarations: [ReshenieStart],
    bootstrap: [ReshenieStart]
}) as any)
export class Reshenie {
}

@NgModule(({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [BdkIt],
    bootstrap: [BdkIt]
}) as any)
export class Bdk {

}

@NgModule(({
    imports: [BrowserModule, FormsModule, HttpClientModule, AngularMaterialModule, BrowserAnimationsModule, ReactiveFormsModule],
    declarations: [BdkLetter],
    bootstrap: [BdkLetter]
}) as any)

export class Letter {}

@NgModule(({
    imports: [BrowserModule, FormsModule, HttpClientModule, AngularMaterialModule, BrowserAnimationsModule, ReactiveFormsModule],
    declarations: [AddTemplate, HeadersAdd, BodyAdd, StoneAdd],
    bootstrap: [AddTemplate],
    entryComponents: [HeadersAdd, BodyAdd, StoneAdd]
}) as any)

export class Template { }

@NgModule(({
    imports: [BrowserModule, FormsModule, HttpClientModule, AngularMaterialModule, BrowserAnimationsModule, ReactiveFormsModule],
    declarations: [Predproverka],
    bootstrap: [Predproverka]
}) as any)

export class Soprovod { }