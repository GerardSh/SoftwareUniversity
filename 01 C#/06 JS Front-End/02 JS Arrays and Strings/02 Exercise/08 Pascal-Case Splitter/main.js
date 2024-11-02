function solve(text = '') {
    let test = text.match(/[A-Z][^A-Z]{0,}/g);

    console.log(test.join(", "));
}