const { assert } = require('chai');
let testNumbers = require('../testNumbers.js');

describe("Test testNumbers", function () {
    describe("sumNumbers", function () {
        it("Should return undefined", function () {
            assert.isUndefined(testNumbers.sumNumbers([], 1));
            assert.isUndefined(testNumbers.sumNumbers({}, 1));
            assert.isUndefined(testNumbers.sumNumbers('sad', 1));
            assert.isUndefined(testNumbers.sumNumbers(true, 1));
            assert.isUndefined(testNumbers.sumNumbers(1, []));
            assert.isUndefined(testNumbers.sumNumbers(1, {}));
            assert.isUndefined(testNumbers.sumNumbers(1, 'sad'));
            assert.isUndefined(testNumbers.sumNumbers(1, false));
        });
        it('Should work', () => {
            assert.equal(testNumbers.sumNumbers(0, 0), 0);
            assert.equal(testNumbers.sumNumbers(1, 1), 2);
            assert.equal(testNumbers.sumNumbers(0.255, 0.256), 0.51);
            assert.notEqual(testNumbers.sumNumbers(0.255, 0.256), 0.511);
        })
    });
    describe("numberChecker", function () {
        it("Should throw error", function () {
            assert.throw(() => testNumbers.numberChecker({}));
            assert.throw(() => testNumbers.numberChecker('sad'));
        });
        it('Should be even', () => {
            assert.equal(testNumbers.numberChecker(2), 'The number is even!');
            assert.equal(testNumbers.numberChecker(0), 'The number is even!');
        })
        it('Should be odd', () => {
            assert.equal(testNumbers.numberChecker(1), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(3), 'The number is odd!');
        })
    });
    describe("averageSumArray", function () {
        it("Should work normally", function () {
            assert.equal(testNumbers.averageSumArray([0, 1, -1]), 0);
            assert.equal(testNumbers.averageSumArray([1, 1, 1]), 1);
        });
    });
});
