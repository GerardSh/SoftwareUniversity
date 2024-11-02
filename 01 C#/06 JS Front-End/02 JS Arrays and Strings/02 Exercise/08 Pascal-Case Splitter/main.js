function solve(text = '') {
    let matches = text.match(/[A-Z][^A-Z]{0,}/g);

    console.log(matches.join(", "));
}