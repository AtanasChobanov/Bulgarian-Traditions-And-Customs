document.addEventListener('DOMContentLoaded', function () {
    // 1. Relation Card Interaction Logic
    const relationCards = document.querySelectorAll('.relation-card');
    
    relationCards.forEach(card => {
        card.addEventListener('click', function (e) {
            if (e.target.tagName === 'INPUT') return;

            const checkbox = this.querySelector('.relation-checkbox');
            const roleInput = this.querySelector('.role-badge-input');
            const checkIcon = this.querySelector('.check-icon i');

            checkbox.checked = !checkbox.checked;
            
            if (checkbox.checked) {
                this.classList.add('selected');
                if(roleInput) roleInput.classList.remove('d-none');
                if(checkIcon) checkIcon.classList.remove('d-none');
            } else {
                this.classList.remove('selected');
                if(roleInput) roleInput.classList.add('d-none');
                if(checkIcon) checkIcon.classList.add('d-none');
            }
            
            checkbox.dispatchEvent(new Event('change', { bubbles: true }));
        });

        const innerRoleInput = card.querySelector('.role-badge-input');
        if (innerRoleInput) {
            innerRoleInput.addEventListener('click', (e) => e.stopPropagation());
        }
    });

    // 2. Refined Image Preview Logic (Click-only)
    const imageInput = document.getElementById('imageFileInput');
    const imagePreview = document.getElementById('formImagePreview');
    const removeInput = document.getElementById('removeImageInput');
    const changeBtn = document.getElementById('changeImageBtn');
    const removeBtn = document.getElementById('removeImageBtn');
    const uploadBox = document.getElementById('uploadBox');
    const placeholder = document.getElementById('uploadPlaceholder');
    const actionsBar = document.getElementById('uploadActionsBar');

    function updatePreviewVisibility(hasImage) {
        if (hasImage) {
            if(imagePreview) imagePreview.classList.remove('d-none');
            if(placeholder) placeholder.classList.add('d-none');
            if(actionsBar) actionsBar.classList.remove('d-none');
        } else {
            if(imagePreview) {
                imagePreview.src = '';
                imagePreview.classList.add('d-none');
            }
            if(placeholder) placeholder.classList.remove('d-none');
            if(actionsBar) actionsBar.classList.add('d-none');
        }
    }

    function handleFile(file) {
        if (!file || !file.type.startsWith('image/')) return;
        
        const reader = new FileReader();
        reader.onload = (re) => {
            if(imagePreview) imagePreview.src = re.target.result;
            updatePreviewVisibility(true);
            if(removeInput) removeInput.value = "false";
        };
        reader.readAsDataURL(file);
    }

    if (imageInput) {
        imageInput.addEventListener('change', function(e) {
            if (e.target.files.length) {
                handleFile(e.target.files[0]);
            } else {
                // Persistence Fix: If selection is cancelled, clear the preview
                // to match the actual empty state of the input field.
                updatePreviewVisibility(false);
                if(removeInput) removeInput.value = "true";
            }
        });
    }

    if (uploadBox) {
        uploadBox.addEventListener('click', (e) => {
            // Don't trigger if overlay buttons are clicked
            if (e.target.closest('#uploadActionsBar')) return;
            imageInput.click();
        });
    }

    if (changeBtn && imageInput) {
        changeBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            imageInput.click();
        });
    }

    if (removeBtn) {
        removeBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            if(imageInput) imageInput.value = '';
            updatePreviewVisibility(false);
            if(removeInput) removeInput.value = "true";
        });
    }
});
