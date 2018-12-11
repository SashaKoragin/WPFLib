//Сам написал проверка на регулярное выражение аналогичные проверки пишатся так-же
export function forbiddenNameValidator(nameRe) {
    return function (control) {
        var forbidden = nameRe.test(control.value);
        return forbidden ? null : { 'forbiddenName': { value: control.value } };
    };
}
export function validatorDate() {
    return function (control) {
        return control.value < new Date() ? null : { 'DateError': { value: control.value } };
    };
}
//# sourceMappingURL=FunctionValidation.js.map