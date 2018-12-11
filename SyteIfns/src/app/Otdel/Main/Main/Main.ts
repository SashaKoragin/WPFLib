import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Otdel, ModelOtdel} from '../ModelOtdel/ModelOtdel';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';

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
    constructor(database: Otdel) {
        this.nestedTreeControl = new NestedTreeControl<ModelOtdel>(this._getChildren);
        this.nestedDataSource = new MatTreeNestedDataSource();
        database.dataChange.subscribe(data => this.nestedDataSource.data = data);
    }
    hasNestedChild = (_: number, nodeData: ModelOtdel) => !nodeData.types;
    private _getChildren = (node: ModelOtdel) => node.children;

    selectmodel(node: ModelOtdel) {
        this.fullpath = 'Ветка: '+node.fullpath;
        this.model = 'Предназначение: ' + node.model;
    }
}