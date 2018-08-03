import { Component, OnInit} from "@angular/core";
import { Face, FaceErrorField, FaceAdd } from "../Model/FaceError";
import { DataService } from '../../../../PostZaprosFull/PostFull';
import { catchError, retry, map } from 'rxjs/operators';
import { plainToClass } from "class-transformer";

//По сути патерн MVVM только в рамках асинхронности
@Component(({
    selector: 'my-app',
    templateUrl: '../Template/MergeFace.html',
    providers: [DataService]
})as any)
    
export class AppComponent implements OnInit { 
    facemodel: Face = null;
    faces: FaceAdd = new FaceAdd();
    server: string = null;
    tableMode: boolean = false;

    constructor(private dataservice: DataService) {}

    ngOnInit(): void {
        this.load();
    }

    load() {
        this.dataservice.getfacepost().subscribe((model) => {
            this.facemodel = plainToClass(Face, model as Object);
            if (this.facemodel.SqlFaceErrorResult != null) {
                this.tableMode = true;
            }
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