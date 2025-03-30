let chars = ["A", "B", "C", 20, "D", "E", 10, 15, 6];
let result = chars.filter((char) => typeof char === "string").concat(
    chars.filter((char) => typeof char === "string")
);

console.log(result);