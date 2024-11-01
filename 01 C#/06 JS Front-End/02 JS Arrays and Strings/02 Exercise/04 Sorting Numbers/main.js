function solve(numbers = []) {
    numbers.sort((a, b) => a - b);

    let sortedNumbers = [];

    if (numbers.length % 2 == 1) {
        for (let i = 0; i <= numbers.length / 2 - 1; i++) {
            sortedNumbers.push(numbers[i]);
            sortedNumbers.push(numbers[numbers.length - i - 1]);
        }

        sortedNumbers.splice(parseInt(numbers.length - 1), 0, numbers[parseInt(numbers.length / 2)])
    } else {
        for (let i = 0; i < numbers.length / 2; i++) {
            sortedNumbers.push(numbers[i]);
            sortedNumbers.push(numbers[numbers.length - i - 1]);
        }
    }

    return sortedNumbers;
}




//2
function solve(numbers) {
    numbers.sort((num1, num2) => num1 - num2);

    let output = [];

    while (numbers.length > 0) {
        output.push(numbers.shift());

        if (numbers.length === 0) {
            break;
        }

        output.push(numbers.pop());
    }

    return output;
}
