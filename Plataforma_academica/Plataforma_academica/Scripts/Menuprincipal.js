jQuery(function ($) {

    $(".logo").click(function() {
       
        if ($(".logo").parent().hasClass("active")) {
            $(".logo").next(".lista-menu").slideDown(200);
            $(".logo").parent().removeClass("active");
        } else {
          //  $(".logo").removeClass("active");
            $(".lista-menu").slideUp(300);            
            $(".logo").parent().addClass("active");
        }
    });
    /*
    $("#close-sidebar").click(function() {
        $(".page-wrapper").removeClass("toggled");
    });
    $("#show-sidebar").click(function() {
        $(".page-wrapper").addClass("toggled");
    });*/
});