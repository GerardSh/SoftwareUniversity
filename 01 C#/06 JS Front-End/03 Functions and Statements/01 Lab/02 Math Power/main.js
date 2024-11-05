function solve(number, power) {
    console.log(mathPower(number, power));

    function mathPower(number, power) {
        let result = number;

        for (let i = 1; i < power; i++) {
            result *= number;
        }

        return result;
    }
}




//2
function solve(base, power) {
    console.log(mathPower(base, power));

    function mathPower(base, power, result = 1, i = 0) {
        if (i == power) {
            return result;
        }

        return mathPower(base, power, result * base, ++i);
    }
}




//3
function solve(base, power) {
    console.log(mathPower(base, power));

    function mathPower(base, power) {
        if (power === 1) {
            return base;
        }

        return base * mathPower(base, power - 1);
    }
}