import { NgModule } from '@angular/core';
import { AppRoutingModule } from './Navigate';
import { MainInventar } from '../../../Inventarka/Main/Main/MainInventarization';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from '../MaterialLibary/MaterialLibary';
import { ReactiveFormsModule } from '@angular/forms';
import { Equipment } from '../../../Inventarka/Equipment/View/Equepment';
import { Invent } from '../../../Inventarka/Invent/View/Invent';
import { User } from '../../../Inventarka/User/View/User';
import { FormsModule } from '@angular/forms';
import { Table } from  '../../../Inventarka/ModelTable/View/ViewModelTable';
import { PostInventar } from '../../../PostZaprosFull/PostInventarization';

@NgModule(({
    imports: [
        FormsModule,
        CommonModule,
        AngularMaterialModule,
        ReactiveFormsModule,
        AppRoutingModule
    ],
    declarations: [
        MainInventar, Equipment, Invent, User, Table
    ]
}) as any)

export class InventarModule { }