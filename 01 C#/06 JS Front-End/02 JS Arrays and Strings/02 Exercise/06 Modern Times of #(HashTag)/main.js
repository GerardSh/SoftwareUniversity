function solve(text = '') {
    let pattern = /[#]([a-zA-Z]+)/g;

    let matches = text.matchAll(pattern);

    for (let match of matches) {
        console.log(match[1]);
    }
}