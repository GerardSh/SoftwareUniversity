function solve(base, increment) {
    let totalStone = 0;
    let totalMarble = 0;
    let totalLapis = 0;
    let totalGold = 0;
    let height = 0;

    while (base > 2) {
        let outerLayer = base * 4 - 4;
        let innerArea = (base - 2) * (base - 2);

        if ((height + 1) % 5 === 0) {
            totalLapis += outerLayer * increment;
        } else {
            totalMarble += outerLayer * increment;
        }

        totalStone += innerArea * increment;
        base -= 2;
        height++;
    }

    totalGold = (base * base) * increment;
    height++;

    console.log(`Stone required: ${Math.ceil(totalStone)}`);
    console.log(`Marble required: ${Math.ceil(totalMarble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(totalLapis)}`);
    console.log(`Gold required: ${Math.ceil(totalGold)}`);
    console.log(`Final pyramid height: ${Math.floor(height * increment)}`);
}