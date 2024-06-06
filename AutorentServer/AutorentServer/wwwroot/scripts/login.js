// async function login() {

//     const user = document.getElementById("username").value;
//     const pass = document.getElementById("password").value;

//     const response = await fetch(`/users/login`, {
//         method: 'POST',
//         headers: {
//             'Content-Type': 'application/json'
//         },
//         body: JSON.stringify({
//             "username": user,
//             "password": pass
//         })
//     });

//     if (!response.ok) {
//         const errorData = await response.json();
//         alert("Belépés sikertelen! Próbálja meg újra.");
//         throw new Error(errorData.message);
//     }

//     const tokenData = await response.json();
//     const token = tokenData.value;
//     console.log(token);

//     localStorage.setItem('token', token);
//     window.location.href = "/cars.html";
// }

async function test() {
    let x = await getRequest('https://eht2.gnssnet.hu/api/transformation/etrs89-to-eov?pointNumber=1&lat=47&lon=20&h=100', false);
    console.log(x);
}

async function newLogin() {
    const user = document.getElementById("username").value;
    const pass = document.getElementById("password").value;

    const json = await postRequest('/users/login', {
        "username": user,
        "password": pass
    }, false)
        .catch(() => alert("Belépés sikertelen! Próbálja meg újra."));

    const token = json.value;
    localStorage.setItem('token', token);

    console.log(token);

    window.location.href = "/test.html";
}