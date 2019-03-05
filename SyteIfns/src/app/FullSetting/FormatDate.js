import * as _moment from 'moment';
import * as _rollupMoment from 'moment';
export var moment = _rollupMoment || _moment;
var ConvertDate = /** @class */ (function () {
    function ConvertDate() {
    }
    ConvertDate.prototype.convertdate = function (date) {
        if (date !== null) {
            return moment(date.value).format('DD.MM.YYYY');
        }
        return null;
    };
    ConvertDate.prototype.convertDateToServer = function (date) {
        return "/Date(" + date.getTime() + ")/";
    };
    return ConvertDate;
}());
export { ConvertDate };
//# sourceMappingURL=FormatDate.js.map