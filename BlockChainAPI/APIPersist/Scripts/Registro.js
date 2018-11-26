
$(document).ready(function () {

    $('#toast-container').find('.toast-top-center').removeClass('.toast-top-center');
    toastr.options = {
        "closeButton": true,
        'autoWidth': false,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "3000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    $("#btnSave").click(function () {
        debugger
        var PID = 0;
        var Name = $("#txtCtaDestino").val();
        var Desc = $("#txtBanco").val();
        var monto = $("#txtMonto").val();
        var Price = parseFloat($("#txtPrice").val()).toFixed(2);
        if (CheckRequiredFields()) {

            $('#dvLoader').show();
            $.ajax({
                url: '@Url.Action("Product", "Api")',
                type: 'POST',
                data: JSON.stringify({ "PID": parseInt(PID), "Name": Name, "Description": Desc, "price": Price }),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (result) {

                    $('#dvLoader').hide();
                    jQuery.noConflict();
                    $('#AddProduct_Model').modal('hide');
                    toastr.success("product insert successfull");
                    clear();


                }
            });

        }

    });
    $("#GetAllProduct").click(function () {
        $.ajax({
            url: '@Url.Action("Product", "Api")',
            type: 'GET',
            // data: JSON.stringify({  }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                jQuery.noConflict();

                $("#idjson").text(JSON.stringify(result));
                $('#GetData').modal('show');

            }
        });

    });

    $("#GetAllProductbyid").click(function () {


        $.ajax({
            url: 'api/product/5',
            type: 'GET',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (result) {

                jQuery.noConflict();
                $("#idjsonbyid").text(JSON.stringify(result));
                $('#GetDatabyid').modal('show');

            }
        });

    });

    $("#btnUpdate").click(function () {
        var PID = 5;
        var Name = $("#txtName2").val();
        var Desc = $("#txtDesc2").val();
        var Price = parseFloat($("#txtPrice2").val()).toFixed(2);

        $('#dvLoader').show();
        $.ajax({
            url: 'api/product/5',
            type: 'PUT',
            data: JSON.stringify({ "PID": parseInt(PID), "Name": Name, "Description": Desc, "price": Price }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                $('#dvLoader').hide();

                $('#UpdateProduct_Model').modal('hide');

                toastr.success("product updated successfully.");
                clear2();


            }
        });



    });
    $("#DeleteProduct").click(function () {

        $.ajax({
            url: 'api/product/5',
            method: 'DELETE',
            contentType: 'application/json',
            success: function (result) {
                toastr.success("product Deleted successfull");
            },
            error: function (request, msg, error) {
                // handle failure
            }
        });



    });
});
function CheckRequiredFields() {
    var isValid = true;
    $('.required').each(function () {
        if ($.trim($(this).val()) == '') {
            isValid = false;
            $(this).addClass('red_border');


        }
        else {
            $(this).removeClass('red_border');

        }
    });
    return isValid;
}
function clear() {
    $("#txtName").val("");
    $("#txtDesc").val("");
    $("#txtPrice").val("");


}
function clear2() {
    $("#txtName2").val("");
    $("#txtDesc2").val("");
    $("#txtPrice2").val("");


}
function isNumberKey(evt) {
    var charcode = (evt.which) ? evt.which : evt.keycode
    if (charcode > 31 && (charcode < 48 || charcode > 58)
        && evt.keyCode != 35 && evt.keyCode != 36 && evt.keyCode != 37
        && evt.keyCode != 38 && evt.keyCode != 39 && evt.keyCode != 40
        && evt.keyCode != 46) {
        return false;
    }
    else {
        return true;
    }
}
