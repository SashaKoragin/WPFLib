import { Component } from '@angular/core';
import { AuthGuard } from '../ModelSicurity/Model';

@Component(({
    selector: 'sicurity',
    templateUrl: '../Html/MySicurity.html',
    providers: [AuthGuard]
}) as any)
export class Sicurity {
    constructor(sicurity:AuthGuard){}
}