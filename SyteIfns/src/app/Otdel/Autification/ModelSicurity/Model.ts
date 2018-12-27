import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router) { }
    str:boolean = false;
    canActivate() {
        if (this.str) {
            return true;
        }
        //Redirect the user before denying them access to this route
        this.router.navigate(['/login']);
        return false;
    }

    use() {
        if (this.str) {
            this.str = true;
        } else {
            this.str = false;
        }
    }
}