function solve(input) {
    const n = input.shift();
    let heroes = [];

    for (let i = 0; i < n; i++) {
        const heroDetails = input.shift();

        let [name, power, energy] = heroDetails.split('-');
        energy = Number(energy);

        const powers = power.split(',');

        if (energy > 100) {
            energy = 100;
        }

        heroes.push({
            name,
            powers,
            energy
        })
    }

    while (input.length > 0) {
        const elements = input.shift();
        if (elements === 'Evil Defeated!') {
            break;
        }

        const [command, name, ...arg] = elements.split(' * ');
        const currentHero = getElement(name);

        switch (command) {
            case 'Use Power': {
                let [power, energyNeeded] = [arg[0], Number(arg[1])];

                if (currentHero.powers.includes(power) && currentHero.energy >= energyNeeded) {
                    currentHero.energy -= energyNeeded;

                    console.log(`${name} has used ${power} and now has ${currentHero.energy} energy!`);
                    continue;
                }

                console.log(`${name} is unable to use ${power} or lacks energy!`);
            }
                break;
            case 'Train': {
                let energy = Number(arg[0]);

                if (currentHero.energy == 100) {
                    console.log(`${name} is already at full energy!`);
                    continue;
                }

                if (currentHero.energy + energy > 100) {
                    energy = 100 - currentHero.energy;
                }

                currentHero.energy += energy;
                console.log(`${name} has trained and gained ${energy} energy!`);
            }
                break;
            case 'Learn': {
                let newPower = arg[0];

                if (currentHero.powers.includes(newPower)) {
                    console.log(`${name} already knows ${newPower}.`);
                    continue;
                }

                console.log(`${name} has learned ${newPower}!`);
                currentHero.powers.push(newPower);
            }
                break;
        }
    }

    for (const hero of heroes) {
        console.log(`Superhero: ${hero.name}`);
        console.log(`- Superpowers: ${hero.powers.join(', ')}`);
        console.log(`- Energy: ${hero.energy}`);
    }

    function getElement(name) {
        return heroes.find(x => x.name === name);
    }
}
