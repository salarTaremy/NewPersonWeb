


function LoadBasket() {
    console.log('Load Basket Start');
    $.ajax({
        url: '/Basket/BasketItems',
        type: 'post',
        success: function (data) {
            $(".content-ajax").empty();
            $(".content-ajax").append(data);
            // goToUp();
            console.log('Load Basket Success')
        },
        error: function (request, error) {
            toastr.error(request.stat, 'خطا در عملیات', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
        }
    });
}


function ChangeQty(ProductID, Qty) {
    $.ajax({
        url: '/Basket/ChangeQty',
        type: 'post',
        data: {
            ProductID: ProductID,
            Qty: Qty
        },
        success: function (data) {
            var result = JSON.stringify(data);
            var obj = jQuery.parseJSON(result);
            if (obj.status === 1) {
                toastr.success(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });

            } else {
                toastr.warning(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });
            }
            LoadBasket();
            // goToUp();
        },
        error: function (request, error) {
            //console.log(request);
            console.log(error);
            toastr.error(request.responseText, 'خطا در عملیات', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
        }
    });
}




$(document).ready(function () {
    LoadBasket();
});

$(document).ajaxSuccess(function () {

    // checkout quantity counter
    var quantityCounter = $(".quantity-counter"),
        CounterMin = 1,
        CounterMax = 99;
    if (quantityCounter.length > 0) {
        quantityCounter.TouchSpin({
            min: CounterMin,
            max: CounterMax
        }).on('touchspin.on.startdownspin', function () {
            var $this = $(this);
        }).on('touchspin.on.startupspin', function () {
            var $this = $(this);
        });
    }
   

    $("div.apply-coupon").click(function myfunction() {
        LoadBasket();
    });
        



    


    $("div.remove").click(function myfunction() {
        var $this = $(this)
        var ID_Product = $this.attr('id');
        console.log('remove');
        $.ajax({
            url: '/Basket/RemoveProductFromBasket',
            type: 'post',
            data: {
                ID_Product: ID_Product
            },
            success: function (data) {
                var result = JSON.stringify(data);
                var obj = jQuery.parseJSON(result);
                if (obj.status === 1) {
                    toastr.info(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });
                } else {
                    toastr.warning(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });
                }
                LoadBasket();
            },
            error: function (request, error) {
                toastr.error("انجام عملیات با خطا مواجه شد", 'خطا', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
            }
        });



    });


    $("div.wishlist").click(function myfunction() {
        console.log('wishlist click');


        var $this = $(this)
        var ID_Product = $this.attr('id');
        if ($this.hasClass('added')) {
            $.ajax({
                url: '/shop/RemoveProductFromFavorite',
                type: 'post',
                data: {
                    ID_Product: ID_Product
                },
                success: function (data) {
                    $this.find("i").toggleClass("fa-heart-o fa-heart")
                    $this.toggleClass("added");
                    var result = JSON.stringify(data);
                    var obj = jQuery.parseJSON(result);
                    if (obj.status === 1) {
                        toastr.info(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });
                    } else {
                        toastr.warning(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });
                    }
                    LoadBasket();
                },
                error: function (request, error) {
                    toastr.error("انجام عملیات با خطا مواجه شد", 'خطا', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
                }
            });
        } else {
            $.ajax({
                url: '/shop/AddProductToFavorite',
                type: 'post',
                data: {
                    ID_Product: ID_Product
                },
                success: function (data) {
                    $this.find("i").toggleClass("fa-heart-o fa-heart")
                    $this.toggleClass("added");
                    var result = JSON.stringify(data);
                    var obj = jQuery.parseJSON(result);
                    if (obj.status === 1) {
                        toastr.success(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });
                    } else {
                        toastr.warning(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });
                    }
                    LoadBasket();
                },
                error: function (jqXHR, request, error) {
                    toastr.error("انجام عملیات با خطا مواجه شد", 'خطا', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
                }
            });
        }

    })

    $('input.quantity-counter').change(function () {
        console.log('input.quantity-counter');

        var $this = $(this);
        var min = 1;
        var max = parseInt($this.attr('max'));
        var id = $this.attr('id');

        if (parseInt($this.val()) < min) {
            $this.val(min);
        }
        if (parseInt($this.val()) > max) {
            $this.val(max);
        }
        //if (parseInt($this.val()) == min && $(this).attr("is-min-value") == "false") {
        if (parseInt($this.val()) == min) {
            console.log('min');
            $(this).siblings().find('.bootstrap-touchspin-down').addClass("disabled-max-min");
            $(this).siblings().find('.bootstrap-touchspin-up').removeClass("disabled-max-min");
            $(this).attr("is-min-value", "true");
            $(this).attr("is-max-value", "false");
            ChangeQty(id, $this.val());

        }
        //if (parseInt($this.val()) == max && $(this).attr("is-max-value") == "false") {
        if (parseInt($this.val()) == max) {
            console.log('max');
            $(this).siblings().find('.bootstrap-touchspin-up').addClass("disabled-max-min");
            $(this).siblings().find('.bootstrap-touchspin-down').removeClass("disabled-max-min");
            $(this).attr("is-min-value", "false");
            $(this).attr("is-max-value", "true");
            ChangeQty(id, $this.val());
        }
        if (parseInt($this.val()) > min && parseInt($this.val()) < max) {
            console.log('between');
            $(this).siblings().find('.bootstrap-touchspin-up').removeClass("disabled-max-min");
            $(this).siblings().find('.bootstrap-touchspin-down').removeClass("disabled-max-min");
            $(this).attr("is-min-value", "false");
            $(this).attr("is-max-value", "false");
            ChangeQty(id, $this.val());
        }

    });

});
