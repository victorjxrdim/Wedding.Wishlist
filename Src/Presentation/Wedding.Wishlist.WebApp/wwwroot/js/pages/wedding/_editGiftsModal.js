(() => {
    const gifts = window.gifts;
    const editGiftModalEl = document.getElementById("editGiftModal");
    const editGiftForm = document.getElementById("editGiftForm");
    const btnEditGiftSave = document.getElementById("btnEditGiftSave");

    const openEditModal = (itemId) => {
        console.log(itemId)
        const item = gifts.find(g => g.Id === itemId);
        if (!item) return toast.error("Item não encontrado.");

        editGiftForm.elements["id"].value = item.Id;
        editGiftForm.elements["name"].value = item.Name;
        editGiftForm.elements["description"].value = item.Description;
        editGiftForm.elements["category"].value = item.Category;
        editGiftForm.elements["imageLink"].value = item.ImageUrl;
        editGiftForm.elements["productLink"].value = item.Url;

        const modal = new bootstrap.Modal(editGiftModalEl);
        modal.show();
    };

    document.querySelectorAll(".btn-edit-gift").forEach(btn => {
        btn.addEventListener("click", () => {
            const itemId = btn.getAttribute("data-item-id");
            openEditModal(itemId);
        });
    });

    btnEditGiftSave?.addEventListener("click", async (e) => {
        e.preventDefault();

        const formData = new FormData(editGiftForm);
        const payload = {
            id: formData.get("id"),
            name: formData.get("name"),
            description: formData.get("description"),
            category: Number(formData.get("category")),
            url: formData.get("productLink"),
            imageUrl: formData.get("imageLink")
        };

        const confirmed = await confirmAction({
            title: "Salvar alterações?",
            message: "Deseja realmente salvar este presente?",
            confirmText: "Salvar",
            cancelText: "Cancelar",
            icon: "question",
            confirmColor: "#0d6efd"
        });

        if (!confirmed) {
            toast.info("Alterações não salvas.");
            return;
        }

        try {
            window.showLoading();

            const response = await fetch(`/api/WebApp/Wishlist/Edit/${payload.id}`, {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(payload)
            });

            if (!response.ok) {
                const errorText = await response.text();
                toast.error(errorText)
            }

            toast.success("Presente atualizado com sucesso!");

            setTimeout(() => {
                bootstrap.Modal.getInstance(editGiftModalEl)?.hide();
                location.reload();
            }, 2000);            

        } catch (error) {
            console.error(error);
            toast.error(error.message || "Erro ao salvar presente");
        } finally {
            window.hideLoading();
        }
    });
})();
