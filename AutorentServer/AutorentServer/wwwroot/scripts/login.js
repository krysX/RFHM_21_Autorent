

async function login() {
    const user = document.getElementById("username").value;
    const pass = document.getElementById("password").value;

    const response = await fetch(`/users/login?username=${user}&password=${pass}`,);

    if(!response.ok) {
        const errorData = await response.json();
        alert("Belépés sikertelen! Próbálja meg újra.");
        throw new Error(errorData.message);
    }

    const tokenData = await response.json();
    const token = tokenData.value;
    console.log(token);

    localStorage.setItem('token', token);
    window.location.href = "/cars.html"
}