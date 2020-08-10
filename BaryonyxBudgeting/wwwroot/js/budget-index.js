$(function() {
    // PAGE LOAD //
    let page = $('#page_body');
    page.on("click", "#create_budget_btn", LoadCreateBudgetComponent);
    page.on("click", ".delete-budget", DeleteBudget);
    page.on("click", "#cancel_btn", CloseCreateBudgetComponent);
    page.on("click", "#add_category", AddCategory);
    page.on("click", ".remove-category", RemoveCategory);
    page.on("submit", "#create_budget_form", function (e) {
        e.preventDefault();
        SendBudgetToController($(this));
    });
});
// END PAGE LOAD //

let categoryCount = 1;

// FUNCTIONS //

function LoadCreateBudgetComponent() {
    $.ajax({
        url: "CreateBudget",
        type: "GET",
        async: true,
        success: function (response) {
            $('#page_body').prepend(response);
        }
    });
}

function CloseCreateBudgetComponent() {
    $('#create_budget_section')[0].remove();
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

function SendBudgetToController(data) {
    data.removeData("validator").removeData("unobtrusiveValidation");
    let url = $('#form_container').attr('data-url');
    $.validator.unobtrusive.parse(data);

    if (data.valid()) {
        FormatCategoryNames(data);
        $.ajax({
            url: url,
            type: 'POST',
            async: true,
            data: data.serialize(),
            success: function(response) {
                data.removeData("validator").removeData("unobtrusiveValidation");
                ReloadBudgets();
                CloseCreateBudgetComponent();
            },
            error: function(response) {
                console.log(response.message);
                $.validator.unobtrusive.parse(data);
            }
        });
    }
}

function DeleteBudget() {
    $.ajax({
        url: "DeleteBudget",
        type: "POST",
        async: true,
        data: "id=" + this.getAttribute("id").replace("delete_", ""),
        success: function (response) {
            console.log(response);
            ReloadBudgets();
        },
        error: function (response) {
            console.log(response)
        }
    })
}

function FormatCategoryNames(data) {
    let categoryElements = data.children('#category_section').children('.category');
    for (let i = 0; categoryElements.length > i; i++) {
        categoryElements.children('.title').children('input')[i].setAttribute("name", "Categories["+i+"].Title");
        categoryElements.children('.total').children('input')[i].setAttribute("name", "Categories["+i+"].Total");
        categoryElements.children('.type').children('select')[i].setAttribute("name", "Categories["+i+"].Type");
    }
}

function AddCategory() {
    let category = $('.category-0').clone();
    category.removeClass('category-0').addClass('category-' + categoryCount);

    let labels = {"span": ["data-valmsg-for"], "label": ["for"], "input": ["name", "id"], "select": ["name", "id"]};
    $.each(labels, function (key, list) {
        $.each(list, function (index, value){
            $.each(category.find(key), function (i, item) {
                item.setAttribute(value, item.getAttribute(value).replace(/.$/, categoryCount.toString()));
            })
        });
    });
    category.append("<div class='form-group col-3 mt-auto text-center'><button id='category_btn_"+categoryCount+"' type='button' class='btn btn-danger remove-category mx-auto'>Remove</button></div>");

    $('#category_section').append(category);
    categoryCount++;
}

function RemoveCategory() {
    let id = this.getAttribute("id").replace("_btn_", "-");
    $("." + id).remove();
}