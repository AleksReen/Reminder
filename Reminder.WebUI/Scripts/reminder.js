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

    (function () {
        jQuery.validator.methods.date = function (value, element) {
            var formats = ["DD.MM.YYYY", "DD.MM.YYYY hh:mm:ss A"];
            return moment(value, formats, true).isValid();
        };
    })(jQuery, moment);

    reminderStyle();
});

function reminderStyle () {
    var reminders = $(".reminder-item-conteiner");

    var now = new Date();
    var currDate = now.getDate();
    var currMonth = now.getMonth() + 1;
    var currYear = now.getFullYear();
    var currHour = now.getHours();
    var currMinutes = now.getMinutes();
    var currSeconds = now.getSeconds();

    var currFullDate = currDate + '.' + currMonth + '.' + currYear;
    var currFullDateTime = currFullDate + " " + currHour + ":" + currMinutes + ":" + currSeconds;

    for (var i = 0; i < reminders.length; i++) {

        var reminderDate = $(reminders[i]).find("#reminderDate").text().trim();
        var reminderTime = $(reminders[i]).find("#reminderTime").text().trim();

        if (reminderDate >= currFullDate && reminderTime >= currFullDateTime) {
            $(reminders[i]).addClass("reminder-future")
        }

        if (reminderDate >= currFullDate && reminderTime <= currFullDateTime) {
            $(reminders[i]).addClass("reminder-current")
        }

        if (reminderDate <= currFullDate && reminderTime <= currFullDateTime) {
            $(reminders[i]).addClass("reminder-fail")
        }
    }
};




