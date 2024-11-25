function solve() {
    const selectToElement = document.getElementById('selectMenuTo');
    selectToElement.children[0].textContent = 'Binary';
    selectToElement.children[0].value = 'binary';

    let paragraph = document.createElement('option');
    paragraph.textContent = 'Hexadecimal';
    paragraph.value = 'hexadecimal';
    document.getElementById('selectMenuTo').appendChild(paragraph);

    const button = document.getElementsByTagName('button')[0];
    button.onclick = buttonSubmit;

    function buttonSubmit() {
        const numberElementValue = Number(document.getElementById('input').value);
        const resultElement = document.getElementById('result');


        switch (selectToElement.value) {
            case 'binary': {
                resultElement.value = numberElementValue.toString(2);
            }
                break;
            case 'hexadecimal': {
                resultElement.value = numberElementValue.toString(16).toUpperCase();
            }
                break;
        }
    }
}
