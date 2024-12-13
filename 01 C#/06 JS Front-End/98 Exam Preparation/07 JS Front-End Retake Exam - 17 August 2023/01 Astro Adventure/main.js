function solve(input) {
    const n = input.shift();
    const astronauts = input.splice(0, n).reduce((agg, curr) => {
        const astroDetails = curr.split(' ');
        const [name, oxygen, energy] = [astroDetails[0], Number(astroDetails[1]), Number(astroDetails[2])];

        if (oxygen > 100) {
            oxygen = 100;
        }

        if (energy > 200) {
            energy = 200;
        }

        agg[name] = { oxygen, energy };

        return agg;
    }, {});

    while (input[0] != 'End') {
        const [command, name, ...arg] = input.shift().split(' - ');

        const currentAstronaut = astronauts[name];

        if (!currentAstronaut) continue;

        switch (command) {
            case 'Explore': {
                const energyNeeded = Number(arg[0]);

                if (currentAstronaut.energy >= energyNeeded) {
                    currentAstronaut.energy -= energyNeeded;
                    console.log(`${name} has successfully explored a new area and now has ${currentAstronaut.energy} energy!`);
                } else {
                    console.log(`${name} does not have enough energy to explore!`);
                }
            }
                break;
            case 'Refuel': {
                let amount = Number(arg[0]);

                if (amount + currentAstronaut.energy > 200) {
                    amount = 200 - currentAstronaut.energy;
                }

                currentAstronaut.energy += amount;
                console.log(`${name} refueled their energy by ${amount}!`);
            }
                break;
            case 'Breathe': {
                let amount = Number(arg[0]);

                if (amount + currentAstronaut.oxygen > 100) {
                    amount = 100 - currentAstronaut.oxygen;
                }

                currentAstronaut.oxygen += amount;
                console.log(`${name} took a breath and recovered ${amount} oxygen!`);
            }
                break;
        }
    }

    for (const key in astronauts) {
        console.log(`Astronaut: ${key}, Oxygen: ${astronauts[key].oxygen}, Energy: ${astronauts[key].energy}`);
    }
}
