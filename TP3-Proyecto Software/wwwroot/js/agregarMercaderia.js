function agregarMercaderia() {
    var rowId =
        event.target.parentNode.parentNode.id;

    const url2 = 'https://localhost:5001/api/Mercaderia/' + rowId;

    fetch(url2)
        .then(
            function (response) {
                if (response.status !== 200) {
                    console.warn('Looks like there was a problem. Status Code: ' +
                        response.status);
                    return;
                }

                // Examine the text in the response
                response.json().then(function (data) {
                    console.warn('OK: ' +
                        response.status);                    

                    listacomanda.innerHTML += `<tr class="mercaderiaid" name=${data.id}>
                                <th class="text-dark" scope="row">${data.nombre}</th>
                                <td class="text-dark" name="precio" class="precio">${data.precio}</td>
                                <td><button type="button" class="btn btn-danger" onclick=DeleteRow()>

                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                                <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
                                <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
                                </svg>

                                Quitar</button></td>
                                </tr>`;

                    var precioTotal = document.getElementById("precioTotal")

                    var getPrecio = parseFloat(precioTotal.innerHTML)

                    getPrecio = getPrecio + data.precio

                    precioTotal.innerHTML = getPrecio


                });
            }
        )
        .catch(function (err) {
            console.error('Fetch Error -', err);
        });
}