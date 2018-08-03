import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from "./Otdel/Analiticks/FaceMerge/StartModule/StartComponent";
import { ReshenieStart} from "./Otdel/Yregulirovanie/Trebovanie/StartModule/Reshenie"
import { Filter } from './Otdel/Yregulirovanie/Trebovanie/Model/Filter'
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { BdkIt } from './Otdel/It/Bdk/StartModule/Bdk'
@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})

export class FaceError {
    
}

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [ReshenieStart,Filter],
    bootstrap: [ReshenieStart]
})
export class Reshenie {
}


@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [BdkIt],
    bootstrap: [BdkIt]
})
export class Bdk {
}