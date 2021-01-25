// you must add this tag in html page => <div class="modal"><!-- For Ajax Loading --></div>
// or Add :  class="modal"   to any div for load animation


$body = $("body");
$(document).on({
    ajaxStart: function () {
        $body.addClass("loading");
        console.log("ajax Start...");
    },
    ajaxStop: function () {
        $body.removeClass("loading");
        console.log("ajax Stop !");
    }
});

$(document).ajaxSuccess(function () {
    console.log('ajax Success');
});


$(document).ajaxComplete(function () {
    console.log('ajax Complete');
});

$(document).ajaxError(function () {
    console.log('ajax Error');
});

$(document).ajaxSend(function () {
    console.log('ajax Send');
});

//$(document).ajaxStart(function () {
//    console.log('ajax Start');
//});

//$(document).ajaxStop(function () {
//    console.log('ajaxStop');
//});