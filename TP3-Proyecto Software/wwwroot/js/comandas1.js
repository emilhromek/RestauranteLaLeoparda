function myFunction() {
    var e = document.getElementById("fecha");
    var strUser = e.value;

    const url2 = 'https://localhost:5001/api/Comanda?fecha=' + strUser;

    fetch(url2)
        .then(
            function (response) {
                if (response.status !== 200) {
                    console.warn('Looks like there was a problem. Status Code: ' +
                        response.status);
                    cuerpodetabla.innerHTML = '';
                    return;
                }

                // Examine the text in the response
                response.json().then(function (data) {

                    cuerpodetabla.innerHTML = '';

                    for (let i = 0; i < data.length; i++) {

                        let mercaderias = '';

                        for (let j = 0; j < data[i].listaMercaderias.length; j++) {

                            mercaderias += `${data[i].listaMercaderias[j].nombre}. `;

                        }

                        cuerpodetabla.innerHTML += `<tr>
                                <th class="text-dark"scope="row">${data[i].formaEntrega}</th>
                                <td class="text-dark">${data[i].precio}</td>
                                <td class="text-dark">${data[i].fecha}</td>
                                <td class="text-dark">${mercaderias}</td>
                            </tr>`
                    }


                });
            }
        )
        .catch(function (err) {
            console.error('Fetch Error -', err);
        });
}