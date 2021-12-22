//1.Even Position Element

function evenElement(input) {
    let output = "";

    for (let i = 0; i < input.length; i += 2) {
        output += input[i] + " ";
    }

    console.log(output);
}

//2.Last K Numbers Sequence

function lastKNumbers(n, k) {

    let result = [1];

    for (let i = 1; i < n; i++) {

        result[i] = sumLastK(result, k);

    }

    function sumLastK(array = result, k) {

        k = array.length > k ? k : array.length;

        let sum = 0;

        for (let i = 1; i <= k; i++) {

            sum += array[array.length - i];

        }

        return sum;

    }

    return result;
}

//3.Sum First Last

function sumFirstAndLast(array) {
    let sum = parseInt(array[0]) + parseInt(array[array.length - 1]);

    console.log(sum);
}

// 4.Negative / Positive Numbers

function numbers(array) {

    let result = [];

    for (let i = 0; i < array.length; i++) {
        if (array[i] < 0) {
            result.unshift(array[i]);
        } else {
            result.push(array[i]);
        }
    }

    for (const element of result) {
        console.log(element);
    }
}

// 5.Smallest Two Numbers

function smallestNumbers(array) {
    array.sort(function (a, b) { return a - b });

    console.log(array[0]);
    console.log(array[1]);
}

// 6.Bigger Half

function biggerHalf(array) {
    array.sort(function (a, b) { return a - b });

    let result = [];
    for (let i = Math.floor(array.length / 2); i < array.length; i++) {
        result.push(array[i]);
    }

    return result;
}

// 7.Piece of Pie

function pie(pies, firstPie, lastPie) {
    return pies.slice(pies.indexOf(firstPie), pies.indexOf(lastPie) + 1);
}

// 8.Process Odd Positions

function oddPositions(array) {
    let result = [];

    for (let i = 1; i < array.length; i += 2) {
        result.push(array[i]);
    }

    result.reverse();

    return result.map(x => x *= 2)
}

// 9.Biggest Element

function biggestElement(matrix) {
    let biggestNum = Number.MIN_SAFE_INTEGER;

    matrix.forEach(
        row => row.forEach(
            col => biggestNum = Math.max(biggestNum, col)));
    console.log(biggestNum);
}

// 10.Diagonal Sums

function diagonalSum(matrix) {
    let mainSum = 0;
    let secondarySum = 0;
    let lastElement = matrix.length - 1;

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if (i === j) {
                mainSum += matrix[i][j];
            }
            if (j === lastElement) {
                lastElement--;
                secondarySum += matrix[i][j];
            }
        }
    }

    console.log(mainSum + " " + secondarySum);
}

// 11.Equal Neighbors

function neighbour(matrix) {
    let currentElement = "";
    let counter = 0;
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            currentElement = matrix[i][j];

            if (i < matrix.length - 1 && j < matrix[i].length - 1) {
                if (currentElement == matrix[i][j + 1]) {
                    counter++;
                }
                if (currentElement == matrix[i + 1][j]) {
                    counter++;
                }
            }
            else if (j == matrix[i].length - 1) {
                if (i == matrix.length - 1 && j == matrix[i].length - 1) {
                    continue;
                }
                if (currentElement == matrix[i + 1][j]) {
                    counter++;
                }
            }
            else if (i == matrix.length - 1) {
                if (i == matrix.length - 1 && j == matrix[i].length - 1) {
                    continue;
                }
                if (currentElement == matrix[i][j + 1]) {
                    counter++;
                }
            }
        }
    }

    return counter;
}
