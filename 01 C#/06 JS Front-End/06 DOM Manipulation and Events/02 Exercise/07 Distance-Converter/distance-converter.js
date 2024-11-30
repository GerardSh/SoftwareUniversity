document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.querySelector('input#convert').addEventListener('click', (e) => {
        const [inputEl, resultEl] = document.querySelectorAll('input[type="text"]');
        const inputValue = Number(inputEl.value);
        const inputOption = document.querySelector('#inputUnits option:checked').value;
        const outputOption = document.querySelector('#outputUnits option:checked').value;

        let inputInMeters = inputValue;

        switch (inputOption) {
            case 'km':
                inputInMeters = inputValue * 1000;
                break;
            case 'cm':
                inputInMeters = inputValue * 0.01;
                break;
            case 'mm':
                inputInMeters = inputValue * 0.001;
                break;
            case 'mi':
                inputInMeters = inputValue * 1609.34;
                break;
            case 'yrd':
                inputInMeters = inputValue * 0.9144;
                break;
            case 'ft':
                inputInMeters = inputValue * 0.3048;
                break;
            case 'in':
                inputInMeters = inputValue * 0.0254;
                break;
        }

        let result = inputInMeters;

        switch (outputOption) {
            case 'km':
                result = inputInMeters / 1000;
                break;
            case 'cm':
                result = inputInMeters / 0.01;
                break;
            case 'mm':
                result = inputInMeters / 0.001;
                break;
            case 'mi':
                result = inputInMeters / 1609.34;
                break;
            case 'yrd':
                result = inputInMeters / 0.9144;
                break;
            case 'ft':
                result = inputInMeters / 0.3048;
                break;
            case 'in':
                result = inputInMeters / 0.0254;
                break;
        }

        resultEl.value = result;
    });
}
