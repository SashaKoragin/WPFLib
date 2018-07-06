var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Pipe } from '@angular/core';
var Filter = /** @class */ (function () {
    function Filter() {
    }
    Filter.prototype.transform = function (reshen, filter) {
        var _this = this;
        if (!reshen || !filter) {
            return reshen;
        }
        return reshen.filter(function (item) { return _this.applyFilter(item, filter); });
    };
    Filter.prototype.applyFilter = function (reshen, filter) {
        for (var field in filter) {
            if (filter[field]) {
                if (typeof filter[field] === 'string') {
                    if (reshen[field].toString().toLowerCase().indexOf(filter[field].toString().toLowerCase()) === -1) {
                        return false;
                    }
                }
                else if (typeof filter[field] === 'number') {
                    if (reshen[field] !== filter[field]) {
                        return false;
                    }
                }
            }
        }
        return true;
    };
    Filter = __decorate([
        Pipe({
            name: 'elementfilter',
            pure: false
        })
    ], Filter);
    return Filter;
}());
export { Filter };
//# sourceMappingURL=Filter.js.map