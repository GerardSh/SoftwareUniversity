function solve(city) {
    let cityData = Object.entries(city);

    for (let property of cityData) {
        console.log(`${property[0]} -> ${property[1]}`);
    }
}
