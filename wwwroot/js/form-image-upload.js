document.addEventListener("DOMContentLoaded", () => {

    const fileInput = document.getElementById("imageFileInput");
    const preview = document.getElementById("imagePreview");
    const placeholder = document.getElementById("imagePlaceholder");
    const uploadBtn = document.getElementById("uploadBtn");
    const removeBtn = document.getElementById("removeBtn");
    const removeInput = document.getElementById("removeImageInput");

    uploadBtn.addEventListener("click", () => {
        fileInput.click();
    });

    fileInput.addEventListener("change", () => {
        // If user didn't choose a file
        if (fileInput.files.length === 0) {
            // If there was an image to be uploaded as a preview -> remove it
            if (preview.src) {
                preview.classList.add("d-none");
                placeholder.classList.remove("d-none");
                removeBtn.classList.add("d-none");
            }
            return;
        }
        const file = fileInput.files[0];

        const reader = new FileReader();
        reader.onload = e => {
            preview.src = e.target.result;
            preview.classList.remove("d-none");
            placeholder.classList.add("d-none");
            removeBtn.classList.remove("d-none");
        };
        reader.readAsDataURL(file);

        removeInput.value = "false";
    });

    removeBtn.addEventListener("click", () => {
        fileInput.value = "";
        preview.src = "";
        preview.classList.add("d-none");
        placeholder.classList.remove("d-none");
        removeBtn.classList.add("d-none");

        removeInput.value = "true";
    });
});
