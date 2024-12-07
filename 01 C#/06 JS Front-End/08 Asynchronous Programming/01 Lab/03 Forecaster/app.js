function attachEvents() {
    const baseUrl = "http://localhost:3030/jsonstore/forecaster/";
    const divCurrentLabelEl = document.querySelector('#current > .label')
    const forecastEl = document.querySelector('#forecast');
    const upcomingDivEl = document.querySelector('#upcoming');

    inputTextEl = document.querySelector('#location')
    inputEl = document.querySelector('#submit');
    inputEl.addEventListener('click', fetchWeather);

    const iconMap = {
        sunny: '&#x2600',
        'partly sunny': '&#x26C5',
        overcast: '&#x2601',
        rain: '&#x2614',
        degrees: '&#176',
    }

    function fetchWeather() {
        let locationName = inputTextEl.value;
        inputTextEl.value = '';
        forecastEl.style.display = 'block';
        upcomingDivEl.style.display = 'block';

        const currentEl = Array.from(document.querySelector('#current').children);
        const upcomingEl = Array.from(document.querySelector('#upcoming').children);

        deleteDynamicElements(currentEl);
        deleteDynamicElements(upcomingEl);

        divCurrentLabelEl.textContent = 'Current conditions';

        fetch(`${baseUrl}locations/`)
            .then(response => response.json())
            .then(result => {
                const locationData = result.filter(x => x.name == locationName)[0];

                if (!locationData) {
                    throw new Error();
                }

                fetch(`${baseUrl}today/${locationData.code}`)
                    .then(response => response.json())
                    .then(result => {
                        const { condition, high, low } = result.forecast;

                        const divEl = document.createElement('div');
                        divEl.classList.add('forecasts');

                        document.querySelector('#current').append(divEl);

                        const spanMain1El = document.createElement('span');
                        spanMain1El.classList.add('condition', 'symbol');
                        spanMain1El.innerHTML = iconMap[condition.toLowerCase()];

                        const spanMain2El = document.createElement('span');
                        spanMain2El.classList.add('condition');

                        divEl.append(spanMain1El, spanMain2El);

                        const spanEl1 = document.createElement('span');
                        const spanEl2 = document.createElement('span');
                        const spanEl3 = document.createElement('span');

                        spanEl1.textContent = result.name;
                        spanEl2.innerHTML = `${low}${iconMap.degrees}/${high}${iconMap.degrees}`
                        spanEl3.textContent = condition;

                        spanEl1.classList.add('forecast-data');
                        spanEl2.classList.add('forecast-data');
                        spanEl3.classList.add('forecast-data');

                        spanMain2El.append(spanEl1, spanEl2, spanEl3);
                    })
                    .catch(err =>
                        console.log(err.message)
                    )

                fetch(`${baseUrl}upcoming/${locationData.code}`)
                    .then(response => response.json())
                    .then(result => {
                        const upcomingEl = document.querySelector('#upcoming');
                        const divEl = document.createElement('div');
                        divEl.classList.add('forecast-info');
                        upcomingEl.append(divEl);

                        for (const day of result.forecast) {
                            const { condition, high, low } = day;

                            const upcomingSpanEl = document.createElement('span');
                            upcomingSpanEl.classList.add('upcoming');

                            const spanEl1 = document.createElement('span');
                            const spanEl2 = document.createElement('span');
                            const spanEl3 = document.createElement('span');

                            spanEl1.innerHTML = iconMap[condition.toLowerCase()];
                            spanEl2.innerHTML = `${low}${iconMap.degrees}/${high}${iconMap.degrees}`
                            spanEl3.textContent = condition;

                            spanEl1.classList.add('symbol');
                            spanEl2.classList.add('forecast-data');
                            spanEl3.classList.add('forecast-data');

                            upcomingSpanEl.append(spanEl1, spanEl2, spanEl3);

                            divEl.append(upcomingSpanEl);
                        }
                    })
                    .catch(err =>
                        console.log(err.message)
                    )
            })
            .catch(err => {
                divCurrentLabelEl.textContent = 'Error';
                upcomingDivEl.style.display = 'none';
            })
    }
}

function deleteDynamicElements(arrayEl) {
    for (let i = 1; i < arrayEl.length; i++) {
        arrayEl[i].remove();
    }
}

attachEvents();
