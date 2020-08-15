$(function () {
    // PAGE LOAD //
    let page = $('#page_body');
    $('#toggle_sidebar').click(function () {
        $('#sidebar').toggle();
        $('#sidebar_content').toggleClass('active-nav');
    });
    $('#view_profile_btn').click(ShowProfile);
    page.on("click", "#create_budget_btn", LoadCreateBudgetComponent);
    page.on("click", ".delete-budget", DeleteBudget);
    page.on("click", "#cancel_btn", CloseCreateBudgetComponent);
    page.on("click", "#add_category", AddCategory);
    page.on("click", ".remove-category", RemoveCategory);
    page.on("submit", "#create_budget_form", function (e) {
        e.preventDefault();
        SendBudgetToController($(this));
    });
    page.on("click", ".post-btn", function () {
        selectedCategory = this.getAttribute('id').replace("post-", "");
        $('#post_modal').modal("show");
    });
    page.on("click", "#post_to_budget_btn", function (e) {
        e.preventDefault();
        PostToBudget($(this));
    });
    page.on("click", ".category-row", ShowCategoryDetails);
    $('#personal_budget_table2').DataTable();
});
// END PAGE LOAD //

let categoryCount = 1;
let selectedCategory;

// FUNCTIONS //

function LoadCreateBudgetComponent() {
    $.ajax({
        url: "API/GetCreateBudgetPartialView",
        type: "GET",
        async: true,
        success: function (response) {
            $('#create_budget_area').prepend(response);
            $('#create_budget_notification').hide();
        }
    });
}

function CloseCreateBudgetComponent() {
    $('#create_budget_section')[0].remove();
    $('#create_budget_notification').show();
}

function ReloadBudgets() {
    $.ajax({
        url: "API/RetrieveBudget",
        type: "GET",
        async: true,
        success: function (response) {
            $('#budget_section').replaceWith(response);
            $('#personal_budget_table2').DataTable();
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
            success: function (response) {
                data.removeData("validator").removeData("unobtrusiveValidation");
                ReloadBudgets();
                CloseCreateBudgetComponent();
            },
            error: function (response) {
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
        categoryElements.children('.title').children('input')[i].setAttribute("name", "Categories[" + i + "].Title");
        categoryElements.children('.total').children('input')[i].setAttribute("name", "Categories[" + i + "].Total");
        categoryElements.children('.type').children('select')[i].setAttribute("name", "Categories[" + i + "].Type");
    }
}

function AddCategory() {
    let category = $('.category-0').clone();
    category.removeClass('category-0').addClass('category-' + categoryCount);

    let labels = {"span": ["data-valmsg-for"], "label": ["for"], "input": ["name", "id"], "select": ["name", "id"]};
    $.each(labels, function (key, list) {
        $.each(list, function (index, value) {
            $.each(category.find(key), function (i, item) {
                if (item.tagName !== "SELECT") {
                    item.value = "";
                }
                item.setAttribute(value, item.getAttribute(value).replace(/.$/, categoryCount.toString()));
            })
        });
    });
    category.append("<div class='form-group col-3 mt-auto text-center'><button id='category_btn_" + categoryCount + "' type='button' class='btn btn-danger remove-category mx-auto'>Remove</button></div>");

    $('#category_section').append(category);
    categoryCount++;
}

function RemoveCategory() {
    let id = this.getAttribute("id").replace("_btn_", "-");
    $("." + id).remove();
}

function PostToBudget(data) {
    data.removeData("validator").removeData("unobtrusiveValidation");
    let url = $('#post_form_container').attr('data-url');
    $.validator.unobtrusive.parse(data);

    if (data.valid()) {
        $.ajax({
            url: url,
            type: "POST",
            async: true,
            data: "CategoryId=" + selectedCategory + "&" + $("#create_post_form").serialize(),
            success: function (response) {
                console.log(response);
                $("#post_modal").modal("hide");
                toastr.success("Post was successful!");
                ReloadBudgets();
            }
        });
    }
}

function ShowCategoryDetails() {
    console.log($(this).attr("id"))
}

function ShowProfile() {
    $.ajax({
       url: "API/GetProfileComponent",
       async: true,
       type: "GET",
       success: function(response) {
           $('#page_body').replaceWith(response);
       }
    });
}