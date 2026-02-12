(() => {
    const btnChoosePresent = document.querySelector('[data-bs-target="#choosePresentModal"]');

    const choosePresentModalEl = document.getElementById("choosePresentModal");
    const choosePresentModalBody = choosePresentModalEl.querySelector(".modal-body");

    btnChoosePresent.addEventListener("click", async () => {
        try {
            window.showLoading();

            var wishlistId = document.querySelector('[data-bs-target="#choosePresentModal"]').id.toString();

            const response = await fetch(`/api/WebApp/Wishlist/${wishlistId}`, {
                method: "GET",
            });

            if (!response.ok) {
                toast.error("Erro ao carregar dados do presente.");
                return;
            }

            var data = await response.json();

            choosePresentModalBody.innerHTML = `
                <div class="text-center">
                    <h6 class="mb-3">${data.name}</h6>

                    <img src="${data.qrCodeUrl}" alt="QR Code" class="img-fluid mb-3" style="max-width: 250px;" />

                    <p class="fw-bold">Valor: R$ 10,00</p>

                    <button id="confirmPresentBtn" class="btn btn-primary mt-2">Confirmar Presente</button>
                </div>`;            

        } catch (error) {
            console.error(error);
            toast.error(error.message || "Erro ao carregar presente");
        } finally {
            window.hideLoading();
        }
    });    
})();

