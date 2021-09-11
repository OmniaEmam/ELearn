
function selected(id,wid){
    var x = document.getElementById(id);
    var w = document.getElementById(wid).getElementsByTagName("div");
    var y = w[0].className;
    if (y == "col-sm-3 col-xs-6 an anco") {
        y = "col-sm-3 col-xs-6 an";
    } else if (y == "col-sm-6 col-xs-12 an anco"){
        y = "col-sm-6 col-xs-12 an";
    }

    w[0].setAttribute("class", y);
    w[1].setAttribute("class", y);
    w[2].setAttribute("class", y);
    w[3].setAttribute("class", y);

    x.setAttribute("class", y +" anco");
}

function changethem(i,wid){
    var w = document.getElementById(wid).getElementsByTagName("div");
    var chack = document.getElementById(i);
    if (chack.checked == true) {
        var w = document.getElementById(wid).getElementsByTagName("div");
        var y = "col-sm-6 col-xs-12 an";
        for (var ii = 0; ii < w.length; ii++){ 
            if (w[ii].className == "col-sm-3 col-xs-6 an") {
                w[ii].setAttribute("class", y);
            }
            else if (w[ii].className[ii].className == "col-sm-3 col-xs-6 an anco") {
                w[ii].setAttribute("class", y + " anco");
            }
        }
    }
    else{
        console.log(false);
        var w = document.getElementById(wid).getElementsByTagName("div");
        var y = "col-sm-3 col-xs-6 an";
        for (var ii = 0; ii <w.length; ii++) {
            if (w[ii].className == "col-sm-6 col-xs-12 an") {
                w[ii].setAttribute("class", y);
            }
            else if (w[ii].className == "col-sm-6 col-xs-12 an anco") {
                w[ii].setAttribute("class", y + " anco");
            }
        }
    }
}

var list_qu = document.getElementsByClassName("T_");

function validatitem(item){
    var x1 = item.getElementsByTagName("input");
    for (var i2=0; i2 <= x1.length; i2++){
        if (x1[i2].checked == true) {
            return true;
        }
    }
    return false;
}

function validatlast(list_qu) {
    for (var i = 0; i <= list_qu.length; i++){
        if (validatitem(list_qu[i]) == false) {
            return false;
        }
    }
    return true;
}

function Editlink(id){
    var x = document.getElementById("go");
    var y = document.getElementById("no");
    var lnk1 = x.getAttribute("href");
    var lnk2 = y.getAttribute("href");

    ridobutom("postqu");
    x.setAttribute("href",link(lnk1,id));
    y.setAttribute("href",link(lnk2,id));
}

function link(link1,id) {
    var x = link1.split("/");
    return "/" + x[1] + "/" + x[2] + "/"+id+"/"+x[4];
}

function selctqu(tagqu) {
    var f2 = document.getElementsByClassName(tagqu);
    for (var i = 0; i < f2.length; i++){
        f2[i].innerHTML = "<input type=\"radio\" name=\"postqu\" onclick=\"Editlink('"+f2[i].id+"\')\""+"value=\""+f2[i].id+"\"/>"+f2[i].innerHTML;
    }
}
function ridobutom(name) {
    var f2 = document.getElementsByName(name);
    var a;
    for (var i = 0; i < f2.length; i++){
        a = document.getElementById(f2[i].value);
        if (f2[i].checked == true) {
            a.style.backgroundColor = 'rgba('+200+','+29+','+43+','+.5+')';;
            continue;
        }
        a.style.backgroundColor = 'rgba(' + 16.9 + ',' + 29 + ',' + 43 + ',' + .15 + ')';
    }
}



document.getElementById("post").addEventListener("click",function(){
    selctqu("Qu");
    var x = document.getElementById("post");
    x.disabled = true;
});