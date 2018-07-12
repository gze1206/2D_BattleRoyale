var socket = io();          // Unity3D에서 emit 할 때 사용하는 클라이언트
socket.isReady = false;     // Unity3D에서 true로 바꿔줌

// 쿠키 얻어오기
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for(var i = 0; i <ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

// 쿠키 초기화
function clearCookie(cname) {
    document.cookie = cname + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
}

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
        console.log('connected : ', data.id);
    });
    
    socket.on('newPlayer', function(data) {
        execInUnity('OnJoinPlayer', data.id, data.name);
        console.log('connected : ', data.id);
    });
    //#endregion

    console.log('room id :', getCookie('roomID') || 'null');
    clearCookie('roomID');
});