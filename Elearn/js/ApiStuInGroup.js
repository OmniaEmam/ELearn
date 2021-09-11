
function gitid() {
    var url = window.location.href;
    var id = url.split("/");
    console.log(id[id.length - 1]);
    return id[id.length-1];
}
function chckd(id) {
    var x = document.getElementById(id);
    if (x.checked == true) {
        addapi(x.value);
    } else if (x.checked == false) {
        deleteapi(x.value);
    }
}

function addapi(value) {

    var formdata = new FormData();
    var url1 = 'https://localhost:44378/api/StuInGroup/'+gitid();
    formdata.append("idstu",value)
    $.ajax({
        url: url1,
        type: 'POST',
        data: formdata,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            console.log(data);
        }
    });
}

function deleteapi(value){
    var formdata = new FormData();
    var url1 = 'https://localhost:44378/api/StuInGroup/' + gitid();
    formdata.append("idstu", value)
    $.ajax({
        url: url1,
        type: 'DELETE',
        data: formdata,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            console.log(data);
        }
    });
}