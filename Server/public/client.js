var socket = io();          // Unity3D에서 emit 할 때 사용하는 클라이언트
socket.isReady = false;     // Unity3D에서 true로 바꿔줌

window.addEventListener('load', function() {
    // JS에서 Unity3D 함수를 호출할 수 있도록 하는 함수
    var execInUnity = function(method) {
        if (!socket.isReady) return;
        var args = Array.prototype.slice.call(arguments, 1);
        gameInstance.SendMessage("GameManager", method, args.join(','));  // GameManager에 method라는 이름의 함수를 인자를 이용해 호출
    };

    //#region socket.io callbacks
    socket.on('connected', function(data) {
        execInUnity('OnConnected', data.id, data.name, data.ids);
    });
    
    socket.on('newPlayer', function(data) {
        execInUnity('OnJoinPlayer', data.id, data.name);
    });
    //#endregion
});