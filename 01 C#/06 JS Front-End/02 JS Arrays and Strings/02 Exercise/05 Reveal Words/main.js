function solve(words, text) {
    let wordsArray = words.split(', ');

    for (let word of wordsArray) {
        text = text.replaceAll(new RegExp(`(^|\\s)\\*{${word.length}}(?=\\s|$)`, 'g'), `$1${word}`);
    }

    console.log(text);
}




//2
function solve(words, text) {
    let wordsArray = words.split(', ');
    let textArray = text.split(' ');

    for (let word of wordsArray) {
        for (let i = 0; i < textArray.length; i++) {
            if (textArray[i] == '*'.repeat(word.length)) {
                textArray[i] = word;
            }
        }
    }

    console.log(textArray.join(' '));
}