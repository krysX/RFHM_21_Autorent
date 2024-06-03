token = localStorage.getItem("token");

// fetchke
async function getRequest(url) {
    let response = await fetch(url, {
        method: 'GET',
        headers: {
            'Authentication': 'Bearer ' + token
        }
    });

    let json = await response.json();
    return json;
}

async function postRequest(url, data) {
    let response = await fetch(url, {
        method: 'POST',
        headers: {
            'Authentication': 'Bearer ' + token
        },
        body: data
    })

    let json = await response.json();
    return json;
}