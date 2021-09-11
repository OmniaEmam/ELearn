var myHistory = [];
function pageLoad() {
    
    for (var i = 0; i <= 50;i++){
        window.history.pushState(myHistory, "<name>", "");
        console.log(i);
    }
}