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
            clon.find(".control-label").text('Action ' + ++actionCount);
            clon.find("input").val("").attr("value", "").attr("id", "Action" + actionCount);
            $("#action_conteiner").append(clon);
        })
    })

    $('#message').delay(2000).hide('slow');

    (function () {
        jQuery.validator.methods.date = function (value, element) {
            var formats = ["DD.MM.YYYY", "DD.MM.YYYY hh:mm:ss A"];
            return moment(value, formats, true).isValid();
        };
    })(jQuery, moment);

    reminderStyle();
});

function ConvertToDateTime(dateTime) {

    var dateArray = dateTime.split(" ");

    var remDate = dateArray[0].split(".");
    var remTime = dateArray[1];

    if (remTime) {
        remTime = remTime.split(":");
        return new Date(remDate[2], remDate[1] - 1, remDate[0], remTime[0], remTime[1], remTime[2])
    }
    return new Date(remDate[2], remDate[1] - 1, remDate[0]);
}

function reminderStyle() {
    var reminders = $(".reminder-item-conteiner");

    if (reminders.length > 0) {

        var now = new Date();

        for (var i = 0; i < reminders.length; i++) {

            var reminderDate = $(reminders[i]).find("#reminderDate").text().trim();
            var reminderTime = $(reminders[i]).find("#reminderTime").text().trim();

            var rDate = ConvertToDateTime(reminderDate);
            var rDateTime = ConvertToDateTime(reminderTime);

            if (rDate >= now) {

                if (rDateTime >= now) {
                    $(reminders[i]).addClass("reminder-future")
                } else {
                    $(reminders[i]).addClass("reminder-current")
                }

            } else {
                $(reminders[i]).addClass("reminder-fail")
            }
        }
    }
};



