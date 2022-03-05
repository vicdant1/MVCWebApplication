
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