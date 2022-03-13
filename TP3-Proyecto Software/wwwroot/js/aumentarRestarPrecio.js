function aumentarPrecio(input) {

    var precioTotal = document.getElementById("precioTotal")

    var getPrecio = parseFloat(precioTotal.innerHTML)

    getPrecio = getPrecio + input

    precioTotal.innerHTML = getPrecio

}

function restarPrecio(input) {

    var precioTotal = document.getElementById("precioTotal")

    var getPrecio = parseFloat(precioTotal.innerHTML)

    getPrecio = getPrecio - input

    precioTotal.innerHTML = getPrecio

}