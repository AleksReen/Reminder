$(document).ready(function () {
    $(function () {
        $('#datetimepicker').datetimepicker({
            useCurrent: false,
            format: "DD.MM.YYYY"
        });
    })

    $(function () {
        var actionCount = 2
        $("#newAction").click(function () {
            var clon = $("#action_group").clone();
            clon.children(".control-label").text('Action ' + actionCount);
            clon.children("div.col-md-10").children("input").val("");
            $("#action_conteiner").append(clon);
            actionCount++;
        })
    })

    $(function () {
        $('#datetimepicker2').datetimepicker({
            useCurrent: false,
            format: "DD.MM.YYYY hh:mm:ss A "
        });
    });
});
