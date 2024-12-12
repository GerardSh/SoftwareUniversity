function solve(input) {
    const n = input.shift();

    const baristasArr = input.splice(0, n);

    const baristas = baristasArr.reduce((agg, curr) => {
        const [name, shift, ...coffee] = curr.split(' ');
        agg[name] = { shift, coffee: coffee[0].split(',') };

        return agg;
    }, {});

    input.forEach(line => {
        if (line == 'Closed') return;

        const [command, name, ...arg] = line.split(' / ');

        switch (command) {
            case 'Prepare': {
                const [shift, coffeeType] = arg;

                if (baristas.hasOwnProperty(name)
                    && baristas[name].shift == shift
                    && baristas[name].coffee.includes(coffeeType)) {
                    console.log(`${name} has prepared a ${coffeeType} for you!`);
                } else {
                    console.log(`${name} is not available to prepare a ${coffeeType}.`);
                }
            }
                break;
            case 'Change Shift': {
                const shift = arg[0];

                if (baristas[name]) {
                    baristas[name].shift = shift;
                    console.log(`${name} has updated his shift to: ${shift}`);
                }
            }
                break;
            case 'Learn': {
                const newCoffee = arg[0];

                if (baristas[name]) {
                    if (baristas[name].coffee.includes(newCoffee)) {
                        console.log(`${name} knows how to make ${newCoffee}.`);
                    } else {
                        console.log(`${name} has learned a new coffee type: ${newCoffee}.`);
                        baristas[name].coffee.push(newCoffee);
                    }
                }
            }
                break;
        }
    });

    for (const key in baristas) {
        console.log(`Barista: ${key}, Shift: ${baristas[key].shift}, Drinks: ${baristas[key].coffee.join(', ')}`);
    }
}
