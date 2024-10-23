function solve(number, op1, op2, op3, op4, op5) {

    for (let i = 0; i < 5; i++) {
        switch (i) {
            case 0:
                switch (op1) {
                    case 'chop': number /= 2; break;
                    case 'dice': number = Math.sqrt(number); break;
                    case 'spice': number += 1; break;
                    case 'bake': number *= 3; break;
                    case 'fillet': number *= 0.8; break;
                }
                break;

            case 1:
                switch (op2) {
                    case 'chop': number /= 2; break;
                    case 'dice': number = Math.sqrt(number); break;
                    case 'spice': number += 1; break;
                    case 'bake': number *= 3; break;
                    case 'fillet': number *= 0.8; break;
                }
                break;

            case 2:
                switch (op3) {
                    case 'chop': number /= 2; break;
                    case 'dice': number = Math.sqrt(number); break;
                    case 'spice': number += 1; break;
                    case 'bake': number *= 3; break;
                    case 'fillet': number *= 0.8; break;
                }
                break;

            case 3:
                switch (op4) {
                    case 'chop': number /= 2; break;
                    case 'dice': number = Math.sqrt(number); break;
                    case 'spice': number += 1; break;
                    case 'bake': number *= 3; break;
                    case 'fillet': number *= 0.8; break;
                }
                break;

            case 4:
                switch (op5) {
                    case 'chop': number /= 2; break;
                    case 'dice': number = Math.sqrt(number); break;
                    case 'spice': number += 1; break;
                    case 'bake': number *= 3; break;
                    case 'fillet': number *= 0.8; break;
                }
                break;
        }

        console.log(number);
    }
}