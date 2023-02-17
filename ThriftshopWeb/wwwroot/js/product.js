﻿var dataTable;

$(document).ready(function (){
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "gender", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "itemCondition.name", "width": "15%" }


        ]

    });
}