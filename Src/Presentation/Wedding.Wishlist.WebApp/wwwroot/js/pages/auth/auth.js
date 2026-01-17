(() => {
        async function submitRegister() {
            const form = document.getElementById("registerUser");

            const formData = new FormData(form);

            const payload = {
                name: formData.get("name"),
                email: formData.get("email"),                                
                password: formData.get("password")
            };

            console.log(payload);

            try {
                showLoading();

                const response = await fetch("/api/WebApp/User", {
                    method: "POST",                    
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(payload)
                });

                if (!response.ok) {
                    toast.error("Erro ao criar usuário.")
                }

                toast.success("Usuário criado com sucesso!");

                setTimeout(() => {
                    window.location.replace("/Login");
                }, 2000);                

            } catch (error) {
                toast.error("Erro ao criar usuário, tente novamente mais tarde.")                
            } finally {
                hideLoading();
            }
    }
            
    window.submitRegister = submitRegister;
})();
