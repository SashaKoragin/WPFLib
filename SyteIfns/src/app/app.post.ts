import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,HttpErrorResponse,HttpResponse} from '@angular/common/http';
import { AdressMerge } from './adress/app.adressservice';
import { Observable } from 'rxjs';
import { Face, FaceErrorField, FaceAdd } from './model/app.model';
import { catchError, retry, map } from 'rxjs/operators';
import * as jquery from 'jquery';

const httpOptions = {
    headers: new HttpHeaders({'Content-Type':'application/json'})

};
@Injectable()





export class DataService {
    
    private url: AdressMerge = new AdressMerge();
    constructor(private http: HttpClient) { }

    getfacepost(){
        return this.http.post(this.url.addresError, null);
    }

    deleteface(face: FaceErrorField){
        return this.http.post(this.url.addresDelFace, face.idField, httpOptions);
    }

    addfacemerge(face: FaceAdd) {
        try {
         return this.http.post(this.url.addresFaceAdd,face, httpOptions);
        } catch (e) {
            alert(e.toString());
        } 
    }

}