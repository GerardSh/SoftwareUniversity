function solve(input) {
    const targetThickness = input[0];

    for (let i = 1; i < input.length; i++) {
        let thickness = input[i];
        console.log(`Processing chunk ${thickness} microns`);

        thickness = processChunk(thickness, targetThickness);
        console.log(`Finished crystal ${targetThickness} microns`);
    }

    function processChunk(thickness, target) {
        const operations = [
            { name: 'Cut', operation: (x) => x / 4, reductionCheck: (x) => x / 4 >= target },
            { name: 'Lap', operation: (x) => x * 0.8, reductionCheck: (x) => x * 0.8 >= target },
            { name: 'Grind', operation: (x) => x - 20, reductionCheck: (x) => x - 20 >= target },
            { name: 'Etch', operation: (x) => x - 2, reductionCheck: (x) => x - 2 >= target }
        ];

        for (const { name, operation, reductionCheck } of operations) {
            let count = 0;
            while (reductionCheck(thickness)) {
                thickness = operation(thickness);
                count++;
            }
            if (count > 0) {
                console.log(`${name} x${count}`);
                thickness = Math.floor(thickness);
                console.log("Transporting and washing");
            }
        }

        if (thickness < target) {
            thickness++;
            console.log("X-ray x1");
        }

        return thickness;
    }
}
