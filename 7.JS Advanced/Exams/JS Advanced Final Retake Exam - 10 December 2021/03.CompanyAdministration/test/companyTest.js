const { assert } = require('chai');
const companyAdministration = require('../companyAdministration.js');

describe("Company administration tests", function () {
    describe("hiringEmployee", function () {
        it("Should hire", function () {
            assert.equal(companyAdministration.hiringEmployee('sad', 'Programmer', 3),
                `sad was successfully hired for the position Programmer.`)
        });
        it('Should not approve', () => {
            assert.equal(companyAdministration.hiringEmployee('sad', 'Programmer', 2),
                `sad is not approved for this position.`)
        })
        it('Should throw error', () => {
            assert.throw(() => companyAdministration.hiringEmployee('sad', 'Code monkey', 5));
        })
    });
    describe("calculateSalary", function () {
        it("Should throw error", () => {
            assert.throw(() => companyAdministration.calculateSalary([]));
            assert.throw(() => companyAdministration.calculateSalary({}));
            assert.throw(() => companyAdministration.calculateSalary('sad'));
            assert.throw(() => companyAdministration.calculateSalary(true));
            assert.throw(() => companyAdministration.calculateSalary(-1));
        });
        it('Should increase salary', () => {
            assert.equal(companyAdministration.calculateSalary(161), 3415);
        })
        it('Should work normally', () => {
            assert.equal(companyAdministration.calculateSalary(0), 0);
            assert.equal(companyAdministration.calculateSalary(1), 15);
        })
    });
    describe("firedEmployee", function () {
        it("Shoult throw error", function () {
            assert.throw(() => companyAdministration.firedEmployee([], 0));
            assert.throw(() => companyAdministration.firedEmployee({}, 0));
            assert.throw(() => companyAdministration.firedEmployee('sad', 0));
            assert.throw(() => companyAdministration.firedEmployee(true, 0));
            assert.throw(() => companyAdministration.firedEmployee(0, 0));
            assert.throw(() => companyAdministration.firedEmployee(['sad', 'asd'], 2));
            assert.throw(() => companyAdministration.firedEmployee(['sad', 'asd'], -1));
            assert.throw(() => companyAdministration.firedEmployee(['sad'], []));
            assert.throw(() => companyAdministration.firedEmployee(['sad'], {}));
            assert.throw(() => companyAdministration.firedEmployee(['sad'], 12.5));
            assert.throw(() => companyAdministration.firedEmployee(['sad'], true));
            assert.throw(() => companyAdministration.firedEmployee(['sad'], 'sad'));
        });
        it('Should work normally', () => {
            assert.equal(companyAdministration.firedEmployee(['sad', 'asd'], 0), 'asd');
            assert.equal(companyAdministration.firedEmployee(['sad', 'asd', 'dsa'], 0), 'asd, dsa');
        })
    });
});
