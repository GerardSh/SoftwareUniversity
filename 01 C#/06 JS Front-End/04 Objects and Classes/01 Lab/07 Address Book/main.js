function solve(input = []) {
    let addressBook = {};

    for (let entry of input) {
        const [name, address] = entry.split(':');
        addressBook[name] = address;
    }

    let sortedArray = Object.entries(addressBook).sort((a, b) => a[0].localeCompare(b[0]));

    for (const [key, value] of sortedArray) {
        console.log(`${key} -> ${value}`);
    }
}
