(() => {
        async function submitCreateGift() {
            const form = document.getElementById("createGiftForm");

            const formData = new FormData(form);

            const payload = {
                name: formData.get("name"),
                description: formData.get("description"),
                category: Number(formData.get("category")),
                url: formData.get("productLink"),
                imageUrl: formData.get("imageLink")
            };

            try {
                showLoading();

                const response = await fetch("/api/WebApp/Wishlists/Item", {
                    method: "POST",
                    credentials: "include",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(payload)
                });

                if (!response.ok) {
                    toast.error("Erro ao criar presente.")
                }

                toast.success("Presente criado com sucesso!");

                location.reload();

            } catch (error) {
                toast.error("Erro ao salvar o presente. Tente novamente.");
                
            } finally {
                hideLoading();
            }
    }
        
    window.submitCreateGift = submitCreateGift;
})();
