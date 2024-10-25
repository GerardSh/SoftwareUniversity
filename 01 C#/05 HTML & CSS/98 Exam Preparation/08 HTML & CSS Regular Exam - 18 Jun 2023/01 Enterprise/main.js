function solve(text) {
    let words = text.match(/\b\w+\b/g);

    let upperCaseWords = words.map(word => word.toUpperCase());

    let result = upperCaseWords.join(', ');
    console.log(result);
}