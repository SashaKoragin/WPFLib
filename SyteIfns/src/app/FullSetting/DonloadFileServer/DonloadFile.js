var DonloadFile = /** @class */ (function () {
    function DonloadFile(donloadservice) {
        this.donloadservice = donloadservice;
        this.statusdonload = false;
    }
    DonloadFile.prototype.loadfile = function (namefile, urlget) {
        var _this = this;
        this.status();
        this.donloadservice.downloadFile(urlget).subscribe(function (data) {
            var blob = new Blob([data], { type: 'application/octet-stream' });
            var url = window.URL.createObjectURL(blob);
            var a = document.createElement('a');
            a.href = url;
            a.download = namefile;
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
            _this.status();
        });
    };
    DonloadFile.prototype.status = function () {
        if (!this.statusdonload) {
            this.statusdonload = true;
        }
        else {
            this.statusdonload = false;
        }
    };
    return DonloadFile;
}());
export { DonloadFile };
//# sourceMappingURL=DonloadFile.js.map