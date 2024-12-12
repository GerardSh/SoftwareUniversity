function solve() {
    const baseURL = 'http://localhost:3030/jsonstore/bus/schedule/';
    const departEl = document.querySelector('#depart');
    const arriveEl = document.querySelector('#arrive');
    const infoEl = document.querySelector('#info span');

    let currentStopId = 'depot';
    let currentStopName = '';

    function depart() {
        disableOrEnableButtons();
        arriveEl.disabled = false;

        fetch(baseURL + currentStopId)
            .then(response => response.json())
            .then(result => {
                currentStopName = result.name;

                infoEl.textContent = `Next stop ${currentStopName}`;
                currentStopId = result.next;
            })
            .catch(err => {
                disableButtons();
                infoEl.textContent = 'Error';
            })
    }

    async function arrive() {
        disableOrEnableButtons();
        infoEl.textContent = `Arriving at ${currentStopName}`;
    }

    function disableOrEnableButtons() {
        departEl.disabled = !departEl.disabled;
        arriveEl.disabled = !arriveEl.disabled;
    }

    function disableButtons() {
        departEl.disabled = true;
        arriveEl.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
