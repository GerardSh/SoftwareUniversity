function solve(speed, area) {
    let output = null;

    switch (area) {
        case 'motorway': {
            let allowedSpeed = 130;
            if (speed <= allowedSpeed) {
                output = `Driving ${speed} km/h in a ${allowedSpeed} zone`
            } else {
                let difference = speed - allowedSpeed;
                let status = '';
                if (difference <= 20) {
                    status = 'speeding';
                } else if (difference <= 40) {
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }

                output = `The speed is ${difference} km/h faster than the allowed speed of ${allowedSpeed} - ${status}`;
            }
        }
            break;

        case 'interstate': {
            let allowedSpeed = 90;

            if (speed <= allowedSpeed) {
                output = `Driving ${speed} km/h in a ${allowedSpeed} zone`
            } else {
                let difference = speed - allowedSpeed;
                let status = '';
                if (difference <= 20) {
                    status = 'speeding';
                } else if (difference <= 40) {
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }

                output = `The speed is ${difference} km/h faster than the allowed speed of ${allowedSpeed} - ${status}`;
            }
        }
            break;

        case 'city': {
            let allowedSpeed = 50;

            if (speed <= allowedSpeed) {
                output = `Driving ${speed} km/h in a ${allowedSpeed} zone`
            } else {
                let difference = speed - allowedSpeed;
                let status = '';
                if (difference <= 20) {
                    status = 'speeding';
                } else if (difference <= 40) {
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }

                output = `The speed is ${difference} km/h faster than the allowed speed of ${allowedSpeed} - ${status}`;
            }
        }
            break;

        case 'residential': {
            let allowedSpeed = 20;

            if (speed <= allowedSpeed) {
                output = `Driving ${speed} km/h in a ${allowedSpeed} zone`
            } else {
                let difference = speed - allowedSpeed;
                let status = '';
                if (difference <= 20) {
                    status = 'speeding';
                } else if (difference <= 40) {
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }

                output = `The speed is ${difference} km/h faster than the allowed speed of ${allowedSpeed} - ${status}`;
            }
        }
            break;
    }

    console.log(output);
}