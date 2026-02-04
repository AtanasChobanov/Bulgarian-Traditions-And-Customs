document.addEventListener("DOMContentLoaded", () => {

    const checkboxes = document.querySelectorAll(".tradition-participant-checkbox");

    checkboxes.forEach(cb => {
        const container = cb.closest(".form-check");
        const roleInput = container.querySelector(".role-input");

        cb.addEventListener("change", () => {

            if (cb.checked) {
                roleInput.classList.remove("d-none");
                roleInput.focus();
            } else {
                roleInput.classList.add("d-none");
                roleInput.value = "";
            }
        });
    });
});
