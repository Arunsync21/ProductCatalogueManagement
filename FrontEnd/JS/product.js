window.addEventListener("load", getDataForProductTypeTable, false);

let productTypeData;
let productData;
let featureData;

function addProduct() {
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    dialogBox.appendChild(createTextElement("Product Types"));

    var selectElement = document.createElement("select");
    selectElement.id = "dynamicDropdown";

    var defaultOption = document.createElement("option");
    defaultOption.value = "";
    defaultOption.textContent = "Select an option";
    selectElement.appendChild(defaultOption);

    productTypeData.forEach(function (data, index) {
        var optionElement = document.createElement("option");
        optionElement.value = data.typeId;
        optionElement.textContent = data.typeName;
        selectElement.appendChild(optionElement);
    });

    dialogBox.appendChild(selectElement);

    selectElement.addEventListener("change", function () {
        var selectedValue = selectElement.value;
    });

    dialogBox.appendChild(createTextElement("Product Name"));

    const productInputElement = createInputTextElement("Product");
    dialogBox.appendChild(productInputElement);

    dialogBox.appendChild(createTextElement("Brand Name"));

    const brandInputElement = createInputTextElement("Brand");
    dialogBox.appendChild(brandInputElement);

    dialogBox.appendChild(createTextElement("Price"));

    const priceInputElement = createInputTextElement("Price");
    dialogBox.appendChild(priceInputElement);

    dialogBox.appendChild(createTextElement("Stock"));

    const stockInputElement = createInputTextElement("Stock");
    dialogBox.appendChild(stockInputElement);

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => validateProduct(selectElement, productInputElement, brandInputElement, priceInputElement, stockInputElement));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function getFeatureByType(product) {
    const featureByTypeURL = `https://localhost:7146/api/Feature/GetFeatureByProductType/${product.typeId}`;
    fetch(featureByTypeURL)
        .then(res => res.json())
        .then(data => {
            featureData = data;
            createFeatureDialog(data, product);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function getDataForProductTypeTable() {
    const productTypeURL = "https://localhost:7146/api/ProductType/GetProductTypes";
    fetch(productTypeURL)
        .then(res => res.json())
        .then(data => {
            productTypeData = data;
            createProductTypeDropDown();
            getProductsByType(data[0].typeId)
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function createProductTypeDropDown() {
    const contentSection = document.getElementById("content-section");
    const divElement = document.createElement("div");
    divElement.classList.add('product-type-container');
    divElement.style.fontWeight = 'bold';
    divElement.appendChild(createTextElement("ProductTypes"))
    contentSection.appendChild(divElement);

    const selectElement = document.createElement("select");
    selectElement.id = "producttype-dropdown";
    selectElement.classList.add('product-type-dropdown');

    productTypeData.forEach(function (data, index) {
        var optionElement = document.createElement("option");
        optionElement.value = data.typeId;
        optionElement.textContent = data.typeName;
        selectElement.appendChild(optionElement);
    });

    divElement.appendChild(selectElement);

    selectElement.addEventListener("change", function () {
        document.getElementById("producttable").remove();
        getProductsByType(selectElement.value);
    });
}

function getProductsByType(id) {
    const productsByTypeURL = `https://localhost:7146/api/Product/GetProductByProductType/${id}`;
    fetch(productsByTypeURL)
        .then(res => res.json())
        .then(data => {
            productData = data;
            createProductTable(data);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function createProductTable(data) {
    const tbl = document.createElement("table");
    tbl.id = "producttable";
    const tblBody = document.createElement("tbody");
    const row = document.createElement("tr");
    row.style.background = 'lightblue';
    const cell1 = document.createElement("td");
    const cellText1 = document.createTextNode('Product');
    const cell2 = document.createElement("td");
    const cellText2 = document.createTextNode("Edit");
    const cell3 = document.createElement("td");
    const cellText3 = document.createTextNode("Delete");
    const cell4 = document.createElement("td");
    const cellText4 = document.createTextNode("Add Value");
    cell1.appendChild(cellText1);
    cell2.appendChild(cellText2);
    cell3.appendChild(cellText3);
    cell4.appendChild(cellText4);
    row.appendChild(cell1);
    row.appendChild(cell4);
    row.appendChild(cell2);
    row.appendChild(cell3);
    tblBody.appendChild(row);

    for (let i = 0; i < data.length; i++) {
        const row = document.createElement("tr");
        const uniqueId = "row_" + data[i].productId;
        row.setAttribute("id", uniqueId);
        const cell1 = document.createElement("td");
        const cellText1 = document.createTextNode(data[i].productName);
        const cell2 = document.createElement("td");
        const editIcon = document.createElement("i");
        editIcon.className = "fas fa-edit edit-icon";
        editIcon.addEventListener("click", () => editProduct(data[i]));
        const cell3 = document.createElement("td");
        const deleteIcon = document.createElement("i");
        deleteIcon.className = "fas fa-trash-alt delete-icon";
        deleteIcon.addEventListener("click", () => deleteProduct(data[i]));
        const cell4 = document.createElement("td");
        const addIcon = document.createElement("i");
        addIcon.className = "fas fa-plus plus-icon";
        addIcon.addEventListener("click", () => addFeatureValue(data[i]));

        cell1.appendChild(cellText1);
        cell2.appendChild(editIcon);
        cell3.appendChild(deleteIcon);
        cell4.appendChild(addIcon);

        row.appendChild(cell1);
        row.appendChild(cell4);
        row.appendChild(cell2);
        row.appendChild(cell3);
        tblBody.appendChild(row);
    }
    tbl.appendChild(tblBody);
    const contentSection = document.getElementById('content-section');
    contentSection.appendChild(tbl);
    tbl.setAttribute("border", "1");
}

function getProductTypeById(selectElement, productInputElement, brandInputElement, priceInputElement, stockInputElement) {
    const productTypeByIDURL = `https://localhost:7146/api/ProductType/GetProductTypeByID/${selectElement.value}`;
    fetch(productTypeByIDURL)
        .then(res => res.json())
        .then(data => {
            addProductToTable(selectElement, productInputElement, brandInputElement, priceInputElement, stockInputElement, data);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function validateProduct(selectElement, productInputElement, brandInputElement, priceInputElement, stockInputElement) {
    if (selectElement.value.trim() != '' && productInputElement.value.trim() != ''
        && brandInputElement.value.trim() != '' && priceInputElement.value.trim() != '' && stockInputElement.value.trim() != '') {
        getProductTypeById(selectElement, productInputElement, brandInputElement, priceInputElement, stockInputElement);
    }
}

function addProductToTable(selectElement, productInputElement, brandInputElement, priceInputElement, stockInputElement, data) {
    const product = {
        productId: 0,
        typeId: selectElement.value,
        categoryId: data.categoryId,
        productName: productInputElement.value,
        price: priceInputElement.value,
        stock: stockInputElement.value,
        brandName: brandInputElement.value
    }
    const addProductURL = "https://localhost:7146/api/Product/AddProduct";
    fetch(addProductURL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(product),
    })
        .then((response) => response.json())
        .then((data) => {
            console.log('Success:', data);
            closeDialog();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function editProduct(value) {
    getDataForProductUpdate(value);
}

function getDataForProductUpdate(value) {
    const productTypeURL = "https://localhost:7146/api/ProductType/GetProductTypes";
    fetch(productTypeURL)
        .then(res => res.json())
        .then(data => {
            productTypeData = data;
            updateDialog(value);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function updateDialog(product) {
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    dialogBox.appendChild(createTextElement("Product Types"));

    var selectElement = document.createElement("select");
    selectElement.id = "dynamicDropdown";

    let selectedIndex;

    productTypeData.forEach(function (data, index) {
        if (data.typeId == product.typeId) {
            selectedIndex = index;
        }
        index++;
        var optionElement = document.createElement("option");
        optionElement.value = data.typeId;
        optionElement.textContent = data.typeName;
        selectElement.appendChild(optionElement);
    });
    selectElement.selectedIndex = selectedIndex;

    dialogBox.appendChild(selectElement);

    selectElement.addEventListener("change", function () {
        var selectedValue = selectElement.value;
    });

    dialogBox.appendChild(createTextElement("Product Name"));

    const productInputElement = createInputTextElement("Product");
    productInputElement.value = product.productName;
    dialogBox.appendChild(productInputElement);

    dialogBox.appendChild(createTextElement("Brand Name"));

    const brandInputElement = createInputTextElement("Brand");
    brandInputElement.value = product.brandName;
    dialogBox.appendChild(brandInputElement);

    dialogBox.appendChild(createTextElement("Price"));

    const priceInputElement = createInputTextElement("Price");
    priceInputElement.value = product.price;
    dialogBox.appendChild(priceInputElement);

    dialogBox.appendChild(createTextElement("Stock"));

    const stockInputElement = createInputTextElement("Stock");
    stockInputElement.value = product.stock;
    dialogBox.appendChild(stockInputElement);

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => updateProductToTable(selectElement, productInputElement, brandInputElement, priceInputElement, stockInputElement, product));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function updateProductToTable(selectElement, productInputElement, brandInputElement, priceInputElement, stockInputElement, data) {
    if (productInputElement.value.trim() != '' && brandInputElement.value.trim() != ''
        && priceInputElement.value.trim() != '' && stockInputElement.value.trim() != '') {
        const product = {
            productId: data.productId,
            typeId: selectElement.value,
            categoryId: data.categoryId,
            productName: productInputElement.value,
            price: priceInputElement.value,
            stock: stockInputElement.value,
            brandName: brandInputElement.value
        }
        const updateProductURL = "https://localhost:7146/api/Product/UpdateProduct";
        fetch(updateProductURL,
            {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(product)
            })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
                closeDialog();
                document.getElementById("producttable").remove();
                getProductsByType(selectElement.value);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
}
function deleteProduct(value) {
    getFeatureValuesByProduct(value);
    deleteProductFromTable(value);
}

function deleteProductFromTable(product) {
    const deleteProductURL = `https://localhost:7146/api/Product/DeleteProduct/${product.productId}`;
    fetch(deleteProductURL,
        {
            method: 'DELETE'
        })
        .then(response => {
            if (response.ok) {
                console.log('Product deleted successfully');
            }
        })
        .then(() => {
            document.getElementById("producttable").remove();
            getProductsByType(product.typeId);
        })
        .catch(error => console.log('Unable to delete item.', error));
}

function getFeatureValuesByProduct(product) {
    const getFeatureValueByProductURL = `https://localhost:7146/api/FeatureValue/GetFeatureValueByProduct/${product.productId}`;

    fetch(getFeatureValueByProductURL)
        .then(res => res.json())
        .then(data => {
            deleteFeatureValues(data);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function deleteFeatureValues(featureValues) {
    for (let i = 0; i < featureValues.length; i++) {
        const deleteFeatureValueURL = `https://localhost:7146/api/FeatureValue/DeleteFeatureValue/${featureValues[i].valueId}`;
        fetch(deleteFeatureValueURL,
            {
                method: 'DELETE'
            })
            .then(response => {
                if (response.ok) {
                    console.log('Product deleted successfully');
                }
            })
            .catch(error => console.log('Unable to delete item.', error));
    }
}

function addFeatureValue(product) {
    getFeatureByType(product);
}

function createFeatureDialog(data, product) {
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    data.forEach(function (feature, index) {
        dialogBox.appendChild(createTextElement(feature.featureName));
        const inputElement = document.createElement("input");
        inputElement.type = "text";
        inputElement.placeholder = feature.featureName;
        inputElement.style.width = "100%";
        inputElement.style.marginBottom = "10px";
        inputElement.style.padding = "8px";
        inputElement.style.boxSizing = "border-box";
        dialogBox.appendChild(inputElement);
    });

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => validateFeature(dialogBox, product));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function validateFeature(dialogBox, product) {
    const inputElements = dialogBox.querySelectorAll('input');
    for (let i = 0; i < inputElements.length; i++) {
        if (inputElements[i].value == '') {
            return;
        }
    }
    const featureValues = [];
    const featureIds = [];
    for (let i = 0; i < inputElements.length; i++) {
        featureValues.push(inputElements[i].value);
        featureIds.push(featureData[i].featureId);
    }
    addFeatureValueToTable(featureValues, featureIds, product);
}

function addFeatureValueToTable(featureValuesData, featureIdsData, product) {
    const addFeatureValueURL = "https://localhost:7146/api/FeatureValue/AddFeatureValue";
    for (let i = 0; i < featureData.length; i++) {
        const featureValue = {
            valueId: 0,
            productId: product.productId,
            featureId: featureIdsData[i],
            valueName: featureValuesData[i]
        };
        fetch(addFeatureValueURL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(featureValue),
        })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
    closeDialog();
}