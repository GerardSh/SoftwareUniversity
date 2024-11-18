function solve(input) {
    let catalog = {};

    for (product of input) {
        const productDetails = product.split(' : ');
        const productName = productDetails[0];
        const productPrice = Number(productDetails[1]);
        const productFirstLetter = productName[0];

        if (!catalog[productFirstLetter]) {
            catalog[productFirstLetter] = {};
        }

        catalog[productFirstLetter][productName] = productPrice;
    }

    for (let [key, value] of Object.entries(catalog).sort((a, b) => a[0].localeCompare(b[0]))) {
        console.log(key);

        for (let [name, price] of Object.entries(value).sort((a, b) => a[0].localeCompare(b[0]))) {
            console.log(`  ${name}: ${price}`);
        }
    }
}




//2
function solve(input) {
    let catalog = {};

    for (product of input) {
        const productDetails = product.split(' : ');
        const productName = productDetails[0];
        const productPrice = Number(productDetails[1]);
        const productFirstLetter = productName[0];

        if (!catalog[productFirstLetter]) {
            catalog[productFirstLetter] = [];
        }

        catalog[productFirstLetter].push(`${productName}: ${productPrice}`);
    }

    for (let [key, value] of Object.entries(catalog).sort((a, b) => a[0].localeCompare(b[0]))) {
        console.log(key);

        for (let product of value.sort((a, b) => a.localeCompare(b))) {
            console.log(`  ${product}`);
        }
    }
}
