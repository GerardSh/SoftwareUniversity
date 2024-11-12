function solve(city) {
    let cityData = Object.entries(city);

    for (let property of cityData) {
        console.log(`${property[0]} -> ${property[1]}`);
    }
}




//2
function solve(city) {
    let cityKeys = Object.keys(city);

    for (let key of cityKeys) {
        console.log(`${key} -> ${city[key]}`);
    }
}
