function solve(number) {
    array = new Array(number).fill(number);

    for (let i = 0; i < number; i++) {
        console.log(array.join(' '));
    }
}




//2
function solve(number) {
    new Array(number).fill(new Array(number).fill(number)).
        forEach(x => console.log(x.join(' ')));
}
solve(7);
