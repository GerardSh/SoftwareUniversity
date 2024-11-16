function solve(input) {
    input.map(x => {
        const [town, latitude, longitude] = x.split(' | ');

        return {
            town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        }
    }).forEach(x => console.log(x));
}
