function extract(content) {
    const targetElementText = document.getElementById(content).textContent;
    const pattern = /\((.+?)\)+/g;

    const matches = targetElementText.matchAll(pattern);

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

    let hasStarted = false;
    let currentWord = '';

    for (let i = 0; i < targetElementText.length; i++) {

        if (targetElementText[i] == '(') {
            hasStarted = true;

            continue;
        } else if (targetElementText[i] == ')') {
            hasStarted = false;
            resultArr.push(currentWord);
            currentWord = '';
        }

        if (hasStarted) {
            currentWord += targetElementText[i];
        }
    }

    console.log(resultArr.join('; '));
}
