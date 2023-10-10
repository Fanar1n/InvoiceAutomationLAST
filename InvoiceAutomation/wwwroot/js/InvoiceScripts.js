var invoiceList = []; // Инициализируем пустой список

document.getElementById("addProductButton").addEventListener("click", function (event) {
    event.preventDefault();

    var invoiceNumberField = document.getElementById("Invoice_Number");
    var documentNumberField = document.getElementById("Document_Number");
    var dataOfCreationField = document.getElementById("Data_Of_Creation");
    var senderCodeField = document.getElementById("Sender_Code");
    var recipientCodeField = document.getElementById("Recipient_Code");
    const productExpenseCode = document.getElementById("Cost_Code").value;
    const productName = document.getElementById("Name").value;
    const productItemNumber = document.getElementById("Item_Number").value;
    const productUnit = document.getElementById("Unit").value;
    const productQuantity = document.getElementById("Quantity").value;
    const productPrice = document.getElementById("Price").value;
    var allowedField = document.getElementById("Allowed");
    var controllerField = document.getElementById("Controller");
    var passedField = document.getElementById("Passed");
    var acceptedField = document.getElementById("Accepted");

    if (dataOfCreationField && senderCodeField && recipientCodeField && productExpenseCode && productName
        && productItemNumber && productUnit && productQuantity && allowedField && controllerField && passedField && acceptedField) {
        // Соберите данные из формы и добавьте их в список
        var invoiceData = {
            Id: null,
            Invoice_Number: document.getElementById("Invoice_Number").value,
            Document_Number: document.getElementById("Document_Number").value,
            Data_Of_Creation: document.getElementById("Data_Of_Creation").value,
            Sender_Code: document.getElementById("Sender_Code").value,
            Recipient_Code: document.getElementById("Recipient_Code").value,
            Cost_Code: document.getElementById("Cost_Code").value,
            Name: document.getElementById("Name").value,
            Item_Number: document.getElementById("Item_Number").value,
            Unit: document.getElementById("Unit").value,
            Quantity: document.getElementById("Quantity").value,
            Price: document.getElementById("Price").value,
            Allowed: document.getElementById("Allowed").value,
            Controller: document.getElementById("Controller").value,
            Passed: document.getElementById("Passed").value,
            Accepted: document.getElementById("Accepted").value
        };
        invoiceList.push(invoiceData);

        // Обновите значение скрытого поля

        // Очистите поля формы, если это необходимо
        // ...

        // Опционально: обновите список изделий на клиенте
        // ...

        const productList = document.getElementById("productList").getElementsByTagName("tbody")[0];
        const newRow = productList.insertRow(productList.rows.length);

        const cells = [];
        for (let i = 0; i < 9; i++) {
            cells[i] = newRow.insertCell(i);
        }

        cells[0].textContent = productList.rows.length;
        cells[1].textContent = productExpenseCode;
        cells[2].textContent = productName;
        cells[3].textContent = productItemNumber;
        cells[4].textContent = productUnit;
        cells[5].textContent = productQuantity;
        cells[6].textContent = productPrice;
        cells[7].textContent = (parseFloat(productQuantity) * parseFloat(productPrice)).toFixed(2);

        const deleteButton = document.createElement("button");

        deleteButton.textContent = "Удалить";

        deleteButton.addEventListener("click", function (event) {
            event.preventDefault();
            // Удаляем строку из таблицы
            productList.deleteRow(newRow.rowIndex - 1);

            // Удаляем соответствующий объект из списка invoiceList
            invoiceList.splice(newRow.rowIndex - 2, 1); // -1, так как индекс строки начинается с 0
        });

        cells[8].appendChild(deleteButton);

        var cell1 = document.getElementById("cell1");
        var cell2 = document.getElementById("cell2");
        var cell3 = document.getElementById("cell3");
        var cell4 = document.getElementById("cell4");
        var cell5 = document.getElementById("cell5");
        var cell6 = document.getElementById("cell6");
        var cell7 = document.getElementById("cell7");
        var cell8 = document.getElementById("cell8");

        // Заполните ячейки данными
        cell1.textContent = document.getElementById("Document_Number").value;
        cell2.textContent = document.getElementById("Data_Of_Creation").value;
        cell3.textContent = document.getElementById("Sender_Code").value;
        cell4.textContent = document.getElementById("Recipient_Code").value;
        cell5.textContent = document.getElementById("Allowed").value;
        cell6.textContent = document.getElementById("Controller").value;
        cell7.textContent = document.getElementById("Passed").value;
        cell8.textContent = document.getElementById("Accepted").value;


        invoiceNumberField.readOnly = true;
        documentNumberField.readOnly = true;
        documentNumberField.readOnly = true;
        dataOfCreationField.readOnly = true;
        senderCodeField.readOnly = true;
        recipientCodeField.readOnly = true;
        allowedField.readOnly = true;
        controllerField.readOnly = true;
        passedField.readOnly = true;
        acceptedField.readOnly = true;

        // Î÷èñòêà ïîëåé ââîäà
        //document.getElementById("Cost_Code").value = "";
        //document.getElementById("Name").value = "";
        //document.getElementById("Item_Number").value = "";
        //document.getElementById("Unit").value = "";
        //document.getElementById("Quantity").value = "";
        //document.getElementById("Price").value = "";
    }
});

document.getElementById("submitListButton").addEventListener("click", function () {
    // Отправьте список на сервер
    fetch("/Invoice/CreateInvoice", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(invoiceList)
    })
        .then(response => {
            if (response.ok) {

                downloadButton.style.display = "block";
                submitListButton.style.display = "none";

                //invoiceList = [];
                //document.getElementById("invoiceList").value = JSON.stringify(invoiceList);
            } else {
                // Ошибка при добавлении на сервер
                console.error("Ошибка при отправке списка на сервер.");
            }
        })
        .catch(error => {
            console.error("Ошибка при выполнении запроса:", error);
        });
});

document.getElementById("downloadButton").addEventListener("click", function () {
    // Отправьте список на сервер
    fetch("/Invoice/DownloadInvoice", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(invoiceList)
    })
        .then(response => {
            if (response.ok) {
                return response.blob(); // Получаем содержимое файла в виде Blob
            } else {
                // Ошибка при добавлении на сервер
                console.error("Ошибка при отправке списка на сервер.");
                throw new Error("Ошибка при отправке запроса на сервер.");
            }
        })
        .then(blob => {
            // Создаем временную ссылку для скачивания файла
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement("a");
            a.style.display = "none";
            a.href = url;
            a.download = "example.docx"; // Устанавливаем имя файла
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
        })
        .catch(error => {
            console.error("Ошибка при выполнении запроса:", error);
        });
});

