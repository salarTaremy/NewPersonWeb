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