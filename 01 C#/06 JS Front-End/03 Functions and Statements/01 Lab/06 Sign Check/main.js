function solve(...numbers) {
    let minusCount = 0;

    for (number of numbers) {
        if (number < 0) {
            minusCount++;
        }
    }

    let result = '';

    switch (minusCount) {
        case 1:
        case 3:
            result = 'Negative';
            break;
        default:
            result = 'Positive';
            break;
    }

    console.log(result);
}




//2
function solve(...numbers) {
    console.log(numbers.filter(x => x < 0).length % 2 == 0 ? 'Positive' : "Negative");
}
