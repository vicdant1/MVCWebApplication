
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
    console.log(url, title)
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