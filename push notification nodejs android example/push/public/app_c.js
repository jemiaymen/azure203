var btn = document.getElementById('ok');

var msg = document.getElementById('msg');


function post(msg){
    xhr = new XMLHttpRequest();
    xhr.open('POST','/notif',true);
    xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    var params = 'msg=' + msg;

    xhr.onload = function(){
        if(xhr.status !== 200 ){
            console.log('thama mochkol');
        }
    }
    xhr.send(params);
}

btn.addEventListener('click',function(e){
    post(msg.value);
    msg.value = '';
});