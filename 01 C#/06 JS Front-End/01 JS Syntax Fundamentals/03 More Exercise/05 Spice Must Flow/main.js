function solve(source) {
    let totalHarvested = 0;
    let days = 0;

    while (source >= 100) {
        days++;
        totalHarvested += source;
        source -= 10;
        totalHarvested -= 26;
    }

    console.log(days);
    console.log(days > 0 ? totalHarvested - 26 : 0);
}