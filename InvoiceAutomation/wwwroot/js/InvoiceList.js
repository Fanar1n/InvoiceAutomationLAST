document.getElementById("searchButton").addEventListener("click", function () {
    // Отправьте список на сервер

    var invoiceNumber = document.getElementById("invoiceNumber1").value;

    fetch("/Invoice/ShowList", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(invoiceNumber)
    })
        .then(response => {
            if (response.ok) {
                console.error("Всё работает заебись");
            } else {
                // Ошибка при добавлении на сервер
                console.error("Ошибка при отправке списка на сервер.");
            }
        })
        .catch(error => {
            console.error("Ошибка при выполнении запроса:", error);
        });
});