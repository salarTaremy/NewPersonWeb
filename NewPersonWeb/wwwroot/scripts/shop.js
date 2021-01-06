var btnTop = document.getElementById("btnTop");
window.onscroll = function () { scrollFunction() };
function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        btnTop.style.display = "block";
    } else {
        btnTop.style.display = "none";
    }
}
btnTop.addEventListener('click', function (e) {
    goToUp(e);
});

function goToUp(e) {
    //e.preventDefault();
    var distance = 0 - window.pageYOffset;
    var increments = distance / (500 / 16);
    function animateScroll() {
        window.scrollBy(0, increments);
        if (window.pageYOffset <= document.body.offsetTop) {
            clearInterval(runAnimation);
        }
    };
    var runAnimation = setInterval(animateScroll, 16);
}
function postIt(pageIndex) {
    //var json = @Html.Raw(Json.Serialize(@Model));
    //console.log(JSON.stringify(json));
    var sortOrder = $("#ecommerce-price-options").val();
    var grp = $('input[name=ProductGrp]:checked').val();
    var selectedBr = [];
    var keyword = $('#TxtOldKeyword').val();
    console.log('keyword is ' + keyword)
    $('#TxtKeyword').val(keyword);

    if (parseInt(pageIndex) == 0) {
        return;
    }

    $('input[name=ProductBr]:checked').each(function () {
        selectedBr.push($(this).attr('id'));
    });

    $.ajax({
        url: '/shop/ProductList',
        type: 'post',
        data: {
            GrpID: grp,
            BrandID: selectedBr,
            Keyword: keyword,
            SortOrder: sortOrder,
            CurentPgae: pageIndex
        },
        success: function (data) {
            $("#salar").empty();
            $("#salar").append(data);
            setBasketListener();
            // List View
            if ($(".list-view-btn").hasClass('active') === true) {
                $("#ecommerce-products").removeClass("grid-view").addClass("list-view");
            }
            goToUp();
        },
        error: function (request, error) {
            //alert("Request: " + JSON.stringify(request));
            toastr.error(ErrorMessageForLogin, 'خطا در عملیات', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
        }
    });
};
$body = $("body");
$(document).on({
    ajaxStart: function () {
        $("#TxtKeyword").attr("disabled", "disabled");
    },
    ajaxStop: function () {
        $("#TxtKeyword").removeAttr("disabled");
    }
});

$(document).ajaxSuccess(function () {
    setPagingEvents();
});

$(document).ready(function () {
    setPagingEvents();
    setBasketListener();
    $("#BtnFilter").click(function () {
        postIt(getCurentPage());
    });
    $('#ecommerce-price-options').on('change', function () {
        postIt(1);
    });
    $('input[name=ProductGrp]').on('change', function () {
        var selectedId = $('input[name=ProductGrp]:checked').val();
        postIt(1);
    });
    //$("ul.list-unstyled > li > span.vs-checkbox-con > span.BrName").css("background-color", "yellow");
    $("#txtSearchBrand").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        var items = $("ul.list-unstyled > li > span.vs-checkbox-con > span.BrName");
        items.each(function (i) {
            if ($(this).text().toLowerCase().indexOf(value) > -1) {
                $(this).parent().parent().removeClass('d-none');
                $(this).parent().parent().addClass('d-flex');
            } else {
                $(this).parent().parent().removeClass('d-flex');
                $(this).parent().parent().addClass('d-none');
            }
        });
    });
    $("#BtnCheckAll").click(function () {
        //$('input[name=ProductBr]').attr("checked", "checked");
        $('input[name=ProductBr]').prop("checked", true);
    });
    $("#BtnUnCheckAll").click(function () {
        //$('input[name=ProductBr]').removeAttr("checked");
        $('input[name=ProductBr]').prop("checked", false);
    });
});

function getCurentPage() {
    var CurentPage = $('ul#Paging').find('li.active').text();
    return parseInt(CurentPage);
};

function setBasketListener() {
    wishlist = $(".wishlist");
    cart = $(".cart");

    // For View in cart
    cart.on("click", function () {
        var $this = $(this),
            addToCart = $this.find(".add-to-cart"),
            viewInCart = $this.find(".view-in-cart");
        var ID_Product = $this.attr('id');
        if (addToCart.is(':visible')) {
            $.ajax({
                url: '/shop/AddProductToBasket',
                type: 'post',
                data: {
                    ID_Product: ID_Product,
                    Qty: 1
                },
                success: function (data) {
                    addToCart.addClass("d-none");
                    viewInCart.addClass("d-inline-block");
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
            var href = viewInCart.attr('href');
            window.location.href = href;
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
                error: function (jqXHR, request, error) {
                    toastr.error("انجام عملیات با خطا مواجه شد", 'خطا', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
                }
            });
        }
    })
}

function setPagingEvents() {
    console.log('setEvents');
    $('.page-item').click(function () {
        //var pageIndex = $(this).text();
        if ($(this).hasClass("disabled")) {
            return;
        }
        if ($(this).hasClass("prev-item")) {
            postIt(getCurentPage() - 1);
            return;
        }
        if ($(this).hasClass("next-item")) {
            postIt(getCurentPage() + 1);
            return;
        }
        else {
            $('ul#Paging').find('li.active').removeClass("active");
            $(this).addClass("active");
            postIt(getCurentPage());
        }
    });
};
function TxtSearchKeyPress(e) {
    if (e.keyCode === 13) {
        console.log('keydown');
        var NewKeyword = $('#TxtKeyword').val()
        var NewOldword = $('#TxtOldKeyword').val()
        if (NewKeyword === NewOldword) {
            return false;
        }
        $('#TxtOldKeyword').val(NewKeyword);
        postIt(1);
        return false;
    }
}