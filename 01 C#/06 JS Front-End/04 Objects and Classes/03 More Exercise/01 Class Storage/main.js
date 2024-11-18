class Storage {
    constructor(capacity) {
        this.capacity = capacity;
		this.storage = [];
    }
	
	    get totalCost() {
        return this.storage.reduce((sum, product) => sum + product.price * product.quantity, 0);
    }

    addProduct(product) {
        this.storage.push(product);
        this.capacity -= product.quantity;
    }

    getProducts() {
        return this.storage.map(x => JSON.stringify(x)).join('\n');
    }
}
