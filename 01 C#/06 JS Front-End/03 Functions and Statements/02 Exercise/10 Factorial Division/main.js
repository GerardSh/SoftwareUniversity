function solve(numberOne, numberTwo) {
    function factorial(number) {
        if (number == 1) {
            return number;
        }

        return number * factorial(number - 1)
    }

    console.log((factorial(numberOne) / factorial(numberTwo)).toFixed(2));
}




//2
function solve(numberOne, numberTwo) {
    function factorial(number) {

        let result = 1;
        for (let i = number; i > 0; i--) {
            result *= i;
        }

        return result;
    }

    console.log((factorial(numberOne) / factorial(numberTwo)).toFixed(2));
}
