var BaseController = function () {
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.add-to-cart', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
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
                }
            });
        });



    }

    function loadHeaderCart() {
        $('#headerCart').load('/AjaxContent/HeaderCart');
    }
}