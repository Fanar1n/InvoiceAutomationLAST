
function addProduct() {
    const productExpenseCode = document.getElementById("expenseCode").value;
    const productName = document.getElementById("name").value;
    const productItemNumber = document.getElementById("itemNumber").value;
    const productUnit = document.getElementById("unit").value;
    const productQuantity = document.getElementById("quantity").value;
    const productPrice = document.getElementById("price").value;

    if (productExpenseCode && productName && productItemNumber && productUnit && productQuantity && productPrice) {
        const productList = document.getElementById("productList").getElementsByTagName("tbody")[0];
        const newRow = productList.insertRow(productList.rows.length);

        const cells = [];
        for (let i = 0; i < 8; i++) {
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

        // Î÷èñòêà ïîëåé ââîäà
        document.getElementById("expenseCode").value = "";
        document.getElementById("name").value = "";
        document.getElementById("itemNumber").value = "";
        document.getElementById("unit").value = "";
        document.getElementById("quantity").value = "";
        document.getElementById("price").value = "";
    }
}