import { Pipe, PipeTransform } from '@angular/core';
import { TableSysNumReshen} from './ModelSelect'
@Pipe({
    name: 'elementfilter',
    pure: false
})

export class Filter implements PipeTransform {
    transform(reshen: TableSysNumReshen[], filter: TableSysNumReshen): TableSysNumReshen[] {
        if (!reshen || !filter) {
            return reshen;
        }
        return reshen.filter((item: TableSysNumReshen) => this.applyFilter(item, filter));

    }

    applyFilter(reshen: TableSysNumReshen, filter: TableSysNumReshen): boolean {
        for (let field in filter) {
            if (filter[field]) {
                if (typeof filter[field] === 'string') {
                    if (reshen[field].toString().toLowerCase().indexOf(filter[field].toString().toLowerCase()) === -1) {
                        return false;
                    }
                } else if (typeof filter[field] === 'number') {
                    if (reshen[field] !== filter[field]) {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}