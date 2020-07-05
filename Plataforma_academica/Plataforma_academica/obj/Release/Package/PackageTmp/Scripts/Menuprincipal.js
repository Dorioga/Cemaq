jQuery(function ($) {

    $(".logo").click(function() {
        $(".lista-menu").slideUp(300);
        if (
          $(this)
            .parent()
            .hasClass("active")
        ) {
            $(".logo").removeClass("active");
            $(this)
              .parent()
              .removeClass("active");
        } else {
            $(".logo").removeClass("active");
            $(this)
              .next(".lista-menu")
              .slideDown(200);
            $(this)
              .parent()
              .addClass("active");
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