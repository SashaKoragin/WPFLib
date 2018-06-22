import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from "./Otdel/Analiticks/FaceMerge/StartModule/StartComponent";
import { TrebovanieStart} from "./Otdel/Yregulirovanie/Trebovanie/StartModule/Trebovanie"

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})

export class FaceError {
    
}

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [TrebovanieStart],
    bootstrap: [TrebovanieStart]
})
export class Trebovanie {

}