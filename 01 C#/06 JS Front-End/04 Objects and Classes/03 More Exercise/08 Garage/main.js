function solve(input) {
    const parking = {};

    for (let car of input) {
        const [garageNumber, carInfo] = car.split(' - ');

        if (!parking.hasOwnProperty(garageNumber)) {
            parking[garageNumber] = [];
        }

        const carObj = {};
        const properties = carInfo.split(', ');

        for (const property of properties) {
            const [key, value] = property.split(': ');
            carObj[key] = value;
        }

        parking[garageNumber].push(carObj);
    }

    for (let key in parking) {
        console.log(`Garage № ${key}`);

        for (let car of parking[key]) {
            let carAsString = '--- ';
            const carProperties = Object.entries(car);

            for (let i = 0; i < carProperties.length; i++) {
                const [key, value] = carProperties[i];

                if (i == carProperties.length - 1) {
                    carAsString += `${key} - ${value}`;
                } else {
                    carAsString += `${key} - ${value}, `;
                }
            }

            console.log(carAsString);
        }
    }
}
