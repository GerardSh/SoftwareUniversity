function solve(input) {
    let wordsToSearch = input.shift().split(' ');
    let wordsCount = {};

    for (const word of wordsToSearch) {
        wordsCount[word] = 0;
    }

    for (const word of input) {
        if (wordsCount.hasOwnProperty(word)) {
            wordsCount[word]++;
        }
    }

    Object.entries(wordsCount).sort((a, b) => b[1] - a[1])
        .forEach(([key, value]) => console.log(`${key} - ${wordsCount[key]}`));
}
