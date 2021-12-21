//1.Fruit

function priceCalculate(fruit, weightInGrams, pricePerKg) {
    console.log(`I need $${((weightInGrams / 1000) * pricePerKg).toFixed(2)} to buy ${(weightInGrams / 1000).toFixed(2)} kilograms ${fruit}.`);
}

//2.Greatest Common Divisor - GCD

function greatestCommonDivisor(x, y) {

    while (y) {
        var t = y;
        y = x % y;
        x = t;
    }
    console.log(x);
}

//3.Same Numbers

function sameNumbers(numbers) {

    numbers = numbers.toString();
    let sum = 0;
    let firstNumber = numbers[0];
    let flag = true;

    for (let i = 0; i < numbers.length; i++) {
        if (numbers[i] != firstNumber) {
            flag = false;
        }

        sum += parseInt(numbers[i]);
    }

    console.log(flag);
    console.log(sum);
}

//4.Previous Day

function getPreviousDay(year, month, day) {
    let date = new Date(year, month - 1, day - 1);

    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

//5.Time to Walk

function timeToWalk(steps, stepDistance, speed) {
    let distanceToUniversityInKm = steps * stepDistance / 1000;
    let timeNeededInSeconds = Math.ceil((distanceToUniversityInKm / speed) * 60 * 60);
    let restInSeconds = Math.floor(distanceToUniversityInKm / 0.500) * 60;

    let totalSeconds = timeNeededInSeconds + restInSeconds;

    let hours = 0;
    let minutes = 0;
    let seconds = 0;

    while (true) {
        if (minutes >= 60) {
            hours++;
            minutes -= 60;
        } else if (totalSeconds < 60) {
            break;
        } else if (totalSeconds >= 60) {
            minutes++;
            totalSeconds -= 60;
        }

    }

    seconds = totalSeconds;

    function padLeadingZeros(num, size) {
        let s = num + "";
        while (s.length < size) s = "0" + s;
        return s;
    }

    padLeadingZeros(hours, 2);// "057"
    console.log(`${padLeadingZeros(hours, 2)}:${padLeadingZeros(minutes, 2)}:${padLeadingZeros(seconds, 2)}`);
}

//6.Road Radar

function roadRadar(speed, location) {

    let speedLimit = 0;
    let flag = false;

    if (location == 'city') {
        speedLimit = 50;
        if (speed > speedLimit) {
            flag = true;
        }
    } else if (location == 'residential') {
        speedLimit = 20;
        if (speed > speedLimit) {
            flag = true;
        }
    } else if (location == 'interstate') {
        speedLimit = 90;
        if (speed > speedLimit) {
            flag = true;
        }
    } else if (location == 'motorway') {
        speedLimit = 130;
        if (speed > speedLimit) {
            flag = true;
        }
    }

    if (flag) {
        let status = "";
        let difference = speed - speedLimit;

        if (difference <= 20) {
            status = "speeding";
        } else if (difference <= 40) {
            status = "excessive speeding"
        } else {
            status = "reckless driving";
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    } else {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }
}

//7.Cooking by Numbers

function cookingByNumbers(inputNumber, op1, op2, op3, op4, op5) {
    let array = [op1, op2, op3, op4, op5];
    let number = parseInt(inputNumber);

    for (let i = 0; i < array.length; i++) {
        if (array[i] == 'chop') {
            number /= 2;
        } else if (array[i] == 'dice') {
            number = Math.sqrt(number);
        } else if (array[i] == 'spice') {
            number++;
        } else if (array[i] == 'bake') {
            number *= 3;
        } else if (array[i] == 'fillet') {
            number *= 0.8;
        }

        console.log(number);
    }
}

//8.Validity Checker

function validityChecker(x1, y1, x2, y2) {

    function distance(x1, y1, x2, y2) {
        let distH = x1 - x2;
        let distY = y1 - y2;
        return Math.sqrt(distH ** 2 + distY ** 2);
    }

    if (Number.isInteger(distance(x1, y1, 0, 0))) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(distance(x2, y2, 0, 0))) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(distance(x1, y1, x2, y2))) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }

}

//9. *Words Uppercase

function uppercase(input) {

    let result = input.toUpperCase()
        .split(/[\W]+/)
        .filter(w => w.length > 0)
        .join(", ");

    console.log(result);
}
