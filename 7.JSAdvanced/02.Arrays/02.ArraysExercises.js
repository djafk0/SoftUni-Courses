// 1.Print an Array with a Given Delimiter

function joinWithDelimeter(array, delimeter) {
    console.log(array.join(delimeter));
}

// 2.Print Every N-th Element from an Array 

function printStepthElement(array, step) {
    let result = [];
    for (let i = 0; i < array.length; i += step) {
        result.push(array[i]);
    }

    return result;
}

// 3.Add and Remove Elements  

function addAndRemoveElements(array) {
    let result = [];
    for (let i = 0; i < array.length; i++) {
        if (array[i] === "add") {
            result.push(i + 1)
        } else if (array[i] === "remove") {
            result.pop();
        }
    }

    console.log(result.length == 0 ? 'Empty' : result.join('\n'));
}

// 4.Rotate Array

function rotateArray(array, rotations) {
    let realRotations = rotations % array.length;

    for (let i = 0; i < realRotations; i++) {
        array.unshift(array.pop());
    }

    console.log(array.join(' '));
}

// 5.Extract Increasing Subsequence from Array

function increasingSubsequence(array) {
    let result = [array[0]];

    for (let i = 1; i < array.length; i++) {
        if (array[i] >= result[result.length - 1]) {
            result.push(array[i]);
        }
    }

    return result;
}

// 6.List of Names

function names(array) {
    array.sort(function (a, b) {
        return a.toLowerCase().localeCompare(b.toLowerCase());
    });

    for (let i = 0; i < array.length; i++) {
        console.log(i + 1 + '.' + array[i]);
    }
}

// 7.Sorting Numbers

function sortNumbers(array) {
    array.sort((a, b) => a - b);
    let result = [];
    for (let i = 0; i < array.length; i++) {
        result.push(array[i]);

        if (i == array.length - 1) {
            break;
        }

        result.push(array.pop());
    }

    return result;
}

// 8.Sort an Array by 2 Criteria

function sortArray(input) {
    const twoCriteriaSort = (cur, next) =>
        cur.length - next.length || cur.localeCompare(next);
    input.sort(twoCriteriaSort);
    console.log(input.join('\n'));
}

// 9.Magic Matrices

function magicMatrices(matrix) {
    let flag = true;
    let magicSum = 0;

    if (matrix.length !== matrix[0].length) {
        flag = false;
        return flag;
    }
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            magicSum += matrix[i][j];
        }

        break;
    }

    for (let i = 0; i < matrix.length; i++) {
        let rowSum = 0;
        let colSum = 0;
        for (let j = 0; j < matrix[i].length; j++) {
            rowSum += matrix[i][j];
            colSum += matrix[j][i];
        }
        if (magicSum !== rowSum || magicSum !== colSum) {
            flag = false;
            break;
        }
    }

    return flag;
}


