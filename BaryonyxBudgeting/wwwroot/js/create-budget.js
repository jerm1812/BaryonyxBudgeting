$(function () {
    RegisterEvents();
});

let categoryCount = 1;


function RegisterEvents() {
    $('#cancel').click(Cancel);
    $('#addCategory').click(AddCategory);
    $('#createBudget').click(CreateBudget);
}

function Cancel() {
    $.ajax({
        url: "Budgets",
        type: "GET",
        success: function (response) {
            $('#card').html(response);
        }
    })
}

function CreateBudget() {
    $.ajax({
        url: "/UpdateBudget",
        type: "POST",
        success: function (response) {
            
        }
    })
}

function AddCategory() {
    console.log("test");
    $('#categorySection').append("<div class=\"form-group col-3\">\n" +
        "                <span asp-validation-for=\"Categories["+categoryCount+"].CategoryTitle\"></span>\n" +
        "                <label asp-for=\"Categories["+categoryCount+"].CategoryTitle\"></label>\n" +
        "                <input asp-for=\"Categories["+categoryCount+"].CategoryTitle\" class=\"form-control\"/>\n" +
        "            </div>\n" +
        "            <div class=\"form-group col-3\">\n" +
        "                <span asp-validation-for=\"Categories["+categoryCount+"].CategoryTotal\"></span>\n" +
        "                <label asp-for=\"Categories["+categoryCount+"].CategoryTotal\"></label>\n" +
        "                <input asp-for=\"Categories["+categoryCount+"].CategoryTotal\" class=\"form-control\"/>\n" +
        "            </div>\n" +
        "            <div class=\"form-group col-3\">\n" +
        "                <span asp-validation-for=\"Categories["+categoryCount+"].CategoryType\"></span>\n" +
        "                <label asp-for=\"Categories["+categoryCount+"].CategoryType\"></label>\n" +
        "                <select asp-for=\"Categories["+categoryCount+"].CategoryType\" class=\"form-control\"></select>\n" +
        "            </div>" +
        "            <div class=\"form-group col-3 mt-auto text-center\">\n" +
        "                <button type=\"button\" class=\"btn btn-danger deleteCategory mx-auto\">Delete Category</button>\n" +
        "            </div>");
    
    categoryCount++;
}

