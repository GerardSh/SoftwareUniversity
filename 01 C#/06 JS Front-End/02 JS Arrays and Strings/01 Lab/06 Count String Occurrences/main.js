function solve(text = '', word = '') {
    const pattern = new RegExp(`\\b${word}\\b`, 'g');
    let test = text.match(pattern);

    console.log(test ? test.length : 0);
}