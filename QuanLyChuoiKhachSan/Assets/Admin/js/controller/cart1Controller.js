var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        //$('#btnContinue').off('click').on('click', function () {
        //    window.location.href ="/Admin/XuatHang"
        //});

        $('#btnUpdate').off('click').on('click', function () {
            var listHanghoa = $('.txtSoLuong');
            var cartList = [];
            $.each(listHanghoa, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    Hang_Hoa: {
                        MaHang: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart1/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/Admin/Cart1'
                    }
                    else {

                    }
                }
            })
        });

        $('#btnDelete').off('click').on('click', function () {
            $.ajax({
                url: '/Cart1/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/Admin/Cart1'
                    }
                    else {

                    }
                }
            })
        });
    }
}
cart.init();