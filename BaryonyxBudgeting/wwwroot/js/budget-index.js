$(function() {
   RegisterEvents(); 
});


function RegisterEvents() {
    $('#create_budget_btn').click(CreateBudget)
}


function CreateBudget() {
    $.ajax({
        url: "CreateBudget",
        type: "GET",
        success: function (response) {
            $('#page_body').prepend(response);
        }
    })
}