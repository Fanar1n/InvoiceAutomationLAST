
document.getElementById("AuthorizationButton").addEventListener("click", function () {

    var userData = {
        Id: null,
        Username: document.getElementById("Username").value,
        Password: document.getElementById("Password").value
    }
    // Отправьте список на сервер
    fetch("/User/AuthorizationUser", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(userData)
    })
        .then(response => {
            if (response.notfound) {
                console.error("Пользователь не был найден.");
            }
            if (response.ok) {
                window.location.href = '/Invoice/Create';
            }
        })
        .catch(error => {
            console.error("Ошибка при выполнении запроса:", error);
        });
});
