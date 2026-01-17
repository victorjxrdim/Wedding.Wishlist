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

            setTimeout(() => {
                location.reload();
            }, 2000);   

        } catch (error) {
            toast.error("Erro ao salvar o presente. Tente novamente.");
                
        } finally {
            hideLoading();
        }
    }
    
    async function deleteGift(giftId) {
        try {
            showLoading();

            const response = await fetch(`/api/WebApp/Wishlists/${giftId}`, {
                method: "DELETE",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                }
            });

            if (!response.ok) {
                toast.error("Erro ao excluir presente.");
            }

            toast.success("Presente excluído com sucesso!");

            setTimeout(() => {
                location.reload();
            }, 2000);
        } catch (error) {

        } finally {

        }
    }
    
    async function onDeleteClick(giftId) {
        const confirmed = await confirmAction({
            title: "Excluir Presente",
            message: "Tem certeza que deseja excluir este presente?",
            confirmText: "Excluir",
            cancelText: "Cancelar",
            icon: "warning",
            confirmColor: "#dc3545",
            cancelColor: "#6c757d"
        });

        if (confirmed) {
            deleteGift(giftId);
        } else {
        }    
    }

    window.submitCreateGift = submitCreateGift;
    window.deleteGift = deleteGift;
    window.onDeleteClick = onDeleteClick;

})();
