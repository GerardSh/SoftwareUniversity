function solve(number) {
    let sum = 0;
    let areEqual = true;
    let lastDigit = number % 10;

    while (number > 0) {
        let digit = number % 10;
        number = Math.floor(number / 10);
        sum += digit;

        if (lastDigit != digit) {
            areEqual = false;
        }
    }

    console.log(areEqual);
    console.log(sum);
}