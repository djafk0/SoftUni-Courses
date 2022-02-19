class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;

        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(productArr) {
        for (let strSequence of productArr) {
            let [product, quantity, price] = strSequence.split(' ');
            quantity = Number(quantity);
            price = Number(price);
 
            if (price <= this.budgetMoney) {
                this.budgetMoney -= price;
                this.history.push(`Successfully loaded ${quantity} ${product}`);
 
                if (!this.stockProducts.hasOwnProperty(product)) {
                    this.stockProducts[product] = 0;
                }
                this.stockProducts[product] += quantity;
            } else {
                this.history.push(
                    `There was not enough money to load ${quantity} ${product}`
                );
            }
        }
 
        return this.history.join('\n');
    }
 
    addToMenu(meal, productArr, price) {
        let neededProducts = [];
 
        for (let strSequence of productArr) {
            let [product, quantity] = strSequence.split(' ');
            quantity = Number(quantity);
 
            neededProducts.push([product, quantity]);
        }
 
        if (this.menu.hasOwnProperty(meal)) {
            return `The ${meal} is already in the our menu, try something different.`;
        }
 
        this.menu[meal] = { products: neededProducts, price };
        let mealCount = Object.keys(this.menu).length;
 
        if (mealCount == 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        } else if (!mealCount || mealCount >= 2) {
            return `Great idea! Now with the ${meal} we have ${mealCount} meals in the menu, other ideas?`;
        }
    }

    showTheMenu() {
        let result = [];
        Object.entries(this.menu).forEach(x => result.push(`${x[0]} - $ ${x[1].price}`));

        if (result.length == 0) {
            return "Our menu is not ready yet, please come later...";
        }

        return result.join('\n');
    }

    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
 
        for (let meal in this.menu) {
            let products = this.menu[meal].products;
            for (let [product, quantity] of products) {
                if (!this.stockProducts.hasOwnProperty(product)) {
                    return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
                }
 
                if (this.stockProducts[product] < quantity) {
                    return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
                }
            }
 
            products.forEach(([product, quantity]) => {
                this.stockProducts[product] - quantity;
            });
 
            this.budgetMoney += this.menu[meal].price;
            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
        }
    }
}