var BaseController = function () {
    this.initialize = function () {
        registerEvents();
    };

    function registerEvents() {
        $('body').on('click', '.add-to-cart', function (e) {
            e.preventDefault();
            var id = parseInt($(this).data('id'));
            var color = $(this).data('color');
            $.ajax({
                url: '/Cart/AddToCart',
                type: 'post',
                data: {
                    productId: id,
                    quantity: 1,
                    color: color
                },
                success: function (response) {
                    common.notify('Sản phẩm đã được thêm vào giỏ hàng.', 'success');
                    loadHeaderCart();
                },
                error: function (response) {
                    common.notify('Không thể thêm vào giỏ hàng. Phiền bạn thử lại', 'error');
                }
            });
        });

        $('body').on('click', '.remove-cart', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: '/Cart/RemoveItemOnCart',
                type: 'post',
                data: {
                    productId: id
                },
                success: function (response) {
                    common.notify('Đã xóa khỏi giỏ hàng', 'success');
                    loadHeaderCart();
                },
                error: function (response) {
                    common.notify('Đã có lỗi. Phiền bạn thử lại', 'error');
                }
            });
        });

    }

    function loadHeaderCart() {
        $('#headerCart').load('/AjaxContent/HeaderCart');
    }
};