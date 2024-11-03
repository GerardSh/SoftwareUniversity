function solve(number, power) {
    let result = number;

    for (let i = 1; i < power; i++) {
        result *= number;
    }

    return result;
}