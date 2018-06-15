import { Component, OnInit} from "@angular/core";
import { AdressMerge } from './adress/app.adressservice';
import { Face, FaceErrorField, FaceAdd } from "./model/app.model";
import { DataService } from './app.post';
import { catchError, retry, map } from 'rxjs/operators';
import { Test } from "./model/test";
import { plainToClass } from "class-transformer";
//По сути патерн MVVM только в рамках асинхронности
@Component({
    selector: "my-app",
    templateUrl: './template/MergeFace.html',
    providers: [DataService]
})
    
export class AppComponent implements OnInit { 
    facemodel: Face;
    faces: FaceAdd = new FaceAdd();
    server: string = null;
    tableMode: boolean = true;

    constructor(private dataservice: DataService) {}

    ngOnInit(): void {
        this.load();
    }

    load() {
        this.dataservice.getfacepost().subscribe((model) => {
            this.facemodel = plainToClass(Face, model as Object);
            } 
        );
    }

    del(face: FaceErrorField) {
        this.dataservice.deleteface(face).subscribe((model) => {
            this.server = JSON.stringify(model);
            this.load();
        });
    }

    addface(faces: FaceAdd) {
        try {
            this.dataservice.addfacemerge(faces).subscribe((model) => {
                this.server = JSON.stringify(model);
                this.load();
            });
        } catch (e) {
            alert(e.toString());
        } 
    }

}