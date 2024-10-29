function solve(number, op1, op2, op3, op4, op5) {

    for (let i = 0; i < 5; i++) {
        switch (i) {
            case 0: numberManipulator(op1); break;
            case 1: numberManipulator(op2); break;
            case 2: numberManipulator(op3); break;
            case 3: numberManipulator(op4); break;
            case 4: numberManipulator(op5); break;
        }

        console.log(number);
    }

    function numberManipulator(operation) {

        if (operation === 'chop') {
            number /= 2;
        } else if (operation === 'dice') {
            number = Math.sqrt(number);
        } else if (operation === 'spice') {
            number += 1;
        } else if (operation === 'bake') {
            number *= 3;
        } else if (operation === 'fillet') {
            number *= 0.8;
        }
    }
}