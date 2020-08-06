$(function() {
   RegisterEvents(); 
});


function RegisterEvents() {
    let page = $('#page_body');
    page.on("click", "#create_budget_btn", CreateBudget);
    page.on("click", ".delete-budget", DeleteBudget);
}


function CreateBudget() {
    $.ajax({
        url: "CreateBudget",
        type: "GET",
        async: true,
        success: function (response) {
            $('#page_body').prepend(response);
        }
    })
}

function ReloadBudgets() {
    $.ajax({
        url: "BudgetList",
        type: "GET",
        async: true,
        success: function (response) {
            $('#budget_section').replaceWith(response);
        }
    });
}

function DeleteBudget() {
    let id = this.getAttribute("id").replace("delete_", "");
    console.log(id)
    $.ajax({
        url: "DeleteBudget",
        type: "POST",
        async: true,
        data: "id=" + id,
        success: function (response) {
            console.log(response);
            ReloadBudgets();
        },
        error: function (response) {
            console.log(response)
        }
    })
}