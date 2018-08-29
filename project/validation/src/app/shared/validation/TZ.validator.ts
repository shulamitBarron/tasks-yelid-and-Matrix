import { AbstractControl } from '@angular/forms';
//alligator web 

export function validateTZ(tz: AbstractControl) {
    if(tz.value.length!=9)
    return { validtz: true };
    let total = 0;
    let i;
    for (i = 0; i < 9; i++) {
        let x = (((i % 2) + 1) * tz.value.charAt(i));
        total += Math.floor(x / 10) + x % 10;
    }
    if (total % 10 == 0)
        return null;
    else return { validtz: true };
}





