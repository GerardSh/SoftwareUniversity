function solve(input) {
    const parking = [];

    for (carDetails of input) {
        let [direction, number] = carDetails.split(', ');

        if (direction == 'IN' && !parking.includes(number)) {
            parking.push(number);
        } else if (direction == 'OUT' && parking.includes(number)) {
            parking.splice(parking.indexOf(number), 1);
        }
    }

    console.log(parking.length > 0 ? parking.sort((a, b) => a.localeCompare(b)).join('\r\n') : 'Parking Lot is Empty');
}
