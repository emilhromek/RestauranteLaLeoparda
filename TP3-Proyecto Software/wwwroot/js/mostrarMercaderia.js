function mostrarMercaderia() {
    var e = document.getElementById("tipoMercaderiaInformacion-dropdown");
    var strUser = e.options[e.selectedIndex].value;

    const url4 = 'https://localhost:5001/api/Mercaderia/?tipo=' + strUser;

    fetch(url4)
        .then(
            function (response) {
                if (response.status !== 200) {
                    console.warn('Looks like there was a problem. Status Code: ' +
                        response.status);
                    return;
                }

                // Examine the text in the response
                response.json().then(function (data) {

                    contenedordemercaderias.innerHTML = ''

                    for (let i = 0; i < data.length; i++) {
                        contenedordemercaderias.innerHTML += `<div class="card mt-4 paquete" style="width: 18rem;">
                            <img src="${data[i].imagen}" class="card-img-top" alt="..."/>
                            <div class="card-body">
                                <h5 class="card-title">Nombre: ${data[i].nombre}</h5>
                                <p class="card-text">Precio: ${data[i].precio}</p>
                            </div>
                            <ul class="list-group list-group-flush" id=${data[i].id}>
                              <li class="list-group-item">Ingredientes: ${data[i].ingredientes}</li>
                              <li class="list-group-item">Preparación: ${data[i].preparacion}</li>
                              <li class="list-group-item"><button type="button" class="btn btn-success" onclick="agregarMercaderia()">

                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
                                <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"></path>
                                </svg>

                            Agregar</button></li>
                            </ul>
                          </div>`
                    }


                });
            }
        )
        .catch(function (err) {
            console.error('Fetch Error -', err);
        });
}