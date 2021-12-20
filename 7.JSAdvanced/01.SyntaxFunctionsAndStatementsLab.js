//1.Echo Function

function echo(text) {
    console.log(text.length);
    console.log(text);
}

//2.String Length

function stringLength(text1, text2, text3) {
    let sum = text1.length + text2.length + text3.length
    console.log(sum);
    console.log(Math.floor(sum / 3));
}

//3.Largest Number

function numberArguments(num1, num2, num3) {
    console.log(`The largest number is ${Math.max(num1, num2, num3)}.`);
}

//4.Circle Area

function circleArea(arg) {
    if (typeof (arg) === 'number') {
        let sum = Math.PI * arg * arg;
        console.log(sum.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof (arg)}.`);
    }
}

//5.Math Operations

function mathOperations(num1, num2, operator) {
    let result = 0;

    switch (operator) {
        case '+': result = num1 + num2; break;
        case '-': result = num1 - num2; break;
        case '/': result = num1 / num2; break;
        case '*': result = num1 * num2; break;
        case '%': result = num1 % num2; break;
        case '**': result = num1 ** num2; break;
    }

    console.log(result);
}

//6.Sum of Numbers N…M

function sumOfNumbers(n, m) {
    let sum = 0;
    let num1 = Number(n);
    let num2 = Number(m);

    for (let i = num1; i <= num2; i++) {
        sum += i;
    }

    console.log(sum);
}

//7.Day of Week

function dayOfWeek(input) {
    let output = '';
    switch (input) {
        case 'Monday': output = 1; break;
        case 'Tuesday': output = 2; break;
        case 'Wednesday': output = 3; break;
        case 'Thursday': output = 4; break;
        case 'Friday': ooutput = 5; break;
        case 'Saturday': output = 6; break;
        case 'Sunday': output = 7; break;
        default: output = 'error'
    }

    console.log(output);
}

//8.Days in a month

function daysInMonth(month, year) {
    console.log(new Date(year, month, 0).getDate());
}

//9.Square of Stars

function squareOfStars(n = 5) {
    for (let i = 1; i <= n; i++) {
        let inside = '';
        for (let j = 1; j <= n; j++) {
            inside += '* ';
        }
        console.log(inside);
    }
}

//10.Aggregate Elements

function aggregateElements(array) {

    let firstSum = 0;
    let secondSum = 0;
    let concat = "";

    for (let i = 0; i < array.length; i++) {
        firstSum += array[i];
        secondSum += 1 / array[i];
        concat += array[i].toString();
    }

    console.log(firstSum);
    console.log(secondSum);
    console.log(concat);
}