const { assert } = require('chai');
const flowerShop = require('../flowerShop.js');

describe("Flower Shop tests", function () {
    describe("calcPriceOfFlowers", function () {
        it("Should throw error", function () {
            assert.Throw(() => flowerShop.calcPriceOfFlowers([], 2, 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers({}, 2, 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers(true, 2, 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers(2, 2, 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers(2.5, 2, 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', [], 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', {}, 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', 'sad', 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', 2.5, 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', true, 2));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', 2, []));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', 2, {}));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', 2, 'sad'));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', 2, true));
            assert.Throw(() => flowerShop.calcPriceOfFlowers('sad', 2, 2.5));
        });
        it('Should work', () => {
            assert.equal(flowerShop.calcPriceOfFlowers('sad', 10, 2), `You need $20.00 to buy sad!`)
        })
    });
    describe("checkFlowersAvailable", function () {
        it("Should return available", function () {
            assert.equal(flowerShop.checkFlowersAvailable('sad', ['sad', 'asd']), `The sad are available!`);
        });
        it('Should return unavailabe', () => {
            assert.equal(flowerShop.checkFlowersAvailable('sad', ['asd']), `The sad are sold! You need to purchase more!`)
        })
    });
    describe("sellFlowers", function () {
        it("Should throw error", function () {
            assert.throw(() => flowerShop.sellFlowers({}, 1));
            assert.throw(() => flowerShop.sellFlowers('sad', 1));
            assert.throw(() => flowerShop.sellFlowers(1, 1));
            assert.throw(() => flowerShop.sellFlowers(1.1, 1));
            assert.throw(() => flowerShop.sellFlowers(true, 1));
            assert.throw(() => flowerShop.sellFlowers(['sad', 'asd'], []));
            assert.throw(() => flowerShop.sellFlowers(['sad', 'asd'], {}));
            assert.throw(() => flowerShop.sellFlowers(['sad', 'asd'], 'sad'));
            assert.throw(() => flowerShop.sellFlowers(['sad', 'asd'], 1.1));
            assert.throw(() => flowerShop.sellFlowers(['sad', 'asd'], true));
            assert.throw(() => flowerShop.sellFlowers(['sad', 'asd'], -1));
            assert.throw(() => flowerShop.sellFlowers(['sad', 'asd'], 2));
            assert.throw(() => flowerShop.sellFlowers([], 0));
        });
        it('Should work normally', () => {
            assert.equal(flowerShop.sellFlowers(['sad', 'asd'], 1), 'sad');
            assert.equal(flowerShop.sellFlowers(['sad', 'asd'], 0), 'asd');
            assert.equal(flowerShop.sellFlowers(['sad', 'asd', 'das', 'dsa', 'sda'], 4), 'sad / asd / das / dsa');
        })
    });
});
