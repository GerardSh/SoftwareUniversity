function extract(content) {
    const targetElementText = document.getElementById(content).textContent;
    const pattern = /\((.+?)\)+/g;

    const matches = [...targetElementText.matchAll(pattern)];

    const matchArray = matches.reduce((aggregate, currentElement) => {
        aggregate.push(currentElement[1]);

        return aggregate;
    }, [])

    const result = matchArray.join('; ');

    return result;
}




//2
function extract(content) {
    const targetElementText = document.getElementById(content).textContent;

    const resultArr = [];

    let writeWord = false;
    let currentWord = '';

    for (let i = 0; i < targetElementText.length; i++) {

        if (targetElementText[i] == '(') {
            writeWord = true;
            continue;
        } else if (targetElementText[i] == ')') {
            writeWord = false;

            resultArr.push(currentWord);

            currentWord = '';
        }

        if (writeWord) {
            currentWord += targetElementText[i];
        }
    }

    return resultArr.join('; ');
}
