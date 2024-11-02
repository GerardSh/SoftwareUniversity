function solve(goldAmounts = []) {
    const bitcoinPrice = 11949.16;
    const goldPricePerGram = 67.51;
    let totalMoney = 0;
    let totalBitcoins = 0;
    let firstBitcoinDay = 0;

    for (let day = 1; day <= goldAmounts.length; day++) {
        let gold = goldAmounts[day - 1];

        if (day % 3 === 0) {
            gold *= 0.7;
        }

        totalMoney += gold * goldPricePerGram;

        while (totalMoney >= bitcoinPrice) {
            totalMoney -= bitcoinPrice;
            totalBitcoins++;

            if (totalBitcoins === 1) {
                firstBitcoinDay = day;
            }
        }
    }

    console.log(`Bought bitcoins: ${totalBitcoins}`);

    if (firstBitcoinDay > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstBitcoinDay}`);
    }

    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}