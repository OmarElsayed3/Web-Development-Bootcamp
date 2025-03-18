const usd = document.querySelector(".USD");
const p = document.querySelector(".result");
usd.addEventListener("input",() => {
    const egp = usd.value * 50.47;
    document.querySelector(".result").innerHTML = `{${usd.value}} USD Dollar = {${egp}} Egyptian Pound`;
});