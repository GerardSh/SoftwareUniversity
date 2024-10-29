function solve(input) {
    if (typeof input != 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeof input}.`);
    } else {
        let result = Math.PI * input ** 2;
        console.log(result.toFixed(2));
    }
}