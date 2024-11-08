function solve(numOne, numTwo, numThree) {
    const sum = (numOne, numTwo) => numOne + numTwo;
    const subtract = (numOne, numTwo) => numOne - numTwo;

    console.log(subtract(sum(numOne, numTwo), numThree));
}
