var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AdressMerge } from '../AdressFullRest/AdresSservice';
var url = new AdressMerge();
var httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
var AuthServiceDomen = /** @class */ (function () {
    function AuthServiceDomen(http) {
        this.http = http;
        this.isLoggedIn = false;
    }
    AuthServiceDomen.prototype.login = function (setting) {
        setting.ModelUser.Error = null;
        console.log("Прошли 2");
        return this.http.post(url.authservicedomain, setting, httpOptionsJson);
    };
    AuthServiceDomen.prototype.result = function (setting) {
        if (setting.ModelUser.Error === null) {
            this.isLoggedIn = true;
        }
        else {
            this.isLoggedIn = false;
        }
    };
    AuthServiceDomen.prototype.logout = function () {
        this.isLoggedIn = false;
    };
    AuthServiceDomen = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [HttpClient])
    ], AuthServiceDomen);
    return AuthServiceDomen;
}());
export { AuthServiceDomen };
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
var Kam5Report = /** @class */ (function () {
    function Kam5Report(http) {
        this.http = http;
    }
    Kam5Report.prototype.reportFile = function (setting) {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.http.post(url.reportKam5, setting, { responseType: 'arraybuffer', headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }).toPromise().then(function (data) {
                            var blob = new Blob([data], { type: 'application/octet-stream' });
                            var url = window.URL.createObjectURL(blob);
                            var a = document.createElement('a');
                            a.href = url;
                            a.download = 'Отчет.xlsx';
                            document.body.appendChild(a);
                            a.click();
                            document.body.removeChild(a);
                            window.URL.revokeObjectURL(url);
                        })];
                    case 1: return [2 /*return*/, _a.sent()];
                }
            });
        });
    };
    Kam5Report = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], Kam5Report);
    return Kam5Report;
}());
export { Kam5Report };
var ServersSqlAll = /** @class */ (function () {
    function ServersSqlAll(http) {
        this.http = http;
    }
    ServersSqlAll.prototype.sqlServer = function (setting) {
        return this.http.post(url.serversFullSql, setting, httpOptionsJson);
    };
    ServersSqlAll = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], ServersSqlAll);
    return ServersSqlAll;
}());
export { ServersSqlAll };
//# sourceMappingURL=PostFull.js.map