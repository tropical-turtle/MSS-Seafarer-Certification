
function SetElementTextById(id, text)
{
    //alert("This is when calling SetElementTextById ");
    document.getElementById(id).innerHTML = text;

}

function IsFrenchURL( url)
{
    var len = url.length
    var index = len - 2;
    var lastLetters = url.substr(index, 2);

    if (lastLetters == "fr")
        return true;
    else
        return false;

}



function ChangeLanguageLinkText(currentUI_language)
{
    var languageSection = document.getElementById("wb-lng");
    var languageLink = languageSection.getElementsByTagName("a").item(0);

    if (currentUI_language == "English")
    {
        languageLink.innerHTML = "Fran" + "\u00E7" + "ais";
    }
    else
    {
        languageLink.innerHTML = "English";
    }
}


function GetLanguageLinkElement()
{

    try
    {
        var current_url = window.location.href;

        if (IsFrenchURL(current_url)) {
            current_url = current_url.replace("/fr", "/en");
        }
        else
        {
            var last_2_letters = GetLastTwoLetters(current_url);
            if (last_2_letters == "en") {
                current_url = current_url.replace("en", "fr");
            }
            else
            {
                current_url = current_url + "fr";
            }               
        }

        window.location.href = current_url;
    }
    catch(err)
    {
        alert(err.message);

    }
}

function GetLastTwoLetters(url)
{
    var index = url.length - 2;
    var twoLetters = url.substr(index, 2);
    return twoLetters;
}
