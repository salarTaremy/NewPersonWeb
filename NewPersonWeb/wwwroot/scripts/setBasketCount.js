

$(document).ready(function () {
    SetBasketCount();
});

function SetBasketCount() {
    console.log('SetBasketCount');
    $.ajax({
        url: '/shop/GetBasketItemCount',
        type: 'get',
        data: {

        },
        success: function (data) {

            $("#cnt1").text(data);
            $("#cnt2").text(data);
        },
        error: function (request, error) {
            toastr.error("انجام عملیات با خطا مواجه شد", 'خطا', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
        }
    });
}



