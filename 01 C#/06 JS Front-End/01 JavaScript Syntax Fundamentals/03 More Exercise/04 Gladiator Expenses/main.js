function solve(lostFaiths, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    let expenses = 0;
    // let armorRepairsCount = 0;

    for (let i = 1; i <= lostFaiths; i++) {
        if (i % 2 == 0) {
            expenses += helmetPrice;
        }

        if (i % 3 == 0) {
            expenses += swordPrice;
        }

        if (i % 6 == 0) {
            expenses += shieldPrice;

            // if (++armorRepairsCount % 2 == 0) {
            //     expenses += armorPrice;
            // }
        }

        if (i % 12 == 0) {
            expenses += armorPrice;
        }
    }

    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`);
}