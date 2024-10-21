function solve(numberOne, numberTwo, operator) {
    let result = null;

    switch (operator) {
        case '+':
            result = numberOne + numberTwo;
            break;
        case '-':
            result = numberOne - numberTwo;
            break;
        case '*':
            result = numberOne * numberTwo;
            break;
        case '/':
            result = numberOne / numberTwo;
            break;
        case '%':
            result = numberOne % numberTwo;
            break;
        case '**':
            result = numberOne ** numberTwo;
            break;
    }

    console.log(result);
}