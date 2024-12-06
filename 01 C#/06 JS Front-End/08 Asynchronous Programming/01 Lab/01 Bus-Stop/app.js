function getInfo() {
    const baseURL = 'http://localhost:3030/jsonstore/bus/businfo/';

    const inputEl = document.querySelector('#stopId');
    const busStopNameEl = document.querySelector('#stopName');
    const busesEl = document.querySelector('#buses');
    const stopId = inputEl.value;
    inputEl.value = '';

    async function createLiElements() {
        try {
            busStopNameEl.textContent = '';
            busesEl.textContent = '';
            const response = await fetch(baseURL + stopId);
            const result = await response.json();

            busStopNameEl.textContent = result.name;

            for (const bus in result.buses) {
                const liEl = document.createElement('li');
                liEl.textContent = `Bus ${bus} arrives in ${result.buses[bus]} minutes`;

                busesEl.append(liEl);
            }
        } catch {
            busStopNameEl.textContent = 'Error'
        }
    }

    createLiElements()
}
