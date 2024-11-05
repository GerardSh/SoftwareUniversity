function mathPower(number, power) {
    let result = number;

    for (let i = 1; i < power; i++) {
        result *= number;
    }

    console.log(result);
}




//2
function mathPower(base, power, result = 1, i = 0) {
    if (i == power) {
        return result;
    }

    return mathPower(base, power, result * base, ++i);
}




//3
function mathPower(base, power) {
    if (power === 1) {
        return base;
    }

    return base * mathPower(base, power - 1);
}




//4
function mathPower(base, power) {
     console.log(base ** power);
}