function solve(numbers = [], number = 0) {
    for (let i = 0; i < number; i++) {
        numbers.push(numbers.shift());
    }

    console.log(numbers.join(' '));
}