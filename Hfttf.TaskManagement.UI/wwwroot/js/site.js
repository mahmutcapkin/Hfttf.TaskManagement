// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$(function () {

//    var placeholderElement = $('#Placeholderhere');
//    $('button[data-toggle="ajax-modal"]').click(function (event) {


//        var url = $(this).data('url');
//        $.get(url).done(function (data) {
//            placeholderElement.html(data);
//            placeholderElement.find('.modal').modal('show');
//        })
//    })
//})

$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});


showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#address-modal .modal-body').html(res);
            $('#address-modal .modal-title').html(title);
            $('#address-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}


jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#address').html(res.html)
                    $('#address-modal .modal-body').html('');
                    $('#address-modal .modal-title').html('');
                    $('#address-modal').modal('hide');
                }
                else
                    $('#address-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}



jQueryAjaxDelete = form => {
    if (confirm('Bu adresi silmek istediğinize emin misiniz ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#address').html(res.html);
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}


