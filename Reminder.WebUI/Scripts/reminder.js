$(document).ready(function () {
    $(function () {
        $('#datetimepicker').datetimepicker({
            useCurrent: false,
            format: "DD.MM.YYYY"
        });
    })

    $(function () {
        $('#datetimepicker2').datetimepicker({
            useCurrent: false,
            format: "DD.MM.YYYY hh:mm:ss A"
        });
    });

    $(function () {
        var actionCount = $(".block").length;
        $("#newAction").click(function () {          
            var clon = $("#action_group").clone();
            clon.children(".control-label").text('Action ' + ++actionCount);
            clon.children("div.col-md-10").children("input").val("").attr("value","").attr("id","Action"+actionCount);
            $("#action_conteiner").append(clon);
        })
    })

    $('#message').delay(2000).hide('slow');
});

(function () {
    jQuery.validator.methods.date = function (value, element) {
        var formats = ["DD.MM.YYYY", "DD.MM.YYYY hh:mm:ss A"];
        return moment(value, formats, true).isValid();
    };
})(jQuery, moment);
