function colorize() {
    for (let i = 2; i <= document.getElementsByTagName('tbody')[0].children.length; i += 2) {
        const selector = `tr:nth-child(${i})`;
        document.querySelector(selector).style.backgroundColor = 'teal';
    }
}




//2
function colorize() {
    const rowElements = document.querySelectorAll('tr');

    for (let i = 1; i < rowElements.length; i += 2) {
        rowElements[i].style.backgroundColor = 'teal';
    }
}




//3
function colorize() {
    const rowElements = document.querySelectorAll('tr:nth-child(even)');

    for (const element of rowElements) {
        element.style.backgroundColor = 'teal';
    }
}
