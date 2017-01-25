
var modal = document.getElementById('onemodal');

var btn = document.getElementById('ide');
var span = document.getElementById('close');

btn.onclick = function(){
    modal.style.display = "block";
}

span.onclick = function () {
    modal.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}