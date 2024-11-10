function solve(number) {
    while (true) {
        let sum = sumDigits(number);
        let digitsLength = number.toString().length;

        if (isValid(sum, digitsLength)) {
            break;
        }

        number = Number(number.toString() + '9');
    }

    console.log(number);

    function sumDigits(number) {
        let sum = 0;
        [...number.toString()].forEach(x => sum += Number(x));

        return sum;
    }

    function isValid(number, length) {
        return number / length >= 5;
    }
}
