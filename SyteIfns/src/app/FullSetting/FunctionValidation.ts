import { ValidatorFn, AbstractControl } from '@angular/forms';


//Сам написал проверка на регулярное выражение аналогичные проверки пишатся так-же
export function forbiddenNameValidator(nameRe: RegExp): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
        const forbidden = nameRe.test(control.value);
        return forbidden ? null : { 'forbiddenName': { value: control.value } };
    };
}

export function validatorDate(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
        return control.value < new Date() ? null : { 'DateError': { value: control.value } }
    };
}