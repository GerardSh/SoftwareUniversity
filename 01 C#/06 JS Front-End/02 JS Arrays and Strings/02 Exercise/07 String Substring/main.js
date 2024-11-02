function solve(word = '', text = '') {
    let output = '';

    if (text.match(new RegExp(`\\b${word}\\b`, 'i'))) {
        output = word;
    } else {
        output = `${word} not found!`
    }

    console.log(output);
}