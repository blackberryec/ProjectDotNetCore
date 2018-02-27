var productController = function () {
    this.initialize = function () {
        //loadData();
        registerEvents();
    }

    function registerEvents() {
        //todo: binding event to controls
       



         /*  Data Table Init
         /*-------------*/
        //$('#bootstrap-data-table').DataTable({
        //    lengthMenu: [[10, 20, 50, -1], [10, 20, 50, "All"]],
        //});

        $('#bootstrap-data-table').DataTable({
            "processing": true,
            "serverSide": true,
            "filter": true, // this is for disable filter (search box) 
            "orderMulti": false, // for disable multiple column at once 
            "ajax": {
                "url": "/Admin/Product/GetAllDataTable",
                "type": "POST",
                "datatype": "json"
            },
            "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }],
            "columns": [
                { "data": "id", "name": "Id", "autoWidth": true },
                { "data": "name", "name": "Tên", "autoWidth": true },
                { "data": "productCategory.name", "name": "Thuộc danh mục", "autoWidth": true },
                { "data": "price", "name": "Giá", "autoWidth": true },
                {
                    "render": function (data, type, full, meta) { return common.dateTimeFormatJson(full.dateCreated); }
                },
                {
                    "render": function (data, type, full, meta) { return common.getStatus(full.status); }
                },
                {
                    "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/DemoGrid/Edit/' + full.Id + '">Edit</a>'; }
                },
                {
                    data: null, render: function (data, type, row) {
                        return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.Id + "'); >Delete</a>";
                    }
                },
            ]  
        });

        $('#bootstrap-data-table-export').DataTable({
            dom: 'lBfrtip',
            lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
            buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ]
        });

        $('#row-select').DataTable({
            initComplete: function () {
                this.api().columns().every(function () {
                    var column = this;
                    var select = $('<select class="form-control"><option value=""></option></select>')
                        .appendTo($(column.footer()).empty())
                        .on('change', function () {
                            var val = $.fn.dataTable.util.escapeRegex(
                                $(this).val()
                            );

                            column
                                .search(val ? '^' + val + '$' : '', true, false)
                                .draw();
                        });

                    column.data().unique().sort().each(function (d, j) {
                        select.append('<option value="' + d + '">' + d + '</option>')
                    });
                });
            }
        });
    }

    function DeleteData(CustomerID) {
        if (confirm("Are you sure you want to delete ...?")) {
            Delete(CustomerID);
        }
        else {
            return false;
        }
    }


    function Delete(CustomerID) {
        var url = '@Url.Content("~/")' + "DemoGrid/Delete";

        $.post(url, { ID: CustomerID }, function (data) {
            if (data) {
                oTable = $('#example').DataTable();
                oTable.draw();
            }
            else {
                alert("Something Went Wrong!");
            }
        });
    }  

    //function loadData() {
    //    var template = $('#table-template').html();
    //    var render = "";
    //    $.ajax({
    //        type: 'GET',
    //        url: '/admin/product/GetAll',
    //        dataType: 'json',
    //        success: function (response) {
    //            $.each(response, function (i, item) {
    //                render += Mustache.render(template, {
    //                    Id: item.id,
    //                    Name: item.name,
    //                    //Image: item.image == null ? '<img src="/admin-side/images/user.png" width=25' : '<img src="' + item.image + '" width=25 />',
    //                    CategoryName: item.productCategory.name,
    //                    Price: common.formatNumber(item.price, 0),
    //                    CreatedDate: common.dateTimeFormatJson(item.dateCreated),
    //                    Status: common.getStatus(item.status)
    //                });
    //                if (render != '') {
    //                    $('#tbl-content').html(render);
    //                }
    //            });
    //        },
    //        error: function (status) {
    //            console.log(status);
    //            common.notify('Không thể tải dữ liệu của sản phẩm', 'error');
    //        }
    //    })
    //}

}