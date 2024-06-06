token = localStorage.getItem("token");

// fetchke
async function getRequest(url, useAuth = true) {

    const options = {
        method: 'GET',
        headers: !useAuth ? {} : {
            'Authentication': 'Bearer ' + token
        }
    }
    
    const response = await fetch(url, options);

    // const json = await response.json();
    // return json;
}

async function postRequest(url, data, useAuth = true) {
    const options = {
        method: 'POST',
        headers: !useAuth ? {
            'Content-type': 'application/json; charset=UTF-8'
        } : {
            'Authentication': 'Bearer ' + token,
            'Content-type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(data)
    }

    const response = await fetch(url, options);

    if(!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message);
    }

    const json = await response.json();
    return json;
}

// function sendRequest(method, endpoint, useAuth = true) {
//     const xhr = new XMLHttpRequest();
//     xhr.open(method, endpoint, true);
//     if(useAuth)
//         xhr.setRequestHeader('Authorization', 'Bearer ' + token);

//     xhr.onload = function() {
//         if(xhr.status >= 200 && xhr.status < 300)
//             return xhr.response;
//         else if(xhr.status == 401)
//             return "Ehhez nincs hozzáférése."
//         else
//             return "Hibakód: " + xhr.status;
//     }

//     xhr.onerror = function() { return "Sikertelen kérés"; };

//     xhr.send();
//     console.log("Kérés elküldve")
// }


