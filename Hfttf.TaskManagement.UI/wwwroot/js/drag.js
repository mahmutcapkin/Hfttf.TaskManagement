const drag = (event) => {
    event.dataTransfer.setData("text/plain", event.target.id);
    console.log(event.target.id);
}

const allowDrop = (ev) => {
    ev.preventDefault();
    if (hasClass(ev.target, "dropzone")) {
        addClass(ev.target, "droppable");
    }
}

const clearDrop = (ev) => {
    removeClass(ev.target, "droppable");
}

const drop = (event) => {
    event.preventDefault();
    const data = event.dataTransfer.getData("text/plain");
    //const deneme = $(data).parent("div").parent("div").find(".card-body").attr("id");
    //const deneme2 = $(data).attr("id");
    //console.log("**********");
    //console.log(deneme);
    //console.log(deneme2);

    //console.log("**********");
    console.log(data);
    const element = document.getElementById(data);
    console.log(element);


    //****************
    //*******************
    //$(function () {
    //    //$(".draggable").draggable({
    //    //    revert: "invalid"
    //    //});

    //    $('.card-body').droppable({
    //        accept: '.draggable',
    //        drop: function (event, ui) {
    //            var dropped = ui.draggable;
    //            var droppedOn = $(this);
    //            $(dropped).detach().css({ top: 0, left: 0 }).appendTo(droppedOn);

    //            $.ajax({
    //                type: "POST",
    //                dataType: "json",
    //                contentType: false,
    //                processData: false,
    //                url: "/Project/MoveTask" + taskId,
    //                data: { taskId: dropped[0].id, taskStatusId: droppedOn[0].id },
    //                success: function (res) {
    //                    if (res.isValid) {
    //                        alert("görev güncelleme başarılı");
    //                    }
    //                    else
    //                        alert("görev güncelleme başarısız");
    //                },
    //                error: function (err) {
    //                    console.log(err)
    //                }
    //            });
    //        }
    //    });
    //});

      //****************
    //*******************


    try {
        // remove the spacer content from dropzone
        event.target.removeChild(event.target.firstChild);
        // add the draggable content
        event.target.appendChild(element);
        // remove the dropzone parent
        unwrap(event.target);
    } catch (error) {
        console.warn("can't move the item to the same place")
    }
    updateDropzones();
}

const updateDropzones = () => {
    /* after dropping, refresh the drop target areas
      so there is a dropzone after each item
      using jQuery here for simplicity */

    var dz = $('<div class="dropzone rounded" ondrop="drop(event)" ondragover="allowDrop(event)" ondragleave="clearDrop(event)"> &nbsp; </div>');

    // delete old dropzones
    $('.dropzone').remove();

    // insert new dropdzone after each item   
    dz.insertAfter('.card.draggable');

    // insert new dropzone in any empty swimlanes
    $(".items:not(:has(.card.draggable))").append(dz);
};

// helpers
function hasClass(target, className) {
    return new RegExp('(\\s|^)' + className + '(\\s|$)').test(target.className);
}

function addClass(ele, cls) {
    if (!hasClass(ele, cls)) ele.className += " " + cls;
}

function removeClass(ele, cls) {
    if (hasClass(ele, cls)) {
        var reg = new RegExp('(\\s|^)' + cls + '(\\s|$)');
        ele.className = ele.className.replace(reg, ' ');
    }
}

function unwrap(node) {
    node.replaceWith(...node.childNodes);
}
