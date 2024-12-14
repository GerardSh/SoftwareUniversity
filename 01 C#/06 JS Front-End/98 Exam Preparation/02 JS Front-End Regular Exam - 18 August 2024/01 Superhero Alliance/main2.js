function solve(input) {
    const n = input.shift();
    const maxEnergy = 100;

    const heroes = input.splice(0, n).reduce((agg, curr) => {
        let [name, powers, energy] = curr.split('-');
        powers = powers.split(',');
        energy = Number(energy);

        if (energy > maxEnergy) energy = 100;

        agg[name] = { powers, energy };
        return agg;
    }, {})

    while (input != 'Evil Defeated!') {
        const [command, name, ...arg] = input.shift().split(' * ');
        const currentHero = heroes[name];

        switch (command) {
            case 'Use Power': {
                const [power, energy] = [arg[0], Number(arg[1])];

                if (currentHero.powers.includes(power) && currentHero.energy >= energy) {
                    currentHero.energy -= energy;

                    console.log(`${name} has used ${power} and now has ${currentHero.energy} energy!`);
                } else {
                    console.log(`${name} is unable to use ${power} or lacks energy!`);
                }
            }
                break;
            case 'Train': {
                let energy = Number(arg[0]);

                if (currentHero.energy === maxEnergy) {
                    console.log(`${name} is already at full energy!`);
                    continue;
                }

                if (currentHero.energy + energy > maxEnergy) {
                    energy = maxEnergy - currentHero.energy;
                }

                currentHero.energy += energy;
                console.log(`${name} has trained and gained ${energy} energy!`);
            }
                break;
            case 'Learn': {
                const newPower = arg[0];

                if (currentHero.powers.includes(newPower)) {
                    console.log(`${name} already knows ${newPower}.`);
                    continue;
                }

                currentHero.powers.push(newPower);

                console.log(`${name} has learned ${newPower}!`);
            }
                break;
        }
    }

    for (const hero in heroes) {
        console.log(`Superhero: ${hero}`);
        console.log(`- Superpowers: ${heroes[hero].powers.join(', ')}`);
        console.log(`- Energy: ${heroes[hero].energy}`);
    }
}
