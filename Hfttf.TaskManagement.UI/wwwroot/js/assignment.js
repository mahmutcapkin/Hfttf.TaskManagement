
showInPopupAssignment = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#assignment-modal .modal-body').html(res);
            $('#assignment-modal .modal-title').html(title);
            $('#assignment-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}


jQueryAjaxPostAssignment = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#pb-20').html(res.html)
                    $('#assignment-modal .modal-body').html('');
                    $('#assignment-modal .modal-title').html('');
                    $('#assignment-modal').modal('hide');
                }
                else
                    $('#assignment-modal .modal-body').html(res.html);
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



jQueryAjaxDeleteAssignment = form => {
    if (confirm('Bu atama bilgisini silmek istediğinize emin misiniz ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#pb-20').html(res.html);
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


