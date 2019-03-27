import { Component, Input } from '@angular/core';
import { ModelColumns } from '../Model/ModelTable';

@Component(({
    selector: 'tablessql',
    templateUrl: '../HtmlTable/HtmlTable.html',
    styleUrls: ['../HtmlTable/HtmlTable.css']

}) as any)


export class Table {
    @Input() model: ModelColumns;
}