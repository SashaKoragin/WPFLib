var ServerAndComputer = /** @class */ (function () {
    function ServerAndComputer() {
    }
    return ServerAndComputer;
}());
export { ServerAndComputer };
var ServerIfns = /** @class */ (function () {
    function ServerIfns() {
    }
    return ServerIfns;
}());
export { ServerIfns };
var ServerModel = /** @class */ (function () {
    function ServerModel() {
        //Сборные строки серверов
        this.app040 = '';
        this.app041 = '';
        this.app001 = '';
        this.app025 = '';
        this.app007 = '';
        this.app051 = '';
    }
    ServerModel.prototype.nullable = function () {
        this.app040 = '';
        this.app041 = '';
        this.app001 = '';
        this.app025 = '';
        this.app007 = '';
        this.app051 = '';
    };
    ServerModel.prototype.select = function (servers) {
        this.nullable();
        for (var _i = 0, servers_1 = servers; _i < servers_1.length; _i++) {
            var ser = servers_1[_i];
            if (ser.Status === 'TimedOut') {
                this.timeOut(ser);
            }
            if (ser.Status === 'DestinationUnreachable') {
                this.destinationUnreachable(ser);
            }
        }
    };
    ServerModel.prototype.destinationUnreachable = function (servers) {
        this.model('Не доступен:', servers);
    };
    ServerModel.prototype.timeOut = function (servers) {
        this.model('Не пингуется: ', servers);
    };
    ServerModel.prototype.model = function (status, servers) {
        if (servers.ServerName === 'i7751-app040' || servers.ServerName === 'i7751-app035' || servers.ServerName === 'i7751-app043' || servers.ServerName === 'i7751-app033') {
            this.app040 += this.app040.concat(status + servers.ServerName + "; ");
        }
        if (servers.ServerName === 'i7751-app001') {
            this.app041 += this.app041.concat(status + servers.ServerName + "; ");
            ;
        }
        if (servers.ServerName === 'i7751-app041' || servers.Children === 'i7751-app041') {
            this.app001 += this.app001.concat(status + servers.ServerName + "; ");
            ;
        }
        if (servers.ServerName === 'i7751-app025') {
            this.app025 += this.app025.concat(status + servers.ServerName + "; ");
            ;
        }
        if (servers.ServerName === 'i7751-app007' || servers.Children === 'i7751-app007') {
            this.app007 += this.app007.concat(status + servers.ServerName + "; ");
            ;
        }
        if (servers.ServerName === 'i7751-app051') {
            this.app051 += this.app051.concat(status + servers.ServerName + "; ");
            ;
        }
    };
    return ServerModel;
}());
export { ServerModel };
//# sourceMappingURL=ServersModel.js.map