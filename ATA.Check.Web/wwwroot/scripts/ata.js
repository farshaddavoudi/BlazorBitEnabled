function setCookie(name, value, seconds) {
    var date = new Date();
    date.setSeconds(date.getSeconds() + seconds);
    var expires = 'expires=' + date.toUTCString();
    document.cookie = name + '=' + value + '; ' + expires + '; path=/';
}
function getCookie(name) {
    var cookies = document.cookie.split(';');
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i].split('=');
        if (trim(cookie[0]) == escape(name)) {
            return unescape(trim(cookie[1]));
        }
    }
    return null;
}
function trim(value) {
    return value.replace(/^\s+|\s+$/g, '');
}
;
function removeCookie(name) {
    document.cookie = name + '=; Max-Age=0';
}
//# sourceMappingURL=ata.js.map