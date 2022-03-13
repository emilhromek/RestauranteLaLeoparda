function mostrarMercaderiaComanda() {
    var e = document.getElementById("tipoMercaderiasComandas-dropdown");
    var strUser2 = e.options[e.selectedIndex].value;

    const url2 = 'https://localhost:5001/api/Mercaderia/?tipo=' + strUser2;

    fetch(url2)
        .then(
            function (response) {
                if (response.status !== 200) {
                    console.warn('Looks like there was a problem. Status Code: ' +
                        response.status);
                    tablamercaderias.innerHTML = '';
                    return;
                }

                // Examine the text in the response
                response.json().then(function (data) {
                    console.warn('OK: ' +
                        response.status);
                    tablamercaderias.innerHTML = '';

                    for (let i = 0; i < data.length; i++) {

                        tablamercaderias.innerHTML += `<tr id="${data[i].id}">
                                <th class="text-dark" scope="row">${data[i].nombre}</th>
                                <td class="text-dark" class="precio">${data[i].precio}</td>
                                <td><button type="button" class="btn btn-success" onclick="agregarMercaderia()">

                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
                                <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"></path>
                                </svg>

                                Agregar</button></td>
                                </tr>`;
                    }

                });
            }
        )
        .catch(function (err) {
            console.error('Fetch Error -', err);
        });
}