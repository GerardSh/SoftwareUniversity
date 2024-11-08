function solve(numOne, numTwo, operator) {
    let result = 0;

    switch (operator) {
        case 'multiply':
            result = numOne * numTwo;
            break;
        case 'divide':
            result = numOne / numTwo;
            break;
        case 'add':
            result = numOne + numTwo;
            break;
        case 'subtract':
            result = numOne - numTwo;
            break;
    }

    console.log(result);
}




//2
function solve(num1, num2, operator) {

    const operations = {
        'multiply': (a, b) => a * b,
        'divide': (a, b) => a / b,
        'add': (a, b) => a + b,
        'subtract': (a, b) => a - b
    };

    console.log(operations[operator](num1, num2));
}
