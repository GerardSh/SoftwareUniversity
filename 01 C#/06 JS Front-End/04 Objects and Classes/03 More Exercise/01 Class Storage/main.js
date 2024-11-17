class Storage {
    constructor(capacity) {
        this.capacity = capacity;
        this.storage = [];
        this.totalCost = 0;
    }

    addProduct(product) {
        this.storage.push(product);
        this.capacity -= product.quantity;
        this.totalCost += (product.price * product.quantity);
    }

    getProducts() {
        return this.storage
            .map((el) => JSON.stringify(el))
            .join("\n");
    }
}
