function solve(numbers = []) {
    let sum = 0;
    numbers.filter(x => x % 2 == 0).forEach(x => sum += x);
    numbers.filter(x => x % 2 != 0).forEach(x => sum -= x);

    console.log(sum);
}