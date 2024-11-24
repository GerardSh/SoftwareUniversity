function subtract() {
    const firstNumberElementValue = Number(document.getElementById('firstNumber').value);
    const secondNumberElementValue = Number(document.getElementById('secondNumber').value);

    document.getElementById('result').textContent = firstNumberElementValue - secondNumberElementValue;
}
