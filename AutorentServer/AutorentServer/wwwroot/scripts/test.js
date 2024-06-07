var token = "";

// function updateToken() {
//     var inputBox = document.getElementById("token-input-box");
//     token = inputBox.value;
// }

const ws = new WebSocket('/ws')

ws.onopen = (event) => {
    console.log('WS connection established.');
}

ws.onmessage = (event) => {
    console.log(event.data);
};

ws.onclose = (event) => {
    if(event.wasClean) {
        console.log('WebSocket connection closed gracefully.');
    } else {
        console.error('RIP connection');
    }
};

function init() {
    token = localStorage.getItem('token');
    getNameOfUser();

//    getCategories();
};

function getNameOfUser() {
    const xhr = new XMLHttpRequest();
    xhr.open('GET', '/users/me', true);
    xhr.setRequestHeader('Authorization', 'Bearer ' + token);

    xhr.onload = function() {
        if(xhr.status >= 200 && xhr.status < 300) {
            const jsonData = JSON.parse(xhr.response);
            document.getElementById('username-text').innerHTML = jsonData.name;
            //console.log(jsonData.name);
        } 
    }
    
    xhr.send();
}

// function getCategories() {
//     const xhr = new XMLHttpRequest();
//     xhr.open('GET', '/cars/categories', true);
//     xhr.setRequestHeader('Authorization', 'Bearer ' + token);

//     let select = document.getElementByID('cats');

//     xhr.onload = function() {
//         let json = JSON.parse(xhr.response);
//         console.log(jsonData);

//         for (var i = 0; i<= json.length; i++){
//             var opt = document.createElement('option');
//             opt.value = `cat0${i}`;
//             var str = `${json[i].name} (${json[i].noCars})`;
//             opt.innerHTML = str;
//             select.appendChild(opt);
//         }
//     }

//     xhr.send();
// }



function getEndpoint(method) {
    switch (method) {
        case 'GET':
            var button = document.activeElement;
            switch (button.id) {
                case 'car':
                    return '/cars';
                case 'car5':
                    return '/cars/5/month'
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

function callToAPI() {
    const endpoint = getEndpoint('GET');
    const responseBox = document.getElementById('response-box');

    responseBox.value = sendRequest('GET', endpoint, true);

    // sendRequest('GET', endpoint)
    //     .then(res => responseBox.value = res.response);
}


// function sendRequest(method, endpoint) {
//     const xhr = new XMLHttpRequest();
//     xhr.open(method, endpoint, true);
//     xhr.setRequestHeader('Authorization', 'Bearer ' + token);
    

//     const responseBox = document.getElementById('response-box');

//     xhr.onload = function() {
//         if(xhr.status >= 200 && xhr.status < 300)
//             responseBox.value = xhr.response; 
//         else if(xhr.status == 401)
//             responseBox.value = "Ehhez nincs hozzáférése.";
//         else
//             responseBox.value = "Hibakód: " + xhr.status;
//     }

//     xhr.onerror = function() {responseBox.value = "Sikertelen kérés"};

//     xhr.send();
//     console.log("Kérés elküldve")
// }

