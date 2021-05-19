

showInPopupTask = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#task-modal .modal-body').html(res);
            $('#task-modal .modal-title').html(title);
            $('#task-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}


jQueryAjaxPostTask = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#row flex-row flex-sm-nowrap py-3').html(res.html)
                    $('#task-modal .modal-body').html('');
                    $('#task-modal .modal-title').html('');
                    $('#task-modal').modal('hide');
                    window.location.reload();
                }
                else
                    $('#task-modal .modal-body').html(res.html);
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



jQueryAjaxDeleteTask = form => {
    if (confirm('Bu görev bilgisini silmek istediğinize emin misiniz ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#row flex-row flex-sm-nowrap py-3').html(res.html);
                    window.location.reload();
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


