import * as _moment from 'moment';
import * as _rollupMoment from 'moment';

export const moment = _rollupMoment || _moment;

export class ConvertDate {

    public convertdate(date: any): string {
        if (date !== null) {
            return moment(date.value).format('DD.MM.YYYY');
        }
        return null;
    }

    public convertDateToServer(date: any): string {
        return `/Date(${date.getTime()})/`;
    }
}