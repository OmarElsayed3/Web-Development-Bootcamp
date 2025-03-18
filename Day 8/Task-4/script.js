const Num = document.querySelector("#num");
const word = document.querySelector("#text");
const Button = document.querySelector("#btn");
const result = document.querySelector(".result");

Button.addEventListener("click", () => {
    result.innerHTML = ""; 
    for (let i = 1; i <= Num.value; i++) {
        const newElement = document.createElement("section");
        newElement.className = "box";
        newElement.innerHTML = word.value;
        
        result.appendChild(newElement);
    }
});