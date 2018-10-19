import { MatTableDataSource } from '@angular/material';
import { AngularTemplate , NameDocument, Headers, Stone, Body } from '../../Otdel/It/AddTemplate/Model/ModelTemplate';
import { WordDocument, UseTableTemplateBdk } from '../../Otdel/It/FormLetter/Model/ModelDataBase/ModelMail';
import { SysNum, Reshenie, TableSysNumReshen, Incass } from '../../Otdel/Yregulirovanie/Trebovanie/Model/ModelSelect';
import { DocumentReglament, DocumentDetalization } from '../../Otdel/Predproverka/Soprovod/Model/Model';
import { ViewChild } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { ServiceModel} from '../../PostZaprosFull/PostFull';


export class TableLetter {
    displaydataSource: string[] = ['id', 'iddoc', 'name', 'date', 'detal', 'vig'];
    displaydataSourceDetal: string[] = ['iddoc', 'imns', 'nameimns', 'namebdk', 'datebdk'];
    dataSource: MatTableDataSource<WordDocument>;
    dataSourceDetal: MatTableDataSource<UseTableTemplateBdk>;
}

export class TableReshenia {
    displaydataSource: string[] = ['d270', 'idstatus', 'error', 'dateBlokReshenie', 'idstat2', 'errorIncass', 'dateBlokIncass', 'detal'];
    displaydataSourceDetalSysNum: string[] = ['D865Res', 'D270', 'N1', 'Summ', 'N120', 'D850Res', 'D851Res', 'D270IshRes','DateCreate'];
    displaydataSourceDetalIncass: string[] = ['D851Res_1', 'D850Incass', 'D851Incass', 'Summ', 'D270IshIncass','DateCreate'];
    dataSource: MatTableDataSource<TableSysNumReshen>;
    dataSourceDetalSysNum: MatTableDataSource<Reshenie>;
    dataSourceDetalIncass: MatTableDataSource<Incass>;
}

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

export class PredproverkaTable {

    displaydataSourceDocumentReglament: string[] = ['Id', 'N441__1', 'Status1', 'MesErSt1', 'Status2', 'MesErSt2', 'DSt2','D85','Detal'];
    dataSourceDocumentReglament: MatTableDataSource<DocumentReglament>;
    displaydataSourceDocumentDetalization: string[] = ['Id', 'N441__1', 'IdProcedure', 'N333__1',
        'IdUser', 'IdGroup', 'IdDocument', 'N77', 'N441__4'];
    dataSourceDocumentDetalization: MatTableDataSource<DocumentDetalization>;
}