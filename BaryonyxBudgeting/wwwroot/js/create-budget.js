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

function AddCategory() {
    $('#category_section').append("<div class=\"row m-auto category-"+categoryCount+"\"><div class=\"form-group col-3\"><span class=\"field-validation-valid text-danger\" data-valmsg-for=\"Categories["+categoryCount+"].CategoryTitle\" data-valmsg-replace=\"true\"></span>\
                                        <label for=\"Categories_"+categoryCount+"__CategoryTitle\">Category Title</label>\
                                        <input class=\"form-control\" data-val=\"true\" data-val-required=\"Category needs a title\" id=\"Categories_"+categoryCount+"__CategoryTitle\" name=\"Categories["+categoryCount+"].CategoryTitle\" type=\"text\" value=\"\">\
                                </div>\
                                <div class=\"form-group col-3\">\
                                    <span class=\"field-validation-valid text-danger\" data-valmsg-for=\"Categories["+categoryCount+"].CategoryTotal\" data-valmsg-replace=\"true\"></span>\
                                    <label for=\"Categories_"+categoryCount+"__CategoryTotal\">Category Total</label>\
                                    <input class=\"form-control\" data-val=\"true\" data-val-number=\"The field Category Total must be a number.\" data-val-required=\"Category needs a total\" id=\"Categories_"+categoryCount+"__CategoryTotal\" name=\"Categories["+categoryCount+"].CategoryTotal\" type=\"text\" value=\"\">\
                                </div>\
                                <div class=\"form-group col-3\">\
                                    <span class=\"field-validation-valid text-danger\" data-valmsg-for=\"Categories["+categoryCount+"].CategoryType\" data-valmsg-replace=\"true\"></span>\
                                    <label for=\"Categories_"+categoryCount+"__CategoryType\">Category Type</label>\
                                    <select class=\"form-control\" data-val=\"true\" data-val-required=\"Category needs a type\" id=\"Categories_"+categoryCount+"__CategoryType\" name=\"Categories["+categoryCount+"].CategoryType\"><option value=\"0\">Amount</option>\
                                        <option value=\"1\">Percent</option>\
                                    </select>\
                                </div>\
                                <div class=\"form-group col-3 mt-auto text-center\">\
                                    <button id='category_btn_"+categoryCount+"' type=\"button\" class=\"btn btn-danger remove-category mx-auto \">Remove</button>\
                                </div></div>");
    
    categoryCount++;
}

function RemoveCategory() {
    let id = this.getAttribute("id").replace("_btn_", "-");
    $("." + id).remove();
}

