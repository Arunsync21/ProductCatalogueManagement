window.addEventListener("load", getDataForProductTypeTable, false);

let productTypeData;
let featureData;

function getDataForProductTypeTable() {
    const productTypeURL = "https://localhost:7146/api/ProductType/GetProductTypes";
    fetch(productTypeURL)
        .then(res => res.json())
        .then(data => {
            productTypeData = data;
            createProductTypeDropDown();
            getFeatureById(data[0].typeId);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function getFeatureById(id) {
    const featureByTypeURL = `https://localhost:7146/api/Feature/GetFeatureByProductType/${id}`;
    fetch(featureByTypeURL)
        .then(res => res.json())
        .then(data => {
            featureData = data;
            createFeatureTable(data);
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
        document.getElementById("featuretable").remove();
        getFeatureById(selectElement.value);
    });
}

function createFeatureTable(data) {
    const tbl = document.createElement("table");
    tbl.id = "featuretable";
    const tblBody = document.createElement("tbody");
    const row = document.createElement("tr");
    row.style.background = 'lightblue';
    const cell1 = document.createElement("td");
    const cellText1 = document.createTextNode('FeatureName');
    const cell2 = document.createElement("td");
    const cellText2 = document.createTextNode("Edit");
    cell1.appendChild(cellText1);
    cell2.appendChild(cellText2);
    row.appendChild(cell1);
    row.appendChild(cell2);
    tblBody.appendChild(row);

    for (let i = 0; i < data.length; i++) {
        const row = document.createElement("tr");
        const uniqueId = "row_" + data[i].featureId;
        row.setAttribute("id", uniqueId);
        const cell1 = document.createElement("td");
        const cellText1 = document.createTextNode(data[i].featureName);
        const cell2 = document.createElement("td");
        const editIcon = document.createElement("i");
        editIcon.className = "fas fa-edit edit-icon";
        editIcon.addEventListener("click", () => editFeature(data[i]));

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

function addFeature() {
    const selectElement = document.getElementById("producttype-dropdown");
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    dialogBox.appendChild(createTextElement("Feature Name"));

    const inputElement = createInputTextElement("FeatureName");
    dialogBox.appendChild(inputElement);

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => addFeatureToTable(selectElement, inputElement));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function addFeatureToTable(selectElement, inputElement) {
    if (inputElement.value.trim() != '') {
        const feature = {
            featureId: 0,
            typeId: selectElement.value,
            featureName: inputElement.value
        }
        const addFeatureURL = "https://localhost:7146/api/Feature/AddFeature";
        fetch(addFeatureURL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(feature),
        })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
                closeDialog();
                document.getElementById("featuretable").remove();
                getFeatureById(selectElement.value);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
}

function editFeature(value) {
    getDataForFeatureUpdate(value);
}

function getDataForFeatureUpdate(feature) {
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    dialogBox.appendChild(createTextElement("Feature Name"));

    const inputElement = createInputTextElement("FeatureName");
    inputElement.value = feature.featureName;
    dialogBox.appendChild(inputElement);

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => updateFeatureToTable(feature, inputElement));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function updateFeatureToTable(value, inputElement) {
    if (inputElement.value.trim() != '') {
        const feature = {
            featureId: value.featureId,
            typeId: value.typeId,
            featureName: inputElement.value
        }
        const updateFeatureURL = "https://localhost:7146/api/Feature/UpdateFeature";
        fetch(updateFeatureURL,
            {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(feature)
            })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
                closeDialog();
                document.getElementById("featuretable").remove();
                getFeatureById(value.typeId);
            })
            .catch((error) => {
                console.log('Error:', error);
            });
    }
}