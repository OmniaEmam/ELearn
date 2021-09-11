var x=0;

function sendcomment(id,idstu) {
    var x = document.getElementById(id);
    var fa = new FormData();
    fa.append("idpost", x.id);
    fa.append("comment", x.value);
    fa.append("idstu", idstu)
    $.ajax({
        url: 'https://localhost:44378/api/commentapi',
        type: 'POST',
        data: fa,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data){
            console.log(data);
            x.value = "";
            console.log(x.value);
        }
    });
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function getcomment(idbu, id) {
    document.getElementById(idbu).disabled = true;
    
    while (true) {        
        
        $.ajax({
            url: 'https://localhost:44378/api/commentapi/' + id,
            type: 'GET',
            success: function (data) {
                console.log(data[0]);
                var comment = document.getElementById("C_" + id);
                comment.innerHTML = "";


                for (var i in data) {
                    comment.innerHTML += "<div class=\"col - xs - 12\"> <h4 class=\"post\" style=\"margin-left: 30px; margin-right:30px; \" > " + data[i].comment + "</h4> </div>";
                }
            }
        });
        await sleep(17000);
    }
}
