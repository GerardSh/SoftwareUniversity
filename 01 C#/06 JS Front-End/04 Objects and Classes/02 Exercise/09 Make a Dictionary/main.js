function solve(input) {
    const termsDictionary = {};

    for (element of input) {
        const obj = JSON.parse(element);
        const key = Object.keys(obj)[0];
        const value = Object.values(obj)[0];

        termsDictionary[key] = value;
    }

    Object.entries(termsDictionary).sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(([term, definition]) => console.log(`Term: ${term} => Definition: ${definition}`));
}
