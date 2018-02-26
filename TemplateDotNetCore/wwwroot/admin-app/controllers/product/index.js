var productController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        //todo: binding event to controls
    }

    function loadData() {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            url: '/admin/product/GetAll',
            dataType: 'json',
            success: function (response) {
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.id,
                        Name: item.name,
                        Image: item.image == null ? '<img src="/admin-side/images/user.png" width=25' : '<img src="' + item.image + '" width=25 />',
                        CategoryName: item.productCategory.name,
                        Price: common.formatNumber(item.price, 0),
                        CreatedDate: common.dateTimeFormatJson(item.dateCreated),
                        Status: common.getStatus(item.status)
                    });
                    if (render != '') {
                        $('#tbl-content').html(render);
                    }
                });
            },
            error: function (status) {
                console.log(status);
                common.notify('Không thể tải dữ liệu của sản phẩm', 'error');
            }
        })
    }

}