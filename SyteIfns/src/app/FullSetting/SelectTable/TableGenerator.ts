import { MatTableDataSource } from '@angular/material';
import { NameDocument, Headers, Stone, Body } from '../../Otdel/It/AddTemplate/Model/ModelTemplate';
import { WordDocument, UseTableTemplateBdk } from '../../Otdel/It/FormLetter/Model/ModelDataBase/ModelMail';
import { Reshenie, TableSysNumReshen, Incass } from '../../Otdel/Yregulirovanie/Trebovanie/Model/ModelSelect';
import { DocumentReglament, DocumentDetalization } from '../../Otdel/Predproverka/Soprovod/Model/Model';

import { SelectionModel } from '@angular/cdk/collections';

import { TableInfoDelo } from '../FormValidation/Dialog/CreateDela/Class/ModelDelaPriem';
import { Delo, AnalizNO } from '../../Otdel/Analiticks/AnalizNo/Model/ModelAnaliz';
//Класс таблиц Создания писем
export class TableLetter {
    displaydataSource: string[] = ['id', 'iddoc', 'name', 'date', 'detal', 'vig'];
    displaydataSourceDetal: string[] = ['iddoc', 'imns', 'nameimns', 'namebdk', 'datebdk'];
    dataSource: MatTableDataSource<WordDocument>;
    dataSourceDetal: MatTableDataSource<UseTableTemplateBdk>;
}
//Класс таблиц Решения
export class TableReshenia {
    displaydataSource: string[] = ['d270', 'idstatus', 'error', 'dateBlokReshenie', 'idstat2', 'errorIncass', 'dateBlokIncass', 'detal'];
    displaydataSourceDetalSysNum: string[] = ['D865Res', 'D270', 'N1', 'Summ', 'N120', 'D850Res', 'D851Res', 'D270IshRes','DateCreate'];
    displaydataSourceDetalIncass: string[] = ['D851Res_1', 'D850Incass', 'D851Incass', 'Summ', 'D270IshIncass','DateCreate'];
    dataSource: MatTableDataSource<TableSysNumReshen>;
    dataSourceDetalSysNum: MatTableDataSource<Reshenie>;
    dataSourceDetalIncass: MatTableDataSource<Incass>;
}
//Класс таблиц для создания Шаблона
export class TableTemplate {
    displaydataSource: string[] = ['Id', 'IdNamedocument', 'NameDocument', 'ManualDoc', 'IdTemplate', 'DateCreate','Detal'];
    dataSource: MatTableDataSource<NameDocument>;
    displaydataSourceBody: string[] = ['Select', 'IdBody', 'BodyGl1', 'BodyGl2', 'BodyGl3', 'BodyGl4', 'BodyGl4','DateCreate'];
    dataSourceBody: MatTableDataSource<Body>;
    selectionBody = new SelectionModel<Body>(false, []);

    displaydataSourceHeaders: string[] = ['Select', 'IdHeaders', 'TextHeade1', 'TextHeade2',
        'TextHeade3', 'TextHeade4', 'TextHeade5', 'TextHeade6', 'TextHeade7', 'TextHeade8', 'TextHeade9', 'TextHeade10', 'DateCreate'];
    dataSourceHeaders: MatTableDataSource<Headers>;
    selectionHeaders = new SelectionModel<Headers>(false, []);

    displaydataSourceStone: string[] = ['Select', 'IdStone', 'Stone1', 'Stone2',
        'Stone3', 'Stone4', 'Stone5', 'Stone6', 'Stone7', 'DateCreate'];
    dataSourceStone: MatTableDataSource<Stone>;
    selectionStone = new SelectionModel<Stone>(false, []);
}
//Класс таблиц предпроверки
export class PredproverkaTable {

    displaydataSourceDocumentReglament: string[] = ['Id', 'N441__1', 'Status1', 'MesErSt1', 'Status2', 'MesErSt2', 'DSt2','D85','Detal'];
    dataSourceDocumentReglament: MatTableDataSource<DocumentReglament>;
    displaydataSourceDocumentDetalization: string[] = ['Id', 'N441__1', 'IdProcedure', 'N333__1',
        'IdUser', 'IdGroup', 'IdDocument', 'N77', 'N441__4'];
    dataSourceDocumentDetalization: MatTableDataSource<DocumentDetalization>;
}

export class DeloPriem {

    displaydataDeloCreate: string[] = ['IdDelo', 'Id', 'Id2', 'Command'];
    dataSourceDeloCreate: MatTableDataSource<TableInfoDelo>;
    //Есть ли данные или нет данных
    yesdate: boolean = true;
    //Добавление в таблицу
    addTable(tableinfo: TableInfoDelo[]) {
        this.dataSourceDeloCreate =new MatTableDataSource<TableInfoDelo>(tableinfo);
    }
}

export class NoAnalizTable {

    displaydataDeloNo: string[] = ['Select', 'D3979', 'Status1Priem', 'MessagePriem', 'Status1Analiz',
        'MessageAnaliz', 'DateCreate', 'Button'];
    dataSourceDeloNo: MatTableDataSource<Delo>;
    selectionDelo = new SelectionModel<Delo>(false, []);
    displaydataAnalizNo: string[] = ['D3979', 'D3972', 'Color', 'DateAnaliz', 'MessageDate1', 'StrahovieAndOtkazAnaliz',
        'MessageStrahovieAndOtkaz1', 'StatusUhAnaliz', 'MessageStatusUh1', 'Vivod', 'MessageVivod1',
        'D6', 'D1560_2', 'D1560_1', 'DatePeredachi', 'DateZakritia', 'N134', 'D3', 'Kbk', 'OKTMO_old',
        'D09_3', 'N1_1', 'N279', 'OKTMO_new', 'DateCreate', 'Error','DateError'];
    dataSourceAnalizNo: MatTableDataSource<AnalizNO>;
    selectAnalizNo: boolean = true;

    addTableDelo(no: Delo[]) {
        this.dataSourceDeloNo = new MatTableDataSource<Delo>(no);
    }

    addTableAnaliz(analiz: AnalizNO[]) {
        this.dataSourceAnalizNo = new MatTableDataSource<AnalizNO>(analiz);
    }

    selectiondelo() {
        if (this.selectionDelo.selected.length > 0) {
            this.selectionDelo.selected.map(delo => {
                this.addTableAnaliz(delo.AnalizNO);
                this.selectAnalizNo = false;
            });
        } else {
            this.addTableAnaliz(null);
            this.selectAnalizNo = true;
        }
    }

}