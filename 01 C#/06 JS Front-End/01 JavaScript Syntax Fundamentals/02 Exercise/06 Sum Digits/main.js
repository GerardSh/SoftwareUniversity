function solve(num) {
    let sum = 0;
    while (num > 0) {
        let currentNumber = num % 10;
        sum += currentNumber;
        num = Math.floor(num / 10)
    }

    console.log(sum);
}