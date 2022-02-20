class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;

        this.availableProducts = []
    }

    loadingVegetables(vegetables) {
        let set = new Set();

        for (const vegetable of vegetables) {
            let splittedVegetable = vegetable.split(' ');
            let type = splittedVegetable[0];
            let quantity = Number(splittedVegetable[1]);
            let price = Number(splittedVegetable[2]);

            let product = this.availableProducts.find(x => x.type == type);

            if (product) {
                product.quantity += quantity;

                if (product.price < price) {
                    product.price = price;
                }
            } else {
                this.availableProducts.push({
                    type,
                    quantity,
                    price
                })
            }

            set.add(type);
        }

        let result = '';
        set.forEach(x => result += x + ', ');
        result = result.substring(0, result.length - 2);

        return `Successfully added ${result}`
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;

        for (const selectedProduct of selectedProducts) {
            let splittedProduct = selectedProduct.split(' ');

            let type = splittedProduct[0];
            let quantity = Number(splittedProduct[1]);

            let product = this.availableProducts.find(x => x.type == type);

            if (!product) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            if (product.quantity < quantity) {
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            product.quantity -= quantity;
            totalPrice += quantity * product.price;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }

    rottingVegetable(type, quantity) {
        let product = this.availableProducts.find(x => x.type == type);

        if (!product) {
            throw new Error(`${type} is not available in the store.`);
        }

        if (quantity >= product.quantity) {
            product.quantity = 0;

            return `The entire quantity of the ${type} has been removed.`;
        }

        product.quantity -= quantity;

        return `Some quantity of the ${type} has been removed.`;
    }

    revision() {
        let result = 'Available vegetables:';

        this.availableProducts
            .sort((a,b) => a.price - b.price)
            .forEach(x => result += `\n${x.type}-${x.quantity}-$${x.price}`);

        result += `\nThe owner of the store is ${this.owner}, and the location is ${this.location}.`

        return result;
    }
}