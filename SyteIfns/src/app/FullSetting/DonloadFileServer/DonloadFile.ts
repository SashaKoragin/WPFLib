import { DonloadFileReport } from '../../PostZaprosFull/PostFull';
export class DonloadFile {

    constructor(public donloadservice: DonloadFileReport) { }

    statusdonload:boolean = false;

    loadfile(namefile: string, urlget: string) {
        this.status();
        this.donloadservice.downloadFile(urlget).subscribe(data => {
            var blob = new Blob([data], { type: 'application/octet-stream' });
            var url = window.URL.createObjectURL(blob);
            var a = document.createElement('a');
            a.href = url;
            a.download = namefile;
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
            this.status();
        });
    }
    private status() {
        if (!this.statusdonload) {
            this.statusdonload = true;
        } else {
            this.statusdonload = false;
        }
    }
}