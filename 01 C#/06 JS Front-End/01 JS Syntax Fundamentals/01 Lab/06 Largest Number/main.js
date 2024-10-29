function solve(numberOne, numberTwo, numberThree) {
    let largestNumber = numberOne;

    if (numberTwo > largestNumber) {
        largestNumber = numberTwo;
    }

    if (numberThree > largestNumber) {
        largestNumber = numberThree;
    }

    console.log(`The largest number is ${largestNumber}.`);
}