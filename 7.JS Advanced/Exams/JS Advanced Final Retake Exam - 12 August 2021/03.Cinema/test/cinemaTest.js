const { assert } = require('chai');
const cinema = require('../cinema.js');

describe("Cinema tests", function () {
    describe("showMovies", function () {
        it("Should be empty", function () {
            assert.equal(cinema.showMovies([]), 'There are currently no movies to show.');
        });
        it('Should return joined movies', () => {
            assert.equal(cinema.showMovies(['sad', 'asd']), 'sad, asd');
        })
    });
    describe("ticketPrice", function () {
        it("Work normally", function () {
            assert.equal(cinema.ticketPrice('Premiere'), '12.00');
            assert.equal(cinema.ticketPrice('Normal'), '7.50');
            assert.equal(cinema.ticketPrice('Discount'), '5.50');
        });
        it('Should throw error', () => {
            assert.throw(() => cinema.ticketPrice('sad'));
        })
    });
    describe("swapSeatsInHall", function () {
        it("Should work normally", function () {
            assert.equal(cinema.swapSeatsInHall(1,20), "Successful change of seats in the hall.");
        });
        it('Should not work normally', () => {
            assert.equal(cinema.swapSeatsInHall([],5), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall({},5), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall('sad',5), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(0,5), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(-1,5), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(21,5), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(true,5), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(5,[]), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(5,{}), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(5,'sad'), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(5,0), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(5,21), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(5,false), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(5,5), "Unsuccessful change of seats in the hall.");
        })
    });
});
