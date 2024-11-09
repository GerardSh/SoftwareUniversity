function solve(number = 0) {
    const numbers = number.toString().split('').map(x => Number(x));
    const evenNumbers = numbers.filter(x => x % 2 == 0);
    const oddNumbers = numbers.filter(x => x % 2 != 0);

    let sumOdd = 0;
    let sumEven = 0;

    oddNumbers.forEach(x => sumOdd += x);
    evenNumbers.forEach(x => sumEven += x);

    console.log(`Odd sum = ${sumOdd}, Even sum = ${sumEven}`);
}
