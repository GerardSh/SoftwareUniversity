function solve(input) {
    const arrays = {};
    let arrayOrder = 1;

    for (let array of input) {
        array = JSON.parse(array);
        array.sort((a, b) => b - a);

        if (!arrays.hasOwnProperty(array)) {
            arrays[array] = arrayOrder++;
        }
    }

    const sortedArrays = Object.entries(arrays).sort((a, b) => {
        const firstArrLength = a[0].split(',').length;
        const secondArrLength = b[0].split(',').length;

        if (firstArrLength == secondArrLength) {
            return a[1] - b[1];
        }

        return firstArrLength - secondArrLength;
    })

    for (let array of sortedArrays) {
        console.log(`[${array[0].split(',').join(', ')}]`);
    }
}
