var token = ""

function updateToken() {
    var inputBox = document.getElementById("token-input-box");
    token = inputBox.value;
}

function login() {
    var unameBox = document.getElementById("username");
    var passBox = document.getElementById("password");

    const username = unameBox.value;
    const password = passBox.value;
    
    const endpoint = "users/login"
    const response = fetch(`/users/login?username=${username}&password=${password}`).then(res => console.log(res.body));
    //const msg = response.json();
    console.log(msg);
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

