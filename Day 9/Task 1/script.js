let myFriends = [
    { title: "Osama", age: 39, available: true, skills: ["HTML", "CSS"] },
    { title: "Ahmed", age: 25, available: false, skills: ["Python", "Django"] },
    { title: "Sayed", age: 33, available: true, skills: ["PHP", "Laravel"] },
];

function getInput() {
    const chosen = parseInt(document.querySelector("#chosen").value);
    if (chosen === 1) {
        [{ title, age, available, skills: [, first] }] = myFriends;
        console.log('\n', title, '\n', age, '\n', available, '\n', first);
    } else if (chosen === 2) {
        [, { title, age, available, skills: [, first] }] = myFriends;
        console.log('\n', title, '\n', age, '\n', available, '\n', first);
    } else if (chosen === 3) {
        [, , { title, age, available, skills: [, first] }] = myFriends;
        console.log('\n', title, '\n', age, '\n', available, '\n', first);
    }
}

document.querySelector("#btn").addEventListener("click", getInput);