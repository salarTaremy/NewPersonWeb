// you must add this tag in html page
// or Add :  class="modal"   to any div for load animation
//  <div class="modal"><!-- For Ajax Loading --></div>

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