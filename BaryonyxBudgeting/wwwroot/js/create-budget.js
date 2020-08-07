RegisterEvents();

let categoryCount = 1;

function RegisterEvents() {
    let pageBody = $('#page_body');
    pageBody.on("click", "#cancel_btn", CloseCreateBudget);
    pageBody.on("click", "#add_category", AddCategory);
    pageBody.on("click", ".remove-category", RemoveCategory);
    pageBody.on("submit", "#create_budget_form", function (e) {
        e.preventDefault();
        CreateBudget($(this));
    });
}

function CloseCreateBudget() {
    $('#create_budget_section')[0].remove();
}

function CreateBudget(data) {
    data.removeData("validator").removeData("unobtrusiveValidation");
    let url = $('#form_container').attr('data-url');
    $.validator.unobtrusive.parse(data);
    
    if (data.valid()) {
        FormatCategoryNames(data);
        $.ajax({
            url: url,
            type: 'POST',
            data: data.serialize(),
            success: function(response) {
                data.removeData("validator").removeData("unobtrusiveValidation");
                ReloadBudgets();
                CloseCreateBudget();
            },
            error: function(response) {
                console.log(response.message);
                $.validator.unobtrusive.parse(data);
            }
        });
    }
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
    category.removeClass('category-0');
    category.addClass('category-' + categoryCount);
    let lastChar = categoryCount.toString();

    let labels = {"span": ["data-valmsg-for"], "label": ["for"], "input": ["name", "id"], "select": ["name", "id"]};
    $.each(labels, function (key, list) {
        $.each(list, function (index, value){
           $.each(category.find(key), function (i, item) {
               ReplaceLastChar(item, value, lastChar)
           })
        });
    });
    category.append("<div class='form-group col-3 mt-auto text-center'><button id='category_btn_"+categoryCount+"' type='button' class='btn btn-danger remove-category mx-auto'>Remove</button></div>");

    $('#category_section').append(category);
    categoryCount++;
}

function ReplaceLastChar(item, attribute, lastChar) {
    item.setAttribute(attribute, item.getAttribute(attribute).replace(/.$/, lastChar));
}

function RemoveCategory() {
    let id = this.getAttribute("id").replace("_btn_", "-");
    $("." + id).remove();
}

