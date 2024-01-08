window.addEventListener("load", getDataForCategoryTable, false);

let categoryData;
let productTypeData;

function addCategory() {
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    dialogBox.appendChild(createTextElement("Category Name"));

    const inputElement = createInputTextElement("Category");
    dialogBox.appendChild(inputElement);

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => addCategoryToTable(inputElement));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function addCategoryToTable(inputElement) {
    if (inputElement.value.trim() != '') {
        const category = {
            categoryId: 0,
            categoryName: inputElement.value
        }
        const addCategoryURL = "https://localhost:7146/api/Category/AddCategory";
        fetch(addCategoryURL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(category),
        })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
                closeDialog();
                const categoryTable = document.getElementById("categorytable");
                if (categoryTable != undefined || categoryTable != null) {
                    categoryTable.remove();
                }
                getDataForCategoryTable();
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
}

function getDataForCategoryTable() {
    let categoryURL = "https://localhost:7146/api/Category/GetCategories";
    fetch(categoryURL)
        .then(res => res.json())
        .then(data => {
            categoryData = data;
            createCategoryTable(categoryData);
        })
        .catch(error => {
            console.log('Fetch error:', error);
        });
}

function createCategoryTable(data) {
    const tbl = document.createElement("table");
    tbl.id = "categorytable";
    const tblBody = document.createElement("tbody");
    const row = document.createElement("tr");
    row.style.background = 'lightblue';
    const cell1 = document.createElement("td");
    const cellText1 = document.createTextNode('CategoryName');
    const cell2 = document.createElement("td");
    const cellText2 = document.createTextNode("Edit");
    cell1.appendChild(cellText1);
    cell2.appendChild(cellText2);
    row.appendChild(cell1);
    row.appendChild(cell2);
    tblBody.appendChild(row);

    for (let i = 0; i < data.length; i++) {
        const row = document.createElement("tr");
        const uniqueId = "row_" + data[i].categoryId;
        row.setAttribute("id", uniqueId);
        const cell1 = document.createElement("td");
        const cellText1 = document.createTextNode(data[i].categoryName);
        const cell2 = document.createElement("td");
        const editIcon = document.createElement("i");
        editIcon.className = "fas fa-edit edit-icon";
        editIcon.addEventListener("click", () => editCategory(data[i]));

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


function editCategory(value) {
    updateCategory(value);
}

function updateCategory(value) {
    openDialog();

    const dialogBox = document.getElementById("dialogBox");
    dialogBox.appendChild(createTextElement("Category Name"));

    const inputElement = createInputTextElement("Category");
    inputElement.value = value.categoryName;
    dialogBox.appendChild(inputElement);

    const okButton = createButton("OK");
    okButton.addEventListener("click", () => updateCategoryToTable(inputElement, value));
    dialogBox.appendChild(okButton);

    const cancelButton = createButton("Cancel");
    cancelButton.addEventListener("click", () => closeDialog());
    dialogBox.appendChild(cancelButton);
}

function updateCategoryToTable(inputElement, categoryValue) {
    if (inputElement.value.trim() != '') {
        const category = {
            categoryId: categoryValue.categoryId,
            categoryName: inputElement.value
        }
        const updateProductTypeURL = "https://localhost:7146/api/Category/UpdateCategory";
        fetch(updateProductTypeURL,
            {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(category)
            })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
                closeDialog();
                const categoryTable = document.getElementById("categorytable");
                if (categoryTable != undefined || categoryTable != null) {
                    categoryTable.remove();
                }
                getDataForCategoryTable();
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
}