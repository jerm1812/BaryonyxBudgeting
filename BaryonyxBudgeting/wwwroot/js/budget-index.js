$(function() {
   RegisterEvents(); 
});


function RegisterEvents() {
    $('#createBudget').click(CreateBudget)
}


function CreateBudget() {
    $.ajax({
        url: "CreateBudget",
        type: "GET",
        success: function (response) {
            $('#card').html(response);
        }
    })
}