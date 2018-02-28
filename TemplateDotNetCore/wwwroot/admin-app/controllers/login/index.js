var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        $('#frmLogin').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                userName: {
                    required: true
                },
                password: {
                    required: true
                }
            },
            messages: {
                userName: {
                    required: 'Mục cần phải nhập'
                },
                password: {
                    required: 'Mục cần phải nhập'
                }
            }
        });
        $('#btnLogin').on('click', function (e) {
            if ($('#frmLogin').valid()) {
                e.preventDefault();
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                var remember = $('#cbRemember').val();
                login(user, password, remember);
            }
        });
    }

    var login = function (user, pass, remember) {
        $.ajax({
            type: 'POST',
            data: {
                UserName: user,
                Password: pass,
                Remember: remember
            },
            dateType: 'json',
            url: '/admin/login/authen',
            success: function (res) {
                if (res.Success) {
                    window.location.href = "/Admin/Home/Index";
                }
                else {
                    common.notify('Đăng nhập không thành công.', 'error');
                }
            }
        })
    }
}