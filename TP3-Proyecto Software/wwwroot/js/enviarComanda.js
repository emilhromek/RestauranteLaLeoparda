function enviarComanda() {
    let e = document.getElementById('formaEntregaComandas-dropdown');

    var opcionElegida = e.options[e.selectedIndex].value;

    var comandas =
        document.getElementById('listacomanda').querySelectorAll(".mercaderiaid");

    let arrayComandas = [];

    for (let i = 0; i < comandas.length; i++) {

        arrayComandas.push(parseInt(comandas[i].getAttribute("name")));
    }

    if (isNaN(parseInt(opcionElegida))) {
        alert('Elija forma de entrega');
        return;
    }

    if (arrayComandas.length == 0) {
        alert('Elija mercaderías');
        return;
    }

    alert('Comanda creada con éxito');

    let output = { formaEntregaId: parseInt(opcionElegida), mercaderia: arrayComandas }

    postData('https://localhost:5001/api/Comanda', output);    


}

function postData(url, data) {
    // Opciones por defecto estan marcadas con un *
    const response = fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    })
        .then(response => response.json())
        .then(json => console.log(json))
        .catch(err => console.log(err));
}