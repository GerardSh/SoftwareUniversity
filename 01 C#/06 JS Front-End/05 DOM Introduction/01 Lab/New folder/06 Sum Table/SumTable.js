function sumTable() {
    const firstTableRowsElements = document.querySelector('tbody').children;

    let sum = 0;

    for (const element of firstTableRowsElements) {
        const number = Number(element.children[1].textContent);

        if (number) {
            sum += number;
        }
    }

    firstTableRowsElements[firstTableRowsElements.length - 1].children[1].textContent = sum;
}




//2
function sumTable() {
    const firstTableRowsElements = document.querySelectorAll('table:nth-of-type(1) td:nth-of-type(2):not(#sum)');

    let sum = 0;

    for (const element of firstTableRowsElements) {
        sum += Number(element.textContent);
    }

    const sumElement = document.getElementById('sum');

    sumElement.textContent = sum;
}
