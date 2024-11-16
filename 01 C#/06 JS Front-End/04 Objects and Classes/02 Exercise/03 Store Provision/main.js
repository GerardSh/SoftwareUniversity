function solve(firstInput, secondInput) {
    let stock = getProducts(firstInput);
    let orderedProducts = getProducts(secondInput);


    for (let product in orderedProducts) {
        if (!stock.hasOwnProperty(product)) {
            stock[product] = 0;
        }

        stock[product] += orderedProducts[product];
    }

    for (let product in stock) {
        console.log(`${product} -> ${stock[product]}`);
    }

    function getProducts(input) {
        let products = {};

        for (let i = 0; i < input.length; i++) {
            if (i % 2 != 0) {

                if (!products[input[i - 1]]) {
                    products[input[i - 1]] = 0;
                }

                products[input[i - 1]] += Number(input[i]);
            }
        }

        return products;
    }
}
