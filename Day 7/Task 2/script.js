let myString = "EElllzzzzzzzzzeroo";
let result = [...new Set(myString)].join('');
console.log(result); // "Elzero"