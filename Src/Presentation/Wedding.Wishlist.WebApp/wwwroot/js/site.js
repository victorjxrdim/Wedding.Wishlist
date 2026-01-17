(() => {
    const loadingElement = document.getElementById("globalLoading");

    window.showLoading = function () {
        loadingElement?.classList.remove("d-none");
    };

    window.hideLoading = function () {
        loadingElement?.classList.add("d-none");
    };

    window.toast = {

        success(message, timer = 3000) {
            showToast("success", message, timer, "#198754");
        },

        error(message, timer = 4000) {
            showToast("error", message, timer, "#dc3545");
        },

        warning(message, timer = 3500) {
            showToast("warning", message, timer, "#ffc107");
        },

        info(message, timer = 3000) {
            showToast("info", message, timer, "#0d6efd");
        }
    };

    function showToast(icon, message, timer, bgColor) {
        Swal.fire({
            toast: true,
            position: "top-start",
            icon: icon,
            title: message,
            showConfirmButton: false,
            timer: timer,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.style.background = bgColor;
                toast.style.color = "#fff";
                toast.style.fontWeight = "500";
            }
        });
    }

    window.confirmAction = async function ({
        title = "Confirmação",
        message = "Tem certeza?",
        confirmText = "Confirmar",
        cancelText = "Cancelar",
        icon = "warning",
        confirmColor = "#dc3545",
        cancelColor = "#6c757d"
    }) {
        const result = await Swal.fire({
            title: title,
            text: message,
            icon: icon,
            showCancelButton: true,
            confirmButtonText: confirmText,
            cancelButtonText: cancelText,
            focusCancel: true,
            reverseButtons: true,
            buttonsStyling: true,
            customClass: {
                confirmButton: "btn btn-sm",
                cancelButton: "btn btn-sm"
            },
            didOpen: (modal) => {
                const confirmBtn = modal.querySelector(".swal2-confirm");
                const cancelBtn = modal.querySelector(".swal2-cancel");
                if (confirmBtn) confirmBtn.style.background = confirmColor;
                if (cancelBtn) cancelBtn.style.background = cancelColor;
                if (confirmBtn) confirmBtn.style.color = "#fff";
                if (cancelBtn) cancelBtn.style.color = "#fff";
            }
        });

        return result.isConfirmed;
    };

})();
