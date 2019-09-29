var express = require('express');
var bodyParser = require('body-parser');

var app = express();

var azure = require('azure-sb');
var notificationHubService = azure.createNotificationHubService('az203','Endpoint=sb://az203space.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=z10VdMmVSmwfm2hxnqo2CZ+f7WehU5XZXTLBuoPDPbg=');

app.use(express.static('public'));
app.use(bodyParser.urlencoded({ extended: true }));

app.get('/', (req, res) => {
    res.sendFile(__dirname + '/index.html');
});

app.post('/notif',(req,res) => {
    var payload =  {"data":{"message":req.body.msg}};

    notificationHubService.gcm.send(null, payload, function(error){
        if(!error){
            console.log('notification sent');
        }else{
            console.log(error);
        }
    });
    res.sendFile(__dirname + '/index.html');
});

app.listen(process.env.PORT || 3000); 