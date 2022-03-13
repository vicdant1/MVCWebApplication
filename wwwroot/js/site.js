
$(document).ready(function () {
    $('.dataTableDisplay').DataTable({
        "language": {
            "lengthMenu": "_MENU_ records per page",
            "zeroRecords": "It is kindof empty here :(",
            "info": "Page _PAGE_ of _PAGES_",
            "infoEmpty": "There is nothing here,",
            "infoFiltered": "(searched in _MAX_ total records)"
        }
    });
});


const OpenStandartModal = (url, title) => {
    $.ajax({
        method: "GET",
        url: url,
        contentType: false,
        dataType: "html",

        success: function (res) {
            $("#generalModalBody").html(res);
            $("#generalModalTitle").html(title);
            $("#generalModal").modal("show");
        }
    });
}

const OpenDeleteModal = (url) => {
    $.ajax({
        method: "GET",
        url: url,
        contentType: false,
        processData: false,
        dataType: "html",

        success: function (res) {
            $("#deleteModal").modal("show");
            $("#ActionDeleteBody").html(res);
        }
    });
}


const handleJqueryFormSubmit = (form) => {
    $.ajax({
        method: "POST",
        url: form.action,
        data: new FormData(form),
        contentType: false,
        processData: false,
        dataType: "json",
        success: function (res) {
            if (res.isValid) {
                $("#mainTableContainer").html(res.html);

                $("#generalModalBody").html('');
                $("#generalModalTitle").html('');
                $("#generalModal").modal("hide");
                $.notify(res.notification, "success");
            }
            else {
                $("#generalModalBody").html(res.html);
                $.notify(res.notification, "error");
            }
        },
        error: function (err) {
            console.log(err);
        }
    });

    return false;
}