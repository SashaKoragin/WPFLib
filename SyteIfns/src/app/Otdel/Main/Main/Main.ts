import { Component } from '@angular/core';
import { Otdel, ModelOtdel} from '../ModelOtdel/ModelOtdel';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import * as images from '../../../Images/ImageConst';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';
import 'signalr/jquery.signalR.js';
const img = images;  //Для WebPack

@Component(({
    selector: 'app-root',
    templateUrl: '../Html/Main.html',
    styleUrls: ['../Html/MainStyle.css'],
    providers: [Otdel]
}) as any)

export class Main {
    fullpath: string = null;
    model: string = null;
    nestedTreeControl: NestedTreeControl<ModelOtdel>;
    nestedDataSource: MatTreeNestedDataSource<ModelOtdel>;
    constructor(database: Otdel, private matIconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
        this.nestedTreeControl = new NestedTreeControl<ModelOtdel>(this._getChildren);
        this.nestedDataSource = new MatTreeNestedDataSource();
        database.dataChange.subscribe(data => this.nestedDataSource.data = data);
        matIconRegistry.addSvgIcon('Acvarius Server', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/Acvarius Server.svg'));
        matIconRegistry.addSvgIcon('DepoStorm 3606', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/DepoStorm 3606.svg'));
        matIconRegistry.addSvgIcon('DL360', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/DL360.svg'));
        matIconRegistry.addSvgIcon('DL580', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/DL580.svg'));
        matIconRegistry.addSvgIcon('IBM 3000', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/IBM 3000.svg'));
        matIconRegistry.addSvgIcon('SHD Acvariuse', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/SHD Acvariuse.svg'));
        matIconRegistry.addSvgIcon('SHD P2000', sanitizer.bypassSecurityTrustResourceUrl('/Ifns/public/images/SHD P2000.svg'));
    }
    hasNestedChild = (_: number, nodeData: ModelOtdel) => !nodeData.types;
    private _getChildren = (node: ModelOtdel) => node.children;

    selectmodel(node: ModelOtdel) {
        this.fullpath = 'Ветка: '+node.fullpath;
        this.model = 'Предназначение: ' + node.model;
    }
}