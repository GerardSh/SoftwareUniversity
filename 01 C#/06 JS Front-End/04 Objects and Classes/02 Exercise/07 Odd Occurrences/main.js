function solve(input) {
    input = input.toLowerCase();
    let wordsByCount = {};
    let trackOrder = [];

    input.split(' ').forEach(x => {
        if (!wordsByCount.hasOwnProperty(x)) {
            wordsByCount[x] = 0;
            trackOrder.push(x);
        }

        wordsByCount[x]++;
    })

    const filteredWords = Object.entries(wordsByCount)
        .filter((x) => x[1] % 2 != 0)
        .map(x => x[0]);

    trackOrder = trackOrder.filter(x => filteredWords.includes(x));

    console.log(trackOrder.join(' '));
}
