var express = require('express');
var app = express();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var cookieParser = require('cookie-parser');

var ServerSettings = {
    serverPort: process.env.SERVER_PORT || 5522
};

//#region Server set up
app.use('/game', express.static('public'));
app.use(cookieParser());

// 주소에 방 ID가 없으면 쿠키가 없는 상태로 게임에 들어감
app.get("/", function(req, res) {
    res.clearCookie('roomID');
    res.redirect('../game');
});

// 주소에 방 ID가 있으면 쿠키에 등록하고 게임에 들어감
app.get("/:roomID", function(req, res) {
    res.cookie('roomID', req.params.roomID);
    res.redirect('../game');
});

http.listen(ServerSettings.serverPort, function() {
    console.log("Server On!!!");
    console.log("now listen on", ServerSettings.serverPort);
});
//#endregion

//#region Global functions
Array.prototype.remove = function() {
    var what, a = arguments, L = a.length, ax;
    while (L && this.length) {
        what = a[--L];
        while ((ax = this.indexOf(what)) !== -1) {
            this.splice(ax, 1);
        }
    }
    return this;
};
function Random(min, max) { return Math.random() * (max - min) + min; }
//#endregion

//#region User data
var name = {
};
var connections = [
];
//#endregion

io.on('connection', function(socket) {
    console.log('welcome, ', socket.id);
    connections.push(socket.id);
    console.log('\ncurrent connections', connections);

    socket.on('disconnect', function() {
        console.log('good bye, ', socket.id);

        connections.remove(socket.id);
        name[socket.id] = null;

        console.log('\nremain connections', connections);

        socket.broadcast.emit('player exit', { id: socket.id, name: name[socket.id] });
    });

    socket.on('rename', function(value) {
        var data = JSON.parse(value);
        name[socket.id] = data.name;

        console.log('rename', socket.id, name[socket.id]);

        socket.emit('connected', { id: socket.id, name: name[socket.id], ids: connections });
        socket.broadcast.emit('newPlayer', { id: socket.id, name: name[socket.id] });
    });
});