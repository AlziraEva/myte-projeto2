
function copyEmailAndPassword() {
    /* Get the text fields */
    var email = document.getElementById("email");
    var password = document.getElementById("password");

    /* Create a temporary textarea to hold the values */
    var tempInput = document.createElement("textarea");
    document.body.appendChild(tempInput);

    /* Set the value of the textarea to the email and password */
    tempInput.value = "Email: " + email.value + "\nPassword: " + password.value;

    /* Select the text in the textarea */
    tempInput.select();

    /* Copy the text inside the textarea */
    document.execCommand("copy");

    /* Remove the temporary textarea */
    document.body.removeChild(tempInput);

    /* Alert the copied text */
    alert("Copied the text: " + tempInput.value);
}