function solve(number, power) {
    let result = number;

    for (let i = 1; i < power; i++) {
        result *= number;
    }

    return result;
}




//2
function solve(base, power, result = 1, i = 0) {
    if (i == power) {
        return result;
    }

    return solve(base, power, result * base, ++i);
}