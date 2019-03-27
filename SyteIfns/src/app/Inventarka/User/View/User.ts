import { Component, OnInit } from '@angular/core';
import {PostInventar } from '../../../PostZaprosFull/PostInventarization';
import { ModelColumns, ModelsTable, Table } from '../../ModelTable/Model/ModelTable';
import { AllSelected, Users} from '../../ModelInventarization/Inventarization';
import { deserialize } from 'class-transformer';
@Component(({
    selector: 'equepment',
    templateUrl: '../Html/User.html',
    styleUrls: ['../Html/User.css'],
    providers: [PostInventar]
}) as any)

export class User implements OnInit {

    constructor(public httpclient: PostInventar) { }
    name: ModelColumns = null;
    model: ModelsTable = new ModelsTable();
    table: Table<Users> = null;
    select:AllSelected = null;
    ngOnInit(): void {
        this.httpclient.alluser(1).subscribe((model)=> {
            if (model) {
                this.select = deserialize(AllSelected, model.toString());
                this.table = new Table<Users>(this.select.Users, this.model.modelusers);
                this.name= new ModelColumns(this.table.models);
            }
        });

    }
}