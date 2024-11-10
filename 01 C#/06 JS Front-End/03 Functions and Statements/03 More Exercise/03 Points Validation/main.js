function solve(input) {
    const [x1, y1, x2, y2] = input;

    function isValidDistance(x1, y1, x2, y2) {
        const distance = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);
        return Number.isInteger(distance);
    }

    if (isValidDistance(x1, y1, 0, 0)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (isValidDistance(x2, y2, 0, 0)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (isValidDistance(x1, y1, x2, y2)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}
