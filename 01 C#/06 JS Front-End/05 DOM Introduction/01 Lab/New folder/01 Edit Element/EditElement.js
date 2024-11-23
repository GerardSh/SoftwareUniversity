function editElement(element, text, textToReplace) {
    let newValue = element.textContent.replaceAll(text, textToReplace)
    element.textContent = newValue;
}
