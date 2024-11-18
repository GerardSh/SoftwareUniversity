function solve([destinationFlights, changedStatuses, flightStatus]) {

    const flightsDictionary = destinationFlights.reduce((flightObj, flight) => {
        let [flightNumber, ...destination] = flight.split(' ');
        flightObj[flightNumber] = destination.join(' ');

        return flightObj;
    }, {});

    const changedDictionary = changedStatuses.reduce((flightObj, flight) => {
        let [flightNumber, status] = flight.split(' ');
        flightObj[flightNumber] = status;
        return flightObj;
    }, {});

    let status = flightStatus[0];

    for (flight in flightsDictionary) {
        const destination = flightsDictionary[flight];

        if (status == 'Ready to fly') {
            if (!changedDictionary.hasOwnProperty(flight)) {
                console.log(`{ Destination: '${destination}', Status: 'Ready to fly' }`);
            }
        } else {
            if (changedDictionary.hasOwnProperty(flight)) {
                console.log(`{ Destination: '${destination}', Status: '${changedDictionary[flight]}' }`);
            }
        }
    }
}
