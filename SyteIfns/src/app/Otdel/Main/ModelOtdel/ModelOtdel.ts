import { BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';

export class ModelOtdel {
    public  otdelfunc: string;
    public children: ModelOtdel[];
    public types: string;
    public pages: string;
    public fullpath: string;
    public model: string;
}

@Injectable()
export class Otdel {
    dataChange = new BehaviorSubject<ModelOtdel[]>([{otdelfunc: 'Выбор отдела',
                            children: [{ otdelfunc: 'Информационный отдел',
                                children: [{ otdelfunc: null, children: null, types: 'Бдк!!!', pages: './page1', fullpath: 'Информационный отдел\\Бдк!!!', model: 'Модуль для работы с Бдк!!!'},
                                    { otdelfunc: null, children: null, types: 'Формированмирование писем', pages: './page2', fullpath: 'Информационный отдел\\Формированмирование писем', model: 'Модуль для формирование писем Бдк!!!'},
                                    { otdelfunc: null, children: null, types: 'Создание шаблонов', pages: './page3', fullpath: 'Информационный отдел\\Создание шаблонов', model: 'Модуль для создания шаблонов!!!' },
                                    { otdelfunc: null, children: null, types: 'Проверка серверов', pages: './page10', fullpath: 'Информационный отдел\\Проверка серверов', model: 'Модуль для проверки серверов!!!' }], types: null, pages: null, fullpath: null, model: null
                                      },
                                      { otdelfunc: 'Урегулирование задолженности',
                                          children: [{ otdelfunc: null, children: null, types: 'Решения!!!', pages: './page4', fullpath: 'Урегулирование задолженности\\Решения!!!', model: 'Модуль для Решений!!!' }], types: null, pages: null, fullpath: null, model: null
                                      },
                                      { otdelfunc: 'Аналитический отдел',
                                          children: [{ otdelfunc: null, children: null, types: 'Отчет слияния лиц!!!', pages: './page5', fullpath: 'Аналитический отдел\\Отчет слияния лиц!!!', model: 'Модуль для слияния лиц!!!'},
                                              { otdelfunc: null, children: null, types: 'Анализ КРСБ!!!', pages: './page6', fullpath: 'Аналитический отдел\\Анализ КРСБ!!!', model: 'Модуль для анализа КРСБ прием!!!' }], types: null, pages: null, fullpath: null, model: null
                                      },
                                      { otdelfunc:'Отдел камеральных проверок №5',
                                          children: [{ otdelfunc: null, children: null, types: 'Разнообразные отчеты!!!', pages: './page9', fullpath: 'Отдел камеральных проверок №5\\Разнообразные отчеты!!!', model: 'Модуль для отчетов!!!' }], types: null, pages: null, fullpath: null, model: null
                                      },
                                      { otdelfunc: 'Отдел предпроверочного анализа',
                                          children: [{ otdelfunc: null, children: null, types: 'Поручение об истребовании!!!', pages: './page7', fullpath: 'Отдел предпроверочного анализа\\Поручение об истребовании!!!', model: 'Модуль для предпроверки!!!' }], types: null, pages: null, fullpath: null, model: null
                                      },
                                      { otdelfunc: 'Тестовый чат',
                                          children: [{ otdelfunc: null, children: null, types: 'Чат', pages: './page8', fullpath:'Тестовый чат\\Чат', model:'Общий чат'}], types:null, pages:null, fullpath:null, model:null
                                      }
        ], types: null, pages: null, fullpath: null, model: null
    }]);
}