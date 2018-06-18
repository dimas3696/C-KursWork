var dishName = $(".dish--name");
var indredients = $(".dish--ingredients");
var deleteIngredient = $(".ingredient--delete"); 
var addIngredient = $(".ingredient--add"); 
var ingredientsList = $(".dish--ingredients");
var ingredientsInput = $(".ingredient--input");
var editDishName = $(".dish--name-edit");
var dishTime = $(".dish--time");
var dishPrice = $(".dish--price");
var dishNameInput = $(".dish--name-input");
var dishId;
var dishSave = $(".dish--save");
var inputVal = ""; 

dishName.on('click', function() {
	event.preventDefault();
	$(this).siblings(".dish--details").slideToggle(700);
});


$(document).on('click', ".ingredient--delete", function() {
	event.preventDefault();
	$(this).fadeOut();
	$(this).siblings(".ingredient--name").fadeOut();
});

editDishName.on('click', function() {
    $(this).siblings(".dish--name").siblings(".dish--span").replaceWith(function (index, oldHTML) {
        return $("<input>").val(oldHTML).addClass("dish--name-input").attr("data-name", "true");
    });
});

ingredientsInput.on('input', function () {
    dishId = $(this).siblings('.dish--id').val();
    var inputVal = $(this).val();

    $(this).siblings('.ingredient--add').attr("onclick", "location.href ='/Home/AddIngredient?ingredientName=" + inputVal + "&idWhere=" + dishId + "'");
})

dishTime.on('input', function () {
    var dishTime = $(this).val();
    var dishPrice = $(this).closest(".dish--form__time").siblings(".dish--form__price").children(".dish--price").val();
    var dishName;
    var dishNameInput = $(this).closest(".dish--form__time").closest(".dish--details").siblings(".dish--name-input");
    var dishId = $(this).closest(".dish--form__time").siblings(".dish--id").val();

    if (dishNameInput.length > 0) {
        dishName = $(dishNameInput).val();
    }
    else {
        dishName = $(this).closest(".dish--form__time").closest(".dish--details").siblings(".dish--span")[0].innerHTML;
    }

    $(this).closest(".dish--form__time").siblings(".dish--save").attr("onclick", "location.href ='/Home/Edit?dishId=" + dishId + "&newName=" + dishName + "&newPrepareTime=" + dishTime + "&newPrice=" + dishPrice + "'");
    console.log(dishName);
    console.log(dishTime);
    console.log(dishPrice);
    console.log(dishId);
});

dishPrice.on('input', function () {
    var dishTime = $(this).closest(".dish--form__price").siblings(".dish--form__time").children(".dish--time").val();
    var dishPrice = $(this).val();
    var dishName;
    var dishNameInput = $(this).closest(".dish--form__price").closest(".dish--details").siblings(".dish--name-input");
    var dishId = $(this).closest(".dish--form__price").siblings(".dish--id").val();

    if (dishNameInput.length > 0) {
        dishName = $(dishNameInput).val();
    }
    else {
        dishName = $(this).closest(".dish--form__price").closest(".dish--details").siblings(".dish--span")[0].innerHTML;
    }

    $(this).closest(".dish--form__price").siblings(".dish--save").attr("onclick", "location.href ='/Home/Edit?dishId=" + dishId + "&newName=" + dishName + "&newPrepareTime=" + dishTime + "&newPrice=" + dishPrice + "'");
    console.log(dishName);
    console.log(dishTime);
    console.log(dishPrice);
    console.log(dishId);
});

$(document).on('input', '[data-name="true"]', function () {

    var dishTime = $(this).siblings(".dish--details").children(".dish--form__time").children(".dish--time").val();
    var dishPrice = $(this).siblings(".dish--details").children(".dish--form__price").children(".dish--price").val();
    var dishName = $(this).val();
    var dishId = $(this).siblings(".dish--details").children(".dish--id").val();

    $(this).siblings(".dish--details").children(".dish--save").attr("onclick", "location.href ='/Home/Edit?dishId=" + dishId + "&newName=" + dishName + "&newPrepareTime=" + dishTime + "&newPrice=" + dishPrice + "'");

    console.log(dishName);
    console.log(dishTime);
    console.log(dishPrice);
    console.log(dishId);
});

dishSave.on('click', function () {
    var dishTime = $(this).siblings(".dish--form__time").children(".dish--time").val();
    var dishPrice = $(this).siblings(".dish--form__price").children(".dish--price").val();
    var dishName;
    var dishNameInput = $(this).closest(".dish--details").siblings(".dish--name").siblings(".dish--name-input");
    var dishId = $(this).siblings(".dish--id").val();

    if (dishNameInput.length > 0) {
        dishName = $(dishNameInput).val();
    }
    else {
        dishName = $(this).closest(".dish--details").siblings(".dish--name").siblings(".dish--span")[0].innerHTML
    }

    

});

var addDish_addIngredient = $(".add-dish--ingredient-add");
var addDish_ingredList = $(".add-dish--ingredients-list");
var addDish_deleteIngred = $(".add-dish--ingredient-delete");

addDish_addIngredient.on('click', function (event) {
    event.preventDefault();
    $(this).before('<li class="add-dish--item"><div class="add-dish--wrapper"><input type="text" class="add-dish--ingredient add-dish--input input"><button class="add-dish--ingredient-delete ingredient--delete">Удалить ингридиент</button></div> </li>');
});

$(document).on('click', '.add-dish--ingredient-delete', function (event) {
    event.preventDefault();
    $(this).fadeOut();
    $(this).siblings(".add-dish--ingredient").fadeOut();
});