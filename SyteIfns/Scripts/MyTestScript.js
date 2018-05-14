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

function post() {
    try {
        var n1Old = $("#N1Old").val();
        var n1New = $("#N1New").val();
        var returnet;
        $.ajax({
            url: "http://10.177.234.151:8181/ServiceRest/SqlFaceAdd",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: '{"N1New":' + n1New + ',"N1Old":' + n1Old + '}',
            success: function (resultdata) {
                alert(JSON.stringify(resultdata).toString());
            },
            error: function (e) { alert(e.toString()); }
        });
    } catch (e) {
        alert(e.toString());
    }
}
