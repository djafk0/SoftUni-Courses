class ArtGallery {
    constructor(creator) {
        this.creator = creator;

        this.guests = [];
        this.listOfArticles = [];
        this.possibleArticles = {
            picture: 200,
            photo: 50,
            item: 250
        };
    }

    addArticle(articleModel, articleName, quantity) {
        if (!this.possibleArticles[articleModel.toLowerCase()]) {
            throw new Error("This article model is not included in this gallery!");
        }

        let article = this.listOfArticles.find(x => x.articleName == articleName);

        if (article && article.articleModel == articleModel.toLowerCase()) {
            article.quantity += Number(quantity);
        } else {
            this.listOfArticles.push({
                articleModel: articleModel.toLowerCase(),
                articleName,
                quantity: Number(quantity)
            })
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`
    }

    inviteGuest(guestName, personality) {
        if (this.guests.some(x => x.guestName == guestName)) {
            throw `${guestName} has already been invited.`
        }

        let points = 50;

        if (personality == 'Middle') {
            points = 250;
        } else if (personality == 'Vip') {
            points = 500;
        }

        this.guests.push({
            guestName,
            points,
            purchaseArticle: 0
        })

        return `You have successfully invited ${guestName}!`
    }

    buyArticle(articleModel, articleName, guestName) {
        let article = this.listOfArticles.find(x => x.articleName == articleName);

        if (!article || (article && article.articleModel != articleModel.toLowerCase())) {
            throw new Error('This article is not found.');
        }

        if (article.quantity == 0) {
            return `The ${articleName} is not available.`;
        }

        if (!this.guests.some(x => x.guestName == guestName)) {
            return 'This guest is not invited.';
        }

        let guest = this.guests.find(x => x.guestName == guestName);

        let articlePoint = Number(this.possibleArticles[articleModel.toLowerCase()]);

        if (guest.points < articlePoint) {
            return 'You need to more points to purchase the article.';
        }

        guest.points -= articlePoint;
        guest.purchaseArticle++;

        article.quantity--;

        return `${guestName} successfully purchased the article worth ${articlePoint} points.`;
    }

    showGalleryInfo(criteria) {
        let result = '';
        if (criteria == 'article') {
            result += `Articles information:`;
            this.listOfArticles
                .forEach(x => result += `\n${x.articleModel} - ${x.articleName} - ${x.quantity}`)
        } else if (criteria == 'guest') {
            result += `Guests information:`;
            this.guests
                .forEach(x => result += `\n${x.guestName} - ${x.purchaseArticle}`)
        }

        return result;
    }
}