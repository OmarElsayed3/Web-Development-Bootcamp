const lis = document.querySelectorAll("img");
console.log(lis);

for (let i = 0; i < lis.length; i++) {
    lis[i].hasAttribute("alt") ? lis[i].setAttribute("alt","Old") : lis[i].setAttribute("alt","Elzero New");
}
