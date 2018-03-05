var productController = function () {
    this.initialize = function () {
        registerEvents();
        loadCategories();
    }

    function registerEvents() {
        //todo: binding event to controls

        $('#global_filter').on('change', function () {
            filterGlobal();
        });

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
                { "data": "Id", "name": "Id", "autoWidth": true },
                { "data": "Name", "name": "Name", "autoWidth": true },
                { "data": "ProductCategory.Name", "name": "ProductCategory.Name", "autoWidth": true },
                { "data": "Price", "name": "Price", "autoWidth": true },
                {
                    "name": "DateCreated", "render": function (data, type, full, meta) { return common.dateTimeFormatJson(full.DateCreated); }
                },
                {
                    "name": "Status", "render": function (data, type, full, meta) { return common.getStatus(full.Status); }
                },
                {
                    "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Admin/Product/Edit/' + full.Id + '">Edit</a>'; }
                },
                {
                    data: null, render: function (data, type, row) {
                        return "<a href='#' class='btn btn-danger' onclick=deleteData('" + row.Id + "');>Delete</a>";
                    }
                },
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
}

function loadCategories() {
    $.ajax({
        type: 'GET',
        url: '/admin/product/GetAllCategories',
        dataType: 'json',
        success: function (response) {
            var render = "<option value=''>--Select category--</option>";
            $.each(response, function (i, item) {
                render += "<option value='" + item.Name + "'>" + item.Name + "</option>"
            });
            $('#global_filter').html(render);
        },
        error: function (status) {
            console.log(status);
            common.notify('Không thể tải dữ liệu của Danh Mục Sản Phẩm', 'error');
        }
    });
}

function filterGlobal() {
    $('#bootstrap-data-table').DataTable().search(
        $('#global_filter').val(),
    ).draw();
}

function deleteData(id) {
    common.confirm('Bạn sẽ xóa item này chứ?', function () {
        $.ajax({
            type: "POST",
            url: "/Admin/Product/Delete",
            data: { id: id },
            dataType: "json",
            beforeSend: function () {
                common.startLoading();
            },
            success: function (response) {
                oTable = $('#bootstrap-data-table').DataTable();
                oTable.draw();
                common.notify('Đã xóa item thành công', 'success');
                common.stopLoading();
            },
            error: function (status) {
                common.notify('Xin lỗi bạn! Xóa item xảy ra lỗi rồi!', 'error');
                common.stopLoading();
            }
        });
    });
}