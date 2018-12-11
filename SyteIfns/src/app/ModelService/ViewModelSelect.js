import { FormSelect } from './ModelSelect';
var ViewModelSelect = /** @class */ (function () {
    function ViewModelSelect() {
        ///Выборка для анализа данных по созданию КРСБ (Мочалов Михаил)
        this.parametrdelo = [
            { name: 'Ун дела приема', nameparametr: 'Delo.D3979', paramvalue: '', select: null, numеrtemplate: false, template: 3, formTemplate: new FormSelect().numberPole },
            { name: 'Ун статуса приема', nameparametr: 'Delo.Status1Priem', paramvalue: '', select: null, numеrtemplate: false, template: 3, formTemplate: new FormSelect().numberPole },
            { name: 'Описание приема', nameparametr: 'StatusPriem.MessagePriem', paramvalue: '', select: null, numеrtemplate: true, template: 2, formTemplate: new FormSelect().stringPole },
            { name: 'Ун статуса анализа', nameparametr: 'Delo.Status1Analiz', paramvalue: '', select: null, numеrtemplate: false, template: 3, formTemplate: new FormSelect().numberPole },
            { name: 'Дата записи', nameparametr: 'Delo.D85', paramvalue: '', select: null, numеrtemplate: true, template: 1, formTemplate: new FormSelect().datePole }
        ];
    }
    return ViewModelSelect;
}());
export { ViewModelSelect };
//# sourceMappingURL=ViewModelSelect.js.map