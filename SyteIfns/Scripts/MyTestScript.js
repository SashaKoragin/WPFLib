function test(param)
{
    try {
        var element = document.getElementById(param);
        element.style.background = "green";
        element.style.visibility = "visible";
        element.style.width = "350px";
    } catch (e) {
        alert(e.toString());
    }
}

function show(param) {
    try {
        var element = document.getElementById(param);
        element.style.visibility = "hidden";
    } catch (e) {
        alert(e.toString());
    }
}

function UnHide(eThis) {
    if (eThis.innerHTML.charCodeAt(0) === 9658) {
        eThis.innerHTML = "&#9660;";
        eThis.parentNode.parentNode.parentNode.className = "";
    } else {
        eThis.innerHTML = "&#9658;";
        eThis.parentNode.parentNode.parentNode.className = "cl";
    }
    return false;
}