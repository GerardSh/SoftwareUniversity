function solve(input) {
    const n = input.shift();
    const riders = input.splice(0, n)
        .reduce((agg, curr) => {
            const raiderDetails = curr.split('|');
            const [name, capacity, position] = [raiderDetails[0], Number(raiderDetails[1]), Number(raiderDetails[2])];

            if (capacity > 100) capacity = 100;

            agg[name] = { capacity, position };

            return agg;
        }, {})

    while (input != 'Finish') {
        const [command, rider, ...arg] = input.shift().split(' - ');
        const currRider = riders[rider];

        if (!currRider) continue;

        switch (command) {
            case 'StopForFuel': {
                const [minFuel, changedPosition] = [Number(arg[0]), Number(arg[1])];

                if (currRider.capacity < minFuel) {
                    currRider.position = changedPosition;

                    console.log(`${rider} stopped to refuel but lost his position, now he is ${changedPosition}.`);
                } else {
                    console.log(`${rider} does not need to stop for fuel!`);
                }
            }
                break;
            case 'Overtaking': {
                const rider2 = arg[0];
                const currRider2 = riders[rider2];

                if (!currRider2) continue;

                if (currRider.position < currRider2.position) {
                    const tempPosition = currRider.position;
                    currRider.position = currRider2.position;
                    currRider2.position = tempPosition;

                    console.log(`${rider} overtook ${rider2}!`);
                }
            }
                break;
            case 'EngineFail': {
                const lapsLeft = Number(arg[0]);

                delete riders[rider];

                console.log(`${rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
            }
                break;
        }
    }

    for (const rider in riders) {
        console.log(rider);
        console.log(`  Final position: ${riders[rider].position}`);
    }
};
