
$(document).ready(function () {
  "use strict";
  // RTL Support
  var direction = 'ltr';
  if ($('html').data('textdirection') == 'rtl') {
    direction = 'rtl';
  }

 

  var sidebarShop = $(".sidebar-shop"),
    shopOverlay = $(".shop-content-overlay"),
    sidebarToggler = $(".shop-sidebar-toggler"),
    priceFilter = $(".price-options"),
    gridViewBtn = $(".grid-view-btn"),
    listViewBtn = $(".list-view-btn"),
    ecommerceProducts = $("#ecommerce-products"),
    cart = $(".cart"),
    wishlist = $(".wishlist");

  // show sidebar
  sidebarToggler.on("click", function () {
    sidebarShop.toggleClass("show");
    shopOverlay.toggleClass("show");
  });

  // remove sidebar
  $(".shop-content-overlay, .sidebar-close-icon").on("click", function () {
    sidebarShop.removeClass("show");
    shopOverlay.removeClass("show");
  })

  //price slider
  var slider = document.getElementById("price-slider");
  if (slider) {
    noUiSlider.create(slider, {
      start: [51, 5000],
      direction: direction,
      connect: true,
      tooltips: [true, true],
      format: wNumb({
        decimals: 0,
      }),
      range: {
        "min": 51,
        "max": 5000
      }
    });
  }
  // for select in ecommerce header
  if (priceFilter.length > 0) {
    priceFilter.select2({
      minimumResultsForSearch: -1,
      dropdownAutoWidth: true,
      width: '100%'
    });
  }

  /***** CHANGE VIEW *****/
  // Grid View
  gridViewBtn.on("click", function () {
    ecommerceProducts.removeClass("list-view").addClass("grid-view");
    listViewBtn.removeClass("active");
    gridViewBtn.addClass("active");
  });

  // List View
  listViewBtn.on("click", function () {
    ecommerceProducts.removeClass("grid-view").addClass("list-view");
    gridViewBtn.removeClass("active");
    listViewBtn.addClass("active");
  });

   ////For View in cart
   // cart.on("click", function () {
   //     alert('1');
   // var $this = $(this),
   // addToCart = $this.find(".add-to-cart"),
   // viewInCart = $this.find(".view-in-cart");
   // if(addToCart.is(':visible')) {
   //   addToCart.addClass("d-none");
   //   viewInCart.addClass("d-inline-block");
   // }
   // else{
   //   var href= viewInCart.attr('href');
   //   window.location.href = href;
   // }
   // });



  $(".view-in-cart").on('click', function(e){
    e.preventDefault();
  });

  // For Wishlist Icon
  //wishlist.on("click", function () {
  //  var $this = $(this)
  //  $this.find("i").toggleClass("fa-heart-o fa-heart")
  //  $this.toggleClass("added");
  //})

  // Checkout Wizard
  var checkoutWizard = $(".checkout-tab-steps"),
    checkoutValidation = checkoutWizard.show();
  if (checkoutWizard.length > 0) {
    $(checkoutWizard).steps({
      headerTag: "h6",
      bodyTag: "fieldset",
      transitionEffect: "fade",
      titleTemplate: '<span class="step">#index#</span> #title#',
      enablePagination: false,
      onStepChanging: function (event, currentIndex, newIndex) {
        // allows to go back to previous step if form is
        if (currentIndex > newIndex) {
          return true;
        }
        // Needed in some cases if the user went back (clean up)
        if (currentIndex < newIndex) {
          // To remove error styles
          checkoutValidation.find(".body:eq(" + newIndex + ") label.error").remove();
          checkoutValidation.find(".body:eq(" + newIndex + ") .error").removeClass("error");
        }
        // check for valid details and show notification accordingly
        if (currentIndex === 1 && Number($(".form-control.required").val().length) < 1) {
          toastr.warning('Error', 'Please Enter Valid Details', { "positionClass": "toast-bottom-right" });
        }
        checkoutValidation.validate().settings.ignore = ":disabled,:hidden";
        return checkoutValidation.valid();
      },
    });
    // to move to next step on place order and save address click
    $(".place-order, .delivery-address").on("click", function () {
      $(".checkout-tab-steps").steps("next", {});
    });
    // check if user has entered valid cvv
    $(".btn-cvv").on("click", function () {
      if ($(".input-cvv").val().length == 3) {
        toastr.success('Success', 'Payment received Successfully', { "positionClass": "toast-bottom-right" });
      }
      else {
        toastr.warning('Error', 'Please Enter Valid Details', { "positionClass": "toast-bottom-right" });
      }
    })
  }



})




//============================================================================================================================
//============================================================================================================================
//============================================================================================================================
//============================================================================================================================
//============================================================================================================================
//============================================================================================================================
//============================================================================================================================





$(document).ajaxSuccess(function () {
    "use strict";
    // RTL Support
    var direction = 'ltr';
    if ($('html').data('textdirection') == 'rtl') {
        direction = 'rtl';
    }

    var sidebarShop = $(".sidebar-shop"),
        shopOverlay = $(".shop-content-overlay"),
        sidebarToggler = $(".shop-sidebar-toggler"),
        priceFilter = $(".price-options"),
        gridViewBtn = $(".grid-view-btn"),
        listViewBtn = $(".list-view-btn"),
        ecommerceProducts = $("#ecommerce-products"),
        cart = $(".cart"),
        wishlist = $(".wishlist");


    // show sidebar
    sidebarToggler.on("click", function () {
        sidebarShop.toggleClass("show");
        shopOverlay.toggleClass("show");
    });

    // remove sidebar
    $(".shop-content-overlay, .sidebar-close-icon").on("click", function () {
        sidebarShop.removeClass("show");
        shopOverlay.removeClass("show");
    })

    //price slider
    var slider = document.getElementById("price-slider");
    if (slider) {
        noUiSlider.create(slider, {
            start: [51, 5000],
            direction: direction,
            connect: true,
            tooltips: [true, true],
            format: wNumb({
                decimals: 0,
            }),
            range: {
                "min": 51,
                "max": 5000
            }
        });
    }
    // for select in ecommerce header
    if (priceFilter.length > 0) {
        priceFilter.select2({
            minimumResultsForSearch: -1,
            dropdownAutoWidth: true,
            width: '100%'
        });
    }

    /***** CHANGE VIEW *****/
    // Grid View
    gridViewBtn.on("click", function () {
        ecommerceProducts.removeClass("list-view").addClass("grid-view");
        listViewBtn.removeClass("active");
        gridViewBtn.addClass("active");
    });

    // List View
    listViewBtn.on("click", function () {
        ecommerceProducts.removeClass("grid-view").addClass("list-view");
        gridViewBtn.removeClass("active");
        listViewBtn.addClass("active");
    });



    $(".view-in-cart").on('click', function (e) {
        e.preventDefault();
    });


    // For Wishlist Icon
    //wishlist.on("click", function () {
    //    var $this = $(this)
    //    $this.find("i").toggleClass("fa-heart-o fa-heart")
    //    $this.toggleClass("added");
    //})

    // Checkout Wizard
    var checkoutWizard = $(".checkout-tab-steps"),
        checkoutValidation = checkoutWizard.show();
    if (checkoutWizard.length > 0) {
        $(checkoutWizard).steps({
            headerTag: "h6",
            bodyTag: "fieldset",
            transitionEffect: "fade",
            titleTemplate: '<span class="step">#index#</span> #title#',
            enablePagination: false,
            onStepChanging: function (event, currentIndex, newIndex) {
                // allows to go back to previous step if form is
                if (currentIndex > newIndex) {
                    return true;
                }
                // Needed in some cases if the user went back (clean up)
                if (currentIndex < newIndex) {
                    // To remove error styles
                    checkoutValidation.find(".body:eq(" + newIndex + ") label.error").remove();
                    checkoutValidation.find(".body:eq(" + newIndex + ") .error").removeClass("error");
                }
                // check for valid details and show notification accordingly
                if (currentIndex === 1 && Number($(".form-control.required").val().length) < 1) {
                    toastr.warning('Error', 'Please Enter Valid Details', { "positionClass": "toast-bottom-right" });
                }
                checkoutValidation.validate().settings.ignore = ":disabled,:hidden";
                return checkoutValidation.valid();
            },
        });
        // to move to next step on place order and save address click
        $(".place-order, .delivery-address").on("click", function () {
            $(".checkout-tab-steps").steps("next", {});
        });
        // check if user has entered valid cvv
        $(".btn-cvv").on("click", function () {
            if ($(".input-cvv").val().length == 3) {
                toastr.success('Success', 'Payment received Successfully', { "positionClass": "toast-bottom-right" });
            }
            else {
                toastr.warning('Error', 'Please Enter Valid Details', { "positionClass": "toast-bottom-right" });
            }
        })
    }

   
              
    function LoadBasket() {
        console.log('LoadBasketAfterAjaxLoad');
        $.ajax({
            url: '/Basket/BasketItems',
            type: 'post',
            success: function (data) {
                $(".content-ajax").empty();
                $(".content-ajax").append(data);
                // goToUp();
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
    $('input.quantity-counter').change(function () {

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

        if (parseInt($this.val()) == min && $(this).attr("is-min-value") == "false") {
            $(this).siblings().find('.bootstrap-touchspin-down').addClass("disabled-max-min");
            $(this).siblings().find('.bootstrap-touchspin-up').removeClass("disabled-max-min");
            $(this).attr("is-min-value", "true");
            $(this).attr("is-max-value", "false");
            ChangeQty(id, $this.val());

        }
        if (parseInt($this.val()) == max && $(this).attr("is-max-value") == "false") {
            $(this).siblings().find('.bootstrap-touchspin-up').addClass("disabled-max-min");
            $(this).siblings().find('.bootstrap-touchspin-down').removeClass("disabled-max-min");
            $(this).attr("is-min-value", "false");
            $(this).attr("is-max-value", "true");
            ChangeQty(id, $this.val());
        }
        if (parseInt($this.val()) > min && parseInt($this.val()) < max) {
            $(this).siblings().find('.bootstrap-touchspin-up').removeClass("disabled-max-min");
            $(this).siblings().find('.bootstrap-touchspin-down').removeClass("disabled-max-min");
            $(this).attr("is-min-value", "false");
            $(this).attr("is-max-value", "false");
            ChangeQty(id, $this.val());
        }

    });

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


    // remove items from wishlist page
    $(".remove-wishlist , .move-cart").on("click", function () {
        $(this).closest(".ecommerce-card").remove();
    })
})
// on window resize hide sidebar
$(window).on("resize", function () {
  if ($(window).width() <= 991) {
    $(".sidebar-shop").removeClass("show");
    $(".shop-content-overlay").removeClass("show");
  }
  else {
    $(".sidebar-shop").addClass("show");
  }
});
