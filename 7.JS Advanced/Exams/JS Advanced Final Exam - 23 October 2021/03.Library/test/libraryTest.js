const { assert } = require('chai');
const library = require('../library');

describe('Library tests', () => {
    describe('calcPriceOfBook', () => {
        it('Should throw error when year is not an integer and book is not a string', () => {
            assert.Throw(() => library.calcPriceOfBook({}, 2000));
            assert.Throw(() => library.calcPriceOfBook([], 2000));
            assert.Throw(() => library.calcPriceOfBook(12, 2000));
            assert.Throw(() => library.calcPriceOfBook(12.5, 2000));
            assert.Throw(() => library.calcPriceOfBook(true, 2000));
            assert.Throw(() => library.calcPriceOfBook('sad', {}));
            assert.Throw(() => library.calcPriceOfBook('sad', []));
            assert.Throw(() => library.calcPriceOfBook('sad', 'sad'));
            assert.Throw(() => library.calcPriceOfBook('sad', 12.5));
            assert.Throw(() => library.calcPriceOfBook('sad', false));
        })
        it('Should let the price at the same value', () => {
            assert.equal(library.calcPriceOfBook('sad', 1981), 'Price of sad is 20.00');
        })
        it('Should calculate the price', () => {
            assert.equal(library.calcPriceOfBook('sad', 1980), 'Price of sad is 10.00');
        })
    })
    describe('findBook', () => {
        it('Should throw error when the array is empty', () => {
            assert.throw(() => library.findBook([], 'sad'));
            assert.throw(() => library.findBook('', 'sad'));
            assert.throw(() => library.findBook({}, 'sad'));
        })
        it('Should work when the book is here', () => {
            assert.equal(library.findBook(['sad', 'asd'], 'sad'), 'We found the book you want.');
            assert.notEqual(library.findBook(['sad', 'asd'], 'sad'), 'The book you are looking for is not here!');
        })
        it('Should work when the book is missing', () => {
            assert.equal(library.findBook(['dsa', 'asd'], 'sad'), 'The book you are looking for is not here!');
            assert.notEqual(library.findBook(['dsa', 'asd'], 'sad'), 'We found the book you want.');
        })
    })
    describe('arrangeTheBooks', () => {
        it('Should throw error when books is not an integer and less than 0', () => {
            assert.Throw(() => library.arrangeTheBooks([]));
            assert.Throw(() => library.arrangeTheBooks({}));
            assert.Throw(() => library.arrangeTheBooks(12.5));
            assert.Throw(() => library.arrangeTheBooks('sad'));
            assert.Throw(() => library.arrangeTheBooks(true));
            assert.Throw(() => library.arrangeTheBooks(-1));
        })
        it('Should work when there is enough space', () => {
            assert.equal(library.arrangeTheBooks(40), 'Great job, the books are arranged.');
            assert.equal(library.arrangeTheBooks(0), 'Great job, the books are arranged.');
            assert.notEqual(library.arrangeTheBooks(40), 'Insufficient space, more shelves need to be purchased.');
            assert.notEqual(library.arrangeTheBooks(0), 'Insufficient space, more shelves need to be purchased.');
        })
        it('Should work when there is not enough space', () => {
            assert.equal(library.arrangeTheBooks(41), 'Insufficient space, more shelves need to be purchased.');
            assert.notEqual(library.arrangeTheBooks(41), 'Great job, the books are arranged.');
        })
    })
})