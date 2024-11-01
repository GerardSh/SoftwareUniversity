function solve(array = [], number = 0) {
    let newArray = array.filter((x, index) => index % number == 0);

    return newArray;
}