import { Component } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';

import { ISignalRConnection } from 'ng2-signalr';
import { ConnectionResolver } from '../../SignalRSignal/ConnectSignalR';
import { AuthServiceDomen } from '../../PostZaprosFull/PostFull';
import { ModelUser } from '../../FullSetting/FullSetting';
import { plainToClass } from 'class-transformer';

@Component({
    selector: 'login',
    templateUrl: '../Html/MySecurity.html',
    styleUrls: ['../Html/MySecurity.css']
})
export class LoginComponent {

    constructor(public authService: AuthServiceDomen, public router: Router, private signalR: ConnectionResolver) { }
    public connection: ISignalRConnection;
    login() {
        this.authService.login(this.signalR.user).subscribe((model) => {
            this.signalR.user.ModelUser = plainToClass(ModelUser, model as Object);
            this.authService.result(this.signalR.user);
                    if (this.authService.isLoggedIn) {
                        this.signalR.createconection();
                        this.signalR.start();
                        this.signalR.welcomestart();
                        let redirect = this.authService.redirectUrl ? this.authService.redirectUrl : '/admin';
                        let navigationExtras: NavigationExtras = {
                            queryParamsHandling: 'preserve',
                            preserveFragment: true
                        };
                        this.router.navigate([redirect], navigationExtras);
                    }
                });
    }

    logout() {
        this.authService.logout();
        this.signalR.stop();;
    }
}