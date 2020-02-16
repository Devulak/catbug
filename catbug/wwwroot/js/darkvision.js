let _cookieName = 'darkvision=';

function darkvisionToggle()
{
    document.body.classList.toggle('dark');
    /*browser.cookies.set({
        name: "darkvision",
        value: document.body.classList.contains('dark')
    });*/
    document.cookie = _cookieName + document.body.classList.contains('dark') + ";path=/";
}


var checkCookie = function ()
{
    let cookies = document.cookie.split(';');
    for (var i = 0; i < cookies.length; i++)
    {
        let cookie = cookies[i].trim();
        if (cookie.indexOf(_cookieName) == 0)
        {
            document.body.classList.toggle('dark', cookie.substring(_cookieName.length, cookie.length) == 'true');
        }
    }
};

window.setInterval(checkCookie, 1);