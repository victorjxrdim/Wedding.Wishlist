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

})();
