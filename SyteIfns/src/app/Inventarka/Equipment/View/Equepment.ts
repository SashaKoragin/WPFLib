import { Component } from '@angular/core';
import { ModelColumns } from '../../ModelTable/Model/ModelTable';

@Component(({
    selector: 'equepment',
    templateUrl: '../Html/Equipment.html',
    styleUrls: ['../Html/Equipment.css'],

}) as any)

export class Equipment {
    tabs = ['Принтеры', 'Сканеры', 'МФУ', 'Системные блоки', 'Мониторы'];

  //  name: ModelColumns = new ModelColumns();
}