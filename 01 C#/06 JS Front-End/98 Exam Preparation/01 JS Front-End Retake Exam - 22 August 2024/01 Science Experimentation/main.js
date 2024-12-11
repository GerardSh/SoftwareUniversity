function solve(input) {
    let n = input.shift();

    const chemicals = [];

    for (let i = 0; i < n; i++) {
        const [chemicalName, quantity] = input.shift().split(' # ');

        chemicals.push({
            chemicalName,
            quantity: Number(quantity),
            formula: ''
        })
    }

    while (input.length > 0) {
        const elements = input.shift();
        if (elements === 'End') {
            break;
        }

        const [command, chemicalName, ...arg] = elements.split(' # ');
        const chemicalObj = getElement(chemicalName)

        switch (command) {
            case 'Mix': {
                let [chemicalName2, amount] = arg;
                amount = Number(amount);

                const chemicalObj2 = getElement(chemicalName2)

                if (!chemicalObj || !chemicalObj2) {
                    continue;
                }

                if (chemicalObj.quantity >= amount && chemicalObj2.quantity >= amount) {
                    console.log(`${chemicalName} and ${chemicalName2} have been mixed. ${amount} units of each were used.`);

                    chemicalObj.quantity -= amount;
                    chemicalObj2.quantity -= amount;
                } else {
                    console.log(`Insufficient quantity of ${chemicalName}/${chemicalName2} to mix.`);
                }
            }
                break;
            case 'Replenish': {
                let amount = arg.shift();
                amount = Number(amount);

                if (!chemicalObj) {
                    console.log(`The Chemical ${chemicalName} is not available in the lab.`);
                    continue;
                }

                if (chemicalObj.quantity + amount > 500) {
                    console.log(`${chemicalName} quantity increased by ${500 - chemicalObj.quantity} units, reaching maximum capacity of 500 units!`);
                    chemicalObj.quantity = 500;
                    continue;
                }

                console.log(`${chemicalName} quantity increased by ${amount} units!`);
                chemicalObj.quantity += amount;
            }
                break;
            case 'Add Formula': {
                const formula = arg.shift();

                if (chemicalObj) {
                    console.log(`${chemicalName} has been assigned the formula ${formula}.`);
                    chemicalObj.formula = formula;
                    continue;
                }

                console.log(`The Chemical ${chemicalName} is not available in the lab.`);
            }
                break;
        }
    }

    for (const chemical of chemicals) {
        console.log(`Chemical: ${chemical.chemicalName}, Quantity: ${chemical.quantity}${chemical.formula ? `, Formula: ${chemical.formula}` : ''}`);
    }

    function getElement(name) {
        return chemicals.find(x => x.chemicalName === name);
    }
}
