wishlist = $(".wishlist");
cart = $(".cart");

// For View in cart
cart.on("click", function () {
    var $this = $(this);
    var AddToBasket = $(".add-to-basket"); //$this.find("add-to-basket");
    var ViewInBasket = $(".view-in-basket"); // $this.find("view-in-basket");
    var ID_Product = $this.attr('id');

    if ($this.hasClass('add-to-basket')) {
        console.log('addToCart is visible');
        $.ajax({
            url: '/shop/AddProductToBasket',
            type: 'post',
            data: {
                ID_Product: ID_Product,
                Qty: 1
            },
            success: function (data) {
                AddToBasket.addClass("d-none");
                ViewInBasket.removeClass("d-none");
                var result = JSON.stringify(data);
                var obj = jQuery.parseJSON(result);
                if (obj.status === 1) {
                    toastr.success(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });
                } else {
                    toastr.warning(obj.message, obj.title, { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000, positionClass: 'toast-top-right' });
                }
            },
            error: function (request, error) {
                toastr.error("انجام عملیات با خطا مواجه شد", 'خطا', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
            }
        });

    }
    else {
        console.log('addToCart is noooooot  visible');
        var href = viewInCart.attr('href');
        //window.location.href = href;
    }
});

// For Wishlist Icon
wishlist.on("click", function () {
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
            },
            error: function (request, error) {
                toastr.error("انجام عملیات با خطا مواجه شد", 'خطا', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
            }
        });
    }
})