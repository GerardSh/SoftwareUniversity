function solve(percentage) {
    if (percentage == 100) {
        console.log('100% Complete!');
        console.log(`[${new Array(10).fill('%').join('')}]`);

    } else {
        let loadCount = percentage / 10;
        array = new Array(10).fill(percentage > 0 ? '%' : '.', 0, loadCount);
        array.fill('.', loadCount, 10);

        console.log(`${percentage}% [${array.join('')}]`);
        console.log('Still loading...');
    }
}




//2
function solve(percentage) {
    let percentAsString = "%".repeat((percentage / 10));
    percentAsString = percentAsString.padEnd(10, ".");

    if (percentage === 100) {
        console.log("100% Complete!");
        console.log(`[${percentAsString}]`);
    } else {
        console.log(`${percentage}% [${percentAsString}]`);
        console.log("Still loading...");
    }
}
