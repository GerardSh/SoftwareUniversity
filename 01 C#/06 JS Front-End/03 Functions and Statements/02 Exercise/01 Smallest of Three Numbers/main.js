function solve(numOne, numTwo, numThree) {
    console.log(numTwo < numOne && numTwo < numThree ? numTwo :
        numThree < numOne && numThree < numTwo ? numThree :
            numOne);
}
