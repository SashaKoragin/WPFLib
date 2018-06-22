import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,HttpErrorResponse,HttpResponse} from '@angular/common/http';
import { AdressMerge } from '../AdressFullRest/AdresSservice';
import { Observable } from 'rxjs';
import { Face, FaceErrorField, FaceAdd } from '../Otdel/Analiticks/FaceMerge/Model/FaceError';
import { Seting } from '../Otdel/Yregulirovanie/Trebovanie/Model/ModelTrebovanie';

const httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })

};

const httpOptionsXml = {
    headers: new HttpHeaders({ 'Content-Type': 'application/xml'})
}
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
    modeltest(seting: Seting) {

        return this.http.post(this.url.testingxml, seting, httpOptionsXml);
    }
}