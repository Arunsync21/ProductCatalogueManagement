// Create dialog
function createDialog() {
    let dialogOverlay = document.createElement('div');
    dialogOverlay.id = "dialogOverlay";
    dialogOverlay.className = "overlay";

    let dialogBox = document.createElement('div');
    dialogBox.id = "dialogBox";
    dialogOverlay.appendChild(dialogBox);

    document.body.appendChild(dialogOverlay);
    console.log(dialogOverlay);
}

// To open the dialog
function openDialog() {
    createDialog();
    document.getElementById('dialogOverlay').style.display = 'flex';
}

// To close the dialog
function closeDialog() {
    document.getElementById('dialogOverlay').remove();
}

// Create text element
function createTextElement(text) {
    var divElement = document.createElement("div");

    var spanElement = document.createElement("span");
    spanElement.textContent = text;

    divElement.appendChild(spanElement);
    return divElement;
}

// Create input text element
function createInputTextElement(elementText) {
    var inputElement = document.createElement("input");

    inputElement.type = "text";
    inputElement.id = elementText;
    inputElement.placeholder = elementText;

    return inputElement;
}

// Create button element
function createButton(buttonText) {
    const button = document.createElement("button");
    button.textContent = buttonText;
    button.classList.add(buttonText + "-button");
    return button;
}