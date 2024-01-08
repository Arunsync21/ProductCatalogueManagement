window.addEventListener("load", getDataForProductTypeTable, false);

let productTypeData;

function getDataForProductTypeTable() {
    let productTypeURL = "https://localhost:7146/api/ProductType/GetProductTypes";
    fetch(productTypeURL)
        .then(res => res.json())
        .then(data => {
            productTypeData = data;
            createProductTypeTable(productTypeData);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function getDataForProductType() {
    let categoryURL = "https://localhost:7146/api/Category/GetCategories";
    let listData;
    fetch(categoryURL)
        .then(res => res.json())
        .then(data => {
            listData = data;
            addProductType(listData);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function addProductType() {
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    dialogBox.appendChild(createTextElement("Categories"));

    var selectElement = document.createElement("select");
    selectElement.id = "dynamicDropdown";

    var defaultOption = document.createElement("option");
    defaultOption.value = "";
    defaultOption.textContent = "Select an option";
    selectElement.appendChild(defaultOption);

    categoryData.forEach(function (data, index) {
        var optionElement = document.createElement("option");
        optionElement.value = data.categoryId;
        optionElement.textContent = data.categoryName;
        selectElement.appendChild(optionElement);
    });

    dialogBox.appendChild(selectElement);

    selectElement.addEventListener("change", function () {
        var selectedValue = selectElement.value;
    });

    dialogBox.appendChild(createTextElement("Product Type Name"));

    const inputElement = createInputTextElement("ProductType");
    dialogBox.appendChild(inputElement);

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => addProductTypeToTable(selectElement, inputElement));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function addProductTypeToTable(selectElement, inputElement) {
    if (selectElement.value.trim() != '' && inputElement.value.trim() != '') {
        const productType = {
            typeId: 0,
            categoryId: selectElement.value,
            typeName: inputElement.value
        }
        const addProductURL = "https://localhost:7146/api/ProductType/AddProductType";
        fetch(addProductURL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(productType),
        })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
                closeDialog();
                const productTypeTable = document.getElementById("producttypetable");
                if (productTypeTable != undefined || productTypeTable != null) {
                    productTypeTable.remove();
                }
                getDataForProductTypeTable();
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
}

function createProductTypeTable(data) {
    const tbl = document.createElement("table");
    tbl.id = "producttypetable";
    const tblBody = document.createElement("tbody");
    const row = document.createElement("tr");
    row.style.background = 'lightblue';
    const cell1 = document.createElement("td");
    const cellText1 = document.createTextNode('ProductType');
    const cell2 = document.createElement("td");
    const cellText2 = document.createTextNode("Edit");
    cell1.appendChild(cellText1);
    cell2.appendChild(cellText2);
    row.appendChild(cell1);
    row.appendChild(cell2);
    tblBody.appendChild(row);

    for (let i = 0; i < data.length; i++) {
        const row = document.createElement("tr");
        const uniqueId = "row_" + data[i].typeId;
        row.setAttribute("id", uniqueId);
        const cell1 = document.createElement("td");
        const cellText1 = document.createTextNode(data[i].typeName);
        const cell2 = document.createElement("td");
        const editIcon = document.createElement("i");
        editIcon.className = "fas fa-edit edit-icon";
        editIcon.addEventListener("click", () => editProductType(data[i]));

        cell1.appendChild(cellText1);
        cell2.appendChild(editIcon);

        row.appendChild(cell1);
        row.appendChild(cell2);
        tblBody.appendChild(row);
    }
    tbl.appendChild(tblBody);
    const contentSection = document.getElementById('content-section');
    contentSection.appendChild(tbl);
    tbl.setAttribute("border", "1");
}

function editProductType(value) {
    getDataForProductTypeUpdate(value);
}

function getDataForProductTypeUpdate(value) {
    let categoryURL = "https://localhost:7146/api/Category/GetCategories";
    fetch(categoryURL)
        .then(res => res.json())
        .then(data => {
            updateDialog(data, value);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function getDataForProductTypeAdd() {
    let categoryURL = "https://localhost:7146/api/Category/GetCategories";
    fetch(categoryURL)
        .then(res => res.json())
        .then(data => {
            addProductType(data);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function addProductType(categoryData) {
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    dialogBox.appendChild(createTextElement("Categories"));

    var selectElement = document.createElement("select");
    selectElement.id = "dynamicDropdown";

    var defaultOption = document.createElement("option");
    defaultOption.value = "";
    defaultOption.textContent = "Select an option";
    selectElement.appendChild(defaultOption);

    categoryData.forEach(function (data, index) {
        var optionElement = document.createElement("option");
        optionElement.value = data.categoryId;
        optionElement.textContent = data.categoryName;
        selectElement.appendChild(optionElement);
    });

    dialogBox.appendChild(selectElement);

    selectElement.addEventListener("change", function () {
        var selectedValue = selectElement.value;
    });

    dialogBox.appendChild(createTextElement("Product Type Name"));

    const inputElement = createInputTextElement("ProductType");
    dialogBox.appendChild(inputElement);

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => addProductTypeToTable(selectElement, inputElement));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function updateDialog(categoryData, productType) {
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    dialogBox.appendChild(createTextElement("Categories"));

    var selectElement = document.createElement("select");
    selectElement.id = "dynamicDropdown";

    let selectedIndex;
    categoryData.forEach(function (data, index) {
        if (data.categoryId == productType.categoryId) {
            selectedIndex = index;
        }
        index++;
        var optionElement = document.createElement("option");
        optionElement.value = data.categoryId;
        optionElement.textContent = data.categoryName;
        selectElement.appendChild(optionElement);
    });

    selectElement.selectedIndex = selectedIndex;

    dialogBox.appendChild(selectElement);

    selectElement.addEventListener("change", function () {
        var selectedValue = selectElement.value;
    });

    dialogBox.appendChild(createTextElement("Product Type Name"));

    const inputElement = createInputTextElement("ProductType");
    inputElement.value = productType.typeName;
    dialogBox.appendChild(inputElement);

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => updateProductTypeToTable(selectElement, inputElement, productType));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function updateProductTypeToTable(selectElement, inputElement, data) {
    if (inputElement.value.trim() != '') {
        const productType = {
            typeId: data.typeId,
            categoryId: selectElement.value,
            typeName: inputElement.value
        }
        const updateProductTypeURL = "https://localhost:7146/api/ProductType/UpdateProductType";
        fetch(updateProductTypeURL,
            {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(productType)
            })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
                closeDialog();
                const productTypeTable = document.getElementById("producttypetable");
                if (productTypeTable != undefined || productTypeTable != null) {
                    productTypeTable.remove();
                }
                getDataForProductTypeTable();
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
}