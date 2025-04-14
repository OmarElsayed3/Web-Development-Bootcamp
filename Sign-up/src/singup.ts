function passwordVisibility(ID: string): void {
    const inputField = document.getElementById(ID) as HTMLInputElement | null;
    if (!inputField) {
        console.error(`Element with id "${ID}" not found.`);
        return;
    }

    const eyeIcon = inputField.nextElementSibling?.querySelector('i');
    if (!eyeIcon) {
        console.error("Eye icon not found.");
        return;
    }

    if (inputField.type === "password") {
        inputField.type = "text";
        eyeIcon.classList.remove('fa-eye-slash');
        eyeIcon.classList.add('fa-eye');
    } else {
        inputField.type = "password";
        eyeIcon.classList.remove('fa-eye');
        eyeIcon.classList.add('fa-eye-slash');
    }
}