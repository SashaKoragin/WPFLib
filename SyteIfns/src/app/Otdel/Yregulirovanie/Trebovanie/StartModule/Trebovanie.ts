import { Component, OnInit } from '@angular/core';
import { PostTrebovanie } from '../../../../PostZaprosFull/PostFull';
import { Seting } from '../Model/ModelTrebovanie'

@Component(
{
        selector: 'my-treb',
        templateUrl: '../Template/Trebovanie.html',
        providers: [PostTrebovanie]

})

export class TrebovanieStart implements OnInit{
    setting:Seting = new Seting();
    component:string = 'Круто!!!';
    constructor(private dataservice: PostTrebovanie) { }

    ngOnInit(): void {
        this.component = 'Крутто 2 компанент!!! Ура добились!!!';
    }
    use(): void {
      this.setting.Db = 'work';
        this.setting.Id = 1;
        this.setting.ParametrSelect.D270 = 22222;
        alert(this.setting.ParametrSelect.D270);
        this.dataservice.modeltest(this.setting).subscribe((model) => { JSON.stringify(model) });
    }
}