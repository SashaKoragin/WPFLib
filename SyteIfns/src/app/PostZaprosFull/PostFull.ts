import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,HttpErrorResponse,HttpResponse} from '@angular/common/http';
import { AdressMerge } from '../AdressFullRest/AdresSservice';
import { Observable } from 'rxjs';
import { Face, FaceErrorField, FaceAdd } from '../Otdel/Analiticks/FaceMerge/Model/FaceError';
import { Setting } from '../Otdel/Yregulirovanie/Trebovanie/Model/ModelReshenie';

const httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })

};

@Injectable()

export class DataService {
    
    private url: AdressMerge = new AdressMerge();
    constructor(private http: HttpClient) { }

    getfacepost(){
        return this.http.post(this.url.addresError, null);
    }

    deleteface(face: FaceErrorField){
        return this.http.post(this.url.addresDelFace, face.idField, httpOptionsJson);
    }

    addfacemerge(face: FaceAdd) {
        try {
            return this.http.post(this.url.addresFaceAdd, face, httpOptionsJson);
        } catch (e) {
            alert(e.toString());
        } 
    }

}



@Injectable()
export class PostTrebovanie {
    private url: AdressMerge = new AdressMerge();
    constructor(private http: HttpClient) { }

    modelreshenie(setting: Setting) {
   try {
       return this.http.post(this.url.loadreshenie, setting, httpOptionsJson);
       } catch(e) {
        alert(e.toString());
    } 
    }

    procedurestart(setting: Setting) {
        try {
            return this.http.post(this.url.useprocedure, setting, httpOptionsJson);
        } catch (e) {
            alert(e.toString());
        } 
    }
}