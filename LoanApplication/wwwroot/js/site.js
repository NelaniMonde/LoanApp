// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var toggleBtn = document.getElementById("navToggle");
var menu = document.getElementById("navMenu");
var count = 0;

//View variables declarations
const indexText = document.getElementById("IndexId");
const addLoanerID = document.getElementById("AddLoanerID");
const updateLoanerID = document.getElementById("UpdateLoanerID");
const deleteLoanerID = document.getElementById("DeleteLoanerID");
const loanerDetailsID = document.getElementById("LoanerDetailsID");





//nav button even listener
toggleBtn.addEventListener("click", () => {
    menu.classList.toggle("active");
    menu.hidden = false;


    //element event conditions
    if (indexText != null) {
        indexText.style.marginTop = '50px';
    }
    if (addLoanerID != null) {
        addLoanerID.style.marginTop = '50px';
    }
    if (updateLoanerID != null) {

        updateLoanerID.style.marginTop = '50px';
    }

    if (deleteLoanerID != null) {
        deleteLoanerID.style.marginTop = '50px';
    }

    if (loanerDetailsID != null) {
        loanerDetailsID.style.marginTop = '50px';
    }

    



    //doing a count for when the nav button is clicked once more
    count += 1;

    if (count > 1) {
        //going back to normal condition 
        if (indexText != null) {

            indexText.style.marginTop = "50px";
        }

        if (addLoanerID != null) {
            addLoanerID.style.marginTop = '50px';
        }
        if (updateLoanerID != null) {
            updateLoanerID.style.marginTop = '25px';
        }

        if (deleteLoanerID != null) {
            deleteLoanerID.style.marginTop = '30px';
        }

        if (loanerDetailsID != null) {
            loanerDetailsID.style.marginTop = '30px';
        }

        count = 0;
    }

});
