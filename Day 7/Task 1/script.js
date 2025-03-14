let mix = [1, 2, 3, "E", 4, "l", "z", "e", "r", 5, "o"];

let result = mix.filter(item => typeof item === "string").join("");

console.log(result);
