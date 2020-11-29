$(document).ready(function () {
    var ErrorMessageForLogin = JSON.parse('@Html.Raw(Json.Serialize(Model.ErrorMessageForLogin))');
    if (ErrorMessageForLogin != null) {
        toastr.error(ErrorMessageForLogin, 'خطا در ورود', { "showMethod": "fadeIn", "hideMethod": "fadeOut", timeOut: 3000 });
    }
});