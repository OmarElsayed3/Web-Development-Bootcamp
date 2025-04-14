function passwordVisibility(ID) {
    var _a;
    var inputField = document.getElementById(ID);
    if (!inputField) {
        console.error("Element with id \"".concat(ID, "\" not found."));
        return;
    }
    var eyeIcon = (_a = inputField.nextElementSibling) === null || _a === void 0 ? void 0 : _a.querySelector('i');
    if (!eyeIcon) {
        console.error("Eye icon not found.");
        return;
    }
    if (inputField.type === "password") {
        inputField.type = "text";
        eyeIcon.classList.remove('fa-eye-slash');
        eyeIcon.classList.add('fa-eye');
    }
    else {
        inputField.type = "password";
        eyeIcon.classList.remove('fa-eye');
        eyeIcon.classList.add('fa-eye-slash');
    }
}
