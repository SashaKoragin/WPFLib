import { Pipe, PipeTransform } from '@angular/core';
import { TableSysNumReshenField} from './ModelSelect'
@Pipe({
    name: 'elementfilter',
    pure: false
})

export class Filter implements PipeTransform {
    transform(reshen: TableSysNumReshenField[], filter: TableSysNumReshenField): TableSysNumReshenField[] {
        if (!reshen || !filter) {
            return reshen;
        }
        return reshen.filter((item: TableSysNumReshenField) => this.applyFilter(item, filter));

    }

    applyFilter(reshen: TableSysNumReshenField, filter: TableSysNumReshenField): boolean {
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