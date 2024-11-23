function extractText() {
    ulElement = document.getElementById('items');
    const textArea = document.getElementById('result');
    console.log(ulElement.textContent);

    textArea.textContent = ulElement.textContent;
}
