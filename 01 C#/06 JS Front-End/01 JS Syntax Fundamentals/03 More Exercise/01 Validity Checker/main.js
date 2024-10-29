function solve(x1, y1, x2, y2) {
    let distance1Valid = isDistanceValid(x1, y1);
    console.log(`{${x1}, ${y1}} to {0, 0} is ${distance1Valid ? 'valid' : 'invalid'}`);

    let distance2Valid = isDistanceValid(x2, y2);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${distance2Valid ? 'valid' : 'invalid'}`);

    let distanceBetweenValid = isDistanceValid(x2 - x1, y2 - y1);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${distanceBetweenValid ? 'valid' : 'invalid'}`);

    function isDistanceValid(x, y) {
        let distance = Math.sqrt(x ** 2 + y ** 2);
        return Number.isInteger(distance);
    }
}