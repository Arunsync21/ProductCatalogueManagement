window.addEventListener("load", getDataForProductTypeDropDown, false);

let productTypeData;
let productData;
let featureValueData;
let featureData;

function getDataForProductTypeDropDown() {
    const productTypeURL = "https://localhost:7146/api/ProductType/GetProductTypes";
    fetch(productTypeURL)
        .then(res => res.json())
        .then(data => {
            productTypeData = data;
            createProductTypeDropDown();
            getProductForProductType(data[0].typeId)
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function getFeatureByType(product) {
    if (product.length > 0) {
        const featureByTypeURL = `https://localhost:7146/api/Feature/GetFeatureByProductType/${product[0].typeId}`;
        fetch(featureByTypeURL)
            .then(res => res.json())
            .then(data => {
                featureData = data;
                getFeatureValueByProduct(product[0].productId);
            })
            .catch(error => {
                console.log('Fetch error:', error);
            });
    }
}

function getProductForProductType(id) {
    const getProductForProductTypeURL = `https://localhost:7146/api/Product/GetProductByProductType/${id}`;
    fetch(getProductForProductTypeURL)
        .then(res => res.json())
        .then(data => {
            productData = data;
            createProductDropDown();
            getFeatureByType(data);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function getFeatureValueByProduct(id) {
    const getFeatureValueByProductURL = `https://localhost:7146/api/FeatureValue/GetFeatureValueByProduct/${id}`;
    fetch(getFeatureValueByProductURL)
        .then(res => res.json())
        .then(data => {
            featureValueData = data;
            createFeatureValueTable();
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
    selectElement.style.marginLeft = "20px";
    selectElement.classList.add('product-type-dropdown');

    productTypeData.forEach(function (data, index) {
        var optionElement = document.createElement("option");
        optionElement.value = data.typeId;
        optionElement.textContent = data.typeName;
        selectElement.appendChild(optionElement);
    });

    divElement.appendChild(selectElement);

    selectElement.addEventListener("change", function () {
        const productDropdown = document.getElementById("product-dropdown-div");
        if (productDropdown != undefined || productDropdown != null) {
            productDropdown.remove();
        }
        const featureTable = document.getElementById("featuretable");
        if (featureTable != undefined || featureTable != null) {
            featureTable.remove();
        }
        getProductForProductType(selectElement.value);
    });
}

function createProductDropDown() {
    if (productData.length > 0) {
        const contentSection = document.getElementById("content-section");
        const divElement = document.createElement("div");
        divElement.id = "product-dropdown-div";
        divElement.classList.add('product-type-container');
        divElement.style.fontWeight = 'bold';
        divElement.appendChild(createTextElement("Products"))
        contentSection.appendChild(divElement);

        const selectElement = document.createElement("select");
        selectElement.id = "product-dropdown";
        selectElement.style.marginLeft = "55px";
        selectElement.style.width = "125px"
        selectElement.classList.add('product-type-dropdown');

        productData.forEach(function (data, index) {
            var optionElement = document.createElement("option");
            optionElement.value = data.productId;
            optionElement.textContent = data.productName;
            selectElement.appendChild(optionElement);
        });

        divElement.appendChild(selectElement);

        selectElement.addEventListener("change", function () {
            document.getElementById("featuretable").remove();
            getFeatureValueByProduct(selectElement.value);
        });
    }
}

function createFeatureValueTable() {
    const tbl = document.createElement("table");
    tbl.id = "featuretable";
    const tblBody = document.createElement("tbody");
    const row = document.createElement("tr");
    row.style.background = 'lightblue';
    const cell1 = document.createElement("td");
    const cellText1 = document.createTextNode('Feature Name');
    const cell2 = document.createElement("td");
    const cellText2 = document.createTextNode("Feature Value");
    cell1.appendChild(cellText1);
    cell2.appendChild(cellText2);
    row.appendChild(cell1);
    row.appendChild(cell2);
    tblBody.appendChild(row);

    if (featureValueData.length > 0) {
        for (let i = 0; i < featureData.length; i++) {
            for (let j = 0; j < featureValueData.length; j++) {
                if (featureData[i].featureId == featureValueData[j].featureId) {
                    const row = document.createElement("tr");
                    const uniqueId = "row_" + featureValueData[i].valueId;
                    row.setAttribute("id", uniqueId);
                    const cell1 = document.createElement("td");
                    const cellText1 = document.createTextNode(featureData[i].featureName);
                    const cell2 = document.createElement("td");
                    const cellText2 = document.createTextNode(featureValueData[j].valueName);

                    cell1.appendChild(cellText1);
                    cell2.appendChild(cellText2);

                    row.appendChild(cell1);
                    row.appendChild(cell2);
                    tblBody.appendChild(row);
                }
            }
        }
    }
    tbl.appendChild(tblBody);
    const contentSection = document.getElementById('content-section');
    contentSection.appendChild(tbl);
    tbl.setAttribute("border", "1");
}