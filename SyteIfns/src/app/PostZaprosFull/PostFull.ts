import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AdressMerge } from '../AdressFullRest/AdresSservice';
import { FaceErrorField, FaceAdd } from '../Otdel/Analiticks/FaceMerge/Model/FaceError';
import { FullSetting } from '../FullSetting/FullSetting';
import { AngularModel, AngularModelFileDonload } from '../ModelService/ModelService';
import { AngularTemplate } from '../Otdel/It/AddTemplate/Model/ModelTemplate'

const url: AdressMerge = new AdressMerge();
const httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })

};

@Injectable({
    providedIn: 'root'
})
    export class AuthServiceDomen {
    constructor(private http: HttpClient) { }


    isLoggedIn = false;

    // store the URL so we can redirect after logging in
    redirectUrl: string;

    login(setting: FullSetting) {
        setting.ModelUser.Error = null;
        return this.http.post(url.authservicedomain, setting, httpOptionsJson);
    }

    result(setting: FullSetting) {
        if (setting.ModelUser.Error === null) {
            this.isLoggedIn = true;
        } else {
            this.isLoggedIn = false;
        }
    }



    logout(): void {
        this.isLoggedIn = false;
    }
}

@Injectable()
export class DataService {
    constructor(private http: HttpClient) { }

    getfacepost() {
        return this.http.post(url.addresError, null);
    }

    deleteface(face: FaceErrorField) {
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
    createkrsb(setting: FullSetting) {
        return this.http.post(url.createkrsb, setting, httpOptionsJson);
    }
    analizkrsb(setting: FullSetting) {
        return this.http.post(url.analizkrsb, setting, httpOptionsJson);
    }
}

@Injectable()
export class LetterForm {
    constructor(private http: HttpClient ) { }

    modelbdk(setting: FullSetting) {
        return this.http.post(url.startoutbdkletter, setting, httpOptionsJson);
    }
}

@Injectable()
export class PostSoprovod {
    constructor(private http: HttpClient) { }

    procedurestart(setting: FullSetting) {
        try {
            return this.http.post(url.startproceduresoprovod, setting, httpOptionsJson);
        } catch (e) {
            alert(e.toString());
        }
    }
}


@Injectable()
export class ServiceModel {
    constructor(private http: HttpClient) { }

    modelservice(setting: FullSetting) {
        try {
            return this.http.post(url.servicecommand, setting, httpOptionsJson);
        } catch (e) {
            alert(e.toString());
        }
    }

    datacommandserver(angular: AngularModel) {
        return this.http.post(url.sqlcommand, angular, httpOptionsJson);
    }

    downloadFile(angular:AngularModelFileDonload) {
        return this.http.post(url.donloadfileangular, angular,
            { responseType: 'arraybuffer', headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
    }
}

@Injectable()
export class TemplateAdd {
    constructor(private http: HttpClient) { }

   public addtemplate(template: AngularTemplate) {
        try {
            return this.http.post(url.addtemplate, template, httpOptionsJson);
        } catch (e) {
            alert(e.toString());
        }
    }
}

@Injectable()
export class DonloadFileReport {
    constructor(private http: HttpClient) { }
   public downloadFile(geturl:string) {
        return this.http.get(geturl, { responseType: 'arraybuffer' });
    }
}

@Injectable()
export class Kam5Report {
    constructor(private http: HttpClient) { }

    public reportFile(setting: FullSetting) {
        return this.http.post(url.reportKam5,
            setting,
            { responseType: 'arraybuffer', headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
    }
}