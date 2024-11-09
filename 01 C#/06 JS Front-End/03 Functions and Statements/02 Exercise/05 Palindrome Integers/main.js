function solve(numbers = []) {
    numbers.forEach(x => {
        console.log(Number(x.toString()
            .split('')
            .reverse()
            .join('')) == x);
    })
}
