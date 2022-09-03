
let Table = $('#Products').DataTable({
    paging: false,
    "order": []
});
$('#SearchField').keyup(function () {
    Table.search($(this).val()).draw();
})