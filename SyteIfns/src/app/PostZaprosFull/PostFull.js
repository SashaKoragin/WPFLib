var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AdressMerge } from '../AdressFullRest/AdresSservice';
var url = new AdressMerge();
var httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
var DataService = /** @class */ (function () {
    function DataService(http) {
        this.http = http;
    }
    DataService.prototype.getfacepost = function () {
        return this.http.post(url.addresError, null);
    };
    DataService.prototype.deleteface = function (face) {
        return this.http.post(url.addresDelFace, face.idField, httpOptionsJson);
    };
    DataService.prototype.addfacemerge = function (face) {
        try {
            return this.http.post(url.addresFaceAdd, face, httpOptionsJson);
        }
        catch (e) {
            alert(e.toString());
        }
    };
    DataService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], DataService);
    return DataService;
}());
export { DataService };
var PostTrebovanie = /** @class */ (function () {
    function PostTrebovanie(http) {
        this.http = http;
    }
    PostTrebovanie.prototype.procedurestart = function (setting) {
        try {
            return this.http.post(url.useprocedure, setting, httpOptionsJson);
        }
        catch (e) {
            alert(e.toString());
        }
    };
    PostTrebovanie = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], PostTrebovanie);
    return PostTrebovanie;
}());
export { PostTrebovanie };
var PostBdk = /** @class */ (function () {
    function PostBdk(http) {
        this.http = http;
    }
    PostBdk.prototype.modelbdk = function (setting) {
        return this.http.post(url.loadbdk, setting, httpOptionsJson);
    };
    PostBdk.prototype.startprocedurebdk = function (setting) {
        return this.http.post(url.procedurebdk, setting, httpOptionsJson);
    };
    PostBdk.prototype.createkrsb = function (setting) {
        return this.http.post(url.createkrsb, setting, httpOptionsJson);
    };
    PostBdk.prototype.analizkrsb = function (setting) {
        return this.http.post(url.analizkrsb, setting, httpOptionsJson);
    };
    PostBdk = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], PostBdk);
    return PostBdk;
}());
export { PostBdk };
var LetterForm = /** @class */ (function () {
    function LetterForm(http) {
        this.http = http;
    }
    LetterForm.prototype.modelbdk = function (setting) {
        return this.http.post(url.startoutbdkletter, setting, httpOptionsJson);
    };
    LetterForm = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], LetterForm);
    return LetterForm;
}());
export { LetterForm };
var PostSoprovod = /** @class */ (function () {
    function PostSoprovod(http) {
        this.http = http;
    }
    PostSoprovod.prototype.procedurestart = function (setting) {
        try {
            return this.http.post(url.startproceduresoprovod, setting, httpOptionsJson);
        }
        catch (e) {
            alert(e.toString());
        }
    };
    PostSoprovod = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], PostSoprovod);
    return PostSoprovod;
}());
export { PostSoprovod };
var ServiceModel = /** @class */ (function () {
    function ServiceModel(http) {
        this.http = http;
    }
    ServiceModel.prototype.modelservice = function (setting) {
        try {
            return this.http.post(url.servicecommand, setting, httpOptionsJson);
        }
        catch (e) {
            alert(e.toString());
        }
    };
    ServiceModel.prototype.datacommandserver = function (angular) {
        return this.http.post(url.sqlcommand, angular, httpOptionsJson);
    };
    ServiceModel.prototype.downloadFile = function (angular) {
        return this.http.post(url.donloadfileangular, angular, { responseType: 'arraybuffer', headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
    };
    ServiceModel = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], ServiceModel);
    return ServiceModel;
}());
export { ServiceModel };
var TemplateAdd = /** @class */ (function () {
    function TemplateAdd(http) {
        this.http = http;
    }
    TemplateAdd.prototype.addtemplate = function (template) {
        try {
            return this.http.post(url.addtemplate, template, httpOptionsJson);
        }
        catch (e) {
            alert(e.toString());
        }
    };
    TemplateAdd = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], TemplateAdd);
    return TemplateAdd;
}());
export { TemplateAdd };
var DonloadFileReport = /** @class */ (function () {
    function DonloadFileReport(http) {
        this.http = http;
    }
    DonloadFileReport.prototype.downloadFile = function (geturl) {
        return this.http.get(geturl, { responseType: 'arraybuffer' });
    };
    DonloadFileReport = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], DonloadFileReport);
    return DonloadFileReport;
}());
export { DonloadFileReport };
//# sourceMappingURL=PostFull.js.map