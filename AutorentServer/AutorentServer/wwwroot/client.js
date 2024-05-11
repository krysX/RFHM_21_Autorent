var token = "";

// function updateToken() {
//     var inputBox = document.getElementById("token-input-box");
//     token = inputBox.value;
// }

function init() {
    token = localStorage.getItem('token');
    document.getElementById('token-input-box').innerText = token;
    getNameOfUser();
}

function getNameOfUser() {
    const xhr = new XMLHttpRequest();
    xhr.open('GET', '/users/me', true);
    xhr.setRequestHeader('Authorization', 'Bearer ' + token);

    let name = undefined;

    xhr.onload = function() {
        if(xhr.status >= 200 && xhr.status < 300) {
            const jsonData = JSON.parse(xhr.response);
            document.getElementById('username-text').innerHTML = jsonData.name;
            console.log(jsonData.name);
        } 
    }
    
    name = xhr.send();
}



function getEndpoint(method) {
    switch (method) {
        case 'GET':
            var button = document.activeElement;
            switch (button.id) {
                case 'car':
                    return '/cars';
                case 'cats':
                    return '/cars/categories'
                case 'cat01':
                    return '/cars/categories/1'
                case 'cat02':
                    return '/cars/categories/2'
                case 'cat03':
                    return '/cars/categories/3'
                case 'user':
                    return '/users';
                case 'sales':
                    return '/cars/sales'
                case 'rentals01':
                    return '/users/1/rentals'
                case 'rentals02':
                    return '/users/2/rentals'
                default:
                    return '';
            }
        default:
            return '';
    }
}


const apiUrl = "localhost:5000"



function sendRequest(method) {
    const xhr = new XMLHttpRequest();
    const endpoint = getEndpoint(method); 
    xhr.open(method, endpoint, true);
    xhr.setRequestHeader('Authorization', 'Bearer ' + token);

    const responseBox = document.getElementById('response-box');

    xhr.onload = function() {
        if(xhr.status >= 200 && xhr.status < 300)
            responseBox.value = xhr.response; 
        else
            responseBox.value = "Hibakód: " + xhr.status;
    }

    xhr.onerror = function() {responseBox.value = "Sikertelen kérés"};

    xhr.send();
    console.log("Kérés elküldve")
}

