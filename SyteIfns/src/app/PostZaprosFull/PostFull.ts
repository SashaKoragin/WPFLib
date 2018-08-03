import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,HttpErrorResponse,HttpResponse} from '@angular/common/http';
import { AdressMerge } from '../AdressFullRest/AdresSservice';
import { Observable } from 'rxjs';
import { Face, FaceErrorField, FaceAdd } from '../Otdel/Analiticks/FaceMerge/Model/FaceError';
import { FullSetting } from '../FullSetting/FullSetting'

const url: AdressMerge = new AdressMerge();
const httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable()

export class DataService {
    
    
    constructor(private http: HttpClient) { }

    getfacepost(){
        return this.http.post(url.addresError, null);
    }

    deleteface(face: FaceErrorField){
        return this.http.post(url.addresDelFace, face.idField, httpOptionsJson);
    }

    addfacemerge(face: FaceAdd) {
        try {
            return this.http.post(url.addresFaceAdd, face, httpOptionsJson);
        } catch (e) {
            alert(e.toString());
        } 
    }

}



@Injectable()
export class PostTrebovanie {
    constructor(private http: HttpClient) { }

    modelreshenie(setting: FullSetting) {
   try {
       return this.http.post(url.loadreshenie, setting, httpOptionsJson);
       } catch(e) {
        alert(e.toString());
    }
    }

    procedurestart(setting: FullSetting) {
        try {
            return this.http.post(url.useprocedure, setting, httpOptionsJson);
        } catch (e) {
            alert(e.toString());
        } 
    }
}

@Injectable()
export class PostBdk {
    constructor(private http: HttpClient) { }

    modelbdk(setting: FullSetting) {
            return this.http.post(url.loadbdk, setting, httpOptionsJson);
    }

    startprocedurebdk(setting: FullSetting) {
            return this.http.post(url.procedurebdk, setting, httpOptionsJson);
    }
}